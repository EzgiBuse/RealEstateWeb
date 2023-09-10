using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstateWeb_MVC.Models;
using RealEstateWeb_MVC.Models.Dto;
using RealEstateWeb_MVC.Services.IServices;
using System.ComponentModel;
using System.Reflection;

namespace RealEstateWeb_MVC.Controllers
{
    public class EstateController : Controller
    {
        private readonly IEstateService _estateService;
        private readonly IMapper _mapper;

        public EstateController(IEstateService estateservice, IMapper mapper)
        {
            _estateService = estateservice;
            _mapper = mapper;
                
        }
        public async Task<IActionResult> IndexEstate()
        {
            List<EstateDto> a = new List<EstateDto>();
            var response = await _estateService.GetAllAsync<ApiResponse>();
            if (response != null && response.IsSuccess) {
                    a = JsonConvert.DeserializeObject<List<EstateDto>>(Convert.ToString(response.Result));
        }
            return View(a);
        }

        public async Task<IActionResult> CreateEstate()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEstate(EstateCreateDto model)
        {
            if(ModelState.IsValid)
            {
                var response = await _estateService.CreateAsync<ApiResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexEstate));
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEstate(int id)
        {
            var response = await _estateService.GetAsync<ApiResponse>(id);
            if (response != null && response.IsSuccess)
            {
                EstateDto model = JsonConvert.DeserializeObject<EstateDto>(Convert.ToString(response.Result));
                return View(_mapper.Map<EstateUpdateDto>(model));
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateEstate(EstateUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _estateService.UpdateAsync<ApiResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexEstate));
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteEstate(int id)
        {
            var response = await _estateService.GetAsync<ApiResponse>(id);
            if (response != null && response.IsSuccess)
            {
                EstateDto model = JsonConvert.DeserializeObject<EstateDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEstate(EstateDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _estateService.DeleteAsync<ApiResponse>(model.ID);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexEstate));
                }
            }
            return View(model);
        }
    }
}
