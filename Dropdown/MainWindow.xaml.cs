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

namespace Dropdown;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        canvas1.Kolor = Brushes.Aqua;

        List<Brush> brushes = new List<Brush>();
        brushes.Add(new SolidColorBrush(Colors.Blue));
        brushes.Add(new SolidColorBrush(Colors.Red));
        brushes.Add(new SolidColorBrush(Colors.Orange));
        brushes.Add(new SolidColorBrush(Colors.Yellow));
        brushes.Add(new SolidColorBrush(Colors.Green));
        brushes.Add(new SolidColorBrush(Colors.Brown));

        for (int i = 0; i < brushes.Count; i++)
        {
            KwadracikHandler kwHandler = new KwadracikHandler(brushes[i], 80, new System.Drawing.Point(10*i, 10*i));
            Rectangle rect = kwHandler.getRectangle();
            Canvas.SetZIndex(rect, i);
            if (i % 2 == 0)
            {
                canvas1.Children.Add(rect);
            }
            else
            {
                canvas2.Children.Add(rect);
            }
        }
    }
}