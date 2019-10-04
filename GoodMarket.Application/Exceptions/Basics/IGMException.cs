namespace GoodMarket.Application.Exceptions.Basics
{
    /// <summary>
    /// Интерфейс-метка кастомных исключений IGMException
    /// </summary>
    public interface IGMException
    {
        int ResponseCode { get; }
    }
}
