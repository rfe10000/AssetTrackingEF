using AssertTrackingEF.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssertTrackingEF.Data.EF
{
    internal class AssetBrand
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public List<AssetModel>? Model { get; set; }
    }
}
