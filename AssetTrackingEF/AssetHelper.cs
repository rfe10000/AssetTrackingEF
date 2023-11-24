using AssetTrackingEF.Data.EF;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEF.AssetHelper
{
    internal class AssetChoiceMenu
    {
        public string Menu {  get; set; }
        public List<int> Identifiers { get; set; }
    }
}

