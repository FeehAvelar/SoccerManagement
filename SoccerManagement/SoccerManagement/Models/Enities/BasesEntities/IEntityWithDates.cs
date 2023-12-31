﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerManagement.Models.Enities.BasesEntities
{
    public interface IEntityWithDates<IdType> : IEntityId<IdType>
    {
        public DateTime DateAdd { get; set; }
        public DateTime? DateUpdate { get; set; }        
        public int? IdWhoChange { get; set; }
        public User WhoChange { get; set; }
    }
}
