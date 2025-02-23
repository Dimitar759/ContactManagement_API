using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UpdateContactRequestDto
    {
        public string ContactName { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public int CountryId { get; set; }
    }
}
