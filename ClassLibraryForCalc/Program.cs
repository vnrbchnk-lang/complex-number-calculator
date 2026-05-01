using System;
using System.Windows.Forms;
using ComplexCalculatorContracts;

class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        ICalculatorUI ui = new MainForm();
        ui.Run();
    }
}
