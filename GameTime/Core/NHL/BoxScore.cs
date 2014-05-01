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
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("updated_at")]
        public DateTime LastUpdate { get; set; }

        [JsonProperty("away_strength")]
        public int AwayStrength { get; set; }

        [JsonProperty("away_strength_type")]
        public string AwayStrengthType { get; set; }

        [JsonProperty("home_strength")]
        public int HomeStrength { get; set; }

        [JsonProperty("home_strength_type")]
        public int HomeStrengthType { get; set; }

        [JsonProperty("team_on_power_play")]
        public string PowerPlayTeam { get; set; }

        [JsonProperty("progress")]
        public GameProgress Progress { get; set; }

        [JsonProperty("score")]
        public GameScore Score { get; set; }

    }
}
