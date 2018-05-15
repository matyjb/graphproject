using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// Edmonds Karp MaxFlow Algorithm
    /// based on en.wikipedia.org/wiki/Edmonds%E2%80%93Karp_algorithm
    public class EdmondsKarp
    {
        private int n = 0;

        public int FindMaxFlow(
            int[,] capacityMatrix,
            Dictionary<int, List<int>> neighbors,
            int source,
            int sink,
            out int[,] legalFlows)
        {
            int n = capacityMatrix.GetLength(0);

            int f = 0; // initial flow is 0
            legalFlows = new int[n, n]; // residual capacity from u to v is capacityMatrix[u,v] - legalFlows[u,v]

            while (true)
            {
                int[] p;
                int m = BreadthFirstSearch(capacityMatrix, neighbors, source, sink, legalFlows, out p);

                if (m == 0) break;
                f += m;
                // backtrakc search, and write flow
                int v = sink;

                while (v != source)
                {
                    int u = p[v];
                    legalFlows[u, v] += m;
                    legalFlows[v, u] -= m;
                    v = u;
                }

            }

            return f;
        }

        private int BreadthFirstSearch(
            int[,] capacityMatrix,
            Dictionary<int, List<int>> neighbors,
            int source,
            int sink,
            int[,] legalFlows,
            out int[] p)
        {
            p = new int[n+1];
            for (int u = 0; u < n; u++)
            {
                p[u] = -1;

            }

            p[source] = -2; // make sure source is not rediscovered
            int[] m = new int[n]; // capacity of found path to node
            m[source] = int.MaxValue;

            Queue<int> q = new Queue<int>();
            q.Enqueue(source);

            while (q.Count > 0)
            {
                int u = q.Dequeue();
                foreach (int v in neighbors[u])
                {
                    // if there is available capacity, and v is not seen before in search
                    if (capacityMatrix[u, v] - legalFlows[u, v] > 0 &&
                        p[v] == -1)
                    {
                        p[v] = u;
                        m[v] = Math.Min(m[u], capacityMatrix[u, v] - legalFlows[u, v]);

                        if (v != sink) q.Enqueue(v);
                        else return m[sink];
                    }
                }
            }

            return 0;

        }

        static void Main(string[] args)
        {
            int[,] capa = { { 0,2,0,1,0,0,0,0,0 }, 
                            { 2,0,3,0,4,0,0,0,0 }, 
                            { 0,3,0,0,0,1,0,0,0 }, 
                            { 1,0,0,0,2,0,2,0,0 }, 
                            { 0,4,0,2,0,2,0,4,0 }, 
                            { 0,0,1,0,2,0,0,0,6 }, 
                            { 0,0,0,2,0,0,0,3,0 },
                            { 0,0,0,0,4,0,3,0,1 },
                            { 0,0,0,0,0,6,0,1,0 } };
            Dictionary<int, List<int>> sąsiedzi = new Dictionary<int, List<int>>();
            sąsiedzi.Add(0, new List<int> { 1, 3 });
            sąsiedzi.Add(1, new List<int> { 0, 2, 4 });
            sąsiedzi.Add(2, new List<int> { 1, 5 });
            sąsiedzi.Add(3, new List<int> { 0, 4, 6 });
            sąsiedzi.Add(4, new List<int> { 1, 3, 5, 7 });
            sąsiedzi.Add(5, new List<int> { 2, 4, 8 });
            sąsiedzi.Add(6, new List<int> { 3, 7 });
            sąsiedzi.Add(7, new List<int> { 4, 6, 8 });
            sąsiedzi.Add(8, new List<int> { 5, 7 });
            int[,] legal; // = new int[10,10];

            EdmondsKarp wynik = new EdmondsKarp();
            wynik.FindMaxFlow(capa, sąsiedzi, 0, 8, out legal);

            Console.WriteLine(wynik.FindMaxFlow(capa, sąsiedzi, 1, 8, out legal)); 

            Console.ReadKey();
        }

    }

}
