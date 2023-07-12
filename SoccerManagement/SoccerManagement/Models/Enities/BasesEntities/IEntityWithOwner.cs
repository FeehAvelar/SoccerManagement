using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerManagement.Models.Enities.BasesEntities
{
    public interface IEntityWithOwner<IdType> : IEntityWithDates<IdType>
    {        
        public int IdCreator { get; set; }
        
        public Player Creator { get; set; }        
    }    
}
