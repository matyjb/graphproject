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

        private List<Vert> wierzcholkiList = new List<Vert>();

        //przykladowy graf
        private int[,] graf = { {0, 1, 1, 1}, 
                                {1, 0, 0, 1}, 
                                {1, 0, 0, 1}, 
                                {1, 1, 1, 0}};

        //resources
        private Text text = new Text("0", new Font("arial.ttf"));
        private CircleShape circle = new CircleShape(20)
        {
            FillColor = Color.Black,
            Origin = new Vector2f(17.5f,11.5f),
            OutlineThickness = 4,
            OutlineColor = Color.White
        };

        public SFMLcanvas()
        {
            InitializeComponent();
        }

        public void StartSLMF()
        {
            Random rnd = new Random();
            renderLoopWorker.RunWorkerAsync(Handle);
            for (int i = 1; i <= graf.GetLength(0); i++)
            {
                var p = new Vert(circle, text, new Vector2f(rnd.Next(20,Width-20), rnd.Next(20, Height - 20)), i);
                wierzcholkiList.Add(p);
            }
        }

        private void DrawStuff()
        {
            //rysowanie linii łączących
            for (int i = 0; i < graf.GetLength(0); i++)
            {
                for (int j = 0; j < graf.GetLength(1); j++)
                {
                    if (i != j && graf[i,j] == 1)
                    {
                        Vertex[] lines = new Vertex[2];
                        lines[0] = new Vertex(wierzcholkiList[i].Position);
                        lines[1] = new Vertex(wierzcholkiList[j].Position);

                        RendWind.Draw(lines,PrimitiveType.Lines);
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
            RendWind = new RenderWindow((IntPtr) e.Argument);
            while (RendWind.IsOpen)
            {
                RendWind.DispatchEvents();
                RendWind.Clear(Color.Black);

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
    }
}