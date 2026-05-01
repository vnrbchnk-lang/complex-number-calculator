partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.title1 = new System.Windows.Forms.Label();
        this.re1Lbl = new System.Windows.Forms.Label();
        this.re1Box = new System.Windows.Forms.TextBox();
        this.im1Lbl = new System.Windows.Forms.Label();
        this.im1Box = new System.Windows.Forms.TextBox();
        this.title2 = new System.Windows.Forms.Label();
        this.re2Lbl = new System.Windows.Forms.Label();
        this.re2Box = new System.Windows.Forms.TextBox();
        this.im2Lbl = new System.Windows.Forms.Label();
        this.im2Box = new System.Windows.Forms.TextBox();
        this.btnAdd = new System.Windows.Forms.Button();
        this.btnSub = new System.Windows.Forms.Button();
        this.btnMul = new System.Windows.Forms.Button();
        this.btnDiv = new System.Windows.Forms.Button();
        this.btnEq = new System.Windows.Forms.Button();
        this.btnLt = new System.Windows.Forms.Button();
        this.btnGt = new System.Windows.Forms.Button();
        this.btnLe = new System.Windows.Forms.Button();
        this.btnGe = new System.Windows.Forms.Button();
        this.opLabel = new System.Windows.Forms.Label();
        this.calcBtn = new System.Windows.Forms.Button();
        this.resultLabel = new System.Windows.Forms.Label();
        this.SuspendLayout();
        //
        // title1
        //
        this.title1.Location = new System.Drawing.Point(20, 15);
        this.title1.Name = "title1";
        this.title1.Size = new System.Drawing.Size(200, 23);
        this.title1.TabIndex = 0;
        this.title1.Text = "Первое число";
        //
        // re1Lbl
        //
        this.re1Lbl.Location = new System.Drawing.Point(20, 45);
        this.re1Lbl.Name = "re1Lbl";
        this.re1Lbl.Size = new System.Drawing.Size(30, 23);
        this.re1Lbl.TabIndex = 1;
        this.re1Lbl.Text = "Re:";
        //
        // re1Box
        //
        this.re1Box.Location = new System.Drawing.Point(55, 42);
        this.re1Box.Name = "re1Box";
        this.re1Box.Size = new System.Drawing.Size(80, 23);
        this.re1Box.TabIndex = 2;
        //
        // im1Lbl
        //
        this.im1Lbl.Location = new System.Drawing.Point(160, 45);
        this.im1Lbl.Name = "im1Lbl";
        this.im1Lbl.Size = new System.Drawing.Size(30, 23);
        this.im1Lbl.TabIndex = 3;
        this.im1Lbl.Text = "Im:";
        //
        // im1Box
        //
        this.im1Box.Location = new System.Drawing.Point(195, 42);
        this.im1Box.Name = "im1Box";
        this.im1Box.Size = new System.Drawing.Size(80, 23);
        this.im1Box.TabIndex = 4;
        //
        // title2
        //
        this.title2.Location = new System.Drawing.Point(20, 80);
        this.title2.Name = "title2";
        this.title2.Size = new System.Drawing.Size(200, 23);
        this.title2.TabIndex = 5;
        this.title2.Text = "Второе число";
        //
        // re2Lbl
        //
        this.re2Lbl.Location = new System.Drawing.Point(20, 110);
        this.re2Lbl.Name = "re2Lbl";
        this.re2Lbl.Size = new System.Drawing.Size(30, 23);
        this.re2Lbl.TabIndex = 6;
        this.re2Lbl.Text = "Re:";
        //
        // re2Box
        //
        this.re2Box.Location = new System.Drawing.Point(55, 107);
        this.re2Box.Name = "re2Box";
        this.re2Box.Size = new System.Drawing.Size(80, 23);
        this.re2Box.TabIndex = 7;
        //
        // im2Lbl
        //
        this.im2Lbl.Location = new System.Drawing.Point(160, 110);
        this.im2Lbl.Name = "im2Lbl";
        this.im2Lbl.Size = new System.Drawing.Size(30, 23);
        this.im2Lbl.TabIndex = 8;
        this.im2Lbl.Text = "Im:";
        //
        // im2Box
        //
        this.im2Box.Location = new System.Drawing.Point(195, 107);
        this.im2Box.Name = "im2Box";
        this.im2Box.Size = new System.Drawing.Size(80, 23);
        this.im2Box.TabIndex = 9;
        //
        // btnAdd
        //
        this.btnAdd.Location = new System.Drawing.Point(20, 145);
        this.btnAdd.Name = "btnAdd";
        this.btnAdd.Size = new System.Drawing.Size(50, 30);
        this.btnAdd.TabIndex = 10;
        this.btnAdd.Tag = "+";
        this.btnAdd.Text = "+";
        this.btnAdd.UseVisualStyleBackColor = true;
        this.btnAdd.Click += new System.EventHandler(this.OpClick);
        //
        // btnSub
        //
        this.btnSub.Location = new System.Drawing.Point(72, 145);
        this.btnSub.Name = "btnSub";
        this.btnSub.Size = new System.Drawing.Size(50, 30);
        this.btnSub.TabIndex = 11;
        this.btnSub.Tag = "-";
        this.btnSub.Text = "-";
        this.btnSub.UseVisualStyleBackColor = true;
        this.btnSub.Click += new System.EventHandler(this.OpClick);
        //
        // btnMul
        //
        this.btnMul.Location = new System.Drawing.Point(124, 145);
        this.btnMul.Name = "btnMul";
        this.btnMul.Size = new System.Drawing.Size(50, 30);
        this.btnMul.TabIndex = 12;
        this.btnMul.Tag = "*";
        this.btnMul.Text = "*";
        this.btnMul.UseVisualStyleBackColor = true;
        this.btnMul.Click += new System.EventHandler(this.OpClick);
        //
        // btnDiv
        //
        this.btnDiv.Location = new System.Drawing.Point(176, 145);
        this.btnDiv.Name = "btnDiv";
        this.btnDiv.Size = new System.Drawing.Size(50, 30);
        this.btnDiv.TabIndex = 13;
        this.btnDiv.Tag = "/";
        this.btnDiv.Text = "/";
        this.btnDiv.UseVisualStyleBackColor = true;
        this.btnDiv.Click += new System.EventHandler(this.OpClick);
        //
        // btnEq
        //
        this.btnEq.Location = new System.Drawing.Point(228, 145);
        this.btnEq.Name = "btnEq";
        this.btnEq.Size = new System.Drawing.Size(50, 30);
        this.btnEq.TabIndex = 14;
        this.btnEq.Tag = "==";
        this.btnEq.Text = "==";
        this.btnEq.UseVisualStyleBackColor = true;
        this.btnEq.Click += new System.EventHandler(this.OpClick);
        //
        // btnLt
        //
        this.btnLt.Location = new System.Drawing.Point(280, 145);
        this.btnLt.Name = "btnLt";
        this.btnLt.Size = new System.Drawing.Size(50, 30);
        this.btnLt.TabIndex = 15;
        this.btnLt.Tag = "<";
        this.btnLt.Text = "<";
        this.btnLt.UseVisualStyleBackColor = true;
        this.btnLt.Click += new System.EventHandler(this.OpClick);
        //
        // btnGt
        //
        this.btnGt.Location = new System.Drawing.Point(332, 145);
        this.btnGt.Name = "btnGt";
        this.btnGt.Size = new System.Drawing.Size(50, 30);
        this.btnGt.TabIndex = 16;
        this.btnGt.Tag = ">";
        this.btnGt.Text = ">";
        this.btnGt.UseVisualStyleBackColor = true;
        this.btnGt.Click += new System.EventHandler(this.OpClick);
        //
        // btnLe
        //
        this.btnLe.Location = new System.Drawing.Point(384, 145);
        this.btnLe.Name = "btnLe";
        this.btnLe.Size = new System.Drawing.Size(50, 30);
        this.btnLe.TabIndex = 17;
        this.btnLe.Tag = "<=";
        this.btnLe.Text = "<=";
        this.btnLe.UseVisualStyleBackColor = true;
        this.btnLe.Click += new System.EventHandler(this.OpClick);
        //
        // btnGe
        //
        this.btnGe.Location = new System.Drawing.Point(436, 145);
        this.btnGe.Name = "btnGe";
        this.btnGe.Size = new System.Drawing.Size(50, 30);
        this.btnGe.TabIndex = 18;
        this.btnGe.Tag = ">=";
        this.btnGe.Text = ">=";
        this.btnGe.UseVisualStyleBackColor = true;
        this.btnGe.Click += new System.EventHandler(this.OpClick);
        //
        // opLabel
        //
        this.opLabel.Location = new System.Drawing.Point(20, 185);
        this.opLabel.Name = "opLabel";
        this.opLabel.Size = new System.Drawing.Size(400, 23);
        this.opLabel.TabIndex = 19;
        this.opLabel.Text = "Выбрано: ";
        //
        // calcBtn
        //
        this.calcBtn.Location = new System.Drawing.Point(20, 215);
        this.calcBtn.Name = "calcBtn";
        this.calcBtn.Size = new System.Drawing.Size(120, 32);
        this.calcBtn.TabIndex = 20;
        this.calcBtn.Text = "Вычислить";
        this.calcBtn.UseVisualStyleBackColor = true;
        this.calcBtn.Click += new System.EventHandler(this.CalcClick);
        //
        // resultLabel
        //
        this.resultLabel.Location = new System.Drawing.Point(20, 260);
        this.resultLabel.Name = "resultLabel";
        this.resultLabel.Size = new System.Drawing.Size(460, 23);
        this.resultLabel.TabIndex = 21;
        this.resultLabel.Text = "Результат: ";
        //
        // MainForm
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(504, 321);
        this.Controls.Add(this.title1);
        this.Controls.Add(this.re1Lbl);
        this.Controls.Add(this.re1Box);
        this.Controls.Add(this.im1Lbl);
        this.Controls.Add(this.im1Box);
        this.Controls.Add(this.title2);
        this.Controls.Add(this.re2Lbl);
        this.Controls.Add(this.re2Box);
        this.Controls.Add(this.im2Lbl);
        this.Controls.Add(this.im2Box);
        this.Controls.Add(this.btnAdd);
        this.Controls.Add(this.btnSub);
        this.Controls.Add(this.btnMul);
        this.Controls.Add(this.btnDiv);
        this.Controls.Add(this.btnEq);
        this.Controls.Add(this.btnLt);
        this.Controls.Add(this.btnGt);
        this.Controls.Add(this.btnLe);
        this.Controls.Add(this.btnGe);
        this.Controls.Add(this.opLabel);
        this.Controls.Add(this.calcBtn);
        this.Controls.Add(this.resultLabel);
        this.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.Name = "MainForm";
        this.Text = "Калькулятор комплексных чисел";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label title1;
    private System.Windows.Forms.Label re1Lbl;
    private System.Windows.Forms.TextBox re1Box;
    private System.Windows.Forms.Label im1Lbl;
    private System.Windows.Forms.TextBox im1Box;
    private System.Windows.Forms.Label title2;
    private System.Windows.Forms.Label re2Lbl;
    private System.Windows.Forms.TextBox re2Box;
    private System.Windows.Forms.Label im2Lbl;
    private System.Windows.Forms.TextBox im2Box;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnSub;
    private System.Windows.Forms.Button btnMul;
    private System.Windows.Forms.Button btnDiv;
    private System.Windows.Forms.Button btnEq;
    private System.Windows.Forms.Button btnLt;
    private System.Windows.Forms.Button btnGt;
    private System.Windows.Forms.Button btnLe;
    private System.Windows.Forms.Button btnGe;
    private System.Windows.Forms.Label opLabel;
    private System.Windows.Forms.Button calcBtn;
    private System.Windows.Forms.Label resultLabel;
}
