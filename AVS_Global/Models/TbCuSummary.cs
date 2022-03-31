using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global.Models
{
    public partial class TbCuSummary
    {
        public int IdSum { get; set; }
        public int? IdForm { get; set; }
        public string Comments { get; set; }
        public bool? BitReadSucc { get; set; }
        public bool? BitReadGtc { get; set; }
    }
}
