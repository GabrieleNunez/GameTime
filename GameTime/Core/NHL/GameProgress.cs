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
        [JsonProperty("clock_label", NullValueHandling = NullValueHandling.Ignore)]
        public string ClockLabel { get; set; }

        [JsonProperty("string", NullValueHandling = NullValueHandling.Ignore)]
        public string String { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("event_status", NullValueHandling = NullValueHandling.Ignore)]
        public string EventStatus { get; set; }

        [JsonProperty("segment",NullValueHandling= NullValueHandling.Ignore)]
        public int Segment { get; set; }

        [JsonProperty("segment_string", NullValueHandling = NullValueHandling.Ignore)]
        public string SegmentString { get; set; }

        [JsonProperty("segment_description", NullValueHandling = NullValueHandling.Ignore)]
        public string SegmentDescription { get; set; }

        [JsonProperty("clock", NullValueHandling = NullValueHandling.Ignore)]
        public string Clock { get; set; }

        [JsonProperty("overtime", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsOvertime { get; set; }
    }
}
