using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVS_Global.Models
{
    public class pkDeportedData
    {
        public int idForm { get; set; }
        public string dateDeport { get; set; }
        public int idCountry { get; set; }
        public string reason { get; set; }
        public string referenceNum { get; set; }
    }
}
