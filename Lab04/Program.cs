internal class Program
{
    public static void Main(string[] args)
    {
        IntNode head = new IntNode() { Data = 5 ,Next = new IntNode(){Data = 7,Next = new IntNode(){Data = 2}}};
        Node<string> names = new Node<string>() { Data = "Adam" };
        WseiStack<string> stack = new WseiStack<string>();
        stack.Push("Adam");
        stack.Push("Ewa");
        stack.Push("Karol");
        Console.WriteLine(stack.Pop());
        
        WseiStack<double> numbers = new WseiStack<double>();
        numbers.Push(2.5);
        numbers.Push(4.4);
        numbers.Push(6.4);

        double res = 0;
        while (!numbers.IsEmpty())
        {
            res += numbers.Pop();
        }
        Console.WriteLine(res);
        
        PizzaBox<PepperoniPizza> box = new();
        box.Content = new PepperoniPizza() { Ingredients = new[] { "pepperoni", "tomato" } };
        box.Print();

        var r= GirlsAndBoys(new[] { "Adam", "Ewa", "Anna", "Karol" });
        Console.WriteLine($"Girls={r.Item1} , Boys={r.Item2}");
    }
    public static (int,int) GirlsAndBoys(IEnumerable<string> names)
    {
        int total = 0;
        int girls = 0;
        foreach (var name in names)
        {
            ++total;
            if(name.ToLower()[name.Length-1]=='a')
            {
                girls++;
            }
        }

        return  (girls, total - girls);
    }

}



class PizzaBox<T> where T:Pizza, new()
{
    public T Content { get; set; } = new T(){Ingredients = new[]{"parmigiano reggiano","chesse"} };

    public void Print()
    {
        Console.WriteLine(string.Join(",",Content.Ingredients));
    }
}

class Pizza
{
    public string [] Ingredients { get; set; }
    
}

class PepperoniPizza : Pizza
{
    
}

class WseiStackArray<T> : IWseiStack<T>
{
    private T[] _array = new T[100];
    private int _last = -1;

    public void Push(T item)
    {
        if (_last < _array.Length-1)
        {
            _array[++_last] = item;
        }
        else
        {
            throw new Exception("Stack is full");
        }
    }

    public T Pop()
    {
        if (_last > -1)
        {
            return _array[_last--];
        }
        else
        {
            throw new Exception("Stack is empty");
        }
    }

    public bool IsEmpty()
    {
        return _last < 0;
    }
}
interface IWseiStack<T>
{
    void Push(T item);
    T Pop();

}

class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }
    
}
class WseiStack<T>:IWseiStack<T>
{
    private Node<T>? _top;
    
    public void Push(T item)
    {
        _top = new Node<T>() { Data = item, Next = _top };
    }

    public T Pop()
    {
        if (_top is null)
        {
            throw new Exception("Stack is empty");
        }

        var data = _top.Data;
        _top = _top.Next;
        return data;
    }

    public bool IsEmpty()
    {
        return _top == null;
    }
}

class IntNode
{
    public int Data { get; set; }
    public IntNode Next { get; set; }
    
}

class StringNode
{
    public string Data { get; set; }
    public StringNode Next { get; set; }
}