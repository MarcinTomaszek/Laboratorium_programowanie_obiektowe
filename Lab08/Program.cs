using System.Net.Sockets;

internal class Program
{
    private static List<string> names = new()
    {
        "Adam", "Karol", "Ewa", "Robert", "Alicja"
    };

    class Player
    {
        public string Name { get; set; }
        public int Points { get; set; }
    }

    public static void Main(string[] args)
    {
        /*names.Print();
        Find3LetterNames(names).Print();
        FindNamesStartingWithA(names).Print();*/
        FilterNamesPredicate(names, Is3Letters).Print();
        FilterNamesPredicate(names, IsStartWithA).Print();
        FilterNamesPredicate(names, a => a.Length % 2 == 0).Print();

        Calculate(1, 5, Div); 
        Calculate(1, 5,  (a,  b) =>  a * b );
        ActionPredicateDemo();
        FuncDelegateDemo();
    }

    public static List<string> FilterNames(List<string> items, StringFilter filter)
    {
        List<string> res = new();
        foreach (var item in items)
        {
            if (filter(item))
            {
                res.Add(item);
            }
        }
        return res;
    }

    public static List<string> FilterNamesPredicate(List<string> items, Predicate<string> filter)
    {
        List<string> res = new();
        foreach (var item in items)
        {
            if (filter(item))
            {
                res.Add(item);
            }
        }
        return res;
    }


    public static void ActionPredicateDemo()
    {
        Action<string> print = toPrint => Console.WriteLine(toPrint);
        print("Marcin");
        Action<int, string> repeat = (t, s) =>
        {
            for(int i=0;i<t;i++)
            {
                print(s);
            }
        };


        repeat(5, "hej");
    }

    public static void FuncDelegateDemo()
    {
        Func<double, double, double> binaryOp = (d, d1) => d + d1;
        Console.WriteLine(binaryOp(4,5));
        
        binaryOp = (d, d1) => d * d1;
        Console.WriteLine(binaryOp(4,5));
        
        binaryOp = (d, d1) => d / d1;
        Console.WriteLine(binaryOp(4,5));
        
        Func<double, double> power = d => d*d;
        Console.WriteLine(power(4));

        Func<string, double> parser = a => double.Parse(a);
        Console.WriteLine(parser("1234,5"));

        Func<string, Player> mapper = str =>
        {
            return new Player()
            {
                Name = str.Split(";")[0],
                Points = int.Parse(str.Split(";")[1])
            };
        };
        
        
        
        
    }
    public static void Calculate(double a, double b, BinaryOperator operation)
    {
        Console.WriteLine(operation(a, b));
    }

    public static bool IsStartWithA(string item)
    {
        return item.ToUpper().StartsWith("A");
    }

    public static bool Is3Letters(string item)
    {
        return item.Length == 3;
    }

    public static double Sum(double a, double b)
    {
        return a + b;
    }
    public static double Mult(double a, double b)
    {
        return a * b;
    }
    public static double Div(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException();
        return a / b;
    }
    public static double Sub(double a, double b)
    {
        return a - b;
    }

}

static class CollectionExtensions
{
    public static void Print<T>(this IEnumerable<T> items)
    {
        Console.WriteLine(string.Join(", ",items));
    }
}

delegate bool StringFilter(string item); 
delegate double BinaryOperator(double a,double b);