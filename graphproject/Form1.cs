using System;
using System.ComponentModel;
using System.IO;
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
            EKbutton.Text = sfmLcanvas1.EdmondsKarpMode ? "Ukryj" : "Pokaż";
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
            rLog.Text = "Max przepływ;Wierzchołków;Drogi;Czas (mikrosekund)" + Environment.NewLine;
            sfmLcanvas1.Log = "";
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
            if (rCustomGraph.Text != "")
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
                                    if (num < 0) num = 0;
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
                        //wypisywanie poprawionego
                        rCustomGraph.Text = "";
                        for (int i = 0; i < final.GetLength(0); i++)
                        {
                            for (int j = 0; j < final.GetLength(1); j++)
                            {
                                rCustomGraph.Text += final[i, j] + (j != final.GetLength(1) - 1 ? "," : "\n");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Macierz pojemności grafu jest nieprawidłowa\nPrzykładowa macierz:\n0,2,4\n2,0,3\n1,2,0\nUjemne elementy i elementy na diagonali zostaną wyzerowane");
                }
            }
        }

        private void bTworcy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Projekt wykonali:\nBartosz Matyjasiak\nZuzanna Gałecka\nMaciej Zwoliński\nKod programu dostępny na:\nhttps://github.com/matyjb/graphproject");
        }
    }
}
