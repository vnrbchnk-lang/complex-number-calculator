using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using ComplexCalculatorContracts;

namespace ClassLibraryForCalc.Tests
{
    [TestClass]
    public class MainFormTests
    {
        TextBox FindTextBox(MainForm form, string name)
        {
            return (TextBox)form.Controls.Find(name, true)[0];
        }

        Button FindButton(MainForm form, string name)
        {
            return (Button)form.Controls.Find(name, true)[0];
        }

        Label FindLabel(MainForm form, string name)
        {
            return (Label)form.Controls.Find(name, true)[0];
        }

        [TestMethod]
        public void Test17_LettersInsteadOfNumber()
        {
            MainForm form = new MainForm();
            FindTextBox(form, "re1Box").Text = "abc";
            FindTextBox(form, "im1Box").Text = "2";

            ICalculatorUI ui = form;
            try
            {
                ui.ReadComplexNumber("first");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("некорректный ввод", ex.Message);
            }
        }

        [TestMethod]
        public void Test18_EmptyField()
        {
            MainForm form = new MainForm();
            FindTextBox(form, "re1Box").Text = "";
            FindTextBox(form, "im1Box").Text = "3";

            ICalculatorUI ui = form;
            try
            {
                ui.ReadComplexNumber("first");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("поле не должно быть пустым", ex.Message);
            }
        }

        [TestMethod]
        public void Test20_OperationSelected()
        {
            MainForm form = new MainForm();
            Button btn = FindButton(form, "btnMul");
            form.OpClick(btn, EventArgs.Empty);

            ICalculatorUI ui = form;
            Assert.AreEqual("*", ui.ReadOperation());
        }

        [TestMethod]
        public void Test21_CalcButtonShowsResult()
        {
            MainForm form = new MainForm();
            FindTextBox(form, "re1Box").Text = "2";
            FindTextBox(form, "im1Box").Text = "3";
            FindTextBox(form, "re2Box").Text = "1";
            FindTextBox(form, "im2Box").Text = "4";

            form.OpClick(FindButton(form, "btnAdd"), EventArgs.Empty);
            form.CalcClick(form, EventArgs.Empty);

            string text = FindLabel(form, "resultLabel").Text;
            StringAssert.Contains(text, "Результат");
            StringAssert.Contains(text, "3");
            StringAssert.Contains(text, "7");
        }

        [TestMethod]
        public void Test22_DisplayCompareResult()
        {
            MainForm form = new MainForm();
            FindTextBox(form, "re1Box").Text = "2";
            FindTextBox(form, "im1Box").Text = "3";
            FindTextBox(form, "re2Box").Text = "2";
            FindTextBox(form, "im2Box").Text = "3";

            form.OpClick(FindButton(form, "btnEq"), EventArgs.Empty);
            form.CalcClick(form, EventArgs.Empty);

            string text = FindLabel(form, "resultLabel").Text;
            StringAssert.Contains(text, "true");
        }
    }
}
