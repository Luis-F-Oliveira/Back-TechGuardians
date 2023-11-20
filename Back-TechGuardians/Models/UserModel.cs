using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Back_TechGuardians.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
