using System;

namespace graphproject
{
    public class GraphGenerator
    {
        public static int[,] Generate(int vcount,bool directed, bool mixed = true)
        {
            int[,] result = new int[0,0];
            do
            {
                if (directed && mixed) result = GenerateDirectedMixed(vcount);
                if (directed && !mixed) result = GenerateDirectedNonMixed(vcount);
                if (!directed) result = GenerateNonDirected(vcount);
            } while (!GraphConsistency.CheckConsistency(result));
            return result;
        }

        private static int[,] GenerateNonDirected(int vcount)
        {
            int[,] result = new int[vcount,vcount];
            //40% szans na krawędz
            Random rnd = new Random();

            for (int i = 0; i < vcount; i++)
            {
                for (int j = i+1; j < vcount; j++)
                {
                    if (rnd.Next(0, 10) < 4)
                    {
                        result[i, j] = result[j, i] = rnd.Next(20);
                    }
                }
            }

            return result;
        }

        private static int[,] GenerateDirectedMixed(int vcount)
        {
            Random rnd = new Random();

            int[,] result = GenerateNonDirected(vcount);

            for (int i = 0; i < vcount; i++)
            {
                for (int j = i + 1; j < vcount; j++)
                {
                    if (result[i, j] != 0)
                    {
                        int los = rnd.Next(0, 6);
                        if (los == 0) result[i, j] = rnd.Next(20);
                        if (los == 1) result[j, i] = rnd.Next(20);
                        if (los == 4) result[i, j] = 0;
                        if (los == 5) result[j, i] = 0;
                    }
                }
            }
            return result;
        }
        private static int[,] GenerateDirectedNonMixed(int vcount)
        {
            Random rnd = new Random();

            int[,] result = GenerateNonDirected(vcount);

            for (int i = 0; i < vcount; i++)
            {
                for (int j = i + 1; j < vcount; j++)
                {
                    if (result[i, j] != 0)
                    {
                        int los = rnd.Next(0, 2);
                        if (los == 0) result[i, j] = 0;
                        if (los == 1) result[j, i] = 0;
                    }
                }
            }
            return result;
        }
    }
}
