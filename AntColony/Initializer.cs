using System;
using System.Windows;
using System.Windows.Threading;
using static AntColony.Configuration;

namespace AntColony;

public class Initializer
{
    public static void Init()
    {
        DispatcherTimer go = new DispatcherTimer();
        go.Tick += go_Tick;
        go.Interval = new TimeSpan(0,0,0,0,50);
        go.Start();     
    }
    private static void go_Tick(object? sender, EventArgs e)
    {
        Field.Go();
    }
    
}