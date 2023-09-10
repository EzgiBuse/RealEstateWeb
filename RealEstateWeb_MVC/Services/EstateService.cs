using Estate_Utility;
using Microsoft.AspNetCore.Mvc;
using RealEstateWeb_MVC.Models;
using RealEstateWeb_MVC.Models.Dto;
using RealEstateWeb_MVC.Services.IServices;

namespace RealEstateWeb_MVC.Services
{
    public class EstateService : BaseService,IEstateService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string EstateUrl;

        public EstateService(IHttpClientFactory clientfactory, IConfiguration configuration) : base(clientfactory)
        {
            _clientFactory = clientfactory;
            EstateUrl = configuration.GetValue<string>("ServiceUrls:RealEstateWeb");
        }

        public Task<T> CreateAsync<T>(EstateCreateDto dto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = EstateUrl + "/api/EstateAPI"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
               
                Url = EstateUrl + "/api/EstateAPI/"+id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
               
                Url = EstateUrl + "/api/EstateAPI"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
               
                Url = EstateUrl + "/api/EstateAPI/"+id
            });
        }

        public Task<T> UpdateAsync<T>(EstateUpdateDto dto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = EstateUrl + "/api/EstateAPI/"+dto.ID
            });
        }
    }
}
