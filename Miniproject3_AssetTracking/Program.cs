﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

// Define a display instance for managing console output
Display display = new Display();

// StringBuilders for user input and product details
StringBuilder sb = new StringBuilder();
StringBuilder input = new StringBuilder();
StringBuilder office = new StringBuilder();
StringBuilder product = new StringBuilder();
StringBuilder brand = new StringBuilder();
StringBuilder model = new StringBuilder();
StringBuilder officeCountry = new StringBuilder();
decimal priceInUSD = 0;
DateTime purchaseDate = new DateTime();
StringBuilder currencyName = new StringBuilder();
decimal currencyValue = 0;
StringBuilder currencySymbol = new StringBuilder();

// Array to control the menu flow
String[] menuFlag = new string[] { "TopMenu", "ProductMenu", "Brand", "Model", "Office", "Purchase date", "Price", "Done", "Exit?", "Exit" };

int flag = 0;
int writeOut = 0;
int count = 0;
int outputListCount = 0;
int lifeSpan = 3;
int exitFlag = menuFlag.Length - 2;
int price;
int milliseconds = 2000;

// Function to capitalize the first character of a string
string FirstCharToUpper(string input)
{
    return Regex.Replace(input, "^[a-z]", c => c.Value.ToUpper());
}

// Function to clear input-related variables
void clearInputVariables()
{
    product.Clear();
    brand.Clear();
    model.Clear();
    officeCountry.Clear();
    price = 0;
    currencyName.Clear();
    currencyValue = 0;
    currencySymbol.Clear();
    flag = 0;
    count = 0;
    sb.Clear();
    writeOut = 0;
    outputListCount = 0;
}

// Define console colors
ConsoleColor darkYelloe = ConsoleColor.DarkYellow;
ConsoleColor red = ConsoleColor.Red;
ConsoleColor green = ConsoleColor.Green;
ConsoleColor blue = ConsoleColor.Blue;
ConsoleColor yellow = ConsoleColor.Yellow;

// List to store currency information for different offices
List<Currency> officeList = new List<Currency>();
officeList.Add(new Currency("Sweden", "SEK", Convert.ToDecimal(10.5624), "sv-SE"));
officeList.Add(new Currency("Great Britain", "GBP", Convert.ToDecimal(0.806311), "en-GB"));
officeList.Add(new Currency("Germany", "EUR", Convert.ToDecimal(0.921532), "de-DE"));
officeList.Add(new Currency("Japan", "JPN", Convert.ToDecimal(151.286), "ja-JP"));
officeList.Add(new Currency("Norway", "NOK", Convert.ToDecimal(10.8085), "nb-NO"));
officeList.Add(new Currency("USA", "USD", Convert.ToDecimal(1.0), "en-US"));

// List to store product information
List<Product> productList = new List<Product>();

// Set the initial cursor position
display.SetCursurPos(0, 4);

