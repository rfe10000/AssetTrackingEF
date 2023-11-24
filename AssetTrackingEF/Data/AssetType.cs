using AssetTrackingEF.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssertTrackingEF.Data.EF
{
    internal class AssetType
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public List<AssetModel>? AssetModel { get; set; }
    }
}
