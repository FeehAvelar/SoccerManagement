namespace SoccerManagement.Models.Enities.BasesEntities
{
    public class EntityWithOwner<IdType> : EntityWithDates<IdType>
    {
        public int FkOwner { get; set; }

    }
}
