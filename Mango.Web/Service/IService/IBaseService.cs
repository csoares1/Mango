using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IBaseService
    {
       Task<Response?> SendAsync(Request request);
    }
}
