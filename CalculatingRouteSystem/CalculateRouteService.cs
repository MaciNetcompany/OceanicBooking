using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatingRouteSystem.Models;

namespace CalculatingRouteSystem
{
    internal class CalculateRouteService
    {
        private Edge[] edgeGraph;
        private Point[] pointsGraph;
        private List<Point> unvisited;
        private List<Point> visited;
        public CalculateRouteService()
        {
            var pointA = new Point() { Name = "A" };
            var pointB = new Point() { Name = "B" };
            var pointC = new Point() { Name = "C" };
            var pointD = new Point() { Name = "D" };
            var pointE = new Point() { Name = "E" };
            var pointF = new Point() { Name = "F" };

            pointsGraph = new Point[] { pointA, pointB, pointC, pointD, pointE, pointF };

            edgeGraph = new Edge[]
            {
                new Edge() {StartPoint=pointA,EndPoint = pointB,Weight = 2},
                new Edge() {StartPoint=pointA,EndPoint = pointB,Weight = 6},
                new Edge() {StartPoint=pointA,EndPoint=pointE,Weight = 4},
                new Edge() {StartPoint=pointA,EndPoint=pointF,Weight = 2},
                new Edge() {StartPoint=pointA,EndPoint=pointC,Weight = 2},

                new Edge() {StartPoint=pointB,EndPoint=pointD,Weight = 6},

                new Edge() {StartPoint=pointD,EndPoint=pointE,Weight = 4},
                new Edge() {StartPoint=pointD,EndPoint=pointF,Weight = 4},

                new Edge() {StartPoint=pointE,EndPoint=pointF,Weight = 4},
            };
            pointA.connections = new List<Edge>()
            {
                edgeGraph[0],edgeGraph[1],edgeGraph[2],edgeGraph[3],edgeGraph[4]
            };
            pointB.connections = new List<Edge>()
            {
                edgeGraph[0],edgeGraph[1],edgeGraph[5]
            };
            pointC.connections = new List<Edge>()
            {
                edgeGraph[4]
            };
            pointD.connections = new List<Edge>()
            {
                edgeGraph[5],edgeGraph[6], edgeGraph[7]
            };
            pointE.connections = new List<Edge>()
            {
                edgeGraph[8],edgeGraph[2], edgeGraph[6]
            };
            pointF.connections = new List<Edge>()
            {
                edgeGraph[3],edgeGraph[7], edgeGraph[8]
            };

            unvisited = new List<Point>()
            {
                pointA, pointB, pointC, pointD, pointE, pointF
            };
            visited = new List<Point>();
        }
        internal List<Edge> FindFastestRoute(Point[] graph, Point sourcePoint, Point destinationPoint)
        {
            List<List<RouteSegment>> routes = new List<List<RouteSegment>>();
        }
    }

}
