using System.Text.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace NtaraCode.Models
{
    #region Model Class
    public class Team
    {
        #region Properties
        [Key]
        [JsonPropertyName("Team")]
        public string Name  { get; set; }
        [JsonPropertyName("Games\r")]
        public int Games { get; set; }
        public int Rank { get; set; }
        [JsonPropertyName("Date of Last Win")]
        public string LastWin { get; set; }
        [JsonPropertyName("Winning Percetnage")]
        public decimal WinPercentage { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }
        public string Mascot { get; set; }
        #endregion

        #region Override ToString Method
        public override string ToString() 
            => JsonSerializer.Serialize<Team>(this);
        #endregion
    }
    #endregion
}
