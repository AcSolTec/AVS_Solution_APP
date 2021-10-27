using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global_API.Models
{
    public partial class TbAvsSecurityOption
    {
        public int IdCon { get; set; }
        public string Value { get; set; }
        public string KeyAcc { get; set; }
        public bool? BitActive { get; set; }
    }
}
