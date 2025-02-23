using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ICompanyService
    {
        Task CreateCompany(CreateCompanyRequestDto request);
        Task<List<CompanyDto>> GetAllCompanies();
        Task<CompanyDto?> GetCompanyById(int id);
        Task UpdateCompany(UpdateCompanyRequestDto request, int id);
        Task DeleteCompany(int id);

    }
}
