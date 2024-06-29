using MagicVilla_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using MagicVilla_Web.Dto.ResponseDto;
using MagicVilla_Web.Dto.Villa;
using MagicVilla_Web.Services.IServices;

namespace MagicVilla_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVillaService _villaService;

        public HomeController(IVillaService villaService)
        {
            _villaService = villaService;
        }

        public async Task<IActionResult> Index()
        {
            List<VillaDto> list = [];
            var response = await _villaService.GetAllAsync<ApiResponse?>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaDto>>(Convert.ToString(response.Result));
            }

            return View(list);
        }
    }
}
