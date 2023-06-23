using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topaz2_shapes.Shapes
{
    //Базовый класс фигура
    public abstract class Shape
    {
        //Смещение относительно верхнего левого угла терминала
        public int X, Y;
        public abstract void Draw();
        public abstract float GetArea();
        //Наверное в проект ещё нужно было добавить virtual метод и protected поля для демонстрации, но я не придумал достойного примера с ними.
        //Поэтому просто напишу про них.
        //virtual метод - это метод который можно, но не обязательно переопределять в наследнике.
        //protected поля - это поля доступные внутри иерархии класса.
    }

    public class Circle : Shape
    {
        public int Radius;

        public Circle(int radius) 
        { 
            Radius = radius;
        }
        public Circle(int x, int y, int radius)
        {
            X = x; 
            Y = y; 
            Radius = radius;
        }
        public override void Draw()
        {
            //Упрощённая отрисовка круга
            for (int yIterator = 0; yIterator <= Y+Radius; yIterator++)
            {
                for (int xIterator = 0; xIterator <= X+Radius; xIterator++)
                {
                    int distanceX = xIterator - X;
                    int distanceY = yIterator - Y;
                    
                    double distance = Math.Sqrt(distanceX * distanceX + distanceY * distanceY);

                    if (Math.Abs(distance - Radius) < 0.5)
                    {
                        Console.Write("*"); // Символ для отрисовки круга
                    }
                    else
                    {
                        Console.Write(" "); // Символ для пустого пространства
                    }
                }

                Console.WriteLine();
            }
        }
        public override float GetArea()
        {
            return Radius*Radius * MathF.PI;
        }

    }
    public class Rectangle : Shape
    {
        public int Width, Height;
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public Rectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        public override void Draw()
        {
            Console.Write(new string('\n', Y));
            for (int i = 1; i <= Width; i++)
            {
                Console.Write(new string(' ', X));
                for (int j = 1; j <= Height; j++)
                {
                    if (i == 1 || i == Width || j == 1 || j == Height)
                    {
                        Console.Write("+");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.Write("\n");
            }
        }
        public override float GetArea()
        {
            return Width * Height;
        }
    }


}
