using LabLib;

class Program
{
    private static List<string> names = new()
    {
        "Adam", "Ewa", "Robert", "Alicja", "Karol"
    };

    public static void Main(string[] args)
    {
        /*WhereAndSelectDemo();*/
        /*Ex1();*/
        /*Ex2();*/
        /*BoolLINQMethods();*/
        /*AgregateLINQDemo();*/
        SortLINQDemo();
    }

    public static void AgregateLINQDemo()
    {
        Console.WriteLine(names.Aggregate((acc, item) => $"{acc}, {item}"));

        var numbers = new List<int>()
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        };
        
        Console.WriteLine(numbers.Aggregate((a,i)=>a*i));
        Console.WriteLine(numbers.Min());
        Console.WriteLine(numbers.Max());
        Console.WriteLine(numbers.Average());
        
    }

    public static void SortLINQDemo()
    {
        var people = new List<Person>()
        {
            new("Adam", true),
            new("Tomasz", true),
            new("Ewa", false),
            new("Tomasz", false)
        };
        people.OrderBy(x => x.name)
            .ThenByDescending(x => x.isActive)
            .Print();
        names.OrderBy(x=>x.Length).Print();
    }
    private static void Ex1()
    {
        var lines = new List<string>()
        {
            "19", "23", "41", "51", "23"
        };


        lines.Select(x => Int32.Parse(x))
            .Print();
    }

    record Person(string name, bool isActive);

    private static void Ex2()
    {
        var lines = new List<string>()
        {
            "Adam\ttrue", "Ewa\tfalse", "Karol\ttrue", "Alicja\ttrue"
        };

        lines.Select(x => new Person(x.Split("\t")[0], bool.Parse(x.Split("\t")[1]))).Print();
    }

    public static void BoolLINQMethods()
    {
        if (names.Any())
        {
            Console.WriteLine("Non Empty");
        }

        if (!names.Any())
        {
            Console.WriteLine("Empty");
        }

        if (names.All(x => x.Length > 2))
        {
            Console.WriteLine("All names longer than 2 letter");
        }

        if (names.Any(x => x.EndsWith("a")))
        {
            Console.WriteLine("At least one name ends with a");
        }
        else
        {
            Console.WriteLine("Not even one name ends with a");
        }
    }

    private static void WhereAndSelectDemo()
    {
        /*names.Where(a=>a.Length==4).Print();*/
        names
            .Where(a => a.ToLower().Contains("o"))
            .Print();

        /*var boys = names.Where(a => !a.ToLower().EndsWith("a"));
        boys.Print();*/

        var boys = names.Where(IsBoy);
        boys.Print();
        boys.Select(a => a.Length).Print();
        boys.Select(x => (x, x.Length)).Print();

        names.Select(x => x.ToUpper()).Print();
    }

    public static bool IsBoy(string x)
    {
        Console.WriteLine("Where");
        return !x.EndsWith("a");
    }
}