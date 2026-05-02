using System;
using System.Windows.Forms;
using ComplexCalculatorContracts;

public partial class MainForm : Form, ICalculatorUI
{
    string operation = "";

    public MainForm()
    {
        InitializeComponent();
    }

    public IComplexNumber ReadComplexNumber(string prompt)
    {
        TextBox reBox = prompt == "first" ? re1Box : re2Box;
        TextBox imBox = prompt == "first" ? im1Box : im2Box;

        if (reBox.Text == "" || imBox.Text == "")
        {
            throw new ArgumentException("поле не должно быть пустым");
        }
        double re;
        double im;
        if (!double.TryParse(reBox.Text, out re) || !double.TryParse(imBox.Text, out im))
        {
            throw new ArgumentException("некорректный ввод");
        }
        return new ComplexNum(re, im);
    }

    public string ReadOperation()
    {
        return operation;
    }

    public void Result(string result)
    {
        resultLabel.Text = "Результат: " + result;
    }

    public void Error(string message)
    {
        resultLabel.Text = "Ошибка: " + message;
    }

    public void Run()
    {
        Application.Run(this);
    }

    public void OpClick(object? sender, EventArgs e)
    {
        Button b = (Button)sender!;
        operation = (string)b.Tag!;
        opLabel.Text = "Выбрано: " + operation;
    }

    public void CalcClick(object? sender, EventArgs e)
    {
        if (ReadOperation() == "")
        {
            Error("операция не выбрана");
            return;
        }
        try
        {
            IComplexNumber a = ReadComplexNumber("first");
            IComplexNumber b = ReadComplexNumber("second");
            string op = ReadOperation();

            string r = "";
            if (op == "+") r = a.Plus(b).ToString() ?? "";
            else if (op == "-") r = a.Minus(b).ToString() ?? "";
            else if (op == "*") r = a.Mnoj(b).ToString() ?? "";
            else if (op == "/") r = a.Delen(b).ToString() ?? "";
            else if (op == "==") r = a.Equals(b) ? "true" : "false";
            else if (op == "<") r = a.Smaller(b) ? "true" : "false";
            else if (op == ">") r = a.Bigger(b) ? "true" : "false";
            else if (op == "<=") r = a.SmallerOrEqual(b) ? "true" : "false";
            else if (op == ">=") r = a.BiggerOrEqual(b) ? "true" : "false";

            Result(r);
        }
        catch (Exception ex)
        {
            Error(ex.Message);
        }
    }
}
