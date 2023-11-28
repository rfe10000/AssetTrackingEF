using AssertTrackingEF.Data;
using AssetTrackingEF.AssetHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class Program
{
    //Delegate to handle the type, brand, model and office alternatives
    delegate AssetChoiceMenu MenuDelegate();
    
    static AssetTrackingDbContext context = new AssetTrackingDbContext();
    
    //Gets the current value of the currencies from internet
    //TODO: Get office currencies from database.
    static Dictionary<string, double?> currencyFromUSD = 
        JsonCurrencyParser.GetCurrenciesFromJson(new List<string>() { "USD", "EUR", "SEK", "GBP", "CHF" }) ??
        new Dictionary<string, double?>()
        {
            { "USD", 1 },
            { "EUR", 0.9782323 },
            { "SEK", 11.2342323 },
            { "GBP", 0.82291064 },
            { "CHF", 0.91649692 }
        };

    static readonly string tblHeader = GetTableHeader(string.Empty);

    const string menue = "Add asset - \"A\" | Show - enter \"S\" | Change or Delete - enter \"C\" or \"D\" | Reports - \"R\" | Quit - enter \"Q\"";
    const string menueUpdateRemove = "Select asset from list (Nr): ";

    private static string GetTableHeader(string pad)
    {
        StringBuilder sbHeader = new StringBuilder();

        sbHeader.Append("Category".PadRight(12)).Append("Brand".PadRight(12)).Append("Model".PadRight(20)).Append("Office".PadRight(12)).Append("Purchase Date".PadRight(15)).Append("Price (USD)".PadRight(12)).Append("Currency".PadRight(12)).Append("Local Price").Append('\n');
        sbHeader.Append(pad).Append("----".PadRight(12)).Append("-----".PadRight(12)).Append("-----".PadRight(20)).Append("------".PadRight(12)).Append("-------------".PadRight(15)).Append("-----------".PadRight(12)).Append("--------".PadRight(12)).Append("-----------");
        return sbHeader.ToString();
    }

    private static void PrintColoredMessage(string msg, ConsoleColor color = ConsoleColor.White, bool onSingleLine = false)
    {
        if (color != ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            if (onSingleLine)
                Console.Write(msg);
            else
                Console.WriteLine(msg);
            Console.ResetColor();
        }
        else
        {
            if (onSingleLine)
                Console.Write(msg);
            else
                Console.WriteLine(msg);
        }
    }
}

