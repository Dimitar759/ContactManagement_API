using Domain;

namespace DataAccess.Interface
{
    public interface IContactRepository : IRepository<Contact>
    {
        Task<List<Contact>> GetContactsWithCompanyAndCountry();
    }
}
