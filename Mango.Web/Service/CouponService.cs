using Mango.Web.Models;
using Mango.Web.Service.IService;

namespace Mango.Web.Service
{
    public class CouponService:ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public Task<Response?> CreateCouponAsync(CouponDTO couponDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Response?> DeleteCouponAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response?> GetAllCouponAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response?> GetAllCouponByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response?> GetCoupon(string couponCode)
        {
            throw new NotImplementedException();
        }

        public Task<Response?> UpdateCouponAsync(CouponDTO couponDTO)
        {
            throw new NotImplementedException();
        }
    }
}
