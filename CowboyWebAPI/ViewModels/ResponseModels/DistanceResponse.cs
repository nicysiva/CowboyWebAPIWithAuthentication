using Newtonsoft.Json;

namespace CowboyWebAPI.ViewModels.ResponseModels
{
    public class DistanceResponse
    {
        public ResponseModel responseModel { get; set; }

        [JsonProperty("Data")]
        public double distance { get; set; }
    }
}
