
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
