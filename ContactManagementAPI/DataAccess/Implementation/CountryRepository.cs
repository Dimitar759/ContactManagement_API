using DataAccess.Interface;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementation
{
    public class CountryRepository : IRepository<Country>
    {
        private readonly AppDbContext _dbContext;

        public CountryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Country entity)
        {
            await _dbContext.Countries.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Country entity)
        {
            _dbContext.Countries.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Country>> GetAll()
        {
            return await _dbContext.Countries.ToListAsync();
        }

        public async Task<Country?> GetById(int id)
        {
            return await _dbContext.Countries.FindAsync(id);
        }

        public async Task Update(Country entity)
        {
            _dbContext.Countries.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
