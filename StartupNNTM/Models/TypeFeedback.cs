using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartupNNTM.Models
{

    [Table("TypeFeedback")]
    public class TypeFeedback
    {
        [Key]
        public Guid Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Feedback> Feedback { get; set; }

    }
}
