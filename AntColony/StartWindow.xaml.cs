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
        public StartWindow()
        {
            mainWindow = this;
            Initializer.Init();
            InitializeComponent();
            Field.SetAntHill();
        }
        private void WorkerBorn(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                AntHill.WorkerBorn();
                Field.Go();
            }

        }
    }
}
