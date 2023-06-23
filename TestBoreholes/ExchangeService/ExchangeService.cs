using NodaMoney;
using ExchangeRate = NodaMoney.ExchangeRate;

namespace TestBoreholes.ExchangeService
{
    public class ExchangeService : IExchangeService
    {
        readonly CurrencyExchange _currencyExchange = new CurrencyExchange();

        public ExchangeService()
        {
            _currencyExchange.SetExchangeRate("USD", 1.18m);
            _currencyExchange.SetExchangeRate("EUR", 1.09m);
            _currencyExchange.SetExchangeRate("NGN", 0.0012m);
        }

        public Money Convert(Money value)
        {
            if (value.Currency == Currency.FromCode("USD"))
            {
                return value;
            }

            var rate = _currencyExchange.GetExchangeRate(value.Currency.Code); ;
            var exchangeRate = new ExchangeRate(value.Currency, Currency.FromCode("GBP"), rate);
            return exchangeRate.Convert(value);
        }
    }
}
