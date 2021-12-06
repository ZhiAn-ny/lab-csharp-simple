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
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public Complex(double real, double imaginary)
        {
            this.Real = real;
            this.Imaginary = imaginary;
        }

        public double Modulus => Math.Sqrt(Math.Pow(this.Real, 2) + Math.Pow(this.Imaginary, 2));

        public double Phase => Math.Atan(this.Imaginary / this.Real);

        public Complex Complement() => new Complex(this.Real, -this.Imaginary);

        public Complex Plus(Complex b) => new Complex(this.Real + b.Real, this.Imaginary + b.Imaginary);

        public Complex Minus(Complex b) => new Complex(this.Real - b.Real, this.Imaginary - b.Imaginary);

        public String ToString()
        {
            String str = $"{this.Real}";
            str = (this.Imaginary >= 0 ? $"{str}+{this.Imaginary}i" : $"{str}{this.Imaginary}i");
            return str;
        }

        public bool Equals(Complex b) => this.Real.Equals(b.Real) && this.Imaginary.Equals(b.Imaginary);

    }
}