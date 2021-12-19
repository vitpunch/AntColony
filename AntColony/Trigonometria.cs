using System;

namespace AntColony;

public static class Trigonometria
{
    private static double[] degresToSinCos = new double[720];

    static Trigonometria()
    {
        TableInitializer();
    } 
    //углы функциям задавать в градусах
    public static double Sin(int angle)
    {
        return degresToSinCos[angle];
    }
    public static double Cos(int angle)
    {
        return degresToSinCos[angle+360];
    }

    private static void TableInitializer()
    {
        double _radians;
        for (int i = 0; i < 360; i++)
        {
            _radians = i / 180.0 * Math.PI;
            degresToSinCos[i] = Math.Sin(_radians);
            degresToSinCos[i+360]=Math.Cos(_radians);
        }
    }
}