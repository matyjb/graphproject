using System;
using System.ComponentModel;
using System.Windows.Forms;
using SFML.Graphics;

namespace graphproject
{
    public partial class SFMLcanvas : UserControl
    {
        private RenderWindow RendWind;

        public SFMLcanvas()
        {
            InitializeComponent();
        }

        public void StartSLMF()
        {
            renderLoopWorker.RunWorkerAsync(Handle);
        }

        private void DrawStuff()
        {
            var CS = new CircleShape(10)
            {
                FillColor = Color.Magenta
            };
            RendWind.Draw(CS);
        }

        private void RenderLoopWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            RendWind = new RenderWindow((IntPtr) e.Argument);
            while (RendWind.IsOpen)
            {
                RendWind.DispatchEvents();
                RendWind.Clear(new Color(51, 77, 102));

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