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
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _dbContext;

        public ContactRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Contact entity)
        {
            await _dbContext.Contacts.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Contact entity)
        {
            _dbContext.Contacts.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Contact>> GetAll()
        {
            return await _dbContext.Contacts.ToListAsync();
        }

        public async Task<Contact?> GetById(int id)
        {
            return await _dbContext.Contacts.FirstOrDefaultAsync(c => c.ContactId == id);
        }

        public async Task Update(Contact entity)
        {
            _dbContext.Contacts.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Contact>> GetContactsWithCompanyAndCountry()
        {
            return await _dbContext.Contacts
                .Include(c => c.Company)
                .Include(c => c.Country)
                .ToListAsync();
        }
    }
}
