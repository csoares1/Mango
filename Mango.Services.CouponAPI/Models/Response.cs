namespace Mango.Services.CouponAPI.Models
{
    public class Response
    {
        public object? Result { get; set; }
        public bool? Success { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
