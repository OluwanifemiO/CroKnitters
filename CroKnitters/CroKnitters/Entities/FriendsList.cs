namespace CroKnitters.Entities
{
    public class FriendsList
    {
        public int ListId { get; set; }

        public int UserId { get; set; }

        public int FriendId { get; set; }

        public User User { get; set; } = null!;

        public User Friend { get; set; } = null!;
    }
}
