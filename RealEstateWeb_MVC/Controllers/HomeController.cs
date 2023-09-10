using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateWeb_MVC.Models;
using RealEstateWeb_MVC.Models.Dto;
using RealEstateWeb_MVC.Services.IServices;
using System.Diagnostics;

namespace RealEstateWeb_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEstateService _estateService;
        private readonly IMapper _mapper;

        public HomeController(IEstateService estateservice, IMapper mapper)
        {
            _estateService = estateservice;
            _mapper = mapper;

        }
        public async Task<IActionResult> Index()
        {
            List<EstateDto> a = new List<EstateDto>();
            var response = await _estateService.GetAllAsync<ApiResponse>();
            if (response != null && response.IsSuccess)
            {
                a = JsonConvert.DeserializeObject<List<EstateDto>>(Convert.ToString(response.Result));
            }
            return View(a);
        }

        public async Task<IActionResult> Contact()
        {
            return View(Contact);
        }

    }
}