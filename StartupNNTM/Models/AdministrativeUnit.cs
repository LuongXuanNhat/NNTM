using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartupNNTM.Models
{
    [Table("AdministrativeUnit")]
    public class AdministrativeUnit
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string FullNameEn { get; set; }
        public string ShortName { get; set; }
        public string ShortNameEn { get; set; }
        public string CodeName { get; set; }
        public string CodeNameEn { get; set; }

        public ICollection<Province> Province { get; set; }
        public ICollection<District> Districts { get; set; }
        public ICollection<Ward> Wards { get; set; }
    }
}
