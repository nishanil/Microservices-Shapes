namespace Circles.Models
{
    public class Circle
    {
        public long Id { get; set; }
        public int Radius { get; set; }
        public string StrokeColor { get; set; }
        public string FillColor { get; set; }
        public int LineWidth { get; set; }
    }
}