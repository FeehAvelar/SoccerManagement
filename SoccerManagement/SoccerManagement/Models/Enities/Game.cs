using SoccerManagement.Models.Enities.BasesEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerManagement.Models.Enities
{
    public class Game : IEntityWithOwner<int>
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime? DateUpdate { get; set; }
        [ForeignKey("IdWhoChange")]
        public int? IdWhoChange { get; set; }
        public virtual User WhoChange { get; set; }
        [ForeignKey("IdOwner")]
        public int IdCreator { get; set; }
        public virtual Player Creator { get; set; }

        public decimal DayAmount { get; set; }
        public DateTime GameDate { get; set; }
        public ICollection<Player> Players { get; set; } = new List<Player>();
    }
}
