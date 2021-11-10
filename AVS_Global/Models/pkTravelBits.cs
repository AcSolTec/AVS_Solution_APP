using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVS_Global.Models
{
    public class pkTravelBits
    {
        public int idForm { get; set; }
        public bool bitRefused { get; set; }
        public bool bitRefusedPakistan { get; set; }
        public bool bitRemoveCountry { get; set; }
        public bool bitConviction { get; set; }

        public string detailRefusal { get; set; }
    }
}
