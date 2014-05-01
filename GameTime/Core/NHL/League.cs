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
        [JsonProperty("default_section")]
        public string Default_Section { get; set; }

        [JsonProperty("medium_name")]
        public string Name { get; set; }

        [JsonProperty("name")]
        public string FullName { get; set; }

        [JsonProperty("season_type")]
        public string SeasonType { get; set; }

        [JsonProperty("short_name")]
        public string ShortName { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("sport_name")]
        public string Sport { get; set; }

        [JsonProperty("updated_at")]
        public DateTime LastUpdate { get; set; }
    }
}
