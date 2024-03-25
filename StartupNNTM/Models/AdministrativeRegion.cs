using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartupNNTM.Models
{
    [Table("AdministrativeRegion")]
    public class AdministrativeRegion
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string CodeName { get; set; }
        public string CodeNameEn { get; set; }

        public ICollection<Province> Province { get; set; }
    }
}
