using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphproject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void restart_Click(object sender, EventArgs e)
        {
            sfmLcanvas1.StartSLMF();
        }

        private void bgenerate_Click(object sender, EventArgs e)
        {
            GenGraphWorker.RunWorkerAsync();
        }

        private void GenGraphWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Random rnd = new Random();
            int[,] r = GraphGenerator.Generate(rnd.Next(5, 10), true);
            sfmLcanvas1.Graf = r;
        }
    }
}
