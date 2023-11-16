using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

Console.WriteLine("Asset Tracking");

Display display = new Display();
string FirstCharToUpper(string input)
{
    return Regex.Replace(input, "^[a-z]", c => c.Value.ToUpper());
}

void PrintOut(string str, int posX, int posY)
{
    int strLen = str.Length;
    display.ClearLine(posX, posY);
    display.SetCursurPos(posX, posY);
    Console.Write(str);
    display.SetCursurPos(strLen + 2, posY);
}

//Computer computer = new Computer();
int[] flag = new int[] { 0, 1, 2, 3, 4 };
int strLen = 0;
int flagPos = 0;
int inputFlag = 0;
int price;
int currency;
int milliseconds = 1100;

//StringBuilder ModelName = new StringBuilder();
//StringBuilder OfficeCountry = new StringBuilder();
//DateTime PurchaseDate = new DateTime();


// public Currency(string currencyName, double currencyValue)

List<Currency> currencyList = new List<Currency>();
currencyList.Add(new Currency("Sweden", "SEK", 10.5624, "Kr"));
currencyList.Add(new Currency("Great Britain", "GBP", 0.806311, "Pund"));
currencyList.Add(new Currency("Germany", "EUR", 0.921532, "Euro"));
currencyList.Add(new Currency("Japan", "JPN", 151.286, "Yen"));
currencyList.Add(new Currency("Norway", "NOK", 10.8085, "Kr"));

/*
foreach (Currency c in currencyList)
{
    Console.WriteLine(c.Show());
}
*/
//    public Computer(string modelName, int price, DateTime purchaseDate, int lifeSpan)

List<Product> productList = new List<Product>();

productList.Add(new Product("Computer", "Dell", "Latitude 5440", "Sweden", 949, Convert.ToDateTime("2020-01-01"), 3));
productList.Add(new Product("Computer", "HP",  "Envy 17t", "Japan", 799, Convert.ToDateTime("2020-08-17"), 3));
productList.Add(new Product("Computer", "HP", "Pavilion", "USA", 629, Convert.ToDateTime("2020-05-17"), 3));
productList.Add(new Product("Computer", "Lenovo", "ThinkPad", "USA", 1499, Convert.ToDateTime("2029-10-12"), 3));
productList.Add(new Product("Computer", "Dell", "Precision 7780","Sweden", 5439, Convert.ToDateTime("2022-12-10"), 3));
productList.Add(new Product("Mobile", "Apple",  "iPhone 15 Pro Max", "Sweden", 999, Convert.ToDateTime("2022 - 12 - 10"), 3));
productList.Add(new Product("Mobile", "Samsung", "Galaxy Z Fold5", "Germany", 1799, Convert.ToDateTime("2021-10-11"), 3));
productList.Add(new Product("Mobile", "Samsung", "Galaxy S23 Ultra", "USA", 1199, Convert.ToDateTime("2021-10-10"), 3));
productList.Add(new Product("Mobile", "Nokia", "G42", "Norway", 2990, Convert.ToDateTime("2020-10-12"), 3));

display.ShowCategory();

foreach (Product p in productList)
{
    p.Show();
}
/*
List<Mobile> mobiles = new List<Mobile>();
//List<Product> products = new List<Product>();
mobiles.Add(new Mobile("Apple iPhone 15 Pro Max", 999, Convert.ToDateTime("2022-12-10"), 3));
mobiles.Add(new Mobile("Samsung Galaxy Z Fold5", 1799, Convert.ToDateTime("2021-10-11"), 3));
mobiles.Add(new Mobile("Samsung Galaxy S23 Ultra", 1199, Convert.ToDateTime("2021-10-10"), 3));
mobiles.Add(new Mobile("Nokia G42", 2990, Convert.ToDateTime("2020-10-12"), 3));
*/
/*
foreach (Mobile c in mobiles)
{
    Console.WriteLine(c.Show());
}
*/
//display.ExpireLevel(Convert.ToDateTime("2020-01-01"), Convert.ToDateTime("2023-03-01"), Convert.ToDateTime("2023-06-01"));

//string[] inputInfo = new string[] {"FirstMenu", "Products"};
//        public Computer(string modelName, int price, DateTime purchaseDate, int lifeSpan, string officeCountry, string currency)
//computers.Add(new Computer("Dell Latitude", 123, Convert.ToDateTime("2023-11-16"), 3, "Stockholm", "SEK"));



