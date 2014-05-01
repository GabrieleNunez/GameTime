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
        [JsonProperty("large")]
        public string Large { get; set; }

        [JsonProperty("small")]
        public string Small { get; set; }

        [JsonProperty("tiny")]
        public string Tiny { get; set; }
    }
}
