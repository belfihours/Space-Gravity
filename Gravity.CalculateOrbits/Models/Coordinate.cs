namespace Gravity.CalculateOrbits.Models
{
    public class Coordinate
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Coordinate()
        {
            X = 0;
            Y = 0;
        }
        
        public Coordinate(double x, double y)
        {
            X = x;
            Y = y;
        }

        public void Update(double x, double y) 
        {
            X = x;
            Y = y;
        }
    }
}
