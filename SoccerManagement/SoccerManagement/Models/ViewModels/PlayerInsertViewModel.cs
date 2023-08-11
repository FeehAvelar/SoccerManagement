using System.ComponentModel.DataAnnotations.Schema;

namespace SoccerManagement.Models.ViewModels
{    
    public class PlayerInsertViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public UserInsertViewModel User { get; set; }
    }
}
