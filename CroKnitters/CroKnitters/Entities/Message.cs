namespace CroKnitters.Entities
{
    public class Message
    {
        public int MessageId { get; set; }

        public string Content { get; set; } = null!;

        public int SenderId { get; set; } 

        public DateTime CreationDate { get; set; }

        public ICollection<GroupChat> GroupChats { get; set; } = new List<GroupChat>();

        public ICollection<PrivateChat> PrivateChats { get; set; } = new List<PrivateChat>();

        public User Sender { get; set; } = null!;
    }
}
