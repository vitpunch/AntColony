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
            foreach (var ant in Ants)
            {
                ant.Go();
            } 
            AddAntsToField(Ants);
        }
        private void AddAntsToField(List<Ant> ants)
        {
            Rectangle newAntToDraw;          
            TransformGroup transformGroup;
            antField.Children.Clear();
            antField.Children.Add(AntHill);


            SolidColorBrush brush = new();
            foreach (var ant in Ants)
            {
                ant.Go();
                newAntToDraw = new Rectangle();
                transformGroup = new();
                transformGroup.Children.Add(new TranslateTransform(ant.X, ant.Y));
                transformGroup.Children.Add(new RotateTransform(360-ant.Direction,ant.X,ant.Y));
                newAntToDraw.RenderTransform = transformGroup;
                brush.Color = Colors.Black;
                newAntToDraw.Fill = new SolidColorBrush(Color.FromRgb(0,0,0));
                newAntToDraw.Width = 6;
                newAntToDraw.Height = 3;
                antField.Children.Add(newAntToDraw);
                
            }
        }
    }
}
