using System;
using System.Windows;
using System.Windows.Threading;

namespace AntColony
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            Initializer.Init();
            InitializeComponent();
        }
        private void Set_AntHill(object sender, RoutedEventArgs e)
        {
            setAntHillBtn.IsEnabled = false;
            Field.SetAntHill();
        }

        private void WorkerBorn(object sender, RoutedEventArgs e)
        {
            AntHill.WorkerBorn();
        }
    }
}
