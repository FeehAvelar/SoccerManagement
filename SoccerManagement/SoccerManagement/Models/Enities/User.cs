using SoccerManagement.Models.Enities.BasesEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerManagement.Models.Enities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime? DateUpdate { get; set; }        
        public int? IdWhoChange { get; set; }        
        public string Username { get; set; }
        public string Password { get; set; }

        public int IdPlayer { get; set; }
        [NotMapped]
        public Player Player { get; set; }
        public byte[] SaltKey { get; set; }
    }
}
