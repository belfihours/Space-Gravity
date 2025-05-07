using System.Drawing;

namespace Gravity.CalculateOrbits.Models
{
    public class Orbit
    {
        public Coordinate Center = new();
        public List<Particel> Particels { get; private set; } = new();



        public Orbit(int x, int y)
        {
            Center.Update(x, y);
            Particels.Add(new Particel
            (
                "Sun",
                6,
                1.98847e30,
                Color.Yellow,
                new(Center.X, Center.Y),
                new(0, 0)
            ));
            Particels.Add(new Particel
            (
                "Mercury",
                2,
                3.3010e23,
                Color.Purple,
                new(Center.X + 4.755e10, Center.Y),
                new(0, -47360)
            ));
            Particels.Add(new Particel
            (
                "Venus",
                2,
                4.867e24,
                Color.Blue,
                new(Center.X + 1.080e11, Center.Y),
                new(0, -35020)
            ));
            Particels.Add(new Particel
            (
                "Earth",
                3,
                5.972e24,
                Color.Green,
                new(Center.X + 1.521e11, Center.Y),
                new(0, -29780)
            ));
            Particels.Add(new Particel
            (
                "Moon",
                2,
                0.07346e24,
                Color.Gray,
                new(Center.X + 1.521e11 + 384e6, Center.Y),
                new(0, -29780 - 1022)
            ));
            Particels.Add(new Particel
            (
                "Mars",
                4,
                6.39e23,
                Color.Red,
                new(Center.X + 2.270e11, Center.Y),
                new(0, -24080)
            ));
            Particels.Add(new Particel
            (
                "Jupiter",
                5,
                1.898e27,
                Color.Orange,
                new(Center.X + 7.788e11, Center.Y),
                new(0, -13060)
            ));


            //Particels.Add(new Particel()
            //{
            //    Name = "ASTEROIDE",
            //    Mass = 3.989e30,
            //    Color = Color.White,
            //    Pos = (_zero.X - 7.788e11, _zero.Y - 7.788e11),
            //    Speed = (13000, 13720)
            //});
            //Particels.Add(new Particel()
            //{
            //    Name = "ASTEROIDE2",
            //    Mass = 3.989e30,
            //    Color = Color.White,
            //    Pos = (_zero.X +7.788e11, _zero.Y - 7.788e11),
            //    Speed = (-13000, 13720)
            //});
            //Particels.Add(new Particel()
            //{
            //    Name = "ASTEROIDE",
            //    Mass = 3.989e30,
            //    Color = Color.White,
            //    Pos = (_zero.X - 7.788e11, _zero.Y - 7.788e11),
            //    Speed = (0,0)
            //});
            //Particels.Add(new Particel()
            //{
            //    Name = "ASTEROIDE2",
            //    Mass = 3.989e30,
            //    Color = Color.White,
            //    Pos = (_zero.X + 7.788e11, _zero.Y - 7.788e11),
            //    Speed = (0,0)
            //});
        }


    }
}
