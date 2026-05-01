using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexCalculatorContracts
{
    
    public interface ICalculatorUI
    {
        
        IComplexNumber ReadComplexNumber(string prompt);

        string ReadOperation();

        void Result(string result);

        void Error(string message);

        void Run();
    }
}