using System;
using System.ComponentModel.Design;
using System.Linq;

namespace ComplexAlgebra
{
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// Model Complex numbers in an object-oriented way and implement this class.
    /// In other words, you must provide a means for:
    /// * instantiating complex numbers
    /// * accessing a complex number's real, and imaginary parts
    /// * accessing a complex number's modulus, and phase
    /// * complementing a complex number
    /// * summing up or subtracting two complex numbers
    /// * representing a complex number as a string or the form Re +/- iIm
    ///     - e.g. via the ToString() method
    /// * checking whether two complex numbers are equal or not
    ///     - e.g. via the Equals(object) method
    public class Complex
    {
        public double Real { get; }
        public double Imaginary { get; }

        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public double Modulus => Math.Sqrt(Math.Pow(Real, 2) + Math.Pow(Imaginary, 2));

        public double Phase => Math.Atan(Imaginary / Real);

        public Complex Complement() => new Complex(Real, -Imaginary);

        public Complex Plus(Complex b) => new Complex(Real + b.Real, Imaginary + b.Imaginary);

        public Complex Minus(Complex b) => new Complex(Real - b.Real, Imaginary - b.Imaginary);

        public override String ToString()
        {
            if (Real.Equals(0) && Imaginary.Equals(0))
            {
                return "0";
            }
            else
            {
                String str = Real != 0 ? $"{Real}" : "";
                double abs = Math.Abs(Imaginary);
                if (abs.Equals(1))
                {
                    str = Real != 0 ? (Imaginary > 0 ? $"{str} + i" : $"{str} - i")
                        : (Imaginary > 0 ? "i" : "-i");
                }
                else if (!Imaginary.Equals(0))
                {
                    str = Real != 0 ? (Imaginary > 0 ? $"{str} + {Imaginary}i" : $"{str} - {abs}i")
                        : (Imaginary > 0 ? $"{Imaginary}i" : $"-{abs}i");
                }
                return str;
            }
        }

        public bool Equals(Complex b) => Real.Equals(b.Real) && Imaginary.Equals(b.Imaginary);

    }
}