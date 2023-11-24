using System.Data.Common;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

using AssertTrackingEF.Data;
using AssertTrackingEF.Data.EF;
using System.Net.WebSockets;
using AssetTrackingEF.Data.EF;
using MenuHelper = AssetTrackingEF.AssetHelper.AssetChoiceMenu;
using AssetTrackingEF.AssetHelper;
using AssetTrackingEF.Utility;
using System.Collections;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;


PrintColoredMessage("Welcome to asset tracking app", ConsoleColor.Gray);

while (true)
{
    PrintColoredMessage(menue, ConsoleColor.Blue);

    string choice = (Console.ReadLine() ?? string.Empty).Trim().ToLower();
    if (choice == "q")
    {
        break;
    }
    else if (choice == "a")
    {
        if (HandleAssetInput())
        {
            PrintColoredMessage("The asset was successfully added!", ConsoleColor.Green);
            Console.Write(Environment.NewLine);
        }        
    }
    else if (choice == "r")
    {
        if (UpdateOrRemoveAsset(false))
            PrintColoredMessage("The asset was successfully deleted!", ConsoleColor.Green);

        Console.Write(Environment.NewLine);
    }
    else if (choice == "c")
    {
        if (UpdateOrRemoveAsset(true))
            PrintColoredMessage("The asset was successfully changed!", ConsoleColor.Green);

        Console.Write(Environment.NewLine);
    }
    else if (choice == "s")
    {
        PrintAssets();
    }
}

static MenuHelper GetModelMenue(int typeId, int brandID)
{
    var selectModel = (from brand in context.Set<AssetBrand>()
                       join model in context.Set<AssetModel>()
                       on brand.Id equals model.AssetBrandID
                       where brand.Id == brandID
                       join types in context.Set<AssetType>()
                       on model.AssetTypeID equals types.Id
                       where types.Id == typeId
                       select new { model.Model, model.Id, brand.Brand, types.Type }).ToList();


    List<int> choice = new List<int>();
    StringBuilder sb = new StringBuilder();
    foreach (var itm in selectModel)
    {
        sb.Append(itm.Id).Append(". ").Append(itm.Model).Append(" ".PadRight(4));
        choice.Add(itm.Id);
    }
    MenuHelper mH = new MenuHelper
    {
        Menu = sb.ToString(),
        Identifiers = choice
    };

    return mH;
}

static MenuHelper GetBrandMenue(int typeId)
{
    var selectBrand = (from brand in context.Set<AssetBrand>()
                       join model in context.Set<AssetModel>()
                       on brand.Id equals model.AssetBrandID
                       join types in context.Set<AssetType>()
                       on model.AssetTypeID equals types.Id
                       where types.Id == typeId
                       select new { brand.Id, brand.Brand }).Distinct().ToList();


    List<int> choice = new List<int>();
    StringBuilder sb = new StringBuilder();
    foreach (var itm in selectBrand)
    {
        sb.Append(itm.Id).Append(". ").Append(itm.Brand).Append(" ".PadRight(4));
        choice.Add(itm.Id);
    }
    MenuHelper mH = new MenuHelper
    {
        Menu = sb.ToString(),
        Identifiers = choice
    };

    return mH;
}

static MenuHelper GetTypeMenue()
{
    var selectType = (from types in context.Set<AssetType>()
                      select new { types.Id , types.Type }).ToList();

    List<int> choice = new List<int>();
    StringBuilder sb = new StringBuilder();
    foreach (var itm in selectType)
    { 
        sb.Append(itm.Id).Append(". ").Append(itm.Type).Append(" ".PadRight(4));
        choice.Add(itm.Id);
    }
    MenuHelper mH = new MenuHelper
    {
        Menu = sb.ToString(),
        Identifiers = choice
    };

    return mH; 
}

static MenuHelper GetOfficeMenue()
{
    var selectOffice = (from office in context.Set<Office>()
                    select new { office.Id, office.Country, office.Currency }).ToList();

    List<int> choice = new List<int>();
    StringBuilder sb = new StringBuilder();
    foreach (var itm in selectOffice)
    {
        sb.Append(itm.Id).Append(". ").Append(itm.Country).Append(" ".PadRight(4));
        choice.Add(itm.Id);
    }

    MenuHelper mH = new MenuHelper
    {
        Menu = sb.ToString(),
        Identifiers = choice
    };

    return mH;
}

