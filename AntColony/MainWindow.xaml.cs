using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;



namespace AntColony
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        static readonly Random _random = new();

        List<Ant> Ants =new ();
        private readonly int _antHillX = _random.Next(300);
        private readonly int _antHillY = _random.Next(300);
        private int counter = 0;

        public MainWindow()
        {
            
  
            DispatcherTimer go = new DispatcherTimer();
            go.Tick += new EventHandler(go_Tick);
            go.Interval = new TimeSpan(0,0,0,0,10);
            go.Start();     
            InitializeComponent();
            AntHill.RenderTransform = new TranslateTransform(_antHillX,_antHillY);
            Ant newAnt;

            for (int i = 0; i < 5000; i++)
            {
                newAnt = new Worker(_antHillX, _antHillY);
                Ants.Add(newAnt);
            }
            AddAntsToField(Ants);
        }
        private void go_Tick(object? sender, EventArgs e)
        {
            counterOfIteration.Content = counter++;
            // foreach (var ant in Ants)
            // {
            //     ant.Go();
            // } 
            AddAntsToField(Ants);
        }
        private void AddAntsToField(List<Ant> ants)
        {
            RectangleGeometry newAntToDraw;          
            TransformGroup transformGroup;
            antField.Children.Clear();
            antField.Children.Add(AntHill);

            Path path = new Path();
            SolidColorBrush brush = new();
            brush.Color = Colors.Black;
            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            
            foreach (var ant in Ants)
            {
                ant.Go();
                drawingContext.DrawRectangle(
                    brush,
                    (System.Windows.Media.Pen)null,
                    new Rect(
                        ant.X,
                        ant.Y,
                        10,
                        5
                        )
                    );

            }
            drawingContext.Close();
        }
    }
}
