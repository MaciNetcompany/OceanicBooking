using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatingRouteSystem.Models
{
    internal class Point
    {
        public string Name { get; set; }
        public bool WasVisted { get; set; }
        public List<Edge> connections { get; set; }
    }
}
