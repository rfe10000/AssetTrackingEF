using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEF.Data.EF
{
    [Keyless]
    internal class ReportGroupTotal
    {
        public string? Office { get; set; }

        public Double? Total { get; set; }
    }
}
