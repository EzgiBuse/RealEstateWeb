using RealEstateWeb_MVC.Models.Dto;

namespace RealEstateWeb_MVC.Services.IServices
{
    public interface IEstateService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(EstateCreateDto dto);
        Task<T> UpdateAsync<T>(EstateUpdateDto dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
