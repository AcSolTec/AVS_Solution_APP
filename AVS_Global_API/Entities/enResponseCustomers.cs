using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVS_Global_API.Entities
{
    public class enResponseCustomers
    {
        public bool loginSuccess { get; set; }
        public string Message { get; set; }
        public string CountryLog { get; set; }
        public string IdForm { get; set; }
        public string rol { get; set; }
    }
}
