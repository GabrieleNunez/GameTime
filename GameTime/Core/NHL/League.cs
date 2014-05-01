using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
namespace GameTime.Core.NHL
{
    [JsonObject("league")]
    public class League
    {
        [JsonProperty("default_section", NullValueHandling = NullValueHandling.Ignore)]
        public string Default_Section { get; set; }

        [JsonProperty("medium_name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string FullName { get; set; }

        [JsonProperty("season_type", NullValueHandling = NullValueHandling.Ignore)]
        public string SeasonType { get; set; }

        [JsonProperty("short_name", NullValueHandling = NullValueHandling.Ignore)]
        public string ShortName { get; set; }

        [JsonProperty("slug", NullValueHandling = NullValueHandling.Ignore)]
        public string Slug { get; set; }

        [JsonProperty("sport_name", NullValueHandling = NullValueHandling.Ignore)]
        public string Sport { get; set; }

        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime LastUpdate { get; set; }
    }
}
