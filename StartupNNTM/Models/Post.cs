using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartupNNTM.Models
{
    [Table("Post")]
    public class Post
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Acreage { get; set; }
        public string Content { get; set; }
        public Guid TypeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UserId { get; set; }
        public bool IsActivate { get; set; }

        public ICollection<Chat> Chat { get; set; }
        public Type Type { get; set; }
    }
}
