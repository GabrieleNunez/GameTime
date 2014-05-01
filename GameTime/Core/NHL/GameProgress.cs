using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
namespace GameTime.Core.NHL
{
    [JsonObject("progress")]
    public class GameProgress
    {
        [JsonProperty("clock_label")]
        public string ClockLabel { get; set; }

        [JsonProperty("string")]
        public string String { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("event_status")]
        public string EventStatus { get; set; }

        [JsonProperty("segment")]
        public int Segment { get; set; }

        [JsonProperty("segment_string")]
        public string SegmentString { get; set; }

        [JsonProperty("segment_description")]
        public string SegmentDescription { get; set; }

        [JsonProperty("clock")]
        public string Clock { get; set; }

        [JsonProperty("overtime")]
        public bool IsOvertime { get; set; }
    }
}
