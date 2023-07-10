using SoccerManagement.Models.Enities.BasesEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerManagement.Models.Enities
{
    public class User : EntityWithDates<int>
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime? DateUpdate { get; set; }
        [ForeignKey("IdWhoChange")]
        public int IdWhoChange { get; set; }
        public virtual Player WhoChange { get; set; }

        public string Username { get; set; }
        public string Passworld { get; set; }
        [ForeignKey("idPlayer")]
        public int PlayerId { get; set; }
        [NotMapped]
        public Player Player { get; set; }


        
    }
}