// Main loop for user interaction
while (true)
{
    display.ShowMenu(yellow, sb.ToString(), 0, 2);

    // Display appropriate menu based on the current state
    if (menuFlag[flag].Equals("TopMenu") && writeOut == 0)
    {
        display.ShowMenu(blue, "To enter a new product - Follow the steps | to Quit enter [Q/q] [Quit] [Exit]", 0, 0);
        display.ShowMenu(green, "Choose >> [1] - Computer | [2] - Mobile", 0, 1);
        flag = 1;
    }
    if (menuFlag[flag].Equals("TopMenu") && menuFlag[exitFlag].Equals("Exit"))
    {
        display.ShowMenu(blue, "If you want to put in more products Press [1] >> Computer or [2] >> Mobile | to Quit enter [Q/q] [Quit] [Exit] Again", 0, 0);
//        display.ShowMenu(green, "Choose >> [1] - Computer | [2] - Mobile", 0, 1);
        flag = 1;
    }
    else if (menuFlag[flag].Equals("Brand"))
    {
        display.ShowMenu(green, "Input a Brand:", 0, 1);
    }
    else if (menuFlag[flag].Equals("Model"))
    {
        display.ShowMenu(green, "Input a Model:", 0, 1);
    }
    else if (menuFlag[flag].Equals("Office"))
    {
        office.Append("Input Office: ");
        foreach (Currency o in officeList)
        {
            count++;
            office.Append(" [" + count.ToString() + "] > " + o.OfficeCountry);
        }

        display.ShowMenu(green, office.ToString(), 0, 1);
        office.Clear();
    }
    else if (menuFlag[flag].Equals("Purchase date"))
    {
        office.Append("Input Purchase date - Format [yyyy-MM-dd]: ");
        display.ShowMenu(green, office.ToString(), 0, 1);
        office.Clear();
    }
    else if (menuFlag[flag].Equals("Price"))
    {
        office.Append("Input Price in Dollar: ");
        display.ShowMenu(green, office.ToString(), 0, 1);
        office.Clear();
    }
    
// Take user input
    input.Append(Console.ReadLine());

    // Check for exit command
    if (input.ToString().ToUpper() == "Q" || input.ToString().ToUpper() == "QUIT" || input.ToString().ToUpper() == "EXIT")
    {
        if (menuFlag[exitFlag].Equals("Exit"))
        {
            break;
        }
        exitFlag++;
    }
    // Process user input and update program state
    if (menuFlag[flag].Equals("ProductMenu") && !menuFlag[exitFlag].Equals("Exit"))
    {
        if (input.Equals("1"))
        {
            product.Append("Computer");
            sb.Append(product);
            flag = 2;
        }
        else if (input.Equals("2"))
        {
            product.Append("Mobile");
            sb.Append(product);
            flag = 2;
        }
        else
        {
            display.ShowMenu(red, "You must use [1] or [2] | Try again!", 0, 2);
            Thread.Sleep(milliseconds);
            display.ClearLine(0, 2);
            display.ShowMenu(green, "Choose >> [1] - Computer | [2] - Mobile", 0, 1);
        }
    }
    else if (menuFlag[flag].Equals("Brand") && input.Length > 0)
    {
        brand.Append(input);
        sb.Append(" " + brand);
        flag = 3;
    }
    else if (menuFlag[flag].Equals("Model") && input.Length > 0)
    {
        model.Append(input);
        sb.Append(" " + model);
        flag = 4;
    }
    else if (menuFlag[flag].Equals("Office") && input.Length > 0)
    {
        try
        {
            int index = Convert.ToInt32(input.ToString());
            display.ClearLine(0, 2);
            officeCountry.Append(officeList.ElementAt(index - 1).OfficeCountry);
            currencyName.Append(officeList.ElementAt(index - 1).CurrencyName);
            currencyValue = officeList.ElementAt(index - 1).CurrencyValue;
            sb.Append(" " + officeCountry);
            count = 0;
            flag = 5;
        }
        catch (FormatException e)
        {
            display.ShowMenu(red, $"You must write a number between 1 and {count} | Try again!", 0, 2);
            Thread.Sleep(milliseconds);
            display.ClearLine(0, 2);
            count = 0;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            display.ShowMenu(red, $"You have chosen a country we arent in!  | Try again!", 0, 2);
            Thread.Sleep(milliseconds);
            display.ClearLine(0, 2);
            count = 0;
        }
    }
    else if (menuFlag[flag].Equals("Purchase date") && input.Length > 0)
    {
        try
        {
            purchaseDate = Convert.ToDateTime(input.ToString());
            if (DateTime.Compare(DateTime.Now, purchaseDate) < 1)
            {
                display.ShowMenu(red, $"Date cant be in future | Try again!", 0, 2);
                Thread.Sleep(milliseconds);
                display.ClearLine(0, 2);
            }
            else
            {
                sb.Append(" " + purchaseDate.ToString("yyyy-MM-dd"));
                flag = 6;
            }
        }
        catch (FormatException e)
        {
            display.ShowMenu(red, $"Wrong format of Date | Try again!", 0, 2);
            Thread.Sleep(milliseconds);
            display.ClearLine(0, 2);
        }
    }
    else if (menuFlag[flag].Equals("Price"))
    {
        try
        {
            priceInUSD =  0.00M;
            priceInUSD = Convert.ToDecimal(Convert.ToInt32(input.ToString()));
            sb.Append(" " + priceInUSD.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("en-us")));
            flag = 7;
        }
        catch (FormatException e)
        {
            display.ShowMenu(red, $"You must write a number | Try again!", 0, 2);
            Thread.Sleep(milliseconds);
            display.ClearLine(0, 2);
        }
    }
        if (input.Length == 0)
    {
        display.ShowMenu(red, "You must write Text | Try again!", 0, 2);
        Thread.Sleep(milliseconds);
        display.ClearLine(0, 2);

    }
    if (menuFlag[flag].Equals("Done"))
    {
        int ListCount = productList.Count;
        productList.Add(new Product(product.ToString(), brand.ToString(), model.ToString(), officeCountry.ToString(), Convert.ToDecimal(priceInUSD), purchaseDate, lifeSpan, currencyName.ToString(), Convert.ToDecimal(currencyValue), currencySymbol.ToString()));
        if (ListCount < productList.Count)
        {
            display.ShowMenu(green, "Product added successfully", 0, 2);
            clearInputVariables();
            Thread.Sleep(milliseconds);
            display.ClearLine(0, 2);
        }
        else
        {
            display.ShowMenu(red, "Something went wrong when it should be added to List!", 0, 2);
            Thread.Sleep(milliseconds);
        }
    }
    if (menuFlag[exitFlag].Equals("Exit"))
    {
        Console.Clear();
        //        display.ClearLine(0, 2);
        //        display.ClearLine(0, 3);
        display.SetCursurPos(0, 3);

        List<Product> SortedproductListComputer = productList.OrderBy(Product => Product.ProductName).ThenBy(Product => Product.PurchaseDate).ToList();
        List<Product> SortedproductListOffice = productList.OrderBy(Product => Product.OfficeCountry).ThenBy(Product => Product.PurchaseDate).ToList();

        display.ShowMenu(green, "List products Sorted by Computer then Purchase date", 0, 2);
        display.SetCursurPos(0, 3);
        display.ShowCategory();
        display.SetCursurPos(0, 5);
        foreach (Product prod in SortedproductListComputer)
        {
            prod.Show();
            outputListCount++;
        }

        display.ShowMenu(green, "List products Sorted by Office then Purchase date", 0, 6 + outputListCount);
        display.SetCursurPos(0, 7 + outputListCount);
        display.ShowCategory();
        display.SetCursurPos(0, 9 + outputListCount);

        foreach (Product prod in SortedproductListOffice)
        {
            prod.Show();
        }

        display.ShowMenu(green, "Do you want to put in more products >> [Y/N]", 0, 0);
        
        do
        {
            input.Clear();
            input.Append(Console.ReadLine());

            if (input.ToString().ToUpper().Equals("Y"))
            {
                exitFlag = menuFlag.Length - 2;
                display.ClearLine(0, 2);
                clearInputVariables();
                break;
            }
            else if (input.ToString().ToUpper().Equals("N"))
            { 
            Environment.Exit(0);
            }
            else 
            {
                display.ShowMenu(red, "You must write [Y/N] | Try again!", 0, 2);
                Thread.Sleep(milliseconds);
                display.ClearLine(0, 2);
            }
        }
        while (true) ;
    }
    input.Clear();
}

