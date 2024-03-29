using StartupNNTM.Models;

public class PostView
{
    public string Id { get; set; }
    public string Title { get; set; }
    public AddressView Address { get; set; }
    public string Price { get; set; }
    public string Content { get; set; }
    public string TypeId { get; set; } // = "C63BAB67-1B5A-4AC2-82A2-3333844543CF";
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string UserId { get; set; } // = "10760574-9806-4c70-e1c5-08dc4c8baad5";
    public ICollection<ImageVm> Images { get; set; }
}
