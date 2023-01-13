namespace CalculatingRouteSystem
{
    public class RouteCalculation
    {

        private int minDistance(int[] dist,
                        bool[] sptSet, int graphSize)
        {
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < graphSize; v++)
                if (sptSet[v] == false && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }

            return min_index;
        }


        private int dijkstra(int[,] graph, int src, int dest)
        {
            int[] dist = new int[graph.GetLength(1)];

            bool[] sptSet = new bool[graph.GetLength(1)];

            for (int i = 0; i < graph.GetLength(1); i++)
            {
                dist[i] = int.MaxValue;
                sptSet[i] = false;
            }

            dist[src] = 0;

            for (int count = 0; count < graph.GetLength(1) - 1; count++)
            {

                int u = minDistance(dist, sptSet, graph.GetLength(1));

                sptSet[u] = true;

                for (int v = 0; v < graph.GetLength(1); v++)


                    if (!sptSet[v] && graph[u, v] != 0 &&
                         dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                        dist[v] = dist[u] + graph[u, v];
            }

            return dist[dest];
        }

        private int calculateTime(int segCount)
        {
            return segCount * 8;
        }

        private int calculatePrice(int segCount, int parcelPrice)
        {
            return segCount * parcelPrice;
        }

        public int shortestPathTime(int src, int dest, int[,] graph)
        {
            return calculateTime(dijkstra(graph, src, dest));
        }

        public int shortestPathPrice(int src, int dest, int[,] graph, int parcelPrice)
        {
            return calculatePrice(dijkstra(graph, src, dest), parcelPrice);
        }
    }
}