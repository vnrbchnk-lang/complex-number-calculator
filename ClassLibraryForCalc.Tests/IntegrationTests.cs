using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using ComplexCalculatorContracts;

namespace ClassLibraryForCalc.Tests
{
    [TestClass]
    public class IntegrationTests
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

        void EnterNumbers(MainForm form, string re1, string im1, string re2, string im2)
        {
            FindTextBox(form, "re1Box").Text = re1;
            FindTextBox(form, "im1Box").Text = im1;
            FindTextBox(form, "re2Box").Text = re2;
            FindTextBox(form, "im2Box").Text = im2;
        }

        void ClickOpAndCalc(MainForm form, string opButton)
        {
            form.OpClick(FindButton(form, opButton), EventArgs.Empty);
            form.CalcClick(form, EventArgs.Empty);
        }

        string GetResult(MainForm form)
        {
            return FindLabel(form, "resultLabel").Text;
        }

        [DataTestMethod]
        [DataRow("2", "3", "1", "4", "3", "7")]
        [DataRow("5", "2", "0", "0", "5", "2")]
        public void Add_FullFlow(string re1, string im1, string re2, string im2,
                                 string expRe, string expIm)
        {
            MainForm form = new MainForm();
            EnterNumbers(form, re1, im1, re2, im2);
            ClickOpAndCalc(form, "btnAdd");

            string text = GetResult(form);
            StringAssert.Contains(text, "Результат");
            StringAssert.Contains(text, expRe);
            StringAssert.Contains(text, expIm);
        }

        [DataTestMethod]
        [DataRow("5", "7", "2", "3", "3", "4")]
        [DataRow("3", "5", "3", "5", "0", "0")]
        public void Subtract_FullFlow(string re1, string im1, string re2, string im2,
                                      string expRe, string expIm)
        {
            MainForm form = new MainForm();
            EnterNumbers(form, re1, im1, re2, im2);
            ClickOpAndCalc(form, "btnSub");

            string text = GetResult(form);
            StringAssert.Contains(text, expRe);
            StringAssert.Contains(text, expIm);
        }

        [DataTestMethod]
        [DataRow("2", "3", "1", "4", "-10", "11")]
        [DataRow("7", "9", "0", "0", "0", "0")]
        public void Multiply_FullFlow(string re1, string im1, string re2, string im2,
                                      string expRe, string expIm)
        {
            MainForm form = new MainForm();
            EnterNumbers(form, re1, im1, re2, im2);
            ClickOpAndCalc(form, "btnMul");

            string text = GetResult(form);
            StringAssert.Contains(text, expRe);
            StringAssert.Contains(text, expIm);
        }

        [DataTestMethod]
        [DataRow("4", "2", "1", "1", "3", "1")]
        [DataRow("3", "5", "3", "5", "1", "0")]
        public void Divide_FullFlow(string re1, string im1, string re2, string im2,
                                    string expRe, string expIm)
        {
            MainForm form = new MainForm();
            EnterNumbers(form, re1, im1, re2, im2);
            ClickOpAndCalc(form, "btnDiv");

            string text = GetResult(form);
            StringAssert.Contains(text, expRe);
            StringAssert.Contains(text, expIm);
        }

        [TestMethod]
        public void DivideByZero_ShowsError()
        {
            MainForm form = new MainForm();
            EnterNumbers(form, "5", "3", "0", "0");
            ClickOpAndCalc(form, "btnDiv");

            string text = GetResult(form);
            StringAssert.Contains(text, "Ошибка");
            StringAssert.Contains(text, "деление на ноль");
        }

        [DataTestMethod]
        [DataRow("2", "3", "2", "3", "true")]
        [DataRow("2", "3", "5", "3", "false")]
        public void EqualsCompare_FullFlow(string re1, string im1, string re2, string im2,
                                           string expected)
        {
            MainForm form = new MainForm();
            EnterNumbers(form, re1, im1, re2, im2);
            ClickOpAndCalc(form, "btnEq");
            StringAssert.Contains(GetResult(form), expected);
        }

        [DataTestMethod]
        [DataRow("btnLt", "1", "1", "3", "4")]
        [DataRow("btnGt", "6", "8", "3", "4")]
        [DataRow("btnLe", "3", "4", "-4", "-3")]
        [DataRow("btnGe", "3", "4", "-4", "-3")]
        public void ModulusCompare_FullFlow(string op, string re1, string im1,
                                            string re2, string im2)
        {
            MainForm form = new MainForm();
            EnterNumbers(form, re1, im1, re2, im2);
            ClickOpAndCalc(form, op);
            StringAssert.Contains(GetResult(form), "true");
        }

        [TestMethod]
        public void InvalidInput_ShowsError()
        {
            MainForm form = new MainForm();
            EnterNumbers(form, "abc", "2", "1", "1");
            ClickOpAndCalc(form, "btnAdd");

            string text = GetResult(form);
            StringAssert.Contains(text, "Ошибка");
            StringAssert.Contains(text, "некорректный ввод");
        }

        [TestMethod]
        public void EmptyField_ShowsError()
        {
            MainForm form = new MainForm();
            EnterNumbers(form, "", "3", "1", "1");
            ClickOpAndCalc(form, "btnAdd");

            string text = GetResult(form);
            StringAssert.Contains(text, "Ошибка");
            StringAssert.Contains(text, "поле не должно быть пустым");
        }

        [TestMethod]
        public void ReadComplexNumber_RejectsLetters()
        {
            MainForm form = new MainForm();
            FindTextBox(form, "re1Box").Text = "abc";
            FindTextBox(form, "im1Box").Text = "2";

            ICalculatorUI ui = form;
            try
            {
                ui.ReadComplexNumber("first");
                Assert.Fail("Ожидалось исключение ArgumentException");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("некорректный ввод", ex.Message);
            }
        }

        [TestMethod]
        public void ReadComplexNumber_RejectsEmptyField()
        {
            MainForm form = new MainForm();
            FindTextBox(form, "re1Box").Text = "";
            FindTextBox(form, "im1Box").Text = "3";

            ICalculatorUI ui = form;
            try
            {
                ui.ReadComplexNumber("first");
                Assert.Fail("Ожидалось исключение ArgumentException");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("поле не должно быть пустым", ex.Message);
            }
        }

        [DataTestMethod]
        [DataRow("btnAdd", "+")]
        [DataRow("btnMul", "*")]
        [DataRow("btnEq", "==")]
        public void OperationButton_UpdatesSelectedOperation(string buttonName, string expectedOp)
        {
            MainForm form = new MainForm();
            form.OpClick(FindButton(form, buttonName), EventArgs.Empty);

            ICalculatorUI ui = form;
            Assert.AreEqual(expectedOp, ui.ReadOperation());
        }

        [TestMethod]
        public void OperationLabel_UpdatesAfterClick()
        {
            MainForm form = new MainForm();
            form.OpClick(FindButton(form, "btnAdd"), EventArgs.Empty);
            StringAssert.Contains(FindLabel(form, "opLabel").Text, "+");
        }
    }
}
