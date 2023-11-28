using AssetTrackingEF.Data.EF;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net;

namespace AssetTrackingEF.AssetHelper
{
    internal class AssetChoiceMenu
    {
        public string? Menu {  get; set; }
        public List<int>? Identifiers { get; set; }
    }

    internal class JsonCurrencyInfo
    {
        public string? code { get; set; }
        public string? alphaCode { get; set; }
        public string? numericCode { get; set; }
        public string? name { get; set; }
        public double? rate { get; set; }
        public string? date { get; set; }
        public double? inverseRate { get; set; }
    }
    internal class JsonCurrencyParser
    {
        private static Dictionary<string, JsonCurrencyInfo> ParseToJsonCurrencyInfo(string jsonString)
        {
            Dictionary<string, JsonCurrencyInfo> curDict = new();

            var nodes = JsonNode.Parse(jsonString)!.AsObject().ToArray();


            foreach (var node in nodes)
            {
                curDict.Add(node.Key.ToUpper(), node.Value.Deserialize<JsonCurrencyInfo>()!);
            }
            return curDict;
        }

        //Method to get the currencies to the app in apps format
        internal static Dictionary<string, double?> GetCurrenciesFromJson(List<string> currencies)        {

            HttpClient httpClient = new HttpClient();

            Dictionary<string, JsonCurrencyInfo> currDict = new();
            Dictionary<string, double?> currForApp = new();
            
            try
            {
                using HttpResponseMessage response = httpClient.GetAsync("https://www.floatrates.com/daily/usd.json").Result;

                response.EnsureSuccessStatusCode();

                string jsonContent = response.Content.ReadAsStringAsync().Result;

                currDict = JsonCurrencyParser.ParseToJsonCurrencyInfo(jsonContent);
               
                foreach (string s in currencies)
                {
                    //All currencies in currDict is relative to USD. But USD is not present.
                    if (s.Equals("USD"))
                    {
                        currForApp.Add(s, 1);
                        continue;
                    }
                    currForApp.Add(s, currDict[s].rate);
                }                
            }
            catch //(HttpRequestException e)
            {
                //The app will load with diffrent data
                return null;                
            }
            return currForApp;
        }
    }
    
}

