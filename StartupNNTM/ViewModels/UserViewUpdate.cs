using StartupNNTM.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StartupNNTM.ViewModels
{
    public class UserViewUpdate
    {
        [StringLength(100)]
        public string Fullname { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public AddressVm AddressVm { get; set; }
        public Gender Gender { get; set; }
        public virtual string Email { get; set; } = string.Empty;
        public virtual string PhoneNumber { get; set; } = string.Empty;
    }
}
