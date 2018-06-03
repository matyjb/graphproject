using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace graphproject
{
    public partial class SFMLcanvas : UserControl
    {
        private RenderWindow RendWind;

        private List<Vert> wierzcholkiList;

        private int source;
        private int sink;

        public int Source
        {
            get { return source; }
            set
            {
                source = value;
                UpdateEdmondsKarp();
            }
        }
        public int Sink
        {
            get { return sink; }
            set
            {
                sink = value;
                UpdateEdmondsKarp();
            }
        }

        public bool EdmondsKarpMode { get; set; }
        public int[,] LegalFlows { get; set; }

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
            EdmondsKarpMode = true;
            Source = 1;
            Sink = 4;
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
            UpdateEdmondsKarp();
        }

        private void UpdateEdmondsKarp()
        {
            EdmondsKarp ek = new EdmondsKarp();
            int wynik = ek.FindMaxFlow(Graf, NeighborsList(), Source, Sink, out var l);
            LegalFlows = l;
        }

        private void UpdateCamera()
        {
            SFML.Graphics.View view = RendWind.DefaultView;
            //centrowanie kamery
            Vector2f center = new Vector2f(0, 0);
            foreach (var item in wierzcholkiList)
            {
                center += item.Position;
            }
            center /= wierzcholkiList.Count;
            view.Center = center;
            //zoomowanie kamery
            Vector2f maxxy = new Vector2f(0,0);
            for (int i = 0; i < wierzcholkiList.Count; i++)
            {
                    Vector2f n = wierzcholkiList[i].Position - center;
                    n = new Vector2f(Math.Abs(n.X),Math.Abs(n.Y));
                    if (n.X > maxxy.X) maxxy.X = n.X;
                    if (n.Y > maxxy.Y) maxxy.Y = n.Y;
            }
            maxxy += new Vector2f(40,40);
            maxxy *= 2;
            float zoomfactor = (maxxy.X > maxxy.Y) ? maxxy.X / view.Size.X : maxxy.Y / view.Size.Y;
            view.Zoom(zoomfactor);

            RendWind.SetView(view);
        }
        private void UpdateVertsPositions(Time elapsedTime)
        {
            float timeMultiplier = 2;
            
            List<Vector2f> f = new List<Vector2f>(wierzcholkiList.Count);
            for (int i = 0; i < wierzcholkiList.Count; i++)
            {
                f.Add(new Vector2f(0, 0));
                for (int j = 0; j < wierzcholkiList.Count; j++)
                {
                    if (i != j)
                    {
                        Vector2f v = wierzcholkiList[j].Position - wierzcholkiList[i].Position;
                        //odpychanie wierzcholkow
                        f[i] += v - v * (25 * wierzcholkiList.Count + 200) / Normalize(v);
                        //przyciaganie polaczonych wierzcholkow
                        if (Graf[i, j] != 0 || Graf[j, i] != 0)
                        {
                            f[i] += (- v + v * (25 * wierzcholkiList.Count + 200) / Normalize(v))/2;
                        }
                    }
                }
                f[i] *= elapsedTime.AsSeconds() * timeMultiplier;
            }

            for (int i = 0; i < wierzcholkiList.Count; i++)
            {
                //if (Normalize(f[i]) > 0.3f) //takie niby tarcie
                    wierzcholkiList[i].Position += f[i];
            }
        }

        private void DrawStuff()
        {
            if (EdmondsKarpMode)
            {
                //rysowanie linii łączących - tryb edmonda
                for (int i = 0; i < graf.GetLength(0); i++)
                {
                    for (int j = i + 1; j < graf.GetLength(1); j++)
                    {
                        if (graf[i, j] != 0 || graf[j, i] != 0)
                        {
                            VertsConnectionLine l =
                                new VertsConnectionLine(LegalFlows[j, i] == 0 ? graf[j, i] : LegalFlows[j, i] < 0 ? 0 : LegalFlows[j, i], LegalFlows[i, j] == 0 ? graf[i, j] : LegalFlows[i, j] < 0 ? 0 : LegalFlows[i, j], 4, wierzcholkiList[i].Position, wierzcholkiList[j].Position, font)
                                { FillColor = color1, OutlineColor = color2, Selected = (LegalFlows[i, j] != 0 || LegalFlows[i, j] != 0) };
                            RendWind.Draw(l);
                            l.Dispose();
                        }
                    }
                }
            }
            else
            {
                //rysowanie linii łączących - tryb zwykly
                for (int i = 0; i < graf.GetLength(0); i++)
                {
                    for (int j = i + 1; j < graf.GetLength(1); j++)
                    {
                        if (graf[i, j] != 0 || graf[j, i] != 0)
                        {
                            VertsConnectionLine l =
                                new VertsConnectionLine(graf[j, i], graf[i, j], 4, wierzcholkiList[i].Position, wierzcholkiList[j].Position, font)
                                { FillColor = color1, OutlineColor = color2 };
                            RendWind.Draw(l);
                            l.Dispose();
                        }
                    }
                }
            }

            //przypisywanie kolorow sink i source
            for (int i = 0; i < wierzcholkiList.Count; i++)
            {
                wierzcholkiList[i].IsSink = i == Sink && EdmondsKarpMode;
                wierzcholkiList[i].IsSource = i == Source && EdmondsKarpMode;
                wierzcholkiList[i].Selected = false;
                for (int j = 0; j < LegalFlows.GetLength(1); j++)
                {
                    if (LegalFlows[i, j] != 0)
                    {
                        wierzcholkiList[i].Selected = EdmondsKarpMode;
                        break;
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
            ContextSettings contextSettings = new ContextSettings() { AntialiasingLevel = 8 };
            RendWind = new RenderWindow((IntPtr)e.Argument, contextSettings);
            RendWind.SetFramerateLimit(60);


            Clock clock = new Clock();
            while (RendWind.IsOpen)
            {
                Time elapsed = clock.ElapsedTime;
                clock.Restart();
                RendWind.DispatchEvents();
                RendWind.Clear(new Color(BackColor.R, BackColor.G, BackColor.B));
                //RendWind.Clear(Color.Black);

                UpdateVertsPositions(elapsed);
                UpdateCamera();
                DrawStuff();

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

        private Dictionary<int, List<int>> NeighborsList()
        {
            Dictionary<int, List<int>> result = new Dictionary<int, List<int>>();

            for (int i = 0; i < Graf.GetLength(0); i++)
            {
                List<int> list = new List<int>();
                for (int j = 0; j < Graf.GetLength(1); j++)
                {
                    if (Graf[i, j] != 0)
                    {
                        list.Add(j);
                    }
                }
                result.Add(i,list);
            }

            return result;
        }
    }
}