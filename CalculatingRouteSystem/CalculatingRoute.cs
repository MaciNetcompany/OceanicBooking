using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using CalculatingRouteSystem.Models;

namespace CalculatingRouteSystem
{
    public class CalculatingRoute
    {
        Dictionary<Node, int> Distances;
        Dictionary<Node, Node> Routes;
        Graph graph;
        List<Node> AllNodes;

        static void Main(string[] args)
        {
            Graph Cities = new Graph();

            Node NewYork = new Node("New York");
            Node Miami = new Node("Miami");
            Node Chicago = new Node("Chicago");
            Node Dallas = new Node("Dallas");
            Node Denver = new Node("Denver");
            Node SanFrancisco = new Node("San Francisco");
            Node LA = new Node("Los Angeles");
            Node SanDiego = new Node("San Diego");

            Cities.Add(NewYork);
            Cities.Add(Miami);
            Cities.Add(Chicago);
            Cities.Add(Dallas);
            Cities.Add(Denver);
            Cities.Add(SanFrancisco);
            Cities.Add(LA);
            Cities.Add(SanDiego);

            NewYork.AddNeighbour(Chicago, 75);
            NewYork.AddNeighbour(Miami, 90);
            NewYork.AddNeighbour(Dallas, 125);
            NewYork.AddNeighbour(Denver, 100);

            Miami.AddNeighbour(Dallas, 50);

            Dallas.AddNeighbour(SanDiego, 90);
            Dallas.AddNeighbour(LA, 80);

            SanDiego.AddNeighbour(LA, 45);

            Chicago.AddNeighbour(SanFrancisco, 25);
            Chicago.AddNeighbour(Denver, 20);

            SanFrancisco.AddNeighbour(LA, 45);

            Denver.AddNeighbour(SanFrancisco, 75);
            Denver.AddNeighbour(LA, 100);

            DistanceCalculator c = new DistanceCalculator(Cities);
            c.Calculate(NewYork, LA);
        }
    }
}