using NodaMoney;

namespace TestBoreholes.ExchangeService
{
    public interface IExchangeService
    {
        Money Convert(Money value);
    }
}
