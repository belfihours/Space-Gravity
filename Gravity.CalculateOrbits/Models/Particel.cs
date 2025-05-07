using System.Drawing;

namespace Gravity.CalculateOrbits.Models
{
    public class Particel
    {
        public string Name { get; set; } = string.Empty;
        public int Size { get; set; }
        public double Mass { get; set; }
        public Color Color { get; set; }
        public Coordinate Pos { get; set; } = new();
        public Coordinate Speed { get; set; } = new();
        public List<Coordinate> Accelerations { get; set; } = new();
        public Coordinate TotalAcceleration => new(Accelerations.Sum(x => x.X), Accelerations.Sum(y => y.Y));

        public Particel(string name, int size, double mass, Color color, Coordinate pos, Coordinate speed)
        {
            Name = name;
            Size = size;
            Mass = mass;
            Color = color;
            Pos = pos;
            Speed = speed;
        }


        public void UpdateParticel(int t, List<Particel> particels)
        {
            // change position
            double posX = GetPosition(Pos.X, Speed.X, TotalAcceleration.X, t);
            double posY = GetPosition(Pos.Y, Speed.Y, TotalAcceleration.Y, t);
            Pos.Update(posX, posY);

            // change speed
            double speedX = GetSpeed(Speed.X, TotalAcceleration.X, t);
            double speedY = GetSpeed(Speed.Y, TotalAcceleration.Y, t);
            Speed.Update(speedX, speedY);

            // update accelerations
            Accelerations.Clear();
            foreach (Particel particel in particels)
            {
                if (particel.Name != Name)
                {
                    SetAcceleration(particel.Mass, particel.Pos);
                }
            }

        }

        private void SetAcceleration(double m2, Coordinate pos2)
        {
            var distance = GetDistance(Pos, pos2);
            var accX = GetAcceleration(Pos.X, pos2.X, m2, distance);
            var accY = GetAcceleration(Pos.Y, pos2.Y, m2, distance);
            Accelerations.Add(new(accX, accY));
        }

        private static double GetSpeed(double initialSpeed, double acceleration, int t)
        {
            return initialSpeed + acceleration * t;
        }

        private static double GetPosition(double initialPosition, double initialSpeed, double acceleration, int t)
        {
            return initialPosition + initialSpeed * t + 0.5 * (acceleration * Math.Pow(t, 2));
        }

        private static double GetAcceleration(double pos1, double pos2, double m2, double r)
        {
            return Constants.G * m2 * (pos2 - pos1) / Math.Pow(r, 3);
        }

        private static double GetDistance(Coordinate pos1, Coordinate pos2)
        {
            return Math.Sqrt(Math.Pow(pos2.X - pos1.X, 2) + Math.Pow(pos2.Y - pos1.Y, 2));
        }
    }

}