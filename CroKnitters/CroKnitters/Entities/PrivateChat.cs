namespace CroKnitters.Entities
{
    public class PrivateChat
    {
        public int PChatId { get; set; }

        public int SenderId { get; set; }

        public int RecieverId { get; set; }

        public int MessageId { get; set; }

        public DateTime CreationDate { get; set; }

        public Message Message { get; set; } = null!;

        public User Reciever { get; set; } = null!;

        public User Sender { get; set; } = null!;
    }
}
