using AutoMapper;
using DataAccess.Interface;
using Domain;
using DTO;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task CreateContact(CreateContactRequestDto request)
        {
            var contact = _mapper.Map<Contact>(request);
            await _contactRepository.Add(contact);
        }

        public async Task<List<ContactDto>> GetAllContacts()
        {
            var contacts = await _contactRepository.GetAll();
            return _mapper.Map<List<ContactDto>>(contacts);
        }

        public async Task<ContactDto?> GetContactById(int id)
        {
            var contact = await _contactRepository.GetById(id);
            return contact == null ? null : _mapper.Map<ContactDto>(contact);
        }

        public async Task UpdateContact(UpdateContactRequestDto request, int id)
        {
            var contact = await _contactRepository.GetById(id);
            if (contact == null) return;

            _mapper.Map(request, contact); // Updates properties without manually setting them
            await _contactRepository.Update(contact);
        }

        public async Task DeleteContact(int id)
        {
            var contact = await _contactRepository.GetById(id);
            if (contact == null) return;

            await _contactRepository.Delete(contact);
        }

        public async Task<List<ContactDetailsDto>> GetContactsWithCompanyAndCountry()
        {
            var contacts = await _contactRepository.GetContactsWithCompanyAndCountry();
            return _mapper.Map<List<ContactDetailsDto>>(contacts);
        }
    }
}
