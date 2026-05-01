using System;

namespace ComplexCalculatorContracts
{
    public class ComplexNum : IComplexNumber
    {
        public double RPart { get; }

        public double ImPart { get; }

        public double Modul
        {
            get { return Math.Sqrt(RPart * RPart + ImPart * ImPart); }
        }

        public ComplexNum(double r, double im)
        {
            RPart = r;
            ImPart = im;
        }

        public IComplexNumber Plus(IComplexNumber other)
        {
            double r = RPart + other.RPart;
            double im = ImPart + other.ImPart;
            return new ComplexNum(r, im);
        }

        public IComplexNumber Minus(IComplexNumber other)
        {
            double r = RPart - other.RPart;
            double im = ImPart - other.ImPart;
            return new ComplexNum(r, im);
        }

        public IComplexNumber Mnoj(IComplexNumber other)
        {
            double r = RPart * other.RPart - ImPart * other.ImPart;
            double im = RPart * other.ImPart + ImPart * other.RPart;
            return new ComplexNum(r, im);
        }

        public IComplexNumber Delen(IComplexNumber other)
        {
            double znam = other.RPart * other.RPart + other.ImPart * other.ImPart;
            if (znam == 0)
            {
                throw new DivideByZeroException("деление на ноль");
            }
            double r = (RPart * other.RPart + ImPart * other.ImPart) / znam;
            double im = (ImPart * other.RPart - RPart * other.ImPart) / znam;
            return new ComplexNum(r, im);
        }

        public bool Equals(IComplexNumber other)
        {
            return RPart == other.RPart && ImPart == other.ImPart;
        }

        public bool Bigger(IComplexNumber other)
        {
            return Modul > other.Modul;
        }

        public bool Smaller(IComplexNumber other)
        {
            return Modul < other.Modul;
        }

        public bool BiggerOrEqual(IComplexNumber other)
        {
            return Modul >= other.Modul;
        }

        public bool SmallerOrEqual(IComplexNumber other)
        {
            return Modul <= other.Modul;
        }

        public override string ToString()
        {
            if (ImPart >= 0)
            {
                return RPart + " + " + ImPart + "i";
            }
            else
            {
                return RPart + " - " + (-ImPart) + "i";
            }
        }
    }
}
