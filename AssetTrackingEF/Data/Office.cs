using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEF.Data.EF
{
    internal class Office
    {
        public int Id { get; set; }
        public string? Country { get; set; }
        public string? Currency { get; set; }

    }
}
