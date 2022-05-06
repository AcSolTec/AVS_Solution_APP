namespace AVS_Global.Models
{
    public class ResponseAPI
    {
        ResponseHeader ResponseHeader { get; set; }
        public string Token { get; set; }
        public string Expiration { get; set; }
        public string RedirectUrl { get; set; }
    }

    public class ResponseHeader
    {
        public string SpecVersion { get; set; }
        public string RequestId { get; set; }
    }
}
