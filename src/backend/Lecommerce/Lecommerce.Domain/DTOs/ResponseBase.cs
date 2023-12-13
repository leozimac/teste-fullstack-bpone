using System.Net;

namespace Lecommerce.Domain.DTOs
{
    public class ResponseBase
    {
        public IList<string> Messages { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public ResponseBase()
        {
            Messages = new List<string>();
        }
    }
}
