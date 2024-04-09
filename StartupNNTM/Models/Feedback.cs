using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartupNNTM.Models
{

    [Table("Feedback")]
    public class Feedback
    {
        [Key]
        public Guid Id { get; set; }


        public string content { get; set; }

        public Guid TopicFeedbackId { get; set; }

        public Guid TypeFeedbackId { get; set; }

        public Guid UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public TopicFeedback TopicFeedback { get; set; }
        public TypeFeedback TypeFeedback { get; set; }

    }
}
