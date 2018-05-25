using System.Collections.Generic;

namespace graphproject
{
    public static class GraphConsistency
    {
        public static bool CheckConsistency(int[,] arr)
        {
            int n = arr.GetLength(0);
            bool[] visited = new bool[n];
            int vc = 0; //licznik odwiedzonych
            Stack<int> S = new Stack<int>();
            S.Push(0);
            visited[0] = true;

            while (S.Count != 0)
            {
                int v = S.Pop();
                vc++;
                for (int u = v; u < n; u++)
                {
                    if (arr[v, u] != 0) //jest sąsiadem v
                    {
                        if (!visited[u])
                        {
                            visited[u] = true;
                            S.Push(u);
                        }
                    }
                }
            }
            if (vc == n) return true;
            return false;
        }
    }
}
