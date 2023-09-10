using Estate_Utility;
using RealEstateWeb_MVC.Models;
using RealEstateWeb_MVC.Models.Dto;
using RealEstateWeb_MVC.Services.IServices;

namespace RealEstateWeb_MVC.Services
{
    public class AuthService : BaseService,IAuthService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string EstateUrl;

        public AuthService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            EstateUrl = configuration.GetValue<string>("ServiceUrls:RealEstateWeb");

        }

        public Task<T> LoginAsync<T>(LoginRequestDto obj)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = obj,
                Url = EstateUrl + "api/UsersAuth/login"
            });
        }

        

        public Task<T> RegisterAsync<T>(RegisterationRequestDTO obj)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = obj,
                Url = EstateUrl + "/api/UsersAuth/register"
            });
        }

       
    }
}
