﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length 
        {
            get => length;

            set
            {
                if(value <= 0)
                {
                    throw new ArgumentException($"{nameof(Length)} cannot be zero or negative.");
                }
                length= value;
            }
        }

        public double Width 
        {
            get => width;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Width)} cannot be zero or negative.");
                }
                width = value;
            }
        }

        public double Height
        {
            get => height;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Height)} cannot be zero or negative.");
                }
                height = value;
            }
        }

        public double LateralSurfaceArea() => 2 * length * height + 2 * width * height;

        public double SurfaceArea() => 2*length * width + LateralSurfaceArea();

        public double Volume() => length * width * height;
    }
}
