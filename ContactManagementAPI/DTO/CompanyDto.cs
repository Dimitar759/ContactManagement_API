using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTO
{
    public class CompanyDto
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;

        public List<int>? ContactIds { get; set; }
    }
}
