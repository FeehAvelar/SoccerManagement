using SoccerManagement.Models.Enities.BasesEntities;
using SoccerManagement.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerManagement.Models.Enities
{
    public class Financial : IEntityWithOwner<int>
    {
        public int IdCreator { get; set; }
        public Player Creator { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime? DateUpdate { get; set; }
        [ForeignKey("IdWhoChange")]
        public int? IdWhoChange { get; set; }
        public virtual User WhoChange { get; set; }
        public int Id { get; set; }

        public int IdOrigin { get; set; }
        public OriginFinance FinanceOrigin { get; set; }
        public TypeFinance TypeFinance { get; set; }
        public decimal Value { get; set; }
        public DateTime? DatePayment { get; set; }
        public int IdAccountable { get; set; }
        public Player Accountable { get; set; }
    }
}
