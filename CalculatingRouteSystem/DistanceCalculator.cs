using CalculatingRouteSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatingRouteSystem
{
    //TODO: insert link to the github this was taken from
    internal class DistanceCalculator
    {
        Dictionary<Node, int> Distances;
        Dictionary<Node, Node> Routes;
        Graph graph;
        List<Node> AllNodes;

        public DistanceCalculator(Graph g)
        {
            this.graph = g;
            this.AllNodes = g.GetNodes();
            Distances = SetDistances();
            Routes = SetRoutes();
        }

        public void Calculate(Node Source, Node Destination)
        {
            Distances[Source] = 0;

            while (AllNodes.ToList().Count != 0)
            {
                Node LeastExpensiveNode = getLeastExpensiveNode();
                ExamineConnections(LeastExpensiveNode);
                AllNodes.Remove(LeastExpensiveNode);
            }
            Print(Source, Destination);
        }

        private void Print(Node Source, Node Destination)
        {
            Console.WriteLine(string.Format("The least possible cost for flying from {0} to {1} is: {2} $", Source.getName(), Destination.getName(), Distances[Destination]));
            PrintLeg(Destination);
            Console.ReadKey();
        }

        private void PrintLeg(Node d)
        {
            if (Routes[d] == null)
                return;
            Console.WriteLine(string.Format("{0} <-- {1}", d.getName(), Routes[d].getName()));
            PrintLeg(Routes[d]);
        }

        private void ExamineConnections(Node n)
        {
            foreach (var neighbor in n.getNeighbors())
            {
                if (Distances[n] + neighbor.Value < Distances[neighbor.Key])
                {
                    Distances[neighbor.Key] = neighbor.Value + Distances[n];
                    Routes[neighbor.Key] = n;
                }
            }
        }

        private Node getLeastExpensiveNode()
        {
            Node LeastExpensive = AllNodes.FirstOrDefault();

            foreach (var n in AllNodes)
            {
                if (Distances[n] < Distances[LeastExpensive])
                    LeastExpensive = n;
            }

            return LeastExpensive;
        }

        private Dictionary<Node, int> SetDistances()
        {
            Dictionary<Node, int> Distances = new Dictionary<Node, int>();

            foreach (Node n in graph.GetNodes())
            {
                Distances.Add(n, int.MaxValue);
            }
            return Distances;
        }

        private Dictionary<Node, Node> SetRoutes()
        {
            Dictionary<Node, Node> Routes = new Dictionary<Node, Node>();

            foreach (Node n in graph.GetNodes())
            {
                Routes.Add(n, null);
            }
            return Routes;
        }
    }
}