// Display class for managing console output
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
    
    public void ClearOutputOnScreen()
    { 
        Console.Clear(); 
    }


    // Metods for set the positions
    public void SetCursurPos(int posX, int posY)
    {
        Console.SetCursorPosition(posX, posY);
    }

    public void ShowCategory()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Product".PadRight(10) + "Brand".PadRight(10) + "Model".PadRight(15) + "Office".PadRight(15) + "Purchase Date".PadRight(14) + "Price in USD".PadRight(17) + "Currency".PadRight(10) + "Local price");
        Console.WriteLine("-------".PadRight(10) + "-----".PadRight(10) + "-----".PadRight(15) + "------".PadRight(15) + "-------------".PadRight(14) + "------------".PadRight(17) + "--------".PadRight(10) + "-----------");
        Console.ResetColor();
    }

    public void ShowMenu(ConsoleColor menuColor, string menuText, int posX, int posY)
    {
        int len = menuText.Length;
        
        ClearLine(posX, posY);
        Console.ForegroundColor = menuColor;
        SetCursurPos(posX, posY);
        Console.WriteLine(menuText);
        Console.ResetColor();
        SetCursurPos(len + 1, posY);
    }
}

class Country
{
    public Country(string officeCountry)
    {
        OfficeCountry = officeCountry;
    }

    public string OfficeCountry { get; set; }
}

