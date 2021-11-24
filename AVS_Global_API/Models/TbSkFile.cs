using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global_API.Models
{
    public partial class TbSkFile
    {
        public int IdFileSk { get; set; }
        public int? IdForm { get; set; }
        public byte[] ValueFile { get; set; }
    }
}
