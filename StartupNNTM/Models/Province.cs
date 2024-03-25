using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace StartupNNTM.Models
{

    [Table("Province")]
    public class Province
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
        public int AdministrativeRegionId { get; set; }
        public AdministrativeRegion AdministrativeRegion { get; set; }

        public ICollection<District> Districts { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
