
using System.Collections;
using System.Drawing;
using System.Security.Cryptography;

class Program
{
    public static void Main(string[] args)
    {
        IList<string> names = new List<string>() { "Adam", "Ewa", "Karol" };
        names.Add("Robert");
        names.Remove("Ewa");
        names.RemoveAt(0);
        Console.WriteLine(string.Join(" ",names ));
        
        names[0] = "Ewa";
        names.Add("Beata");
        Console.WriteLine(string.Join(" ",names ));
        
        (names[0], names[names.Count - 1]) = (names[names.Count - 1], names[0]);
        Console.WriteLine(string.Join(" ",names ));
        
        names.Insert(0,names[names.Count-1]);
        names.RemoveAt(names.Count-1);
        Console.WriteLine(string.Join(" ",names ));

        string[] arr = { "b", "a", "c" };
        LinkedList<string> linked = new LinkedList<string>(arr);
        var first = linked.First;
        Console.WriteLine(first.Value);

        linked.AddAfter(linked.First, new LinkedListNode<string>("z"));
        Console.WriteLine(string.Join(" ",linked ));

        List<Player> players = new List<Player>()
        {
            new() { Id = 1, Name = "Adam", Points = 123 },
            new() { Id = 2, Name = "Karol", Points = 111 },
            new() { Id = 3, Name = "Ania", Points = 142 },
            new() { Id = 1, Name = "Adam", Points = 123 }
        };

        int index = players.IndexOf(new Player() { Id = 3 });
        Console.WriteLine(index);

        foreach (var player in players)
        {
            if (player.Name.StartsWith("a") || player.Name.StartsWith("A"))
            {
                Console.WriteLine(player);
            }
        }

        ISet<Player> room = new HashSet<Player>(players);
        Console.WriteLine(string.Join(" ||| ",room ));

        room.Add(new Player
        {
            Id = 5,
            Name = "Maciek",
            Points = 12332
        });
        Console.WriteLine(string.Join(" ||| ",room ));
        
        Console.WriteLine(room.Contains(new Player(){Id = 1}));

        ISet<Player> team = new HashSet<Player>();
        team.Add(players[1]);
        team.Add(new Player
        {
            Id = 6,
            Name = "Paweł",
            Points = 1251
        });

        var intersect = new HashSet<Player>(room).Intersect(team);
        Console.WriteLine(string.Join(" ||| ",intersect ));

        ISet<string> sortedNames = new SortedSet<string>(names);
        sortedNames.Add("Alicja");
        Console.WriteLine(string.Join(" ||| ",sortedNames ));
        
        ISet<Player> sortedPlayers = new SortedSet<Player>(players);
        Console.WriteLine(string.Join(" ||| ",sortedPlayers ));

        IDictionary<string, Player> playersDictionary = new Dictionary<string, Player>();
        playersDictionary.Add("adam@wsei.gmail.com",players[0]);
        playersDictionary.Add("karol@wsei.com",players[1]);
        playersDictionary.Add("ania@gmail.pl",players[2]);
        
        Console.WriteLine(playersDictionary["ania@gmail.pl"]);
        var ania = playersDictionary["ania@gmail.pl"];
        ania = new Player
        {
            Id = ania.Id,
            Name = ania.Name,
            Points = ania.Points + 10
        };
        playersDictionary["ania@gmail.pl"] = ania;
        Console.WriteLine(playersDictionary["ania@gmail.pl"]);
    }
    
}

public class Player:IComparer<Player>, IComparable<Player>
{
    
    public override string ToString()
    {
        return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Points)}: {Points}";
    }

    protected bool Equals(Player other)
    {
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Player)obj);
    }

    public override int GetHashCode()
    {
        return Id;
    }

    public int Id { get; init; }
    public string Name { get; init; }
    public int Points { get; init; }

    public int Compare(Player x, Player y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (ReferenceEquals(null, y)) return 1;
        if (ReferenceEquals(null, x)) return -1;
        return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
    }

    public int CompareTo(Player? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        return string.Compare(Name, other.Name, StringComparison.Ordinal);
    }
}

