using Newtonsoft.Json;

namespace CowboyWebAPI.ViewModels
{
    public class NameFakeModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("maiden_name")]
        public string MaidenName { get; set; }

        [JsonProperty("birth_data")]
        public DateTime BirthData { get; set; }

        [JsonProperty("phone_h")]
        public string PhoneH { get; set; }

        [JsonProperty("phone_w")]
        public string PhoneW { get; set; }

        [JsonProperty("email_u")]
        public string EmailU { get; set; }

        [JsonProperty("email_d")]
        public string EmailD { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("useragent")]
        public string Useragent { get; set; }

        [JsonProperty("ipv4")]
        public string Ipv4 { get; set; }

        [JsonProperty("macaddress")]
        public string Macaddress { get; set; }

        [JsonProperty("plasticcard")]
        public string Plasticcard { get; set; }

        [JsonProperty("cardexpir")]
        public string Cardexpir { get; set; }

        [JsonProperty("bonus")]
        public long Bonus { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("weight")]
        public double Weight { get; set; }

        [JsonProperty("blood")]
        public string Blood { get; set; }

        [JsonProperty("eye")]
        public string Eye { get; set; }

        [JsonProperty("hair")]
        public string Hair { get; set; }

        [JsonProperty("pict")]
        public string Pict { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("sport")]
        public string Sport { get; set; }

        [JsonProperty("ipv4_url")]
        public string Ipv4Url { get; set; }

        [JsonProperty("email_url")]
        public string EmailUrl { get; set; }

        [JsonProperty("domain_url")]
        public string DomainUrl { get; set; }
    }
}
