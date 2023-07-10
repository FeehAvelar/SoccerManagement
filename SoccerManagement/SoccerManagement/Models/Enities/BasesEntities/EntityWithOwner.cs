using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerManagement.Models.Enities.BasesEntities
{
    public interface EntityWithOwner<IdType> : EntityWithDates<IdType>
    {        
        public int IdOwner { get; set; }
        
        public Player Owner { get; set; }        
    }    
}