static void HandleInput(string mnu, out bool isBreak, ref string quitOption, ref int id, MenuHelper mnDel)
{
    isBreak = false;
    MenuHelper mnHlp = mnDel; 

    do
    {
        PrintColoredMessage($"{mnu} {quitOption}: ", ConsoleColor.Cyan, true); 
        PrintColoredMessage(mnHlp.Menu);

        string read = (Console.ReadLine() ?? string.Empty).Trim();
        if (read == "q")
        {
            //So break; is trigged in main loop
            isBreak = true;
            return;
        }
        if (read == string.Empty)
        {
            quitOption = ", or quit \"q\"";
            continue;
        }
        else if (int.TryParse(read, out int value))
        {
            if (mnHlp.Identifiers.Contains(value))
            {
                id = value;
                quitOption = string.Empty;
                return;
            }
            else
            {
                PrintColoredMessage("Not a valid choice", ConsoleColor.Red);
                quitOption = ", or quit \"q\"";
                continue;
            }
        }
        else
            continue;            
        
    }
    while (true);
}

static bool HandleAssetInput()
{
    bool assetAdded = false;
    string quitOption = string.Empty;

    //skapar en tuple, tillfällig datahållare
    var assetTpl = (TypeId: -1, BrandId: -1, ModelId: -1, OfficeId: -1, Price: double.NaN, PurchaseDate: default(DateTime));
    
    while (!assetAdded)
    {
        //Om quitOption har ett värde saknas någon inmatning
        if (quitOption == string.Empty)
            PrintColoredMessage("To enter a new asset - follow the steps | To quit enter \"q\"", ConsoleColor.DarkYellow);

        if (assetTpl.TypeId < 0) 
        {
            HandleInput("Select a type from the list (number)", out bool isBreak, ref quitOption, ref assetTpl.TypeId, GetTypeMenue());

            if (isBreak)
                break;
        }
        if (assetTpl.BrandId < 0)
        {
            HandleInput("Select a brand from the list (number)", out bool isBreak, ref quitOption, ref assetTpl.BrandId, GetBrandMenue(assetTpl.TypeId));

            if (isBreak)
                break;

        }
        if (assetTpl.ModelId < 0) 
        {
            HandleInput("Select a model from the list (number)", out bool isBreak, ref quitOption, ref assetTpl.ModelId, GetModelMenue(assetTpl.TypeId, assetTpl.BrandId));

            if (isBreak)
                break;
        }
        if (assetTpl.OfficeId < 0) 
        {
            HandleInput("Select an office from the list (number)", out bool isBreak, ref quitOption, ref assetTpl.OfficeId, GetOfficeMenue());

            if (isBreak)
                break;
        }
        if (Double.IsNaN(assetTpl.Price))
        {
            PrintColoredMessage($"Enter the asset price (USD){quitOption}: ", ConsoleColor.Cyan);

            string strPrice = (Console.ReadLine() ?? string.Empty).Trim().Replace('.', ',');
            if (strPrice == "q")
                break;
            double price;
            if (Double.TryParse(strPrice, out price))
            {
                assetTpl.Price = price;
                quitOption = string.Empty;
            }
            else
            {
                quitOption = ", or quit \"q\"";
                continue;
            }
        }

        PrintColoredMessage($"Enter a purchase date in format yyyy-MM-dd (if empty todays date){quitOption}: ", ConsoleColor.Cyan);

        string purchased = (Console.ReadLine() ?? string.Empty).Trim().ToLower();
        if (purchased == "q")
            break;

        DateTime date;
        if (DateTime.TryParse(purchased, out date))
            assetTpl.PurchaseDate = date;
        else
            assetTpl.PurchaseDate = DateTime.Today;

        quitOption = string.Empty;

        Asset asset = new Asset();
        asset.AssetModelId = assetTpl.ModelId;
        asset.OfficeId = assetTpl.OfficeId;
        asset.Price = assetTpl.Price;
        asset.PurchaseDate = assetTpl.PurchaseDate;

        context.Asset.Add(asset);
        context.SaveChanges();

        assetTpl = (TypeId: -1, BrandId: -1, ModelId: -1, OfficeId: -1, Price: double.NaN, PurchaseDate: default(DateTime));

        quitOption = string.Empty;
        assetAdded = true;        
    }
    return assetAdded;
}