// Currency class to represent currency information
class Currency : Display
{
    public Currency()
    {
    }

    public Currency(string officeCountry, string currencyName, decimal currencyValue, string countryLangTag)
    {
        CurrencyName = currencyName;
        CurrencyValue = currencyValue;
        OfficeCountry = officeCountry;
        CountryLangTag = countryLangTag;
    }

    public string OfficeCountry { get; set; }
    public string CurrencyName { get; set; }
    public decimal CurrencyValue { get; set; }
    public string CountryLangTag { get; set; }

    public string Show()
    {
        return $"CurrencyName: {CurrencyName} CurrencyValue: {CurrencyValue} Currency Symbol: {CountryLangTag}";
    }
}

// Asset class representing an asset with additional information
class Asset : Currency
{
//    public DateTime EndOfLife { get; set; }
    public int LifeSpan { get; set; }
    public DateTime ExpireDate { get; set; }
    public DateTime ThreeMonthsBeforeExpireDate { get; set; }
    public DateTime SixMonthsBeforeExpireDate { get; set; }
    public DateTime PurchaseDate { get; set; }

    public DateTime CalculateExireDate(DateTime purchaseDate, int expireAfterMonth)
    {
        DateTime end_date = purchaseDate.AddYears(LifeSpan);
        return end_date.AddMonths(expireAfterMonth);
    }

    public int ExpireLevel()
    {

        if (DateTime.Now >= SixMonthsBeforeExpireDate && DateTime.Now < ThreeMonthsBeforeExpireDate)
        {
            return 2; // Located within 3 months of the end of the warranty
        }
        else if (DateTime.Now >= ThreeMonthsBeforeExpireDate)
        {
            return 1; // Located between 3 and 6 months before the end of the warranty
        }
        else
        {
            return 0; // Located more than 6 months before the end of the warranty or after the end of the warranty
        }
    }
}


class Product : Asset
{
    public Product(string productName, string brand, string modelName, string officeCountry, decimal price, DateTime purchaseDate, int lifeSpan, string currencyName, decimal currencyValue, string countryLangTag)
    { 
        ProductName = productName;
        Brand = brand;
        ModelName = modelName;
        OfficeCountry = officeCountry;
        Price = price;
        PurchaseDate = purchaseDate;
        LifeSpan = lifeSpan;
        CurrencyName = currencyName;
        CurrencyValue = currencyValue;
        CountryLangTag = countryLangTag;
        ExpireDate = CalculateExireDate(PurchaseDate, 0);
        ThreeMonthsBeforeExpireDate = CalculateExireDate(PurchaseDate, -3);
        SixMonthsBeforeExpireDate = CalculateExireDate(PurchaseDate, -6);
    }
    public string ProductName { get; set; }
    public string Brand { get; set; }
    public string ModelName { get; set; }
    public decimal Price { get; set; }

    public void Show()
    {
        string priceUSD = Price.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("en-us"));
        string localPrice = (Price * CurrencyValue).ToString("C2", System.Globalization.CultureInfo.GetCultureInfo(CountryLangTag));
        localPrice = localPrice + " " + CurrencyName;

        switch (ExpireLevel())
        {
            case 0:
                Console.WriteLine($"{ProductName.PadRight(10)}{Brand.PadRight(10)}{ModelName.PadRight(15)}{OfficeCountry.PadRight(15)}{PurchaseDate.ToString("yyyy-MM-dd").PadRight(14)}{priceUSD.PadRight(17)}{CurrencyName.PadRight(10)}{localPrice}");
                break;
            case 1:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{ProductName.PadRight(10)}{Brand.PadRight(10)}{ModelName.PadRight(15)}{OfficeCountry.PadRight(15)}{PurchaseDate.ToString("yyyy-MM-dd").PadRight(14)}{priceUSD.PadRight(17)}{CurrencyName.PadRight(10)}{localPrice}");
                Console.ResetColor();
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{ProductName.PadRight(10)}{Brand.PadRight(10)}{ModelName.PadRight(15)}{OfficeCountry.PadRight(15)}{PurchaseDate.ToString("yyyy-MM-dd").PadRight(14)}{priceUSD.PadRight(17)}{CurrencyName.PadRight(10)}{localPrice}");
                Console.ResetColor();
                break;
        }
    }
}
