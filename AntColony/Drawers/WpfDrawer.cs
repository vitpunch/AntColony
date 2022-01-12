using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using AntColony.Animals;
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

    public void DrawAllAnts(List<IAnimal> animals)
    {
        int actualHeight = (int)mainWindow.antField.ActualHeight;
        int actualWidth = (int)mainWindow.antField.ActualWidth;
        int heightInCells = actualHeight / Scale;
        int widthInCells = actualWidth / Scale;
        int xTopLeftCorner = XCenter - widthInCells / 2;
        int yTopLeftCorner = YCenter - heightInCells / 2;
        mainWindow.antField.Children.Clear();
        
        foreach (var animal in animals)
        {
            Worker? worker =animal as Worker;
            if (worker==null)
                continue;
            if (worker.X > xTopLeftCorner &&
                worker.X < xTopLeftCorner + widthInCells && 
                worker.Y > yTopLeftCorner &&
                worker.Y < yTopLeftCorner + heightInCells)
                DrawAnimal(animal);
        }

        void DrawAnimal(IAnimal animal)
        {
            //***************
            mainWindow.animakCount++;
            //********************
            Worker? worker = animal as Worker;
            if(worker==null)
                return;
            Rectangle rect = new Rectangle();
            TransformGroup trans = new TransformGroup();
            trans.Children.Add(new TranslateTransform(
                (worker.XForDrawer-xTopLeftCorner)*Scale,
                (worker.YForDrawer-yTopLeftCorner)*Scale));
            trans.Children.Add(new RotateTransform(worker.Direction,
                (worker.XForDrawer-xTopLeftCorner)*Scale+Scale/2,
                (worker.YForDrawer-yTopLeftCorner)*Scale+Scale/2));
            rect.Width = Scale;
            rect.Height = Scale / 3;
            rect.Fill = new SolidColorBrush(Colors.Black);
            rect.RenderTransform = trans;
            mainWindow.antField.Children.Add(rect);
        }
    }

    public void ScaleDown()
    {
        Scale = (int)(Scale*0.9);
        if (Scale < 5)
            Scale -= 1;
        if (Scale <3)
            Scale = 3;
    }
    public void ScaleUp()
    {
        Scale = (int)(Scale * 1.2);
        if (Scale < 5)
            Scale += 1;
    }
}