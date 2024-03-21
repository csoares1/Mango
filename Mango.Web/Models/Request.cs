using static Mango.Web.Utility.SD;

namespace Mango.Web.Models
{
    public class Request
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string ApiUrl { get; set; }
        public object Data { get; set; }
        public string AccesToken { get; set; }
    }
}
