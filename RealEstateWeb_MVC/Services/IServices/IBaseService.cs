using RealEstateWeb_MVC.Models;

namespace RealEstateWeb_MVC.Services.IServices
{
    public interface IBaseService
    {
        ApiResponse responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
