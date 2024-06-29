using System.Net;
using AutoMapper;
using MagicVilla_VillaAPI.Dto.ResponseDto;
using MagicVilla_VillaAPI.Dto.VillaNumber;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Controllers.V1;

[Route("api/v{version:apiVersion}/VillaNumberApi")]
[ApiController]
[ApiVersion("1.0")]
public class VillaNumberApiController : ControllerBase
{
    private readonly IVillaNumberRepository _villaNumberRepository;
    private readonly IVillaRepository _villaRepository;
    private readonly IMapper _mapper;
    protected ApiResponse _response;

    public VillaNumberApiController(IVillaNumberRepository villaNumberRepository,
        IVillaRepository villaRepository, IMapper mapper)
    {
        _villaNumberRepository = villaNumberRepository;
        _villaRepository = villaRepository;
        _mapper = mapper;
        _response = new();
    }

    [HttpGet("GetString")]
    public IEnumerable<string> Get()
    {
        return new string[] { "String1", "string2" };
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ApiResponse>> GetVillasNumber()
    {
        try
        {
            var villaList = await _villaNumberRepository.GetAllAsync(includeProperties: "Villa");
            _response.Result = _mapper.Map<List<VillaNumberDto>>(villaList);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = [e.ToString()];
            _response.StatusCode = HttpStatusCode.InternalServerError;

        }

        return _response;

    }
    [Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet("{id:int}", Name = "GetVillaNumber")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse>> GetVillaNumber(int id)
    {

        if (id <= 0)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = ["Invalid villa Number ID"];
            _response.StatusCode = HttpStatusCode.BadRequest;
            return BadRequest(_response);
        }

        var villa = await _villaNumberRepository.GetAsync(u => u.VillaNo == id, includeProperties: "Villa");

        if (villa == null)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = ["Villa Number not found"];
            _response.StatusCode = HttpStatusCode.NotFound;
            return NotFound(_response);
        }

        var villaDto = _mapper.Map<VillaNumberDto>(villa);
        _response.Result = villaDto;
        _response.StatusCode = HttpStatusCode.OK;

        return Ok(_response);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult<ApiResponse>> CreateVillaNumber([FromBody] VillaNumberCreateDto villaNumberCreateDto)
    {
        if (await _villaRepository.GetAsync(u => u.Id == villaNumberCreateDto.VillaId) == null)
        {
            ModelState.AddModelError("ErrorMessages", "Villa Id is invalid!");
            return BadRequest(ModelState);
        }
        if (await _villaNumberRepository.GetAsync(u => u.VillaNo == villaNumberCreateDto.VillaNo) != null)
        {
            ModelState.AddModelError("ErrorMessages", "Villa Number already Exist!");
            return BadRequest(ModelState);
        }

        var villaNumber = _mapper.Map<VillaNumber>(villaNumberCreateDto);

        try
        {
            await _villaNumberRepository.CreateAsync(villaNumber);
            _response.StatusCode = HttpStatusCode.Created;
            return Ok(_response);
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { e.Message };
            _response.StatusCode = HttpStatusCode.InternalServerError;
            return StatusCode(StatusCodes.Status500InternalServerError, _response);
        }
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult<ApiResponse>> DeleteVillaNumber(int id)
    {

        try
        {
            var villaNumber = await _villaNumberRepository.GetAsync(u => u.VillaNo == id);

            if (villaNumber == null)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { "Villa not found" };
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_response);
            }

            await _villaNumberRepository.RemoveAsync(villaNumber);
            _response.StatusCode = HttpStatusCode.NoContent;
            return Ok(_response);
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { e.Message };
            _response.StatusCode = HttpStatusCode.InternalServerError;
            return StatusCode(StatusCodes.Status500InternalServerError, _response);
        }
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult<ApiResponse>> UpdateVillaNumber([FromBody] VillaNumberUpdateDto villaNumberUpdateDto)
    {

        try
        {

            if (await _villaRepository.GetAsync(u => u.Id == villaNumberUpdateDto.VillaId) == null)
            {
                ModelState.AddModelError("ErrorMessages", "Villa Id is invalid!");
                return BadRequest(ModelState);
            }


            var updatedVillaNumber = _mapper.Map<VillaNumber>(villaNumberUpdateDto);

            await _villaNumberRepository.UpdateAsync(updatedVillaNumber);
            _response.StatusCode = HttpStatusCode.NoContent;
            return Ok(_response);
        }
        catch (Exception e)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { e.Message };
            _response.StatusCode = HttpStatusCode.InternalServerError;
            return StatusCode(StatusCodes.Status500InternalServerError, _response);
        }
    }
}