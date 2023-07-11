using Microsoft.EntityFrameworkCore;
using SoccerManagement.Models.Enities.BasesEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerManagement.Models.Enities
{
    public class Player : EntityWithDates<int>
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime? DateUpdate { get; set; }
        [ForeignKey("IdWhoChange")]        
        public int? IdWhoChange { get; set; }
        public virtual User WhoChange { get; set; }

        public string Name { get; set; }        
        public string Surname { get; set; } //Apelido
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public ICollection<Game> Games{ get; set; }
        
        [ForeignKey("IdUser")]
        public int? IdUser { get; set; }
        public User User { get; set; }
    }
}
