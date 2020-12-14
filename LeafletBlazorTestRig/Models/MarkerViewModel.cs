namespace LeafletBlazorTestRig.Models
{
    public class MarkerViewModel
    {
        public bool Keyboard { get; set; } = true;
        public string Title { get; set; }
        public string Alt { get; set; }
        public int ZIndexOffset { get; set; }
        public double Opacity { get; set; } = 1.0f;
        public bool RiseOnHover { get; set; }
        public int RiseOffset { get; set; } = 250;
    }
}
