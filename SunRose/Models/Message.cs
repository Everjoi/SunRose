using System.Reflection.Metadata.Ecma335;

namespace SunRose.Models
{
    public class Message
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Text { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
