using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace GameTime.Core.NHL
{
    [JsonObject("score")]
    public class GameScore
    {
        [JsonProperty("home")]
        public TeamScore Home { get; set; }

        [JsonProperty("away")]
        public TeamScore Away { get; set; }

        [JsonProperty("winning_team")]
        public string WinningTeam { get; set; }

        [JsonProperty("losing_team")]
        public string LosingTeam { get; set; }

        [JsonProperty("tie_game")]
        public bool IsTie { get; set; }
    }
}
