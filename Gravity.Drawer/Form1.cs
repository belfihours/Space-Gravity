using Gravity.CalculateOrbits;

namespace Gravity.Drawer
{
    public partial class Form1 : Form
    {
        int time;
        Orbit _orbit = new(0, 0);
        double G;
        List<Particel> _parts = new();
        double _scale = 2e12;
        bool exit = false;

        //record per ricordare la storia
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            time = 1600;
            this.BackColor = Color.Black;
            _orbit = new(0, 0);
            G = 6.67e-11;
        }
        private void ScaleAndDraw(object sender, EventArgs e, Particel part)
        {
            try
            {
                var scaledCoordinates = Scale(part.Pos.X, part.Pos.Y, _scale);
                Draw_Point(sender, new PaintEventArgs(this.CreateGraphics(), this.DisplayRectangle),
                    scaledCoordinates.X, scaledCoordinates.Y, part.Color, part.Size);
                _parts.Add(new Particel()
                {
                    Name = part.Name,
                    Color = part.Color,
                    Size = part.Size,
                    Pos = part.Pos
                });
            }
            catch (Exception) { }

            part.ChangePos(time, _orbit.Particels, G);
        }
        private async void btn_start_Click(object sender, EventArgs e)
        {
            while (!exit)
            {
                Parallel.ForEach(_orbit.Particels, part =>
                {
                    ScaleAndDraw(sender, e, part);
                    Application.DoEvents();
                });
                //await Task.Delay(1);
            }
        }
        private void Reload(object sender, EventArgs e)
        {
            exit = false;
            this.BackColor = Color.Black;
            Parallel.ForEach(_parts, part =>
                {
                    ScaleAndDraw(sender, e, part);
                    Application.DoEvents();
                });
            btn_start_Click(sender, e);
        }
        private void Draw_Point(object sender, PaintEventArgs pe, double x, double y, Color color, int size = 4)
        {
            Graphics g = pe.Graphics;
            g.FillEllipse(new SolidBrush(color), Convert.ToInt32(x + this.Width / 2), Convert.ToInt32(y + this.Height / 2), size, size);
        }

        //Asteroide
        private void button1_Click(object sender, EventArgs e)
        {
            _orbit.Particels.Add(new Particel()
            {
                Name = "ASTEROIDE",
                Mass = 3.989e30,
                Color = Color.White,
                Pos = (_orbit.Zero.X - 7.788e11, _orbit.Zero.Y - 7.788e11),
                Speed = (13000, 13720),
                Size = 6
            });
            _orbit.Particels.Add(new Particel()
            {
                Name = "ASTEROIDE2",
                Mass = 3.989e30,
                Color = Color.White,
                Pos = (_orbit.Zero.X + 7.788e11, _orbit.Zero.Y - 7.788e11),
                Speed = (-13000, 13720),
                Size = 6
            });
            btn_start_Click(sender, e);
        }
        //Swap earth and sun
        private void btn_swap_Click(object sender, EventArgs e)
        {
            var x = _orbit.Particels.First(x => x.Name == "Earth").Mass;
            _orbit.Particels.First(x => x.Name == "Earth").Mass = _orbit.Particels.First(x => x.Name == "Sun").Mass;
            _orbit.Particels.First(x => x.Name == "Sun").Mass = x;
            var earth = _orbit.Particels.First(x => x.Name == "Earth");
            earth.Speed = (0, 0);
            btn_start_Click(sender, e);
        }
        //POV Earth
        private void Draw_Point_Earth(object sender, PaintEventArgs pe, (double X, double Y) scaledCoordinates
            , (double X, double Y) earthCoordinates, Color color, int size = 4)
        {
            Graphics g = pe.Graphics;
            scaledCoordinates = (scaledCoordinates.X - earthCoordinates.X, scaledCoordinates.Y - earthCoordinates.Y);
            g.FillEllipse(new SolidBrush(color), Convert.ToInt32(scaledCoordinates.X + this.Width / 2), Convert.ToInt32(scaledCoordinates.Y + this.Height / 2), size, size);
        }

        private async void btn_heliocenter_Click(object sender, EventArgs e)
        {
            while (true)
            {
                Parallel.ForEach(_orbit.Particels, part =>
                {
                    var scaledCoordinates = Scale(part.Pos.X, part.Pos.Y, _scale);
                    (double X, double Y) earthCoord = Scale(_orbit.Particels.First(x => x.Name == "Earth").Pos.X, _orbit.Particels.First(x => x.Name == "Earth").Pos.Y, _scale);
                    try
                    {
                        Draw_Point_Earth(sender, new PaintEventArgs(this.CreateGraphics(), this.DisplayRectangle), scaledCoordinates, earthCoord, part.Color, part.Size);
                    }
                    catch (Exception) { }

                    part.ChangePos(time, _orbit.Particels, G);
                });
                Application.DoEvents();
                //await Task.Delay(1);
            }
        }

        //SCALE
        private (double X, double Y) Scale(double x, double y, double scale)
        {
            var outX = (x / scale) * this.Height;
            var outY = (y / scale) * this.Height;
            return (outX, outY);
        }

        private void btn_zoom_in_Click(object sender, EventArgs e)
        {
            _scale /= 2.5;
            this.Refresh();
            Reload(sender, e);
        }

        private void btn_zoom_out_Click(object sender, EventArgs e)
        {
            _scale *= 2.5;
            this.Refresh();
            Reload(sender, e);
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            exit = true;
            this.Refresh();
            _orbit = new(0, 0);
        }
    }
}