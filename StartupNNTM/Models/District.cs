using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartupNNTM.Models
{


    [Table("DisTrict")]
    public class District
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string FullName { get; set; }
        public string FullNameEn { get; set; }
        public string CodeName { get; set; }

        public int AdministrativeUnitId { get; set; }
        public AdministrativeUnit AdministrativeUnit { get; set; }

        public int ProvinceId { get; set; }
        public Province Province { get; set; }

        public ICollection<Ward> Wards { get; set; }
        public ICollection<Address> Addresses { get; set; }

    }
}
