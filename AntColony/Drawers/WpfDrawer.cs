using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using AntColony.Animals.Ants;
using static AntColony.Configuration;

namespace AntColony.Drawers;
using static Configuration;

public class WpfDrawer : IDrawer
{
    public int Scale { get; set; } = InitScale;
    public int XCenter { get; set; } = FieldSizeX / 2;
    public int YCenter { get; set; } = FieldSizeY / 2;
    public void DrawAntHill() { }

    public void DrawAllAnts(Cell[,] cells)
    {
        int actualHeight = (int)mainWindow.antField.ActualHeight;
        int actualWidth = (int)mainWindow.antField.ActualWidth;
        int heightInCells = actualHeight / Scale;
        int widthInCells = actualWidth / Scale;
        int xTopLeftCorner = XCenter - widthInCells / 2;
        int yTopLeftCorner = YCenter - heightInCells / 2;
        mainWindow.antField.Children.Clear();
        for (int y = yTopLeftCorner; y < yTopLeftCorner+heightInCells; y++)
        {
            for (int x = xTopLeftCorner; x < xTopLeftCorner+widthInCells; x++)
            {
                if (x > FieldSizeX - 1 || y > FieldSizeY - 1 || x < 0 || y < 0) 
                    continue;
                if (cells[x, y].Animal != null)
                {
                    Worker? worker = cells[x, y].Animal as Worker;
                    if(worker==null)
                        break;
                    Rectangle rect = new Rectangle();
                    TransformGroup trans = new TransformGroup();
                    trans.Children.Add(new TranslateTransform(
                        worker.XForDrawer*Scale-xTopLeftCorner,
                        worker.YForDrawer*Scale-yTopLeftCorner));
                    trans.Children.Add(new RotateTransform(worker.Direction,
                        worker.XForDrawer*Scale-xTopLeftCorner+Scale/2,
                        worker.YForDrawer*Scale-xTopLeftCorner+Scale/2));
                    rect.Width = Scale;
                    rect.Height = Scale / 3;
                    rect.Fill = new SolidColorBrush(Colors.Black);
                    rect.RenderTransform = trans;
                    mainWindow.antField.Children.Add(rect);
                }
            }
        }
    }
}