class Display
{
    public Display()
    {
    }

    public int PosX { get; set; } 
    public int PosY { get; set; }


    public void ClearLine(int posX, int posY)
    {
        Console.SetCursorPosition(posX, posY);
        Console.Write(new String(' ', Console.BufferWidth));
    }

    public void ShowCategory()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Product".PadRight(10) + "Brand".PadRight(10) + "Model".PadRight(18) + "Office".PadRight(15) + "Price in USD".PadRight(17) + "Currency".PadRight(10) + "Local price");
        Console.WriteLine("-------".PadRight(10) + "-----".PadRight(10) + "-----".PadRight(18) + "------".PadRight(15) + "------------".PadRight(17) + "--------".PadRight(10) + "-----------");
        Console.ResetColor();
    }


    // Metods for set the positions
    public void SetCursurPos(int posX, int posY)
    {
        Console.SetCursorPosition(posX, posY);
    }

/*
    public int ExpireLevel(DateTime date1, DateTime date2, DateTime date3)
    {
        string bought = date1.ToString("yy-MM-dd");
        string Expire1 = date2.ToString("yy-MM.dd");
        string Expire2 = date3.ToString("yy-MM.dd");
        switch (ExpireLevel())
        {
            case 0:
                Console.WriteLine($"Model: {ModelName} Price: {Price.ToString()} Purchase date: {bought} Expire date1: {Expire1} Expire date2: {Expire2}");
                break;
            case 1:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Model: {ModelName} Price: {Price.ToString()} Purchase date: {bought} Expire date1: {Expire1} Expire date2: {Expire2}");
                Console.ResetColor();
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Model: {ModelName} Price: {Price.ToString()} Purchase date: {bought} Expire date1: {Expire1} Expire date2: {Expire2}");
                Console.ResetColor();
                break;
        }
    }
*/

}

class Country
{
    public Country(string officeCountry)
    {
        OfficeCountry = officeCountry;
    }

    public string OfficeCountry { get; set; }
}

/*
   double CurrencyValue()
    {
        switch (Currency)
        {
            case "SEK":
                return 10.5534;
                break;
            case "EUR":
                return 0.921311;
                break;
            case "GBP":
                return 0.921311;
                break;
            case "EUR":
                return 0.921311;
                break;
            case "EUR":
                return 0.921311;
                break;
            default:
                return 1;
        }
    }
*/

class Currency
{
    public Currency()
    {
    }

    public Currency(string officeCountry, string currencyName, double currencyValue, string currencySymbol)
    {
        CurrencyName = currencyName;
        CurrencyValue = currencyValue;
        CurrencySymbol = currencySymbol;
        OfficeCountry = officeCountry;
    }

    public string OfficeCountry { get; set; }
    public string CurrencyName { get; set; }
    public double CurrencyValue { get; set; }
    public string CurrencySymbol { get; set; }

    public string Show()
    {
        return $"CurrencyName: {CurrencyName} CurrencyValue: {CurrencyValue} Currency Symbol: {CurrencySymbol}";
    }
}

class Asset : Currency
{
     public DateTime EndOfLife { get; set; }
    public int LifeSpan { get; set; }
    public DateTime ExpireDate1 { get; set; }
    public DateTime ExpireDate2 { get; set; }
    public DateTime PurchaseDate { get; set; }

    public DateTime CalculateExireDate(DateTime purchaseDate, int expireAfterMonth)
    {
        DateTime end_date = purchaseDate.AddYears(LifeSpan);
        return end_date.AddMonths(expireAfterMonth);
    }

    public int ExpireLevel()
    {
        if (DateTime.Compare(DateTime.Now, ExpireDate1) < 0 )
        {
            return 0; // Ligger innanför lifespan
        }
        else if (DateTime.Compare(DateTime.Now, ExpireDate2) == -1)
        {
            return 1; // Ligger efter lifespan men före Expiredate2 6 månader
        }
        else 
        { 
            return 2; // Ligger efter lifespan och efer Expiredate2 6 månader
        }
    }
}


