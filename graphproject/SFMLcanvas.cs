using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using SFML.Graphics;
using SFML.System;

namespace graphproject
{
    public partial class SFMLcanvas : UserControl
    {
        private RenderWindow RendWind;

        private List<Vert> wierzcholkiList;

        //przykladowy graf
        //private int[,] graf =
        //{
        //    {0, 15, 6, 100},
        //    {1, 0, 0, 1},
        //    {1, 0, 0, 1},
        //    {1, 0, 1, 0}
        //};

        private int[,] graf =
        {
            {0, 12, 0, 14, 15, 16},
            {12, 0, 0, 24,0, 0},
            {0, 23, 0, 34, 35, 0},
            {14, 24, 34, 0, 45, 46},
            {0, 25, 0, 45, 0, 56},
            {16, 0, 36, 466, 56, 0}
        };

        public int[,] Graf
        {
            get { return graf; }
            set
            {
                graf = value;
                StartSLMF();
            }
        }

        private Font font = new Font("arial.ttf");
        private Color color1;
        private Color color2;

        public SFMLcanvas()
        {
            InitializeComponent();
            color1 = Color.Black;
            color2 = new Color(BackColor.R, BackColor.G, BackColor.B);
    }

        public void StartSLMF()
        {
            if (!renderLoopWorker.IsBusy)
            {   
                renderLoopWorker.RunWorkerAsync(Handle);
            }
            wierzcholkiList = new List<Vert>();
            Random rnd = new Random();
            for (int i = 1; i <= graf.GetLength(0); i++)
            {
                var p = new Vert(font, new Vector2f(rnd.Next(20, Width - 20), rnd.Next(20, Height - 20)), i) { FillColor = color2, OutlineColor = color1, TextColor = color1 };
                wierzcholkiList.Add(p);
            }
        }

        private void UpdateVertsPositions(Time elapsedTime)
        {
            //update camera
            Vector2f center = new Vector2f(0, 0);
            foreach (var item in wierzcholkiList)
            {
                center += item.Position;
            }
            center /= wierzcholkiList.Count;
            SFML.Graphics.View view = RendWind.DefaultView;
            view.Center = center;
            RendWind.SetView(view);
            ///////
            List<Vector2f> f = new List<Vector2f>(wierzcholkiList.Count);
            for (int i = 0; i < wierzcholkiList.Count; i++)
            {
                f.Add(new Vector2f(0, 0));
                for (int j = 0; j < wierzcholkiList.Count; j++)
                {
                    if (i != j)
                    {
                        Vector2f v = wierzcholkiList[j].Position - wierzcholkiList[i].Position;
                        f[i] += v - v * 350 / Normalize(v);
                        if (f[i].X < 0) f[i] = new Vector2f(0, f[i].Y);
                        if (f[i].Y < 0) f[i] = new Vector2f(f[i].X, 0);
                    }
                }
                f[i] *= elapsedTime.AsSeconds() * 2;
            }
            for (int i = 0; i < wierzcholkiList.Count; i++)
            {
                if(Normalize(f[i]) > 1) //takie niby tarcie
                    wierzcholkiList[i].Position += f[i];
            }
        }

        private void DrawStuff(Time elapsedTime)
        {
            UpdateVertsPositions(elapsedTime);

            //rysowanie linii łączących
            for (int i = 0; i < graf.GetLength(0); i++)
            {
                for (int j = i + 1; j < graf.GetLength(1); j++)
                {
                    if (graf[i, j] >= 1 || graf[j, i] >= 1)
                    {
                        VertsConnectionLine l = new VertsConnectionLine(graf[j, i], graf[i, j], 4, wierzcholkiList[i].Position, wierzcholkiList[j].Position, font) { FillColor = color1, OutlineColor = color2 };
                        RendWind.Draw(l);
                        l.Dispose();
                    }
                }
            }

            //rysowanie wierzcholkow
            foreach (var itemVert in wierzcholkiList)
            {
                RendWind.Draw(itemVert);
            }
        }

        private void RenderLoopWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            RendWind = new RenderWindow((IntPtr)e.Argument);
            RendWind.SetFramerateLimit(60);
            Clock clock = new Clock();
            while (RendWind.IsOpen)
            {
                Time elapsed = clock.ElapsedTime;
                clock.Restart();
                RendWind.DispatchEvents();
                RendWind.Clear(new Color(BackColor.R, BackColor.G, BackColor.B));
                //RendWind.Clear(Color.Black);

                DrawStuff(elapsed);

                RendWind.Display();

            }
        }

        private void SFMLcanvas_Load(object sender, EventArgs e)
        {
            StartSLMF();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (RendWind == null)
                base.OnPaint(e);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (RendWind == null)
                base.OnPaintBackground(pevent);
        }

        private float Normalize(Vector2f v)
        {
            return (float)Math.Sqrt(v.X * v.X + v.Y * v.Y);
        }
    }
}