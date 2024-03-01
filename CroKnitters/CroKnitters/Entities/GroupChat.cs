namespace CroKnitters.Entities
{
    public class GroupChat
    {
        public int GChatId { get; set; }

        public int? MessageId { get; set; }

        public int? GroupId { get; set; }

        public Message? Message { get; set; } = null!;

        public Group? Group { get; set; } = null!;
    }
}
