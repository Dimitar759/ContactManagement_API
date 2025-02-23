using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; } = string.Empty;

        // Foreign keys
        public int CompanyId { get; set; }
        public Company? Company { get; set; }  // Navigation property

        public int CountryId { get; set; }
        public Country? Country { get; set; }  // Navigation property
    }
}
