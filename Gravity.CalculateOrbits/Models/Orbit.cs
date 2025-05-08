using System.Drawing;

namespace Gravity.CalculateOrbits.Models
{
    public class Orbit
    {
        public Coordinate Center = new();
        public List<Particel> Particels { get; private set; } = new();

        public Orbit() { }

        public Orbit(IEnumerable<Particel> particels)
        {
            Particels = particels.ToList();
        }

        public void AddParticel(Particel particel)
        {
            Particels.Add(particel);
        }
    }
}
