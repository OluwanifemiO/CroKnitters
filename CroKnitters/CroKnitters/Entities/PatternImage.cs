namespace CroKnitters.Entities
{
    public class PatternImage
    {
        public int PatImId { get; set; }

        public int PatternId { get; set; }

        public int ImageId { get; set; }

        public Pattern Pattern { get; set; } = null!;

        public Image Image { get; set; } = null!;
    }
}
