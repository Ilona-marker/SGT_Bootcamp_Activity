using System;

namespace CSharp.Activity.Polymorphism
{
    public abstract class Shape
    {
       /// <summary>
       ///  Holds the area of the shape. 
       /// </summary>
       public double Area { get; protected set; }

        /// <summary>
        /// Calculates the area. 
        /// </summary>
        public abstract void CalculateArea();

    }
}
