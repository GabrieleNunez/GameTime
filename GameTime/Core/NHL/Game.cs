using Newtonsoft.Json;
using System;
namespace GameTime.Core.NHL
{
    /// <summary>
    /// Represents a game of NHL Hockey
    /// </summary>
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

        /// <summary>
        /// Converts a string to an id
        /// </summary>
        /// <param name="team">The team resource url</param>
        /// <returns>The id of the team</returns>
        private int StringToId(string team)
        {
            string[] splits = team.Split('/');
            int id = int.Parse(splits[splits.Length - 1]);
            return id;
        }
        /// <summary>
        /// Matches the team thats playing in the game to the specified id
        /// </summary>
        /// <param name="id">ID of the team we want to check for</param>
        /// <returns>The matching team</returns>
        private Team MatchTeam(int id)
        {
            return id == HomeTeam.Id ? HomeTeam : AwayTeam;
        }
        /// <summary>
        /// Matches the team from the provided string
        /// </summary>
        /// <param name="team">The name of the team</param>
        /// <returns>The matching team</returns>
        private Team MatchTeam(string team)
        {
            int id = StringToId(team);
            return MatchTeam(id);
        }
        /// <summary>
        /// Gets the team that is winning
        /// </summary>
        /// <returns>The winning team</returns>
        public Team GetWinningTeam()
        {
            if (BoxScore.Score.IsTie)
                return null;
            else
                return MatchTeam(BoxScore.Score.WinningTeam);
        }
        /// <summary>
        /// Gets the team that is losing
        /// </summary>
        /// <returns>The losing team</returns>
        public Team GetLosingTeam()
        {
            if (BoxScore.Score.IsTie)
                return null;
            else
                return MatchTeam(BoxScore.Score.LosingTeam);
        }
        /// <summary>
        /// A formatted string that represents the game
        /// </summary>
        /// <returns> (Away Team) vs (Home Team)</returns>
        public override string ToString()
        {
            return string.Format("{0} vs {1}", AwayTeam, HomeTeam);
        }
    }
}
