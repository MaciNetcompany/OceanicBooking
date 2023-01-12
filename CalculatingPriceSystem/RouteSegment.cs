using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatingPriceSystem
{
    internal class RouteSegment
    {

        private String PointA;
        private String PointB;
        private String Vehicle;
        public RouteSegment(String Point_A, String Point_B, String Veh)
        {
            PointA = Point_A;
            PointB = Point_B;
            Vehicle = Veh;
        }
    }
}
