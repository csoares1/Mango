using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly AppDBContext _db;
        private Response _response;
        private IMapper _mapper;

        public CouponController(AppDBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new Response();

        }

        [HttpGet]
        public Response Get()
        {            
            try
            {
                IEnumerable<Coupon> list = _db.Coupons.ToList();              
                _response.Result = _mapper.Map<IEnumerable<CouponDTO>>(list);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
                
            }

            return _response;
        }


        [HttpGet]
        [Route("{id:int}")]
        public  Response Get(int id)
        {            
            try
            {
              Coupon   list = _db.Coupons.First(c=>c.CouponId==id);
                _response.Result = _mapper.Map<CouponDTO>(list); ;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;

            }
            return _response;
        }


        [HttpGet]
        [Route("GetByCode/{code}")]
        public Response GetByCode(string code)
        {
            try
            {
                Coupon list = _db.Coupons.First(c => c.CouponCode.ToLower() == code.ToLower());
                _response.Result = _mapper.Map<CouponDTO>(list); ;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;

            }
            return _response;
        }

        [HttpPost]      
        public Response Post([FromBody] CouponDTO couponDTO)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDTO);
                _db.Coupons.Add(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<CouponDTO>(obj); 
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;

            }
            return _response;
        }

        [HttpPut]
        public Response Put([FromBody] CouponDTO couponDTO)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDTO);
                _db.Coupons.Update(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<CouponDTO>(obj);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;

            }
            return _response;
        }

        [HttpDelete]
        public Response Delete(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(u=>u.CouponId==id);
                _db.Coupons.Remove(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<CouponDTO>(obj);
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;

            }
            return _response;
        }
    }
}
