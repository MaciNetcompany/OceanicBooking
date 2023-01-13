using Azure;
using System;
using System.Collections.Generic;

namespace CalculatingRouteSystem.Models
{
    public class Node
    {

        private string Name;
        private Dictionary<Node, int> Neighbors;

        public Node(string NodeName)
        {
            this.Name = NodeName;
            Neighbors = new Dictionary<Node, int>();
        }

        public void AddNeighbour(Node n, int cost)
        {
            if(Neighbors.ContainsKey(n))
            {
                return;
            }
            Neighbors.Add(n, cost);
        }

        public string getName()
        {
            return Name;
        }

        public Dictionary<Node, int> getNeighbors()
        {
            return Neighbors;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
