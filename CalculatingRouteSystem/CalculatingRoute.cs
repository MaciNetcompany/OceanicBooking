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

            Node Nairobi = new Node("Nairobi");
            Node Cairo = new Node("Cairo");
            Node Lagos = new Node("Lagos");
            Node Luanda = new Node("Luanda");
            Node Giza = new Node("Giza");
            Node Accra = new Node("Accra");
            Node LA = new Node("Los Angeles");
            Node SanDiego = new Node("San Diego");

            Cities.Add(Nairobi);
            Cities.Add(Cairo);
            Cities.Add(Lagos);
            Cities.Add(Luanda);
            Cities.Add(Giza);
            Cities.Add(Accra);
            Cities.Add(Dakar);
            Cities.Add(Kano);

            Nairobi.AddNeighbour(Lagos, 75);
            Nairobi.AddNeighbour(Cairo, 90);
            Nairobi.AddNeighbour(Luanda, 125);
            Nairobi.AddNeighbour(Giza, 100);

            Cairo.AddNeighbour(Luanda, 50);

            Luanda.AddNeighbour(Kano, 90);
            Luanda.AddNeighbour(Dakar, 80);

            Kano.AddNeighbour(Dakar, 45);

            Lagos.AddNeighbour(Accra, 25);
            Lagos.AddNeighbour(Giza, 20);

            Accra.AddNeighbour(Dakar, 45);

            Giza.AddNeighbour(Accra, 75);
            Giza.AddNeighbour(Dakar, 100);

            DistanceCalculator c = new DistanceCalculator(Cities);
            c.Calculate(Nairobi, Dakar);
        }
    }
}
