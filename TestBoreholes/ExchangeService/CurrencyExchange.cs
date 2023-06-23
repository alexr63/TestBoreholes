namespace TestBoreholes.ExchangeService;

public class CurrencyExchange
{
    private Dictionary<string, decimal> exchangeRates;

    public CurrencyExchange()
    {
        exchangeRates = new Dictionary<string, decimal>();
    }

    public void SetExchangeRate(string currencyCode, decimal rate)
    {
        exchangeRates[currencyCode] = rate;
    }

    public decimal GetExchangeRate(string currencyCode)
    {
        if (exchangeRates.ContainsKey(currencyCode))
        {
            return exchangeRates[currencyCode];
        }

        throw new ArgumentException("Exchange rate not found for the currency code: " + currencyCode);
    }
}