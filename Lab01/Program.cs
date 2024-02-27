using System;

class Program
{
    static void Main()
    {
        var s1 = Console.ReadLine();
        var s2 = Console.ReadLine();

        if (int.TryParse(s1, out var a) && int.TryParse(s2, out var b))
        {
            Console.WriteLine(a + b);
        }
        else
        {
            Console.WriteLine("Invalid number format");
        }
    }

       static void Main2(string[] args)
       {
           if (args.Length < 2)
           {
               Console.WriteLine("Invalid number of parameters");
               return;
           }

           if (int.TryParse(args[0], out var a) && int.TryParse(args[1], out var b))
           {
               Console.WriteLine(a + b);
           }
           else
           {
               Console.WriteLine("Invalid number format");
           }
       }
}