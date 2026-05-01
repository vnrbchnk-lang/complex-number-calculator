using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexCalculatorContracts
{
    
    public interface IComplexNumber
    {
        double RPart { get; }

        double ImPart { get; }

        double Modul { get; }

        IComplexNumber Plus(IComplexNumber other);

        IComplexNumber Minus(IComplexNumber other);

        IComplexNumber Mnoj(IComplexNumber other);

        IComplexNumber Delen(IComplexNumber other);

        bool Equals(IComplexNumber other);

        bool Bigger(IComplexNumber other);

        bool Smaller(IComplexNumber other);

        bool BiggerOrEqual(IComplexNumber other);
        
        bool SmallerOrEqual(IComplexNumber other);

        string ToString();
    }
}



