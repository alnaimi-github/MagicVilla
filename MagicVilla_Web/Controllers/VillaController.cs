using MagicVilla_Web.Dto.ResponseDto;
using MagicVilla_Web.Dto.Villa;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVilla_Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaService _villaService;

        public VillaController(IVillaService villaService)
        {
            _villaService = villaService;
        }
        public async Task<IActionResult> VillaIndex()
        {
            List<VillaDto> list = [];
            var response = await _villaService.GetAllAsync<ApiResponse?>();
            if (response !=null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaDto>>(Convert.ToString(response.Result));
            }

            return View(list);
        }
        [Authorize(Roles = "admin")]
        public IActionResult CreateVilla()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateVilla(VillaCreateDto model)
        {
            if(ModelState.IsValid)
            {
                var response = await _villaService.CreateAsync<ApiResponse?>(model);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Villa created successfully!";
                    return RedirectToAction(nameof(VillaIndex));
                }
            }
            TempData["error"] = "Error encountered";
            return View(model);
        }

        public async Task<IActionResult> UpdateVilla(int VillaId)
        {
            var response = await _villaService.GetAsync<ApiResponse>(VillaId);
            if (response.IsSuccess && response!=null)
            {
                VillaUpdateDto dto = JsonConvert.DeserializeObject<VillaUpdateDto>(Convert.ToString(response.Result)!)!;
               return View(dto);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVilla(VillaUpdateDto model)
        {
            if(ModelState.IsValid)
            {
                var response = await _villaService.UpdateAsync<ApiResponse>(model);
                if (response.IsSuccess && response!=null)
                {
                    TempData["success"] = "Villa updated successfully!";
                    return RedirectToAction(nameof(VillaIndex));
                }
                ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault()!);
            }
            TempData["error"] = "Error encountered";
            return View(model);
        }

        public async Task<IActionResult> DeleteVilla(int VillaId)
        {
            var response = await _villaService.GetAsync<ApiResponse>(VillaId);
            if(!response.IsSuccess || response == null){ return NotFound();}
            VillaDto dto = JsonConvert.DeserializeObject<VillaDto>(Convert.ToString(response.Result)!)!;
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVilla(VillaDto model)
        {
            var response = await _villaService.DeleteAsync<ApiResponse>(model.Id);
            if(response.IsSuccess && response!=null)
            {
                TempData["success"] = "Villa deleted successfully!";
                return RedirectToAction(nameof(VillaIndex));
            }
            TempData["error"] = "Error encountered";
            return View(model);
        }



    }
}
