# Pair Programming Task

We will spend part of the interview on a short coding exercise in C#/.NET.

## Problem

Implement a small in-memory quote aggregation component.
You will receive quote updates in the following form:

```json
{
  "symbol": "AAPL",
  "exchange": "X1",
  "sequence": 10,
  "bid": 187.12,
  "ask": 187.15
}
```

Your task is to implement a component that:
- accepts quote updates
- stores only the latest valid quote for each `symbol + exchange`
- rejects stale updates using sequence numbers
- returns the best bid and best ask for a symbol across all exchanges

## Rules

A quote update is valid only if:
- `symbol` is not null or empty
- `exchange` is not null or empty
- `sequence > 0`
- `bid > 0`
- `ask > 0`
- `bid <= ask`

For each unique `symbol + exchange`, only accept an update if its sequence is strictly greater than the last accepted sequence.
Examples:
- last sequence = 10, incoming = 11 → accept
- last sequence = 10, incoming = 10 → reject
- last sequence = 10, incoming = 9 → reject

For a given symbol:
- best bid = highest bid across all latest accepted exchange quotes
- best ask = lowest ask across all latest accepted exchange quotes

If no quotes exist for a symbol, you may return `null` or another clearly defined “not found” result.

## Suggested interface
```csharp
public record QuoteUpdate(string Symbol, string Exchange, long Sequence, decimal Bid, decimal Ask);

public record BestPrice(string Symbol, decimal BestBid, decimal BestAsk);

public interface IQuoteStore
{
    void ApplyUpdate(QuoteUpdate update);
    BestPrice? GetBestPrice(string symbol);
}
```

## Example

Given these updates:

```csharp
{ "symbol": "AAPL", "exchange": "X1", "sequence": 1, "bid": 100.0, "ask": 101.0 }
{ "symbol": "AAPL", "exchange": "X2", "sequence": 1, "bid": 100.5, "ask": 101.5 }
{ "symbol": "AAPL", "exchange": "X1", "sequence": 2, "bid": 101.0, "ask": 102.0 }
```

Then the latest accepted quotes are:

- X1 → 101.0 / 102.0
- X2 → 100.5 / 101.5

So the result for `AAPL` is:

- best bid = `101.0`
- best ask = `101.5`

This update should be rejected as stale:

```json
{ "symbol": "AAPL", "exchange": "X1", "sequence": 1, "bid": 99.0, "ask": 100.0 }
```

## Notes

- Focus on the core logic first
- If time permits, add 1–2 unit tests
- We are more interested in code clarity, correctness, and reasoning than in a full production-ready API