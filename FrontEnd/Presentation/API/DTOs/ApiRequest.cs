using FrontEnd.Core.Common;

namespace FrontEnd.Presentation.API.DTOs
{
    public class ApiRequest
    {
        public object Data { get; set; }
        public string Url {  get; set; }
        public string AccessToken { get; set; }
        
    }
}
