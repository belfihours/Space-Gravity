using System.Drawing;
using System.Numerics;

namespace Gravity.CalculateOrbits
{
    public class Particel
    {
        public string? Name { get; set; }
        public double Mass { get; set; }
        public Color Color { get; set; }
        public int Size { get; set; }
        //
        public (double X,double Y) Pos { get; set; }
        public (double X,double Y) Speed { get; set; }
        public List<(double X,double Y)> Accs { get; set; } = new();
        public (double X,double Y) AccSum => (Accs.Sum(x => x.X), Accs.Sum(y => y.Y));
        public void SetAcc(double G, double m2, (double X,double Y) pos2)
        {
            var r = Math.Sqrt((Math.Pow((pos2.X - this.Pos.X), 2)) + (Math.Pow((pos2.Y - this.Pos.Y), 2)));
            var accX = ((G * m2)*(pos2.X - this.Pos.X)) / Math.Pow(r, 3);
            var accY = ((G * m2)*(pos2.Y - this.Pos.Y)) /Math.Pow(r, 3);
            Accs.Add((accX, accY));
        }
        public void ChangePos(int t, List<Particel> particels, double G)
        {
            //change pos
            double posX=this.Pos.X+(this.Speed.X*t)+((0.5)*(this.AccSum.X*Math.Pow(t,2)));
            double posY=this.Pos.Y+(this.Speed.Y*t)+((0.5)*(this.AccSum.Y*Math.Pow(t,2)));
            this.Pos=(posX, posY);
            //change vel
            double velX =this.Speed.X+this.AccSum.X*t;
            double velY =this.Speed.Y+this.AccSum.Y*t;
            this.Speed=(velX, velY);
            Accs.Clear();
            //update Accs
            foreach (Particel particel in particels)
            {
                if (particel.Name != this.Name)
                {
                    this.SetAcc(G, particel.Mass, particel.Pos);
                }
            }
            
        }
    }

}