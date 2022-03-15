using System;
using static System.Console;
using static System.Convert;
using static System.Math;

namespace CornerThrow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double h0 = -1, g = 9.8, v0 = 0, alpha = -1, sin, cos, l, h, tMax;
            WriteLine("РЕШЕНИЕ ЗАДАЧИ:\nДвижение тела, брошенного под углом к горизонту\n");
            WriteLine("Введите высоту, с которой изначально было брошено тело (h0 >= 0).");
            while (h0 < 0)
            {
                Write("h0 = ");
                try
                {
                    h0 = ToDouble(ReadLine());
                }
                catch (FormatException) { }
            }
            WriteLine("Введите скорость, с которой изначально было брошено тело (v0 > 0).");
            while (v0 <= 0)
            {
                Write("v0 = ");
                try
                {
                    v0 = ToDouble(ReadLine());
                }
                catch (FormatException) { }
            }
            WriteLine("Введите угол, на который было брошено тело (alpha >= 0 & alpha <= 90).");
            while (alpha < 0 | alpha > 90)
            {
                Write("alpha = ");
                try
                {
                    alpha = ToDouble(ReadLine());
                }
                catch (FormatException) { }
            }
            sin = Sin(alpha * PI / 180);
            cos = Cos(alpha * PI / 180);
            WriteLine($"Синус угла alpha равен {Round(sin, 5)}\nКосинус угла alpha равен {Round(cos, 5)}\n");
            l = v0 * cos * ((Sqrt(Pow(v0, 2) * Pow(sin, 2) + 2 * g * h0) + v0 * sin) / g);
            h = Pow(v0, 2) * Pow(sin, 2) / (2 * g) + h0;
            WriteLine($"Длина полета равна {Round(l, 2)}\nМаксимальная высота полета равна {Round(h, 2)}\n");
            tMax = v0 * sin / g + Sqrt(2 * h / g);
            WriteLine("t / x / y");
            for (double i = 0; i <= tMax; i += tMax / 20)
                WriteLine($"{Round(i, 5)} / {Round(v0 * cos * i, 5)} / {Round(-g * Pow(i, 2) / 2 + v0 * sin * i + h0, 5)}");
            ReadKey();
        }
    }
}
