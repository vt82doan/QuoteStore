// QuoteStoreTests.cs
// Single-file solution: domain + store + MSTest tests 

namespace QuoteStore;

public record QuoteUpdate(string Symbol, string Exchange, long Sequence, decimal Bid, decimal Ask);

public record BestPrice(string Symbol, decimal BestBid, decimal BestAsk);

public interface IQuoteStore
{
    void ApplyUpdate(QuoteUpdate update);
    BestPrice? GetBestPrice(string symbol);
}

public sealed class QuoteStore : IQuoteStore
{
    public void ApplyUpdate(QuoteUpdate update)
    {
        throw new NotImplementedException();
    }

    public BestPrice? GetBestPrice(string symbol)
    {
        throw new NotImplementedException();
    }
}