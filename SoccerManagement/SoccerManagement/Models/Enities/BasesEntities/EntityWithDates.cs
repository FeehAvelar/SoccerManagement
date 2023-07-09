namespace SoccerManagement.Models.Enities.BasesEntities
{
    public abstract class EntityWithDates<IdType> : EntityId<IdType>
    {
        public DateTime DateAdd { get; set; }
        public DateTime DateUpdate { get; set; }
        public int WhoChange { get; set; }
    }
}
