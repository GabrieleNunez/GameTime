using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace GameTime.Core.NHL
{
    [JsonObject("logos")]
    public class LogoUrls
    {
        [JsonProperty("large", NullValueHandling = NullValueHandling.Ignore)]
        public string Large { get; set; }

        [JsonProperty("small", NullValueHandling = NullValueHandling.Ignore)]
        public string Small { get; set; }

        [JsonProperty("tiny", NullValueHandling = NullValueHandling.Ignore)]
        public string Tiny { get; set; }
    }
}
