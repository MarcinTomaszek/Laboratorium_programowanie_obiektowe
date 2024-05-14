namespace LabLib;

internal class Program
{
    public static int totalSum = 0;
    private static Mutex mutex = new Mutex();
    public static void Main(string[] args)
    {
        /*Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        
        var inputThread = new Thread(() =>
        {
            while (true)
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                string option = Console.ReadLine();
                if (option == "q")
                {
                    Environment.Exit(0);
                }
            }
        }); 
        
        inputThread.Start();
        while (true)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        */

        SharedVariableDemo();
    }

    public static void SharedVariableDemo()
    {
        var e=Enumerable.Range(0, 100).Select(i=>1);
        var t1 = new Thread(() => SumTask(e));
        var t2 = new Thread(() => SumTask(e));
        var t3 = new Thread(() => SumTask(e));
        t1.Start();
        t2.Start();
        t3.Start();
        t1.Join();
        t2.Join();
        t3.Join();
        Console.WriteLine(totalSum);
    }

    public static void SumTask(IEnumerable<int> ints)
    {
       
        foreach (var i in ints)
        {
            //wzajemne wykluczanie 
            if (mutex.WaitOne())
            {
                totalSum += i;
                mutex.ReleaseMutex();
            }
            
        }

    }
    
    public static void TaskDemo()
    {
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        Task.Run(() =>
        {
            while (true)
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                Console.Write(".");
            }
        });
        Console.ReadLine();
    }


    public static void Ex1()
    {
        string[] signs = { "-", "\\", "|", "/" };
        var inputThread = new Thread(() =>                               
        {                                                                
            while (true)
            {
                if (Console.ReadLine() == "") ;                                       
                {                                                        
                    Environment.Exit(0);                                 
                }                                                        
            }                                                            
        });
        inputThread.Start();

        while (true)
        {
            foreach (var i in signs)
            {
                Thread.Sleep(200);
                Console.SetCursorPosition(0,0);
                Console.Write(i);
            }
        }

    }

    public static void TaskWithReturnValueDemo()
    {
        Task<int> sumTask = Task<int>.Run(() =>
        {
            //Thread.Sleep(2000);
            Task.Delay(2000).Wait();
            return 100;
        });
        sumTask.GetAwaiter().OnCompleted(()=>Console.WriteLine(sumTask.Result));
        Console.WriteLine("End");


    }
}