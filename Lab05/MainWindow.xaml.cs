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

namespace Lab05;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    private int _counter = 0;
    public MainWindow()
    {
        InitializeComponent();

        Units.ItemsSource = Enum.GetNames<LengthUnit>();
        UnitsTarget.ItemsSource = Enum.GetNames<LengthUnit>();
    }



    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
    }

    private void Result_OnClick(object sender, RoutedEventArgs e)
    {
        if (Double.TryParse(value.Text, out var parsed))
        {
            if (Enum.TryParse<LengthUnit>((string)Units.SelectedItem, out var sourceUnit))
            {
                if (Enum.TryParse<LengthUnit>((string)UnitsTarget.SelectedItem, out var targetUnit))
                {
                    result.Content = (decimal)parsed * sourceUnit.ToDecimal() / targetUnit.ToDecimal();
                }
            }
        }
    }
}