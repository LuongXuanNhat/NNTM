using StartupNNTM.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

[Table("Address")]
public class Address
{
    [Key]   
    public Guid Id { get; set; }
    public int ProvinceId { get; set; }
    public int DistrictId { get; set; }
    public int WardId { get; set; }
    public string Detail { get; set; }

    [JsonIgnore]
    public ICollection<Post> Post { get; set; }
    public Province Province { get; set; }
    public District District { get; set; }
    public Ward Ward { get; set; }

}

