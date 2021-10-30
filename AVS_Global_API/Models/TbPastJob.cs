using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global_API.Models
{
    public partial class TbPastJob
    {
        public int IdpJob { get; set; }
        public int? IdForm { get; set; }
        public string Designation { get; set; }
        public string Depto { get; set; }
        public string DateStart { get; set; }
        public string DateFinish { get; set; }
        public string Duties { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string DescAddContr { get; set; }
        public bool? BitApplyVisaThird { get; set; }

        public virtual TbFormulary IdFormNavigation { get; set; }
    }
}
