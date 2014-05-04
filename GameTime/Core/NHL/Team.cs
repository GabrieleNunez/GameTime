using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
namespace GameTime.Core.NHL
{
    public class Team
    {
        [JsonProperty("abbreviation", NullValueHandling = NullValueHandling.Ignore)]
        public string Abbreviation { get; set; }

        [JsonProperty("full_name", NullValueHandling = NullValueHandling.Ignore)]
        public string FullName { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public string Location { get; set; }

        [JsonProperty("acroynm", NullValueHandling = NullValueHandling.Ignore)]
        public string Acroynm { get; set; }

        [JsonProperty("conference", NullValueHandling = NullValueHandling.Ignore)]
        public string Conference { get; set; }

        [JsonProperty("divison", NullValueHandling = NullValueHandling.Ignore)]
        public string Division { get; set; }

        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime LastUpdate { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("injuries", NullValueHandling = NullValueHandling.Ignore)]
        public bool HasInjuredPlayers { get; set; }

        [JsonProperty("logos", NullValueHandling = NullValueHandling.Ignore)]
        public LogoUrls Logo { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
