using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVS_Global.Models
{
    public class Payment
    {
        public Amount Amount { get; set; }
        public string OrderId { get; set; }
        public string Description { get; set; }
    }
}
