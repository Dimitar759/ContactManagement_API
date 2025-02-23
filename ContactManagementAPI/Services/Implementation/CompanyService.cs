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
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(IRepository<Company> companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task CreateCompany(CreateCompanyRequestDto request)
        {
            var company = _mapper.Map<Company>(request);
            await _companyRepository.Add(company);
        }

        public async Task<List<CompanyDto>> GetAllCompanies()
        {
            var companies = await _companyRepository.GetAll();
            return _mapper.Map<List<CompanyDto>>(companies);
        }

        public async Task<CompanyDto?> GetCompanyById(int id)
        {
            var company = await _companyRepository.GetById(id);
            return company == null ? null : _mapper.Map<CompanyDto>(company);
        }

        public async Task UpdateCompany(UpdateCompanyRequestDto request, int id)
        {
            var company = await _companyRepository.GetById(id);
            if (company == null) return;

            _mapper.Map(request, company); // Updates properties without manually setting them
            await _companyRepository.Update(company);
        }

        public async Task DeleteCompany(int id)
        {
            var company = await _companyRepository.GetById(id);
            if (company == null) return;

            await _companyRepository.Delete(company);
        }


    }
}
