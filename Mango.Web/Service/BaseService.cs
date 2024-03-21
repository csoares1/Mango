using Mango.Web.Models;
using Mango.Web.Service.IService;
using Newtonsoft.Json;
using System.Text;

namespace Mango.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

        }
        public async Task<Response?> SendAsync(Request request)
        {
            HttpClient client= _httpClientFactory.CreateClient("MangoAPI");
            HttpRequestMessage message = new();
            message.Headers.Add("Content-Type", "application/json");
            message.RequestUri = new Uri(request.ApiUrl);
            if(request.Data != null)
            {
              message.Content = new StringContent(JsonConvert.SerializeObject(request.Data),Encoding.UTF8, "application/json");
            }
            HttpResponseMessage? apiResponse = null;
            switch (request.ApiType)
            {
                case Utility.SD.ApiType.GET:
                    message.Method = HttpMethod.Get;
                    break;
                case Utility.SD.ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case Utility.SD.ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                case Utility.SD.ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                default:
                    break;
            }

            apiResponse = await client.SendAsync(message);
            try
            {
                switch (apiResponse.StatusCode)
                {
                    case System.Net.HttpStatusCode.NotFound:
                        return new()
                        {
                            Success = false,
                            Message = "Não encontrado"
                        };
                    case System.Net.HttpStatusCode.Forbidden:
                        return new()
                        {
                            Success = false,
                            Message = "Não encontrado"
                        };
                    case System.Net.HttpStatusCode.Unauthorized:
                        return new()
                        {
                            Success = false,
                            Message = "Não encontrado"
                        };
                    case System.Net.HttpStatusCode.InternalServerError:
                        return new()
                        {
                            Success = false,
                            Message = "Não encontrado"
                        };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<Response>(apiContent);
                        return apiResponseDto;
                }
            }
            catch (Exception ex)
            {
                var dto = new Response
                {
                    Message = ex.Message,
                    Success = false,

                };
                return dto;
            }
            }
        }
    }
}
