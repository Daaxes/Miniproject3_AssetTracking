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
