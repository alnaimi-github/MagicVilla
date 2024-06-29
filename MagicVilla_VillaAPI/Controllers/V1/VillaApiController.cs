using System.Net;
using AutoMapper;
using MagicVilla_VillaAPI.Dto.ResponseDto;
using MagicVilla_VillaAPI.Dto.Villa;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVilla_VillaAPI.Controllers.V1;

[Route("api/v{version:apiVersion}/VillaApi")]
[ApiController]
[ApiVersion("1.0")]
public class VillaApiController : ControllerBase
{
    private readonly IVillaRepository _villaRepository;
    private readonly IMapper _mapper;
    protected ApiResponse _response;

    public VillaApiController(IVillaRepository villaRepository, IMapper mapper)
    {
        _villaRepository = villaRepository;
        _mapper = mapper;
        _response = new ApiResponse();
    }

    [HttpGet]
    // [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Client)]
    //[ResponseCache(CacheProfileName = "Default30")]
    public async Task<ActionResult<ApiResponse>> GetVillas([FromQuery(Name = "FilterOccupancy")] int? occupancy,
        [FromQuery] string? search, int pageSize = 0, int pageNumber = 1)
    {
        try
        {
            IEnumerable<Villa> villaList;
            if (occupancy > 0)
            {
                villaList = await _villaRepository.GetAllAsync(u => u.Occupancy == occupancy,
                    pageSize: pageSize,
                    pageNumber: pageNumber);
            }
            else
            {
                villaList = await _villaRepository.GetAllAsync(pageSize: pageSize, pageNumber: pageNumber);
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                villaList = villaList.Where(u =>
                    u.Amenity.ToLower().Contains(search) || u.Name.ToLower().Contains(search));
            }

            Pagination pagination = new() { PageNumber = pageNumber, PageSize = pageSize};
            Response.Headers.Add("X-Pagination",JsonConvert.SerializeObject(pagination));
            _response.Result = _mapper.Map<List<VillaDto>>(villaList);
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

  
    [HttpGet("{id:int}", Name = "GetVilla")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ResponseCache(Duration = 30)]
    [Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult<ApiResponse>> GetVilla(int id)
    {

        if (id <= 0)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = ["Invalid villa ID"];
            _response.StatusCode = HttpStatusCode.BadRequest;
            return BadRequest(_response);
        }

        Villa villa = await _villaRepository.GetAsync(u => u.Id == id);

        if (villa == null)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = ["Villa not found"];
            _response.StatusCode = HttpStatusCode.NotFound;
            return NotFound(_response);
        }

        var villaDto = _mapper.Map<VillaDto>(villa);
        _response.Result = villaDto;
        _response.StatusCode = HttpStatusCode.OK;

        return Ok(_response);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult<ApiResponse>> CreateVilla([FromBody] VillaCreateDto villaCreateDto)
    {
        if (villaCreateDto == null)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string> { "Villa data is missing" };
            _response.StatusCode = HttpStatusCode.BadRequest;
            return BadRequest(_response);
        }

        var villa = _mapper.Map<Villa>(villaCreateDto);

        try
        {
            await _villaRepository.CreateAsync(villa);
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
    public async Task<ActionResult<ApiResponse>> DeleteVilla(int id)
    {

        try
        {
            if (id <= 0)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { "Invalid villa ID" };
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            var villa = await _villaRepository.GetAsync(u => u.Id == id);

            if (villa == null)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { "Villa not found" };
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_response);
            }

            await _villaRepository.RemoveAsync(villa);
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
    public async Task<ActionResult<ApiResponse>> UpdateVilla([FromBody] VillaUpdateDto villaUpdateDto)
    {

        try
        {
            if (villaUpdateDto.Id <= 0)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { "Invalid villa ID" };
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }
            var updatedVilla = _mapper.Map<Villa>(villaUpdateDto);

            var resp = await _villaRepository.UpdateAsync(updatedVilla);
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