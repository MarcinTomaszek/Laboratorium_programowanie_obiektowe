using System.ComponentModel;
using AggregateException = System.AggregateException;

namespace Lab01Task01;
//Marcin Tomaszek 15232

public enum WeightUnits
{
    G=1,
    DAG=10,
    KG=1000,
    T=1000000,
    LB=(int)453.59237,
    OZ=WeightUnits.LB/16
}

public class Weight:IEquatable<Weight>, IComparable<Weight>
{
    public double Value { get; init; }
    public WeightUnits Unit { get; init; }
    
    private double UnitValue{ 
        get
        {
            switch(Unit){
                case WeightUnits.G:
                    return 1;
                case WeightUnits.DAG:
                    return 10;
                case WeightUnits.KG:
                    return 1_000;
                case WeightUnits.T:
                    return 1_000_000;
                case WeightUnits.LB:
                    return 453.59237;
                case WeightUnits.OZ:
                    return 28.3495;
                default:
                    throw new ArgumentException("Invalid unit");
            }
        } 
    }
    private Weight()
    {
        
    }
    public static Weight Of(double val, WeightUnits uni)
    {
        if (val < 0)
            throw new ArgumentException("Ivalid value");
        return new Weight(){Value = val, Unit = uni};
            
    }
    public static Weight Parse(string item)
    {
        if(!double.TryParse(item.Split(" ")[0], out double val)){
            throw new ArgumentException("Niepoprawny format liczby określającej masę!");
        }
        if(val<0){
            throw new ArgumentException("Ujemna wartość masy!");
        }
        WeightUnits.TryParse(item.Split(" ")[0].ToUpper(), out  WeightUnits uni);
        return Weight.Of(val, uni);
    }
    private double ToGram()
    {
        return Math.Round(Value*UnitValue,6);
    }
    public bool Equals(Weight other)
    {
        return ToGram() == other.ToGram();
    }
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Weight)obj);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Value, (int)Unit);
    }
    public int CompareTo(Weight? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        return Math.Round(ToGram(),2).CompareTo(Math.Round(other.ToGram(),2));
    }

    public static bool operator >(Weight x, Weight y)
    {
        return Math.Round(x.ToGram(), 4) > Math.Round(y.ToGram(), 4);
        
    }

    public static bool operator <(Weight x, Weight y)
    {
        return Math.Round(x.ToGram(),4) < Math.Round(y.ToGram(),4);
    }

    public static bool operator ==(Weight x, Weight y)
    {
        return Math.Round(x.ToGram(),2) == Math.Round(y.ToGram(),2);
    }

    public static bool operator !=(Weight x, Weight y)
    {
        return !(x == y);
    }
}

