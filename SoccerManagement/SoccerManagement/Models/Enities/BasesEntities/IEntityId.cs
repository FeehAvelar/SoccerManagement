using System.ComponentModel.DataAnnotations;

namespace SoccerManagement.Models.Enities.BasesEntities
{
    public interface IEntityId<IdType>        
    {
        public IdType Id { get; set; }
    }
}
