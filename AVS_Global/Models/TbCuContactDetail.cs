using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global.Models
{
    public partial class TbCuContactDetail
    {
        public int IdCuContact { get; set; }
        public int? IdForm { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Town { get; set; }
        public string EmailAddress { get; set; }
        public string TelNumber { get; set; }
    }
}
