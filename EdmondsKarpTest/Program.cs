using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace graphproject
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string wyjscie = "";
            do
            {

                string log = string.Format("{0,23}|{1,23}|{2,23}|{3,23}|{4,23}", "Max Flow", "Czas wykonania(ticks)", "Ilość wierzchołków", "Ilość krawędzi", "Ilość dróg(BFS)");
                Console.Write("podaj ilosc grafów do losowego wygenerowania i przetestowania: ");
                int n = Convert.ToInt16(Console.ReadLine());
                Console.Write("podaj poziom trudnosci[E/M/H]: ");
                string poziom = Console.ReadLine();
                Random rnd = new Random();
                Console.WriteLine(log);
                for (int i = 0; i < n; i++)
                {
                    int min=90, max=150;
                    if (poziom.ToLower() == "e")
                    {
                        min = 4;
                        max = 50;
                    }
                    if (poziom.ToLower() == "m")
                    {
                        min = 50;
                        max = 90;
                    }
                    int[,] graf = GraphGenerator.Generate(rnd.Next(min, max), true);
                    EdmondsKarp ek = new EdmondsKarp();
                    int sink = 0, source = 0;
                    while (sink == source)
                    {
                        sink = rnd.Next(0, graf.GetLength(0));
                        source = rnd.Next(0, graf.GetLength(0));
                    }
                    Stopwatch c = Stopwatch.StartNew();
                    int mf = ek.FindMaxFlow(graf, NeighborsList(graf), source, sink, out var lf);
                    c.Stop();
                    int k = ek.k;
                    int kraw = 0;
                    for (int p = 0; p < graf.GetLength(0); p++)
                    {
                        for (int q = p + 1; q < graf.GetLength(1); q++)
                        {
                            if (graf[p, q] != 0) kraw++;
                            if (graf[q, p] != 0 && graf[q, p] != graf[p,q]) kraw++;
                        }
                    }
                    string nowywpis = string.Format("{0,23}|{1,23}|{2,23}|{3,23}|{4,23}", mf, c.ElapsedTicks, graf.GetLength(0), kraw,
                        k);
                    log += Environment.NewLine + nowywpis;
                    Console.WriteLine(nowywpis);
                }
                string odp = "";
                do
                {
                    Console.Write("czy chcesz zapisać wynik do pliku?[T/N] ");
                    odp = Console.ReadLine();
                } while (odp.ToLower() != "n" && odp.ToLower() != "t");
                if (odp.ToLower() == "t")
                {
                    SaveFileDialog sfd = new SaveFileDialog();

                    sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    sfd.FilterIndex = 2;
                    sfd.RestoreDirectory = true;

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        StreamWriter stream = new StreamWriter(sfd.FileName);
                        stream.WriteLine(log);
                        stream.Close();
                    }
                }
                do
                {
                    Console.Write("Czy zamnknąć program?[T/N]");
                    wyjscie = Console.ReadLine();
                } while (wyjscie.ToLower() != "n" && wyjscie.ToLower() != "t");
            } while (wyjscie.ToLower() == "n");
        }
        static Dictionary<int, List<int>> NeighborsList(int[,] graf)
        {
            Dictionary<int, List<int>> result = new Dictionary<int, List<int>>();

            for (int i = 0; i < graf.GetLength(0); i++)
            {
                List<int> list = new List<int>();
                for (int j = 0; j < graf.GetLength(1); j++)
                {
                    if (graf[i, j] != 0)
                    {
                        list.Add(j);
                    }
                }
                result.Add(i, list);
            }

            return result;
        }
    }
}