static bool UpdateOrRemoveAsset(bool update)
{ 
    var assetTpls = GetAssets();

    Console.WriteLine($"Navigate with {char.ConvertFromUtf32(0x2191)} {char.ConvertFromUtf32(0x2193)}, Enter to select, Escape to abort\n");

    PrintColoredMessage("  ".PadLeft(2) + "Category".PadRight(12) + "Brand".PadRight(12) + "Model".PadRight(20) + "Office".PadRight(12) + "Purchase Date".PadRight(15), ConsoleColor.DarkYellow);

    //For arrow navigation in the asset table
    List<string> list = new List<string>();

    assetTpls.ForEach(asset => list.Add($"{asset.Item2.PadRight(12)}{asset.Item3.PadRight(12)}" +
                $"{asset.Item4.PadRight(20)}{asset.Item5.PadRight(12)}{asset.Item6:yyyy-MM-dd}"));

    int selectedIndex = AssetUtils.AssetChoice(list);

    if (selectedIndex > 0)
    {
        int index = assetTpls[selectedIndex - 1].Item1;

        Asset? assetRemoveOrUpdate = context.Asset.FirstOrDefault(x => x.Id == index);

        if (assetRemoveOrUpdate == null)
            return false;

        if (update)
        {
            //The only thing that is allowed to change in an asset is it's location
            string str = string.Empty;
            int oId = -1;
            HandleInput("Select an office from the list (number)", out bool isBreak, ref str, ref oId, GetOfficeMenue());

            if (!isBreak)
            {
                assetRemoveOrUpdate.OfficeId = oId;
                context.Asset.Update(assetRemoveOrUpdate);
                context.SaveChanges();
            }
            else
                return false;
        }
        else 
        {
            context.Asset.Remove(assetRemoveOrUpdate);
            context.SaveChanges();
        }
    }
    else 
        return false;

    return true;
}
static void PrintAssets()
{
    DateTime threeMonthAgo = DateTime.Today.AddMonths(-3);
    DateTime sixMonthAgo = DateTime.Today.AddMonths(-6);

    //Använder en Linq Query för att få "assets" i rätt ordning.
    var queryList = (from asset in context.Set<Asset>()
                     orderby asset.OfficeId, asset.PurchaseDate descending
                     join office in context.Set<Office>()
                     on asset.OfficeId equals office.Id
                     join model in context.Set<AssetModel>()
                     on asset.AssetModelId equals model.Id
                     join types in context.Set<AssetType>()
                     on model.AssetTypeID equals types.Id
                     join brands in context.Set<AssetBrand>()
                     on model.AssetBrandID equals brands.Id                     
                     select new
                     {
                         types.Type,
                         brands.Brand,
                         office.Country,
                         model.Model,
                         asset.PurchaseDate,
                         asset.Price,
                         office.Currency,
                         asset.Id,
                         asset.AssetModelId
                     }).ToList();

    PrintColoredMessage(tblHeader, ConsoleColor.Green);

    queryList.ForEach(asset => PrintColoredMessage($"{asset.Type.PadRight(12)}{asset.Brand.PadRight(12)}{asset.Model.PadRight(20)}" +
                $"{asset.Country.PadRight(12)}{asset.PurchaseDate:yyyy-MM-dd}{" ".PadRight(5)}{asset.Price,-12:f2}" +
                $"{asset.Currency.PadRight(12)}{(currencyFromUSD[asset.Currency] * asset.Price):f2}",
                (asset.PurchaseDate > threeMonthAgo ? ConsoleColor.Red :
                asset.PurchaseDate > sixMonthAgo ? ConsoleColor.Yellow : ConsoleColor.White)));

    Console.Write(Environment.NewLine);
}

/*
 * For update and remove
 */
static List<Tuple<int, string, string, string, string, DateTime>> GetAssets()
{
    var queryList = (from asset in context.Set<Asset>()
                     join office in context.Set<Office>()
                     on asset.OfficeId equals office.Id
                     join model in context.Set<AssetModel>()
                     on asset.AssetModelId equals model.Id
                     join types in context.Set<AssetType>()
                     on model.AssetTypeID equals types.Id
                     join brands in context.Set<AssetBrand>()
                     on model.AssetBrandID equals brands.Id
                     select Tuple.Create 
                     (
                         asset.Id,
                         types.Type,
                         brands.Brand,
                         model.Model,
                         office.Country,
                         asset.PurchaseDate
                     )).ToList();

    return queryList;
}

