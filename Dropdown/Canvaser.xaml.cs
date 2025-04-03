using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Security.AccessControl;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Dropdown;

public partial class Canvaser : UserControl
{
    public ObservableCollection<UIElement> Children { get; } = new ObservableCollection<UIElement>();
    public Canvaser()
    {
        InitializeComponent();
        Kolor = Brushes.Black;
        
        Children.CollectionChanged += ChildrenOnCollectionChanged;
        
        theCanvas.Drop += OnDragOver;
        
        theCanvas.DragLeave += OnDragLeave;
        
        theCanvas.DragOver += ContinueDrag;
        
        theCanvas.DragEnter += OnDragEnter;
    }

    private void OnDragEnter(object sender, DragEventArgs e)
    {
        e.Handled = true;
        UIElement? element = e.Data.GetData(DataFormats.Serializable) as UIElement;
        if (element != null)
        {
            if( element is UIElement)
                if (!theCanvas.Children.Contains(element))
                {
                    theCanvas.Children.Add(element);
                }
        }
    }

    private void ContinueDrag(object sender, DragEventArgs e)
    {
        e.Handled = true;
        Point location = e.GetPosition(theCanvas);
        UIElement? element = e.Data.GetData(DataFormats.Serializable) as UIElement;
        if (element != null)
        {
            Canvas.SetLeft(element, location.X);
            Canvas.SetTop(element, location.Y);
        }
    }

    private void OnDragLeave(object sender, DragEventArgs e)
    {
        UIElement? element = e.Data.GetData(DataFormats.Serializable) as UIElement;
        if (theCanvas.Children.Contains(element))
        {
            theCanvas.Children.Remove(element);
        }
    }

    private void OnDragOver(object sender, DragEventArgs e)
    {
        e.Handled = true;
        Point location = e.GetPosition(theCanvas);
        UIElement? element = e.Data.GetData(DataFormats.Serializable) as UIElement;
        if (element != null)
        {
            Canvas.SetLeft(element, location.X);
            Canvas.SetTop(element, location.Y);
        }
        
    }

    private void ChildrenOnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
        {
            foreach (UIElement item in e.NewItems)
            {
                theCanvas.Children.Add(item);
            }
        }

        if (e.OldItems != null)
        {
            foreach (UIElement item in e.NewItems)
            {
                theCanvas.Children.Remove(item);
            }
        }
    }

    public static readonly DependencyProperty KolorProperty =
        DependencyProperty.Register(nameof(Kolor), typeof(Brush), typeof(Canvaser), new PropertyMetadata(Brushes.Transparent));

    public Brush Kolor
    {
        get
        {
            return (Brush)GetValue(KolorProperty);
        }
        set {
            SetValue(KolorProperty, value);
            theCanvas.Background = value;
        }
    } 
}