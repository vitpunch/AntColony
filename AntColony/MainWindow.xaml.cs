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
        List<IAnt> Ants =new ();
        
        public MainWindow()
        {
            
  
            DispatcherTimer go = new DispatcherTimer();
            go.Tick += new EventHandler(go_Tick);
            go.Interval = new TimeSpan(0,0,0,0,40);
            go.Start();     
            InitializeComponent();
            
            IAnt newAnt;
            //Первоначальная генерации колонии муравьёв-рабочих
            for (int i = 0; i < 5000; i++)
            {
                newAnt = new Worker(AntHill.X,AntHill.Y);
                Ants.Add(newAnt);
            }
        }
        private void go_Tick(object? sender, EventArgs e)
        {
            Configuration.drawer.DrawAllAnts();
        }
    }
}
