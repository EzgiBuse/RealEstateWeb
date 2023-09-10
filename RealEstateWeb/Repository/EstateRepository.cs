using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using RealEstateWeb.Data;
using RealEstateWeb.Models;
using System.Linq;
using System.Linq.Expressions;

namespace RealEstateWeb.Repository
{
    public class EstateRepository : Repository<Estate>,IEstateRepository
    {
        private readonly ApplicationDbContext _db;

        public EstateRepository(ApplicationDbContext db) : base(db)
        {
            this._db = db;
        }
      
        public async Task<Estate> UpdateAsync(Estate entity)
        {
            entity.DateUpdated = DateTime.UtcNow;
            _db.Estates.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
