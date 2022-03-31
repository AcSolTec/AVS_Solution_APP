using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global.Models
{
    public partial class TbUrlActivation
    {
        public int IdUrl { get; set; }
        public int? IdCustomer { get; set; }
        public string ValueUrl { get; set; }
        public bool? Active { get; set; }

        public virtual TbCustomersAv IdCustomerNavigation { get; set; }
    }
}
