using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DTO
{
    public class CountryDto
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; } = string.Empty;
        public List<int>? ContactIds { get; set; }
    }
}
