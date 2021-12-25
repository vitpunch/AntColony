﻿using System;
using System.Windows;
using System.Windows.Threading;

namespace AntColony;

public class Initializer
{
    public static void Init()
    {
            DispatcherTimer go = new DispatcherTimer();
            go.Tick += go_Tick;
            go.Interval = new TimeSpan(0,0,0,0,40);
            go.Start();     
    }
    private static void go_Tick(object? sender, EventArgs e)
    {
        Field.Go();
    }
    
}