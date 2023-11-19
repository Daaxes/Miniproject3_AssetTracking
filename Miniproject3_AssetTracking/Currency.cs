
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
