using System;

namespace CSharp.Activity.Polymorphism
{
    public class Circle : Shape, IPrintable
    {
        public double Radius { get; protected set; }

        public Circle(double radius)
        {
            if (radius < 0 )
            {
                throw new ArgumentOutOfRangeException(nameof(radius), "Value may not negative.");
            }

            Radius = radius;
            CalculateArea();
        }

        public override void CalculateArea()
        {
            Area = Math.PI * Radius * Radius;
        }

        public void Print()
        {
            Console.WriteLine($"Circle({Radius}): Area {Area}");
        }
    }
}
