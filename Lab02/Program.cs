using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;

namespace Lab01;

public class Program
{
    public static void Main(string[] args)
    {
        Money m1 = Money.Of(10.4m, Currency.PLN);
        Money m2 = Money.Of(120.4m, Currency.PLN);
        Money m3 = m1 + m2;
        Console.WriteLine(m3);
    }

    public enum Currency
    {
        USD = 1,
        EUR = 2,
        PLN = 3
    }

    public class Money : IEquatable<Money>, IComparable<Money>
    {
        public decimal Value { get; init; }
        public Currency Currency;

        private Money()
        {
        }

        public static Money Of(decimal Value, Currency currency)
        {
            if (Value <= 0)
                throw new ArgumentException("Invalid Value");
            return new Money() { Value = Value, Currency = currency };
        }

        // alt + insert  Formating members

        public override string ToString()
        {
            return $"{nameof(Currency)}: {Currency}, {nameof(Value)}: {Value}";
        }

        public static Money operator +(Money a, Money b)
        {
            IsSameCurrencies(a, b);
            return Money.Of(a.Value + b.Value, a.Currency);
        }

        private static void IsSameCurrencies(Money a, Money b)
        {
            if (a.Currency != b.Currency)
                throw new ArgumentException("Currency not equal");
        }

        public static bool operator ==(Money a, Money b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Money a, Money b)
        {
            return !(a == b);
        }

        public static bool operator <(Money a, Money b)
        {
            IsSameCurrencies(a, b);
            return a.Value < b.Value;
        }

        public static bool operator >(Money a, Money b)
        {
            IsSameCurrencies(a, b);
            return a.Value > b.Value;
        }


        public bool Equals(Money other)
        {
            return Currency == other.Currency && Value == other.Value;
        }

        public int CompareTo(Money? other)
        {
            if (other is null)
            {
                return 1;
            }

            IsSameCurrencies(this, other);
            return decimal.Compare(this.Value, other.Value);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Money)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine((int)Currency, Value);
        }
    }

    public class Product
    {
        public int Id { get; set; }
        private string _name;

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Price)}: {Price}";
        }

        public string Name
        {
            get => _name;
            init
            {
                if (value.Length > 1)
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentException("Invalid Name");
                }
            }
        }

        public decimal Price { get; init; }

        private Product()
        {
        }

        public static Product Of(string Name, decimal Price)
        {
            if (Name.Length < 2)
                throw new ArgumentException("Name can not be empty");
            if (Price <= 0)
                throw new ArgumentException("Ivalid Price");
            return new Product() { Name = Name, Price = Price };
        }
    }
}