using System.Windows.Controls;

namespace Lab06;

public partial class MainWindow
{
    public void GenerateButtons(StackPanel panel)
    {
        Team team = new Team()
        {
            Lead = "Adam",
            Architect = "Maciek",
            Testers = new[] { "Paweł", "Łukasz" },
            Developers = new[] { "Kacper", "Marcin" }
        };
        
        
        for (int i =1 ; i<= team.Length; i++)
        {
            Button button = new Button();
            button.Content = team[i];
            Panel.Children.Add(button);
        }

        info.Content = team[1];

    }
    
}