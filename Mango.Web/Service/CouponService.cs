using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class CouponService:ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<Response?> CreateCouponAsync(CouponDTO couponDTO)
        {
            return await _baseService.SendAsync(new Request()
            {
                ApiType = SD.ApiType.POST,
                Data = couponDTO,
                ApiUrl = SD.CouponAPIBase + "/api/coupon/"
            });
        }

        public async Task<Response?> DeleteCouponAsync(int id)
        {
            return await _baseService.SendAsync(new Request()
            {
                ApiType = SD.ApiType.DELETE,
                ApiUrl = SD.CouponAPIBase + "/api/coupon/" + id
            });
        }

        public async Task<Response?> GetAllCouponAsync()
        {
            return await _baseService.SendAsync(new Request()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.CouponAPIBase + "/api/coupon"
            });
        }

        public async Task<Response?> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new Request()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.CouponAPIBase + "/api/coupon/" + id
            });
        }

        public async Task<Response?> GetCouponAsync(string couponCode)
        {
            return await _baseService.SendAsync(new Request()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.CouponAPIBase + "/api/coupon/GetByCode/"+couponCode
            });
        }

        public async Task<Response?> UpdateCouponAsync(CouponDTO couponDTO)
        {
            return await _baseService.SendAsync(new Request()
            {
                ApiType = SD.ApiType.PUT,
                Data = couponDTO,
                ApiUrl = SD.CouponAPIBase + "/api/coupon/"
            });
        }
    }
}
