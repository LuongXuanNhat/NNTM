using StartupNNTM.Models;

public class Address
{   
    public Guid Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Ward { get; set; }

    public ICollection<Post> Post { get; set; }

}

