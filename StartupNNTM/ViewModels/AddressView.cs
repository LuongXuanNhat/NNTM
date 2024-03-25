using StartupNNTM.Models;

public class AddressView
{
    public Guid Id { get; set; }
    public int ProvinceId { get; set; }
    public string ProvinceName { get; set; }
    public int DistrictId { get; set; }
    public string DistrictName { get; set; }
    public int WardId { get; set; }
    public string WardName { get; set; }
    public string Detail { get; set; }

}