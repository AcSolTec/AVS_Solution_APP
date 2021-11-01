using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVS_Global.Models
{
    public class CatModelsView
    {
        public CatVisasApplied visasApplied { get; set; }
        public CatVisasRequiered visasRequiered { get; set; }

        public CatTypeVisas typeVisas { get; set; }
    }
}
