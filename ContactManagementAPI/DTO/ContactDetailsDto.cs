using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ContactDetailsDto
    {

        public int ContactId { get; set; }
        public string ContactName { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string CountryName { get; set; } = string.Empty;

    }
}
