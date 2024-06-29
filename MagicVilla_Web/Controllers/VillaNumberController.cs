using MagicVilla_Web.Dto.ResponseDto;
using MagicVilla_Web.Dto.VillaNumber;
using MagicVilla_Web.Services.IServices;
using MagicVilla_Web.VM;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using MagicVilla_Web.Dto.Villa;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicVilla_Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IVillaNumberService _villaNumberService;
        private readonly IVillaService _villaService;

        public VillaNumberController(IVillaNumberService villaNumberService, IVillaService villaService)
        {
            _villaNumberService = villaNumberService;
            _villaService = villaService;
        }

        public async Task<IActionResult> VillaNumberIndex()
        {
            List<VillaNumberDto>? list = [];
            var response = await _villaNumberService.GetAllAsync<ApiResponse?>();
            if (response !=null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaNumberDto>>(Convert.ToString(response.Result)!);
            }

            return View(list);
        }
        public async Task<IActionResult> CreateVillaNumber()
        {
            VillaNumberCreateVM villaNumberCreateVm= new VillaNumberCreateVM();
            var response = await _villaService.GetAllAsync<ApiResponse?>();
            if (response != null && response.IsSuccess)
            {
               villaNumberCreateVm.villaList = JsonConvert.DeserializeObject<List<VillaDto>>
                   (Convert.ToString(response.Result)!)
                   .Select(x=>new SelectListItem
                       {Text = x.Name,Value = x.Id.ToString()});
            }

            return View(villaNumberCreateVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVillaNumber(VillaNumberCreateVM model)
        {
            if(ModelState.IsValid)
            {
                var response = await _villaNumberService.CreateAsync<ApiResponse?>(model.VillaNumber);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Villa number created successfully!";
                    return RedirectToAction(nameof(VillaNumberIndex));
                }
                else
                {
                    TempData["error"] = response!.ErrorMessages != null && response.ErrorMessages.Count > 0
                        ? response.ErrorMessages[0]
                        : "Error Encountered !";
                }
            }
            var resp = await _villaService.GetAllAsync<ApiResponse?>();
            if (resp != null && resp.IsSuccess)
            {
                model.villaList = JsonConvert.DeserializeObject<List<VillaDto>>
                        (Convert.ToString(resp.Result)!)
                    .Select(x => new SelectListItem
                        { Text = x.Name, Value = x.Id.ToString() });
            }
            else
            {
                TempData["error"] = resp!.ErrorMessages != null && resp.ErrorMessages.Count > 0
                    ? resp.ErrorMessages[0]
                    : "Error Encountered !";
            }
            return View(model);
        }

        public async Task<IActionResult> UpdateVillaNumber(int VillaNo)
        {
            VillaNumberUpdateVM villaNumberUpdateVm = new();
            var response = await _villaNumberService.GetAsync<ApiResponse>(VillaNo);
            if (response.IsSuccess && response!=null)
            {
                VillaNumberUpdateDto dto = JsonConvert.DeserializeObject<VillaNumberUpdateDto>(Convert.ToString(response.Result)!)!;
                villaNumberUpdateVm.VillaNumber = dto;
            }
            response = await _villaService.GetAllAsync<ApiResponse?>();
            if (response != null && response.IsSuccess)
            {
                villaNumberUpdateVm.villaList = JsonConvert.DeserializeObject<List<VillaDto>>
                        (Convert.ToString(response.Result)!)
                    .Select(x => new SelectListItem
                        { Text = x.Name, Value = x.Id.ToString() });
                return View(villaNumberUpdateVm);
            }
            TempData["error"] = response!.ErrorMessages != null && response.ErrorMessages.Count > 0
                ? response.ErrorMessages[0]
                : "Error Encountered !";
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVillaNumber(VillaNumberUpdateVM model)
        {
            if(ModelState.IsValid)
            {
                var response = await _villaNumberService.UpdateAsync<ApiResponse>(model.VillaNumber);
                if (response.IsSuccess && response!=null)
                {
                    TempData["success"] = "Villa number updated successfully!";
                    return RedirectToAction(nameof(VillaNumberIndex));
                }

                else
                {
                    TempData["error"] = response!.ErrorMessages != null && response.ErrorMessages.Count > 0
                        ? response.ErrorMessages[0]
                        : "Error Encountered !";
                }
            }
            var responseReturnVillas = await _villaService.GetAllAsync<ApiResponse?>();
            if (responseReturnVillas != null && responseReturnVillas.IsSuccess)
            {
                model.villaList = JsonConvert.DeserializeObject<List<VillaDto>>
                        (Convert.ToString(responseReturnVillas.Result)!)
                    .Select(x => new SelectListItem
                        { Text = x.Name, Value = x.Id.ToString() });
            }
            else
            {
                TempData["error"] = responseReturnVillas!.ErrorMessages != null && responseReturnVillas.ErrorMessages.Count > 0
                    ? responseReturnVillas.ErrorMessages[0]
                    : "Error Encountered !";
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteVillaNumber(int VillaNo)
        {
            VillaNumberDeleteVM villaNumberDeleteVm = new();
            var response = await _villaNumberService.GetAsync<ApiResponse>(VillaNo);
            if (response.IsSuccess && response != null)
            {
                VillaNumberDto dto = JsonConvert.DeserializeObject<VillaNumberDto>(Convert.ToString(response.Result)!)!;
                villaNumberDeleteVm.VillaNumber = dto;
            }
            response = await _villaService.GetAllAsync<ApiResponse?>();
            if (response != null && response.IsSuccess)
            {
                villaNumberDeleteVm.villaList = JsonConvert.DeserializeObject<List<VillaDto>>
                        (Convert.ToString(response.Result)!)
                    .Select(x => new SelectListItem
                    { Text = x.Name, Value = x.Id.ToString() });
                return View(villaNumberDeleteVm);
            }
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVillaNumber(VillaNumberDeleteVM model)
        {
            var response = await _villaNumberService.DeleteAsync<ApiResponse>(model.VillaNumber.VillaNo);
            if(response.IsSuccess && response!=null)
            {
                TempData["success"] = "Villa number deleted successfully!";
                return RedirectToAction(nameof(VillaNumberIndex));
            }

            TempData["error"] = response!.ErrorMessages != null && response.ErrorMessages.Count > 0
                ? response.ErrorMessages[0]
                : "Error Encountered !";

            return View(model);
        }



    }
}
