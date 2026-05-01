using System;
using System.Drawing;
using System.Windows.Forms;
using ComplexCalculatorContracts;

public class MainForm : Form, ICalculatorUI
{
    TextBox re1Box = new TextBox();
    TextBox im1Box = new TextBox();
    TextBox re2Box = new TextBox();
    TextBox im2Box = new TextBox();
    Label opLabel = new Label();
    Label resultLabel = new Label();
    string operation = "";

    public MainForm()
    {
        Text = "Калькулятор комплексных чисел";
        Width = 520;
        Height = 360;
        Font = new Font("Segoe UI", 10);

        Label title1 = new Label();
        title1.Text = "Первое число";
        title1.Left = 20;
        title1.Top = 15;
        title1.Width = 200;
        Controls.Add(title1);

        Label re1Lbl = new Label();
        re1Lbl.Text = "Re:";
        re1Lbl.Left = 20;
        re1Lbl.Top = 45;
        re1Lbl.Width = 30;
        Controls.Add(re1Lbl);

        re1Box.Left = 55;
        re1Box.Top = 42;
        re1Box.Width = 80;
        Controls.Add(re1Box);

        Label im1Lbl = new Label();
        im1Lbl.Text = "Im:";
        im1Lbl.Left = 160;
        im1Lbl.Top = 45;
        im1Lbl.Width = 30;
        Controls.Add(im1Lbl);

        im1Box.Left = 195;
        im1Box.Top = 42;
        im1Box.Width = 80;
        Controls.Add(im1Box);

        Label title2 = new Label();
        title2.Text = "Второе число";
        title2.Left = 20;
        title2.Top = 80;
        title2.Width = 200;
        Controls.Add(title2);

        Label re2Lbl = new Label();
        re2Lbl.Text = "Re:";
        re2Lbl.Left = 20;
        re2Lbl.Top = 110;
        re2Lbl.Width = 30;
        Controls.Add(re2Lbl);

        re2Box.Left = 55;
        re2Box.Top = 107;
        re2Box.Width = 80;
        Controls.Add(re2Box);

        Label im2Lbl = new Label();
        im2Lbl.Text = "Im:";
        im2Lbl.Left = 160;
        im2Lbl.Top = 110;
        im2Lbl.Width = 30;
        Controls.Add(im2Lbl);

        im2Box.Left = 195;
        im2Box.Top = 107;
        im2Box.Width = 80;
        Controls.Add(im2Box);

        string[] ops = { "+", "-", "*", "/", "==", "<", ">", "<=", ">=" };
        int x = 20;
        for (int i = 0; i < ops.Length; i++)
        {
            Button b = new Button();
            b.Text = ops[i];
            b.Left = x;
            b.Top = 145;
            b.Width = 50;
            b.Height = 30;
            b.Tag = ops[i];
            b.Click += OpClick;
            Controls.Add(b);
            x += 52;
        }

        opLabel.Text = "Выбрано: ";
        opLabel.Left = 20;
        opLabel.Top = 185;
        opLabel.Width = 400;
        Controls.Add(opLabel);

        Button calcBtn = new Button();
        calcBtn.Text = "Вычислить";
        calcBtn.Left = 20;
        calcBtn.Top = 215;
        calcBtn.Width = 120;
        calcBtn.Height = 32;
        calcBtn.Click += CalcClick;
        Controls.Add(calcBtn);

        resultLabel.Text = "Результат: ";
        resultLabel.Left = 20;
        resultLabel.Top = 260;
        resultLabel.Width = 460;
        Controls.Add(resultLabel);
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

    void OpClick(object? sender, EventArgs e)
    {
        Button b = (Button)sender!;
        operation = (string)b.Tag!;
        opLabel.Text = "Выбрано: " + operation;
    }

    void CalcClick(object? sender, EventArgs e)
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
