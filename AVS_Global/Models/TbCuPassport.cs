using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global.Models
{
    public partial class TbCuPassport
    {
        public int IdPassport { get; set; }
        public int? IdForm { get; set; }
        public byte[] Passport { get; set; }
        public bool? BitAdult { get; set; }
        public bool? BitChild { get; set; }
    }
}
