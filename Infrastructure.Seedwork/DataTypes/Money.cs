using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using CSharpFunctionalExtensions;

namespace Infrastructure.Seedwork.DataTypes;

[DebuggerDisplay("{Amount} {Currency.Key}")]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class Money : ValueObject<Money>
{
    private const byte AmountDecimals = 2;

    public decimal Amount { get; protected init; }

    public Currency Currency { get; protected init; } = null!;

    protected Money()
    {
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        return obj.GetType() == GetType() && EqualsCore((Money)obj);
    }

    protected override bool EqualsCore(Money other)
    {
        return Equals(Currency, other.Currency) && Amount == other.Amount;
    }

    protected override int GetHashCodeCore()
    {
        return HashCode.Combine(Amount, Currency);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (Currency.GetHashCode() * 397) ^ Amount.GetHashCode();
        }
    }

    public static Money KGS(decimal amount)
    {
        if (amount < 0)
            throw new ArgumentException("Amount must be greater than 0");

        amount = Math.Round(amount, AmountDecimals);

        return new Money
        {
            Amount   = amount,
            Currency = Currency.KGS
        };
    }

    public static Money KZT(decimal amount)
    {
        if (amount < 0)
            throw new ArgumentException("Amount must be greater than 0");

        amount = Math.Round(amount, AmountDecimals);

        return new Money
        {
            Amount   = amount,
            Currency = Currency.KZT
        };
    }

    public static Money Create(decimal amount, Currency currency)
    {
        if (amount < 0)
            throw new ArgumentException("Amount must be greater than 0");

        return new Money
        {
            Amount   = Math.Round(amount, AmountDecimals),
            Currency = currency
        };
    }

    public static bool operator ==(Money x, Money y)
    {
        return x.EqualsCore(y);
    }

    public static bool operator !=(Money x, Money y)
    {
        return !x.EqualsCore(y);
    }
}