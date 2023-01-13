using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatingRouteSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatingRouteSystem.Tests
{
    [TestClass()]
    public class RouteCalculationTests
    {
        [TestMethod()]
        public void shortestPathTimeTest()
        {
            int src = 0;
            int dest = 5;
            int[,] graph = new int[,] {
                {0, 1, 1, 0, 0, 0},
                {1, 0, 1, 1, 0, 0},
                {1, 1, 0, 0, 1, 0},
                {0, 1, 0, 0, 1, 1},
                {0, 0, 1, 1, 0, 1},
                {0, 0, 0, 1, 1, 0}
            };

            RouteCalculation routing = new RouteCalculation();
            int time = routing.shortestPathTime(src, dest, graph);

            Assert.AreEqual(24, time);
        }

        [TestMethod()]
        public void shortestPathPriceTest()
        {
            int src = 0;
            int dest = 5;
            int[,] graph = new int[,] {
                {0, 1, 1, 0, 0, 0},
                {1, 0, 1, 1, 0, 0},
                {1, 1, 0, 0, 1, 0},
                {0, 1, 0, 0, 1, 1},
                {0, 0, 1, 1, 0, 1},
                {0, 0, 0, 1, 1, 0}
            };

            int parcelPrice = 40;

            RouteCalculation routing = new RouteCalculation();
            int price = routing.shortestPathPrice(src, dest, graph, parcelPrice);

            Assert.AreEqual(120, price);
        }
    }
}