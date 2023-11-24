using AssertTrackingEF.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEF.Data.EF
{
    internal class Asset
    {
        public int Id { get; set; }
        public int AssetModelId { get; set; }
        public AssetModel? AssetModel { get; set; }
        public int OfficeId { get; set; }
        public Office? Office { get; set; }
        public double Price { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
