using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global_API.Models
{
    public partial class TbAccountsValidate
    {
        public int IdAccountVal { get; set; }
        public int? IdForm { get; set; }
        public string UrlDynamic { get; set; }
        public bool? BitActive { get; set; }
        public string ValueDynamic { get; set; }
    }
}
