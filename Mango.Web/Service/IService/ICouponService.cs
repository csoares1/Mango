using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface ICouponService
    {
        Task<Response?>GetCoupon(string couponCode);
        Task<Response?> GetAllCouponAsync();
        Task<Response?> GetAllCouponByIdAsync(int id);
        Task<Response?> CreateCouponAsync(CouponDTO couponDTO);
        Task<Response?> UpdateCouponAsync(CouponDTO couponDTO);
        Task<Response?> DeleteCouponAsync(int id);
    }
}
