using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AVS_Global
{
    public class NoKeepAliveWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address) as HttpWebRequest;
            if (request != null)
            {
                request.KeepAlive = false;
            }
            return request;
        }
    }
}
