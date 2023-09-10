using RealEstateWeb.Models;
using System.Linq.Expressions;

namespace RealEstateWeb.Repository
{
    public interface IEstateNumberRepository : IRepository<EstateNumber>
    {
       
        Task<EstateNumber> UpdateAsync(EstateNumber entity);
      
    }
}
