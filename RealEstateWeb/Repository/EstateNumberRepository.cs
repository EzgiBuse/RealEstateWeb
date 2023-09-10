using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using RealEstateWeb.Data;
using RealEstateWeb.Models;
using System.Linq;
using System.Linq.Expressions;

namespace RealEstateWeb.Repository
{
    public class EstateNumberRepository : Repository<EstateNumber>,IEstateNumberRepository
    {
        private readonly ApplicationDbContext _db;

        public EstateNumberRepository(ApplicationDbContext db) : base(db)
        {
            this._db = db;
        }
      
        public async Task<EstateNumber> UpdateAsync(EstateNumber entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            _db.EstateNumbers.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

       
    }
}
