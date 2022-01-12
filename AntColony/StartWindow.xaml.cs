using System;
using System.Windows;
using static AntColony.Configuration;
using System.Windows.Controls;
using System.Windows.Threading;
using AntColony.Drawers;

namespace AntColony
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class StartWindow : Window
    {
        public int animakCount;
        public StartWindow()
        {
            mainWindow = this;
            Initializer.Init();
            InitializeComponent();
            Field.SetAntHill();
        }
        private void WorkerBorn(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 500; i++)
            {
                Field.AntBorn();
            }
        }
        private void ScaleDown(object sender, RoutedEventArgs e)
        {
            drawer.ScaleDown();
        }
        private void ScaleUp(object sender, RoutedEventArgs e)
        {
            drawer.ScaleUp();
        }
    }
}
