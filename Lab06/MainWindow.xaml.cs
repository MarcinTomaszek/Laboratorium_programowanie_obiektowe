using System.Collections;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Lab06.Customer;

namespace Lab06;

public partial class Customer
{
    public string Adress { get; set; }
}
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        GenerateButtons(Panel);
        
        /*
        for (var enumerator = team.GetEnumerator(); enumerator.MoveNext();)
        {
            var member = enumerator.Current;
            
            Button button = new Button();
            button.Content = member;
            Panel.Children.Add(button);
        }
        */
        
        /*foreach (var member in team)
        {
            Button button = new Button();
            button.Content = member;
            Panel.Children.Add(button);
        }*/
        var customer = new Customer
        {
            Adress = "Kurvinox",
            Name = "Kurvinox",
            Id = 1
        };
    }
}


class Team:IEnumerable<string>
{
    public string Lead { get; set; }
    public string? Architect { get; set; }
    public string[] Testers { get; set; }
    public string[] Developers { get; set; }

    public int Length
    {
        get
        {
            return 1 + Testers.Length + Developers.Length + (Architect is null ? 0 : 1);
        }
    }
    public string this[int index]
    {
        get
        {
            switch (index)
            {
                case 1: return Lead;
                case 2: return Architect;
                default:
                    if (index > 2 && index <= Testers.Length + 2)
                    {
                        return Testers[index-3];
                    }
                    if (index > 2 +Testers.Length && index <= Developers.Length+Testers.Length + 2)
                    {
                        return Developers[index -3 - Testers.Length];
                    }

                    throw new IndexOutOfRangeException();
            }
        }
    }

    public class TeamEnumerator : IEnumerator<string>
    {
        private string[] _items;

        public TeamEnumerator(Team team)
        {
            int size = team.Testers.Length + team.Developers.Length+2+ (team.Architect == null ? 1 : 0);
            _items = new string[size];
            _items[0] = team.Lead;
            if (team.Architect == null)
            {
                for (int i = 0; i < team.Testers.Length; i++)
                {
                    _items[1 + i] = team.Testers[i];
                }
                for (int i = 0; i < team.Developers.Length; i++)
                {
                    _items[1 + team.Testers.Length + i] = team.Developers[i];
                }
            }
            else
            {
                _items[1] = team.Architect;
                for (int i = 0; i < team.Testers.Length; i++)
                {
                    _items[2 + i] = team.Testers[i];
                }
                for (int i = 0; i < team.Developers.Length; i++)
                {
                    _items[2 + team.Testers.Length + i] = team.Developers[i];
                }
            }
        }

        private int _index = -1;
        
        public bool MoveNext()
        {
            return ++_index < _items.Length;
        }

        public void Reset()
        {
            _index = -1;
        }

        public string Current
        {
            get
            {
                return _items[_index];
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            
        }
    }
    public IEnumerator<string> GetEnumerator()
    {
        /*return new TeamEnumerator(this);*/
        yield return Lead;
        if (Architect!=null)
        {
            yield return Architect;
        }

        foreach (var t in Testers)
        {
            yield return t;
        }
        
        foreach (var d in Developers)
        {
            yield return d;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}