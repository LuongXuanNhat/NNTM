using Microsoft.AspNetCore.Identity;
using StartupNNTM.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartupNNTM.Models
{
    [Table("User")]
    public class User : IdentityUser<Guid>
    {
        public string Fullname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Status { get; set; }
        public Gender Gender { get; set; }

        public string Introduction { get; set; }

        public string PhoneNumber { get; set; }
        public string Image { get; set; } = string.Empty;

        public Guid AddressId { get; set; }
        public ICollection<Message> Message { get; set; }
        public ICollection<Post> Post { get;}
        public Address Address { get; set; }

    }
}
