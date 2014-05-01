using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
namespace GameTime.Core.NHL
{
    [JsonObject("box_score")]
    public class BoxScore
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime LastUpdate { get; set; }

        [JsonProperty("away_strength", NullValueHandling = NullValueHandling.Ignore)]
        public int AwayStrength { get; set; }

        [JsonProperty("away_strength_type", NullValueHandling = NullValueHandling.Ignore)]
        public string AwayStrengthType { get; set; }

        [JsonProperty("home_strength", NullValueHandling = NullValueHandling.Ignore)]
        public int HomeStrength { get; set; }

        [JsonProperty("home_strength_type", NullValueHandling = NullValueHandling.Ignore)]
        public int HomeStrengthType { get; set; }

        [JsonProperty("team_on_power_play", NullValueHandling = NullValueHandling.Ignore)]
        public string PowerPlayTeam { get; set; }

        [JsonProperty("progress", NullValueHandling = NullValueHandling.Ignore)]
        public GameProgress Progress { get; set; }

        [JsonProperty("score", NullValueHandling = NullValueHandling.Ignore)]
        public GameScore Score { get; set; }

    }
}
