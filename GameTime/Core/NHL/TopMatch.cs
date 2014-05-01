using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
namespace GameTime.Core.NHL
{
    [JsonObject("top_match")]
    public class TopMatch
    {
        [JsonProperty("priority", NullValueHandling = NullValueHandling.Ignore)]
        public string Priority { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
        public string Note { get; set; }
    }
}
