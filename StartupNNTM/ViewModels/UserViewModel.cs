using StartupNNTM.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StartupNNTM.ViewModels
{
    public class UserViewModel
    {
        [StringLength(200)]
        public string Fullname { get; set; } = string.Empty;
        public virtual string UserName { get; set; } = string.Empty;
        [Column(TypeName = "datetime")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }
        [StringLength(50)]
        public Gender Gender { get; set; }

        public AddressView Address { get; set; }
        public virtual string Email { get; set; } = string.Empty;
        public virtual string PhoneNumber { get; set; } = string.Empty;
    }
}
