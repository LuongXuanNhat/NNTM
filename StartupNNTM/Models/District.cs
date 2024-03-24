using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartupNNTM.Models
{


    [Table("DisTrict")]
    public class District
    {
        [Key]
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string FullName { get; set; }
        public string FullNameEn { get; set; }
        public string CodeName { get; set; }
        public string ProvinceCode { get; set; }
        public int AdministrativeUnitId { get; set; }
        public AdministrativeUnit AdministrativeUnit { get; set; }
    }
}
