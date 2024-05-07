namespace LabLib;

public static class EnumerableExtension
{
    public static void Print<T>(this IEnumerable<T> items)
    {
        Console.WriteLine(string.Join("\n", items));
    }
}