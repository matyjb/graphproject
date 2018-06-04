using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            NUDsink.Maximum = NUDsource.Maximum = sfmLcanvas1.Graf.GetLength(0);
            NUDsink.Minimum = NUDsource.Minimum = 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bgenerate.PerformClick();
            bClearLog.PerformClick();
        }

        private void restart_Click(object sender, EventArgs e)
        {
            sfmLcanvas1.StartSLMF();
        }

        private void bgenerate_Click(object sender, EventArgs e)
        {
            if (!GenGraphWorker.IsBusy)
                GenGraphWorker.RunWorkerAsync();
        }

        private void GenGraphWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //bgenerate.Enabled = false;
            try
            {
                sfmLcanvas1.Graf = GraphGenerator.Generate((int)NUPvcount.Value, CBdirected.Checked, CBmixed.Checked);
                NUDsink.Maximum = NUDsource.Maximum = sfmLcanvas1.Graf.GetLength(0);

                NUDsource.Value = NUDsink.Value = 1;
                sfmLcanvas1.EdmondsKarpMode = false;
            }
            catch (Exception ex)
            {

            }
            //bgenerate.Enabled = true;
        }

        private void EKbutton_Click(object sender, EventArgs e)
        {
            sfmLcanvas1.EdmondsKarpMode = !sfmLcanvas1.EdmondsKarpMode;
        }

        private void NUDsource_ValueChanged(object sender, EventArgs e)
        {
            sfmLcanvas1.Source = (int)NUDsource.Value - 1;
        }

        private void NUDsink_ValueChanged(object sender, EventArgs e)
        {
            sfmLcanvas1.Sink = (int)NUDsink.Value - 1;

        }

        private void bClearLog_Click(object sender, EventArgs e)
        {
            rLog.Text = sfmLcanvas1.Log = "";
        }

        private void bSaveLog_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            sfd.FilterIndex = 2;
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter stream = new StreamWriter(sfd.FileName);
                stream.WriteLine(rLog.Text);
                stream.Close();
            }
        }

        private void bAddToLog_Click(object sender, EventArgs e)
        {
            rLog.AppendText(sfmLcanvas1.Log);
            rLog.ScrollToCaret();
        }

        private void bLoadGraph_Click(object sender, EventArgs e)
        {
            try
            {
                string[] rows = rCustomGraph.Text.Split('\n');
                int n = rows[0].Split(',').Length;
                int[,] final = new int[n, n];
                for (int i = 0; i < final.GetLength(0); i++)
                {
                    if (rows[i] != "")
                    {
                        string[] numbers = rows[i].Split(',');
                        for (int j = 0; j < final.GetLength(1); j++)
                        {
                            int num = Convert.ToInt16(numbers[j]);
                            if (i != j)
                            {
                                final[i, j] = num;
                            }
                        }
                    }
                }
                if (!GraphConsistency.CheckConsistency(final))
                {
                    MessageBox.Show("Nie wszystkie wierzchołki grafu są połączone");
                }
                else
                {
                    sfmLcanvas1.Graf = final;
                    NUDsink.Maximum = NUDsource.Maximum = sfmLcanvas1.Graf.GetLength(0);
                    NUDsource.Value = NUDsink.Value = 1;
                    sfmLcanvas1.EdmondsKarpMode = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Macierz pojemności grafu jest nieprawidłowa");
            }
        }
    }
}
