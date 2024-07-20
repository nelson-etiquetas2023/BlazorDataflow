using System.ComponentModel.DataAnnotations;

namespace Dataflow.Shared.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string UserType { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Departament { get; set; } = null!;
        public bool Active { get; set; }
    }
}
