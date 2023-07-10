using System.ComponentModel.DataAnnotations;

namespace SoccerManagement.Models.Enities.BasesEntities
{
    public interface EntityId<IdType>        
    {
        public IdType Id { get; set; }
    }
}
