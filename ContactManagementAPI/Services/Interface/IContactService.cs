using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IContactService
    {
        Task CreateContact(CreateContactRequestDto request);
        Task<List<ContactDto>> GetAllContacts();
        Task<ContactDto?> GetContactById(int id);
        Task UpdateContact(UpdateContactRequestDto request, int id);
        Task DeleteContact(int id);
        Task<List<ContactDetailsDto>> GetContactsWithCompanyAndCountry();

    }
}
