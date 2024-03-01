namespace CroKnitters.Entities
{
    public class ProjectImage
    {
        public int ProImId { get; set; }

        public int ProjectId { get; set; }

        public int ImageId { get; set; }

        public Project Project { get; set; } = null!;

        public Image Image { get; set; } = null!;

    }
}
