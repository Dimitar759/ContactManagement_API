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
    public class CompanyRepository : IRepository<Company>
    {
        private readonly AppDbContext _dbContext;

        public CompanyRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Company entity)
        {
            await _dbContext.Companies.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Company entity)
        {
            _dbContext.Companies.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Company>> GetAll()
        {
            return await _dbContext.Companies.ToListAsync();
        }

        public async Task<Company?> GetById(int id)
        {
            return await _dbContext.Companies.FirstOrDefaultAsync(c => c.CompanyId == id);
        }

        public async Task Update(Company entity)
        {
            _dbContext.Companies.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
