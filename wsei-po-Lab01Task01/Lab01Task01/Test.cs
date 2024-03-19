namespace Lab01Task01;

public record TestCase(string title, string failMessage, string successMessage, Func<bool> testCase, int points)
{
    public int RunTestCase()
    {
        Console.WriteLine("****************************************************************************");
        Console.WriteLine($"{title}");
        if (testCase.Invoke())
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Test passed! {successMessage}");
            Console.ForegroundColor = ConsoleColor.White;
            return points;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Test failed! {failMessage}");
            Console.ForegroundColor = ConsoleColor.White;
            return 0;
        }
    }
}

public class Test
{
    private readonly List<TestCase> _cases = new List<TestCase>();

    public void AddCase(TestCase testCase)
    {
        _cases.Add(testCase);
    }

    public void RunAllCases()
    {
        var list = _cases.Select(test =>
            test.RunTestCase()
        ).ToList();
        Console.WriteLine("****************************************************************************");
        Console.WriteLine($"Łączna liczba punktów: {list.Sum()}");
    }
}