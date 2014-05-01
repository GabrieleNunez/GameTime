using Newtonsoft.Json;
using System;
namespace GameTime.Core.NHL
{
    public class Game
    {
        [JsonProperty("game_date")]
        public DateTime Date { get; set; }

        [JsonProperty("game_type")]
        public string Type { get; set; }

        [JsonProperty("tba")]
        public bool Tba { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("event_status")]
        public string EventStatus { get; set; }

        [JsonProperty("updated_at")]
        public DateTime LastUpdate { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("away_team")]
        public Team AwayTeam { get; set; }

        [JsonProperty("home_team")]
        public Team HomeTeam { get; set; }

        [JsonProperty("top_match")]
        public TopMatch TopMatch { get; set; }

        [JsonProperty("league")]
        public League League { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("stadium")]
        public string Stadium { get; set; }

        [JsonProperty("total_periods")]
        public string Periods { get; set; }

        [JsonProperty("box_score")]
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
            return string.Format("{0} vs {1}", HomeTeam, AwayTeam);
        }
    }
}
