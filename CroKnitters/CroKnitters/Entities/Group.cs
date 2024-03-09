namespace CroKnitters.Entities
{
    public class Group
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime CreationDate { get; set; }

        public ICollection<GroupUser> GroupUsers { get; set; } = new List<GroupUser>();

        public ICollection<GroupChat> GroupChats { get; set; } = new List<GroupChat>();
    }
}
