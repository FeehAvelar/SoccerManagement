using SoccerManagement.Models.Enities.BasesEntities;
using SoccerManagement.Models.Enums;

namespace SoccerManagement.Models.Enities
{
    public class Financial : EntityWithOwner<int>
    {
        public int IdOwner { get; set; }
        public Player Owner { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int IdWhoChange { get; set; }
        public Player WhoChange { get; set; }
        public int Id { get; set; }

        public int IdOrigin { get; set; }
        public OriginFinance FinanceOrigin { get; set; }
        public TypeFinance TypeFinance { get; set; }
        public decimal Value { get; set; }
        public DateTime DatePayment { get; set; }
    }
}
