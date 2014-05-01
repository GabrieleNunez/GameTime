using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
namespace GameTime.Core.NHL
{
    public class TeamScore
    {
        [JsonProperty("score", NullValueHandling = NullValueHandling.Ignore)]
        public int Score { get; set; }
    }
}
