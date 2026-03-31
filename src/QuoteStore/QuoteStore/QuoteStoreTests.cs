namespace QuoteStore;

[TestClass]
public class QuoteStoreTests
{
    [TestMethod]
    public void ApplyUpdate_AcceptsFreshUpdate_AndReturnsBestPrice()
    {

    }

    [TestMethod]
    public void ApplyUpdate_RejectsStaleUpdate_PerSymbolAndExchange()
    { 
    }

    [TestMethod]
    public void GetBestPrice_AggregatesAcrossExchanges()
    { 
    }

    [TestMethod]
    public void ApplyUpdate_RejectsInvalidQuote_BidGreaterThanAsk()
    {
       
    }
}