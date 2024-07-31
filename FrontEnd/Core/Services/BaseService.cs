using FrontEnd.Core.Interfaces.Services;
using FrontEnd.Presentation.API.DTOs;
using Newtonsoft.Json;
using System.Text;

namespace FrontEnd.Core.Services
{
    public abstract class BaseService : IBaseService
    {
        public ResponseDTO response { get; set ; }
        public IHttpClientFactory _httpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
            response = new ResponseDTO();
        }

        public async Task<T> SendGetAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = _httpClient.CreateClient("RMSystem");
                HttpRequestMessage httpRequest = new HttpRequestMessage();
                httpRequest.Headers.Add("Accept", "application/json");
                httpRequest.RequestUri = new Uri(apiRequest.Url);
                httpRequest.Method = HttpMethod.Get;

                if (apiRequest.Data != null) 
                {
                    httpRequest.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }

                HttpResponseMessage apiResponse = await client.SendAsync(httpRequest);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDTO = JsonConvert.DeserializeObject<T>(apiContent);
                return apiResponseDTO;

            }
            catch(Exception e)
            {
                var dto = new ResponseDTO
                {
                    DisplayMessage = "ERROR",
                    Errors = new List<string> { Convert.ToString(e.ToString()) },
                    IsSuccess = false
                };

                var res = JsonConvert.SerializeObject(dto);
                var apiResponse = JsonConvert.DeserializeObject<T>(res);
                return apiResponse;

            }
        }
        
        public async Task<T> SendPostAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = _httpClient.CreateClient("RMSystem");
                HttpRequestMessage httpRequest = new HttpRequestMessage();
                httpRequest.Headers.Add("Accept", "application/json");
                httpRequest.RequestUri = new Uri(apiRequest.Url);
                httpRequest.Method = HttpMethod.Post;

                if (apiRequest.Data != null)
                {
                    httpRequest.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }

                HttpResponseMessage apiResponse = await client.SendAsync(httpRequest);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDTO = JsonConvert.DeserializeObject<T>(apiContent);
                return apiResponseDTO;

            }
            catch (Exception e)
            {
                var dto = new ResponseDTO
                {
                    DisplayMessage = "ERROR",
                    Errors = new List<string> { Convert.ToString(e.ToString()) },
                    IsSuccess = false
                };

                var res = JsonConvert.SerializeObject(dto);
                var apiResponse = JsonConvert.DeserializeObject<T>(res);
                return apiResponse;

            }
        }

        public async Task<T> SendPutAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = _httpClient.CreateClient("RMSystem");
                HttpRequestMessage httpRequest = new HttpRequestMessage();
                httpRequest.Headers.Add("Accept", "application/json");
                httpRequest.RequestUri = new Uri(apiRequest.Url);
                httpRequest.Method = HttpMethod.Put;

                if (apiRequest.Data != null)
                {
                    httpRequest.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }

                HttpResponseMessage apiResponse = await client.SendAsync(httpRequest);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDTO = JsonConvert.DeserializeObject<T>(apiContent);
                return apiResponseDTO;

            }
            catch (Exception e)
            {
                var dto = new ResponseDTO
                {
                    DisplayMessage = "ERROR",
                    Errors = new List<string> { Convert.ToString(e.ToString()) },
                    IsSuccess = false
                };

                var res = JsonConvert.SerializeObject(dto);
                var apiResponse = JsonConvert.DeserializeObject<T>(res);
                return apiResponse;

            }
        }

        public async Task<T> SendDeleteAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = _httpClient.CreateClient("RMSystem");
                HttpRequestMessage httpRequest = new HttpRequestMessage();
                httpRequest.Headers.Add("Accept", "application/json");
                httpRequest.RequestUri = new Uri(apiRequest.Url);
                httpRequest.Method = HttpMethod.Delete;

                if (apiRequest.Data != null)
                {
                    httpRequest.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }

                HttpResponseMessage apiResponse = await client.SendAsync(httpRequest);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDTO = JsonConvert.DeserializeObject<T>(apiContent);
                return apiResponseDTO;

            }
            catch (Exception e)
            {
                var dto = new ResponseDTO
                {
                    DisplayMessage = "ERROR",
                    Errors = new List<string> { Convert.ToString(e.ToString()) },
                    IsSuccess = false
                };

                var res = JsonConvert.SerializeObject(dto);
                var apiResponse = JsonConvert.DeserializeObject<T>(res);
                return apiResponse;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
