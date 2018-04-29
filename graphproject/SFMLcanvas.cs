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
        private int[,] graf = { {0, 15, 6, 100}, 
                                {1, 0, 0, 1}, 
                                {1, 0, 0, 1}, 
                                {1, 1, 1, 0}};

        private Font font = new Font("arial.ttf");

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
                var p = new Vert(font, new Vector2f(rnd.Next(20,Width-20), rnd.Next(20, Height - 20)), i);
                wierzcholkiList.Add(p);
            }
        }

        private void DrawStuff()
        {
            //rysowanie linii łączących
            for (int i = 0; i < graf.GetLength(0); i++)
            {
                for (int j = i + 1; j < graf.GetLength(1); j++)
                {
                    if (graf[i,j] >= 1)
                    {
                        //VertsConnectionLine l = new VertsConnectionLine(4, wierzcholkiList[i].Position, wierzcholkiList[j].Position, 1, graf[i, j],font);
                        VertsConnectionLine l = new VertsConnectionLine(graf[j,i],graf[i,j],4, wierzcholkiList[i].Position, wierzcholkiList[j].Position,font);
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
            RendWind = new RenderWindow((IntPtr) e.Argument);
            RendWind.SetFramerateLimit(60);
            while (RendWind.IsOpen)
            {
                RendWind.DispatchEvents();
                //RendWind.Clear(new Color(BackColor.R, BackColor.G, BackColor.B));
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