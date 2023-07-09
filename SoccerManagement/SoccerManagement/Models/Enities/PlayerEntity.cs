using SoccerManagement.Models.Enities.BasesEntities;

namespace SoccerManagement.Models.Enities
{
    public sealed class PlayerEntity : EntityWithDates<int>
    {
        public string Name { get; set; }        
        public string Surname { get; set; } //Apelido
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public UsuarioEntity Usuario { get; set; }
    }

    public class UsuarioEntity : EntityWithOwner<int>
    {
        public string Username { get; set; }
        public string Passworld { get; set; }
    }
}
