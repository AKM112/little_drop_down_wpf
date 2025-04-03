using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Point = System.Drawing.Point;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace Dropdown;

public class KwadracikHandler
{
    private Rectangle rectangle;

    public Rectangle getRectangle()
    {
        return rectangle;
    }
    public KwadracikHandler(Brush brush, double width, Point position)
    {
        rectangle = new Rectangle();
        rectangle.Width = width;
        rectangle.Height = width;
        rectangle.Fill = brush;
        
        setPos(position);

        rectangle.IsHitTestVisible = true;
        rectangle.MouseMove += RectangleOnMouseMove;
    }

    private void RectangleOnMouseMove(object sender, MouseEventArgs e)
    {   
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            rectangle.IsHitTestVisible = false;
            var drag = DragDrop.DoDragDrop(rectangle, new DataObject(DataFormats.Serializable, rectangle), DragDropEffects.Move);
            rectangle.IsHitTestVisible = true;
        }
    }

    public void setPos(Point position)
    {
        Canvas.SetLeft(rectangle, position.X);
        Canvas.SetTop(rectangle, position.Y);
    }

}