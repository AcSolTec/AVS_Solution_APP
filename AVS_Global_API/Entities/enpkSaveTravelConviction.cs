using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVS_Global_API.Entities
{
    public class enpkSaveTravelConviction
    {
        public int idForm { get; set; }
        public string dateConvict { get; set; }
        public int idCountry { get; set; }
        public string offence { get; set; }
        public string sentence { get; set; }
    }
}
