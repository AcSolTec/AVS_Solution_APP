using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVS_Global.Models
{
    public class RequestHeader
    {
        public string SpecVersion { get; set; }
        public string CustomerId { get; set; }
        public string RequestId { get; set; }
        public int RetryIndicator { get; set; }
        public ClientInfo ClientInfo { get; set; }

    }

    public class ClientInfo
    {
        public string ShopInfo { get; set; }
        public string OsInfo { get; set; }
    }
}
