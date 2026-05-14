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

        // Заполняет 4 поля формы значениями двух комплексных чисел.
        void EnterNumbers(MainForm form, string re1, string im1, string re2, string im2)
        {
            FindTextBox(form, "re1Box").Text = re1;
            FindTextBox(form, "im1Box").Text = im1;
            FindTextBox(form, "re2Box").Text = re2;
            FindTextBox(form, "im2Box").Text = im2;
        }

        // Эмулирует нажатие кнопки операции (по имени) и затем нажатие «Вычислить».
        void ClickOpAndCalc(MainForm form, string opButton)
        {
            form.OpClick(FindButton(form, opButton), EventArgs.Empty);
            form.CalcClick(form, EventArgs.Empty);
        }

        string GetResult(MainForm form)
        {
            return FindLabel(form, "resultLabel").Text;
        }

        // --- Арифметические операции: ввод -> кнопка -> результат ---

        [TestMethod]
        public void IntegrationTest01_AddTwoNumbersFullFlow()
        {
            MainForm form = new MainForm();
            EnterNumbers(form, "2", "3", "1", "4");
            ClickOpAndCalc(form, "btnAdd");
            StringAssert.Contains(GetResult(form), "Результат");
            StringAssert.Contains(GetResult(form), "3");
            StringAssert.Contains(GetResult(form), "7");
        }

        [TestMethod]
        public void IntegrationTest02_SubtractTwoNumbersFullFlow()
        {
            MainForm form = new MainForm();
            EnterNumbers(form, "5", "7", "2", "3");
            ClickOpAndCalc(form, "btnSub");
            StringAssert.Contains(GetResult(form), "3");
            StringAssert.Contains(GetResult(form), "4");
        }

        [TestMethod]
        public void IntegrationTest03_MultiplyTwoNumbersFullFlow()
        {
            MainForm form = new MainForm();
            EnterNumbers(form, "2", "3", "1", "4");
            ClickOpAndCalc(form, "btnMul");
            // (2+3i)(1+4i) = -10 + 11i
            StringAssert.Contains(GetResult(form), "-10");
            StringAssert.Contains(GetResult(form), "11");
        }

        [TestMethod]
        public void IntegrationTest04_DivideTwoNumbersFullFlow()
        {
            MainForm form = new MainForm();
            EnterNumbers(form, "4", "2", "1", "1");
            ClickOpAndCalc(form, "btnDiv");
            // (4+2i)/(1+i) = 3 - 1i
            StringAssert.Contains(GetResult(form), "3");
            StringAssert.Contains(GetResult(form), "1");
        }

        [TestMethod]
        public void IntegrationTest05_FractionalAddFullFlow()
        {
            MainForm form = new MainForm();
            // На русской локали разделитель дробной части — запятая.
            string sep = System.Globalization.CultureInfo.CurrentCulture
                            .NumberFormat.NumberDecimalSeparator;
            EnterNumbers(form,
                "2" + sep + "5", "-1" + sep + "75",
                "1" + sep + "5", "0" + sep + "25");
            ClickOpAndCalc(form, "btnAdd");
            // (2.5 - 1.75i) + (1.5 + 0.25i) = 4 - 1.5i
            StringAssert.Contains(GetResult(form), "4");
            StringAssert.Contains(GetResult(form), "1" + sep + "5");
        }

        // --- Операции сравнения ---

        [TestMethod]
        public void IntegrationTest06_EqualsTrueFullFlow()
        {
            MainForm form = new MainForm();
            EnterNumbers(form, "2", "3", "2", "3");
            ClickOpAndCalc(form, "btnEq");
            StringAssert.Contains(GetResult(form), "true");
        }

        [TestMethod]
        public void IntegrationTest07_EqualsFalseFullFlow()
        {
            MainForm form = new MainForm();
            EnterNumbers(form, "2", "3", "5", "3");
            ClickOpAndCalc(form, "btnEq");
            StringAssert.Contains(GetResult(form), "false");
        }

        [TestMethod]
        public void IntegrationTest08_LessThanByModulusFullFlow()
        {
            MainForm form = new MainForm();
            EnterNumbers(form, "1", "1", "3", "4");
            ClickOpAndCalc(form, "btnLt");
            StringAssert.Contains(GetResult(form), "true");
        }

        [TestMethod]
        public void IntegrationTest09_GreaterThanByModulusFullFlow()
        {
            MainForm form = new MainForm();
            EnterNumbers(form, "6", "8", "3", "4");
            ClickOpAndCalc(form, "btnGt");
            StringAssert.Contains(GetResult(form), "true");
        }

        [TestMethod]
        public void IntegrationTest10_LessOrEqualOnEqualModulusFullFlow()
        {
            MainForm form = new MainForm();
            EnterNumbers(form, "3", "4", "-4", "-3");
            ClickOpAndCalc(form, "btnLe");
            StringAssert.Contains(GetResult(form), "true");
        }

        [TestMethod]
        public void IntegrationTest11_GreaterOrEqualOnEqualModulusFullFlow()
        {
            MainForm form = new MainForm();
            EnterNumbers(form, "3", "4", "-4", "-3");
            ClickOpAndCalc(form, "btnGe");
            StringAssert.Contains(GetResult(form), "true");
        }

        // --- Обработка ошибок (форма + класс) ---

        [TestMethod]
        public void IntegrationTest12_DivideByZeroShowsErrorFullFlow()
        {
            MainForm form = new MainForm();
            EnterNumbers(form, "5", "3", "0", "0");
            ClickOpAndCalc(form, "btnDiv");
            StringAssert.Contains(GetResult(form), "Ошибка");
            StringAssert.Contains(GetResult(form), "деление на ноль");
        }

        [TestMethod]
        public void IntegrationTest13_InvalidInputShowsErrorFullFlow()
        {
            MainForm form = new MainForm();
            EnterNumbers(form, "abc", "2", "1", "1");
            ClickOpAndCalc(form, "btnAdd");
            StringAssert.Contains(GetResult(form), "Ошибка");
            StringAssert.Contains(GetResult(form), "некорректный ввод");
        }

        [TestMethod]
        public void IntegrationTest14_EmptyFieldShowsErrorFullFlow()
        {
            MainForm form = new MainForm();
            EnterNumbers(form, "", "3", "1", "1");
            ClickOpAndCalc(form, "btnAdd");
            StringAssert.Contains(GetResult(form), "Ошибка");
            StringAssert.Contains(GetResult(form), "поле не должно быть пустым");
        }

        [TestMethod]
        public void IntegrationTest15_NoOperationSelectedShowsErrorFullFlow()
        {
            MainForm form = new MainForm();
            EnterNumbers(form, "1", "2", "3", "4");
            // Кнопку операции не нажимаем — сразу «Вычислить».
            form.CalcClick(form, EventArgs.Empty);
            StringAssert.Contains(GetResult(form), "Ошибка");
            StringAssert.Contains(GetResult(form), "операция не выбрана");
        }

        // --- Проверка состояния интерфейса ---

        [TestMethod]
        public void IntegrationTest16_OperationLabelUpdatesAfterClick()
        {
            MainForm form = new MainForm();
            form.OpClick(FindButton(form, "btnAdd"), EventArgs.Empty);
            StringAssert.Contains(FindLabel(form, "opLabel").Text, "+");
        }

        [TestMethod]
        public void IntegrationTest17_OperationCanBeChanged()
        {
            MainForm form = new MainForm();
            form.OpClick(FindButton(form, "btnAdd"), EventArgs.Empty);
            form.OpClick(FindButton(form, "btnMul"), EventArgs.Empty);
            ICalculatorUI ui = form;
            Assert.AreEqual("*", ui.ReadOperation());
        }

        [TestMethod]
        public void IntegrationTest18_TwoCalculationsInARow()
        {
            MainForm form = new MainForm();

            // Первое вычисление: 2 + 3i и 1 + 4i, сложение -> 3 + 7i
            EnterNumbers(form, "2", "3", "1", "4");
            ClickOpAndCalc(form, "btnAdd");
            StringAssert.Contains(GetResult(form), "3");
            StringAssert.Contains(GetResult(form), "7");

            // Меняем операнды и операцию -> новый результат на той же форме
            EnterNumbers(form, "5", "7", "2", "3");
            ClickOpAndCalc(form, "btnSub");
            StringAssert.Contains(GetResult(form), "3");
            StringAssert.Contains(GetResult(form), "4");
        }
    }
}
