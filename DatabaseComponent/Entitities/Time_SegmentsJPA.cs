using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseComponent.Entitities
{
    [Keyless]
    public class Time_SegmentsJPA
    {
        public int Rel_ID { get; set; }
        public int Time { get; set; }
    }
}
