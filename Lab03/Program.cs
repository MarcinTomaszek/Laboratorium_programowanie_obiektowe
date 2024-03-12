internal class Program
{
    public static void Main(string[] args)
    {
        List<Shape> picture = new List<Shape>();
        picture.Add(new Rectangle() { Width = 34, Height = 45 });
        picture.Add(new Rectangle() { Width = 12, Height = 23 });
        picture.Add(new Circle() { Radius = 10 });
        


        static void CalculateAreas(List<Shape> shapes)
        {
            double res = 0;

            foreach (var i in shapes)
            {
                res += i.Area;
            }

            Console.WriteLine($"Full area{res}");
        }

        CalculateAreas(picture);
    }
}


public abstract class Shape
{
    public abstract double Area { get; }
    public int color { get; set; }
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public override double Area
    {
        get => Width * Height;
    }
}

class Circle : Shape
{
    public double Radius { get; set; }

    public override double Area
    {
        get => Math.PI * Radius * Radius;
    }
}

class Airplane : IFlyable
{
    public bool IsFuel { get; set; }
    public void TakeOff()
    {
        if (IsFuel)
        {
            Console.WriteLine("Airplane taking off");
        }
        else
        {
            throw new Exception();
        }
    }

    public void Fly(int distance)
    {
        throw new NotImplementedException();
    }

    public void Land()
    {
        throw new NotImplementedException();
    }
}

public class Duck : IFlyable
{
    public bool IsAlive { get; set; }

    public void TakeOff()
    {
        if (IsAlive)
        {
            Console.WriteLine("Duck taking off");
        }
        else
        {
            throw new Exception();
        }
    }

    public void Fly(int distance)
    {
        throw new NotImplementedException();
    }

    public void Land()
    {
        throw new NotImplementedException();
    }
}

public interface IFlyable
{
    void TakeOff();
    void Fly(int distance);
    void Land();
}