class Product : Asset
{
    public Product(string productName, string brand, string modelName, string officeCountry, int price, DateTime purchaseDate, int lifeSpan)
    {
        ProductName = productName;
        Brand = brand;
        ModelName = modelName;
        OfficeCountry = officeCountry;
        Price = price;
        PurchaseDate = purchaseDate;
        LifeSpan = lifeSpan;
        ExpireDate1 = CalculateExireDate(PurchaseDate.AddDays(-1), 3);
        ExpireDate2 = CalculateExireDate(PurchaseDate.AddDays(-1), 6);
    }
    public string ProductName { get; set; }
    public string Brand { get; set; }
    public string ModelName { get; set; }
    public int Price { get; set; }
    //         Console.WriteLine("Product".PadRight(10) + "Brand".PadRight(10) + "Model".PadRight(10) + "Office".PadRight(15) + "Price in USD".PadRight(13) + "Currency".PadRight(10) + "Local price");

    public void Show()
    {
        string bought = PurchaseDate.ToString("yy-MM-dd");
        string Expire1 = ExpireDate1.ToString("yy-MM.dd");
        string Expire2 = ExpireDate2.ToString("yy-MM.dd");
        switch (ExpireLevel())
        {
            case 0:
                Console.WriteLine($"{ProductName.PadRight(10)}{Brand.PadRight(10)}{ModelName.PadRight(18)}{OfficeCountry.PadRight(15)}{Price.ToString().PadRight(17)}{bought.PadRight(14)}");
                break;
            case 1:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{ProductName.PadRight(10)}{Brand.PadRight(10)}{ModelName.PadRight(18)}{OfficeCountry.PadRight(15)}{Price.ToString().PadRight(17)}{bought.PadRight(14)}");
                Console.ResetColor();
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{ProductName.PadRight(10)}{Brand.PadRight(10)}{ModelName.PadRight(18)}{OfficeCountry.PadRight(15)}{Price.ToString().PadRight(17)}{bought.PadRight(14)}");
                Console.ResetColor();
                break;
        }
    }
}
/*
class Computer : Asset
{
    public Computer(string modelName, int price, DateTime purchaseDate, int lifeSpan)
    {
        ModelName = modelName;
        Price = price;
        PurchaseDate = purchaseDate;
        //        OfficeCountry = officeCountry;
        //        CurrencyName = currencyName;
        LifeSpan = lifeSpan;
        ExpireDate1 = CalculateExireDate(PurchaseDate.AddDays(-1), 3);
        ExpireDate2 = CalculateExireDate(PurchaseDate.AddDays(-1), 6);
    }
    public string ModelName { get; set; }
    public int Price { get; set; }

    public void Show()
    {
        string bought = PurchaseDate.ToString("yy-MM-dd");
        string Expire1 = ExpireDate1.ToString("yy-MM.dd");
        string Expire2 = ExpireDate2.ToString("yy-MM.dd");
        switch (ExpireLevel())
        {
            case 0:
                Console.WriteLine($"Model: {ModelName} Price: {Price.ToString()} Purchase date: {bought} Expire date1: {Expire1} Expire date2: {Expire2}");
                break;
            case 1:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Model: {ModelName} Price: {Price.ToString()} Purchase date: {bought} Expire date1: {Expire1} Expire date2: {Expire2}");
                Console.ResetColor();
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Model: {ModelName} Price: {Price.ToString()} Purchase date: {bought} Expire date1: {Expire1} Expire date2: {Expire2}");
                Console.ResetColor();
                break;
        }
    }
}
*/
/*
class Mobile : Asset
{
    public Mobile(string modelName, int price, DateTime purchaseDate, int lifeSpan)
    {
        ModelName = modelName;
        Price = price;
        PurchaseDate = purchaseDate;
        LifeSpan = lifeSpan;
        ExpireDate1 = CalculateExireDate(PurchaseDate, 3);
        ExpireDate2 = CalculateExireDate(PurchaseDate, 6);
        //       OfficeCountry = officeCountry;
        //        CurrencyName = currencyName;
    }

    public string ModelName { get; set; }
    public int Price { get; set; }

    public string Show()
    {
        string bought = PurchaseDate.ToString("yy-MM-dd");
        string Expire1 = ExpireDate1.ToString("yy-MM.dd");
        string Expire2 = ExpireDate2.ToString("yy-MM-dd");
        
        return $"Model: {ModelName} Price: {Price.ToString()} Purchase date: {bought} Expire date1: {Expire1} Expire date2: {Expire2}";
    }
}

*/