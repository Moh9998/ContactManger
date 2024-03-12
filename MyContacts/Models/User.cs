using Microsoft.AspNetCore.Identity;

namespace MyContacts.Models
{
    public class User 
    {
        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string UserName { get; set; } = null!;
        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; } = null!;

    }
}
