using Newtonsoft.Json;
using System;
namespace GameTime.Core.NHL
{
    public class Game
    {
        [JsonProperty("game_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Date { get; set; }

        [JsonProperty("game_type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("tba", NullValueHandling = NullValueHandling.Ignore)]
        public bool Tba { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("event_status", NullValueHandling = NullValueHandling.Ignore)]
        public string EventStatus { get; set; }

        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime LastUpdate { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("away_team", NullValueHandling = NullValueHandling.Ignore)]
        public Team AwayTeam { get; set; }

        [JsonProperty("home_team", NullValueHandling = NullValueHandling.Ignore)]
        public Team HomeTeam { get; set; }

        [JsonProperty("top_match", NullValueHandling = NullValueHandling.Ignore)]
        public TopMatch TopMatch { get; set; }

        [JsonProperty("league", NullValueHandling = NullValueHandling.Ignore)]
        public League League { get; set; }

        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public string Location { get; set; }

        [JsonProperty("stadium", NullValueHandling = NullValueHandling.Ignore)]
        public string Stadium { get; set; }

        [JsonProperty("total_periods", NullValueHandling = NullValueHandling.Ignore)]
        public string Periods { get; set; }

        [JsonProperty("box_score", NullValueHandling = NullValueHandling.Ignore)]
        public BoxScore BoxScore { get; set; }

        private int StringToId(string team)
        {
            string[] splits = team.Split('/');
            int id = int.Parse(splits[splits.Length - 1]);
            return id;
        }
        private Team MatchTeam(int id)
        {
            return id == HomeTeam.Id ? HomeTeam : AwayTeam;
        }
        private Team MatchTeam(string team)
        {
            int id = StringToId(team);
            return MatchTeam(id);
        }
        public Team GetWinningTeam()
        {
            if (BoxScore.Score.IsTie)
                return null;
            else
                return MatchTeam(BoxScore.Score.WinningTeam);
        }
        public Team GetLosingTeam()
        {
            if (BoxScore.Score.IsTie)
                return null;
            else
                return MatchTeam(BoxScore.Score.LosingTeam);
        }
        public override string ToString()
        {
            return string.Format("{0} vs {1}", AwayTeam, HomeTeam);
        }
    }
}
