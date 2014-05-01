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
        [JsonProperty("home", NullValueHandling = NullValueHandling.Ignore)]
        public TeamScore Home { get; set; }

        [JsonProperty("away", NullValueHandling = NullValueHandling.Ignore)]
        public TeamScore Away { get; set; }

        [JsonProperty("winning_team", NullValueHandling = NullValueHandling.Ignore)]
        public string WinningTeam { get; set; }

        [JsonProperty("losing_team", NullValueHandling = NullValueHandling.Ignore)]
        public string LosingTeam { get; set; }

        [JsonProperty("tie_game", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsTie { get; set; }
    }
}
