using FrontEnd.Presentation.API.DTOs;

namespace FrontEnd.Core.Interfaces.Services
{
    public interface IBaseService: IDisposable
    {
        public ResponseDTO response { get; set; }
        Task<T> SendGetAsync<T>(ApiRequest apiRequest);
        Task<T> SendPostAsync<T>(ApiRequest apiRequest);
        Task<T> SendPutAsync<T>(ApiRequest apiRequest);
        Task<T> SendDeleteAsync<T>(ApiRequest apiRequest);
    }
}
