using AutoMapper;
using Domain;
using DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping from Domain -> DTO
            CreateMap<Company, CompanyDto>()
                .ForMember(dest => dest.ContactIds, opt => opt.MapFrom(src => src.Contacts.Select(c => c.ContactId).ToList()));

            CreateMap<Contact, ContactDto>()
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Company.CompanyId))
                .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.Country.CountryId));

            CreateMap<Country, CountryDto>()
                .ForMember(dest => dest.ContactIds, opt => opt.MapFrom(src => src.Contacts.Select(c => c.ContactId).ToList()));

            // Mapping from DTO -> Domain 
            CreateMap<CompanyDto, Company>();

            CreateMap<ContactDto, Contact>()
             .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
             .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.CountryId));

            CreateMap<Contact, ContactDetailsDto>()
            .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyName))
            .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.CountryName));

            CreateMap<CountryDto, Country>();


            CreateMap<CreateCountryRequestDto, Country>();
            CreateMap<CreateCompanyRequestDto, Company>();
            CreateMap<CreateContactRequestDto, Contact>();

            CreateMap<UpdateCountryRequestDto, Country>();
            CreateMap<UpdateCompanyRequestDto, Company>();
            CreateMap<UpdateContactRequestDto, Contact>();
        }
    }
}
