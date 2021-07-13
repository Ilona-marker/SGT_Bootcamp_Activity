using System;

namespace CSharp.Activity.Polymorphism
{
    public class Rectangle : Shape, IPrintable
    {

        public double Length { get; protected set; }
        public double Width { get; protected set; }

        public Rectangle(double length, double width)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "Value may not negative.");
            }
            if (width < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(width), "Value may not negative.");
            }

            Length = length;
            Width = width;
            CalculateArea();
        }

        public override void  CalculateArea()
        {
            Area = Length * Width;
        }

        public void Print()
        {
            Console.WriteLine($"Rectangle({Length}x{Width}): Area {Area}");
        }
    }
}
