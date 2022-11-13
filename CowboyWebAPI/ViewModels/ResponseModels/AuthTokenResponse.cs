using Newtonsoft.Json;

namespace CowboyWebAPI.ViewModels.ResponseModels
{
    public class AuthTokenResponse
    {
        public ResponseModel responseModel { get; set; }

        [JsonProperty("Data")]
        public string Token { get; set; }
    }
}
