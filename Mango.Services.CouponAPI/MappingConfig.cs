using AutoMapper;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.DTO;

namespace Mango.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(
                c =>
                {
                    c.CreateMap<CouponDTO, Coupon>();
                    c.CreateMap<Coupon,CouponDTO>();
                });
            return mappingConfig;
        }
    }
}
