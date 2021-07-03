using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandelbrot_Set
{
    class Complex
    {
        public double integer;
        public double imaginary;

        public Complex(double integer, double imaginary)
        {
            this.integer = integer;
            this.imaginary = imaginary;
        }

        public void Sqr()
        {
            double temp = (integer * integer) - (imaginary * imaginary);
            imaginary = 2.0d * integer * imaginary;
            integer = temp;
        }

        public double Vect()
        {
            return Math.Sqrt((integer * integer) + (imaginary * imaginary));
        }

        public void Add(Complex a)
        {
            integer += a.integer;
            imaginary += a.imaginary;
        }
    }
}
