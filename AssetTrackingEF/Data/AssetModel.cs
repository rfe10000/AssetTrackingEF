using AssertTrackingEF.Data.EF;
using AssetTrackingEF.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace AssertTrackingEF.Data.EF
{
    internal class AssetModel
    {
        public int Id { get; set; }
        public string? Model { get; set; }

        public int AssetTypeID { get; set; }
        public AssetType? AssetType { get; set; }
        public int AssetBrandID { get; set; }
        public AssetBrand? AssetBrand { get; set; }
        public List<Asset>? Assets { get; set; }
    }
}
