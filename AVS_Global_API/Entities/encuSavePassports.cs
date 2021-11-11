using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVS_Global_API.Entities
{
    public class encuSavePassports
    {
        public byte[] pasportAdult { get; set; }
        public byte[] pasportChild { get; set; }
        public int idForm { get; set; }
        
    }
}
