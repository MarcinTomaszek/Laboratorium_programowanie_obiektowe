namespace Lab03.Restaurant;

public class Menu
{
    public DateOnly Published { get; init;}
    public List<MenuItem> Items { get; set; }
    public List<Order> Orders { get; set; }

    public void PrintMenu()
    {
        
    }
    
    
}