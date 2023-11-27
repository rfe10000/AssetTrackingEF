using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEF.Data.EF
{
    [Keyless]
    internal class ReportOffice
    {
        // Office, t.Type, m.Model, b.Brand, a.Price, Total
        public string? Office { get; set; }
        public string? Type { get; set; }
        public string? Model { get; set; }
        public string? Brand { get; set; }
        public Double? Price { get; set; }
        public Double? Total { get; set; }
    }
}
