using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
namespace GameTime.Core.NHL
{
    public class Team
    {
        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("acroynm")]
        public string Acroynm { get; set; }

        [JsonProperty("conference")]
        public string Conference { get; set; }

        [JsonProperty("divison")]
        public string Division { get; set; }

        [JsonProperty("updated_at")]
        public DateTime LastUpdate { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("injuries")]
        public bool HasInjuredPlayers { get; set; }

        [JsonProperty("logos")]
        public LogoUrls Logo { get; set; }

        public override string ToString()
        {
            return Abbreviation;
        }
    }
}
