using Gravity.CalculateOrbits.Models;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Gravity.Drawer
{
    public partial class OrbitDrawerForm : Form
    {
        readonly int _time = 5000;
        Orbit _orbit;
        readonly List<Particel> _parts = new();
        double _scale = 2e12;
        bool _exit = false;

        //record per ricordare la storia
        public OrbitDrawerForm()
        {
            this.DoubleBuffered = true;
            DefaultOrbitInitialize();
            InitializeComponent();
        }
        private void btn_start_Click(object sender, EventArgs e)
        {
            DrawOrbitNames();

            while (!_exit)
            {
                Parallel.ForEach(_orbit.Particels, part =>
                {
                    ScaleAndDraw(part);
                    Application.DoEvents();
                });
            }
        }

        // asteroids
        private async void button_asteroids_Click(object sender, EventArgs e)
        {
            await RefreshView();
            var asteroids = LoadJson("Data\\asteroids.json");
            foreach (var asteroid in asteroids)
            {
                _orbit.Particels.Add(asteroid);
            }
            btn_start_Click(sender, e);
        }

        private async void btn_heliocenter_Click(object sender, EventArgs e)
        {
            await RefreshView();
            _exit = false;
            DrawOrbitNames();
            while (!_exit)
            {
                Parallel.ForEach(_orbit.Particels, part =>
                {
                    var scaledCoordinates = Scale(part.Position.X, part.Position.Y, _scale);
                    var earthCoord = Scale(_orbit.Particels.First(x => x.Name == "Earth").Position.X, _orbit.Particels.First(x => x.Name == "Earth").Position.Y, _scale);
                    Draw_Point_Earth(sender, new PaintEventArgs(this.CreateGraphics(), this.DisplayRectangle), scaledCoordinates, earthCoord, part.Color, part.Size);
                    part.UpdateParticel(_time, _orbit.Particels);
                });
                Application.DoEvents();
            }
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

        private async void btn_stop_Click(object sender, EventArgs e)
        {
            _exit = true;
            await RefreshView();
        }

        private void DefaultOrbitInitialize()
        {
            var solarSystem = LoadJson("Data\\solarSystem.json");
            _orbit = new Orbit(solarSystem);
        }

        private void OrbitDrawerForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
        }


        private void DrawOrbitNames()
        {
            for (int i = 0; i < _orbit.Particels.Count; i++)
            {
                Graphics formGraphics = this.CreateGraphics();
                var part = _orbit.Particels[i];
                DrawWord(formGraphics, 0, 50 + i * 30, part.Name, part.Color);
            }
        }

        private void ScaleAndDraw(Particel part)
        {
            var scaledCoordinates = Scale(part.Position.X, part.Position.Y, _scale);
            Graphics formGraphics = this.CreateGraphics();
            DrawPoint(formGraphics,
                scaledCoordinates.X, scaledCoordinates.Y, part.Color, part.Size);

            part.UpdateParticel(_time, _orbit.Particels);
        }

        private void Reload(object sender, EventArgs e)
        {
            _exit = false;
            this.BackColor = Color.Black;
            Parallel.ForEach(_parts, part =>
                {
                    ScaleAndDraw(part);
                    Application.DoEvents();
                });
            btn_start_Click(sender, e);
        }

        private void DrawPoint(Graphics g, double x, double y, Color color, int size = 4)
        {
            g.FillEllipse(new SolidBrush(color), Convert.ToInt32(x + this.Width / 2), Convert.ToInt32(y + this.Height / 2), size, size);
        }

        private static void DrawWord(Graphics g, double x, double y, string word, Color color)
        {
            Font drawFont = new("Arial", 16);
            SolidBrush drawBrush = new(color);
            g.DrawString(word, drawFont, drawBrush, (float)x, (float)y);
        }

        private void Draw_Point_Earth(object sender, PaintEventArgs pe, Coordinate scaledCoordinates
            , Coordinate earthCoordinates, Color color, int size = 4)
        {
            Graphics g = pe.Graphics;
            scaledCoordinates = new(scaledCoordinates.X - earthCoordinates.X, scaledCoordinates.Y - earthCoordinates.Y);
            g.FillEllipse(new SolidBrush(color), Convert.ToInt32(scaledCoordinates.X + this.Width / 2), Convert.ToInt32(scaledCoordinates.Y + this.Height / 2), size, size);
        }

        private Coordinate Scale(double x, double y, double scale)
        {
            var outX = (x / scale) * this.Height;
            var outY = (y / scale) * this.Height;
            return new (outX, outY);
        }

        private async Task RefreshView()
        {
            this.Refresh();
            await Task.Delay(100);
            _orbit = new();
            DefaultOrbitInitialize();
        }

        private static IEnumerable<Particel> LoadJson(string filePath)
        {
            using StreamReader r = new(filePath);
            string json = r.ReadToEnd();
            if(json is not null)
            {
                var items = JsonConvert.DeserializeObject<IEnumerable<Particel>>(json);
                return items??new List<Particel>();
            }

            throw new FileNotFoundException();
        }
    }
}