using RealEstateWeb.Models;
using System.Linq.Expressions;

namespace RealEstateWeb.Repository
{
    public interface IEstateRepository : IRepository<Estate>
    {
       
        Task<Estate> UpdateAsync(Estate entity);
      
    }
}
