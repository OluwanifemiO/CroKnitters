namespace CroKnitters.Entities
{
    public class GroupUser
    {
        public int GroupUserId { get; set; }

        public int UserId { get; set; }

        public string Role { get; set; } = "Member";

        public int GroupId { get; set; }

        public User User { get; set; } = null!;

        public Group Group { get; set; } = null!;
    }
}
