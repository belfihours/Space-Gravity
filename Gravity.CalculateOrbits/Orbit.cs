using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Gravity.CalculateOrbits
{
    public class Orbit
    {
        public (double X,double Y) Zero;
        public List<Particel> Particels { get; set; } = new();

        #region Inizialize
        public Orbit(int x, int y)
        {
            Zero.X = x;
            Zero.Y = y;
            Zero.X = 0;
            Zero.Y = 0;
            Particels.Add(new Particel()
            {
                Name = "Sun",
                Mass = 1.98847e30,
                Color = Color.Yellow,
                Pos = (Zero.X,Zero.Y),
                Speed= (0,0),
                Size=6
            });
            Particels.Add(new Particel()
            {
                Name = "Mercury",
                Mass = 3.3010e23,
                Color = Color.Purple,
                Pos = (Zero.X + 4.755e10, Zero.Y),
                Speed = (0, -47360),
                Size = 2
            });
            Particels.Add(new Particel()
            {
                Name = "Venus",
                Mass = 4.867e24,
                Color = Color.Blue,
                Pos = (Zero.X + 1.080e11, Zero.Y),
                Speed = (0, -35020),
                Size = 2
            });
            Particels.Add(new Particel()
            {
                Name = "Earth",
                Mass = 5.972e24,
                Color = Color.Green,
                Pos = (Zero.X + 1.521e11, Zero.Y),
                Speed = (0, -29780),
                Size = 3
            });
            Particels.Add(new Particel()
            {
                Name = "Moon",
                Mass = 0.07346e24,
                Color = Color.Gray,
                Pos = (Zero.X + 1.521e11+ 384e6, Zero.Y),
                Speed = (0, -29780 - 1022),
                Size = 2
            });
            Particels.Add(new Particel()
            {
                Name = "Mars",
                Mass = 6.39e23,
                Color = Color.Red,
                Pos = (Zero.X + 2.270e11, Zero.Y),
                Speed = (0, -24080),
                Size = 4
            });
            Particels.Add(new Particel()
            {
                Name = "Jupiter",
                Mass = 1.898e27,
                Color = Color.Orange,
                Pos = (Zero.X + 7.788e11, Zero.Y),
                Speed = (0, -13060),
                Size = 5
            });
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

        #endregion

    }
}
