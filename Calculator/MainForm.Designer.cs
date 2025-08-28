namespace Calculator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            operationTextDisplay = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            buttonComa = new Button();
            buttonEqual = new Button();
            buttonCleanAll = new Button();
            buttonAdd = new Button();
            buttonSubtract = new Button();
            buttonMultiply = new Button();
            buttonDivide = new Button();
            buttonLeftParenthesis = new Button();
            buttonRightParenthesis = new Button();
            buttonFactorial = new Button();
            buttonSqrt = new Button();
            buttonCleanEntry = new Button();
            buttonPower = new Button();
            buttonSquare = new Button();
            panelHistory = new Panel();
            buttonHistory = new Button();
            listHistory = new ListView();
            panelHistory.SuspendLayout();
            SuspendLayout();
            // 
            // operationTextDisplay
            // 
            operationTextDisplay.Font = new Font("Segoe UI", 18F);
            operationTextDisplay.Location = new Point(39, 35);
            operationTextDisplay.Name = "operationTextDisplay";
            operationTextDisplay.ReadOnly = true;
            operationTextDisplay.Size = new Size(268, 39);
            operationTextDisplay.TabIndex = 0;
            operationTextDisplay.Text = "0";
            // 
            // button1
            // 
            button1.Location = new Point(39, 94);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonNumber_Click;
            // 
            // button2
            // 
            button2.Location = new Point(136, 94);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonNumber_Click;
            // 
            // button3
            // 
            button3.Location = new Point(232, 94);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 3;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += buttonNumber_Click;
            // 
            // button4
            // 
            button4.Location = new Point(39, 146);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 4;
            button4.Text = "4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += buttonNumber_Click;
            // 
            // button5
            // 
            button5.Location = new Point(136, 146);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 5;
            button5.Text = "5";
            button5.UseVisualStyleBackColor = true;
            button5.Click += buttonNumber_Click;
            // 
            // button6
            // 
            button6.Location = new Point(232, 146);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 6;
            button6.Text = "6";
            button6.UseVisualStyleBackColor = true;
            button6.Click += buttonNumber_Click;
            // 
            // button7
            // 
            button7.Location = new Point(39, 195);
            button7.Name = "button7";
            button7.Size = new Size(75, 23);
            button7.TabIndex = 7;
            button7.Text = "7";
            button7.UseVisualStyleBackColor = true;
            button7.Click += buttonNumber_Click;
            // 
            // button8
            // 
            button8.Location = new Point(136, 195);
            button8.Name = "button8";
            button8.Size = new Size(75, 23);
            button8.TabIndex = 8;
            button8.Text = "8";
            button8.UseVisualStyleBackColor = true;
            button8.Click += buttonNumber_Click;
            // 
            // button9
            // 
            button9.Location = new Point(232, 195);
            button9.Name = "button9";
            button9.Size = new Size(75, 23);
            button9.TabIndex = 9;
            button9.Text = "9";
            button9.UseVisualStyleBackColor = true;
            button9.Click += buttonNumber_Click;
            // 
            // button10
            // 
            button10.Location = new Point(39, 244);
            button10.Name = "button10";
            button10.Size = new Size(75, 23);
            button10.TabIndex = 10;
            button10.Text = "0";
            button10.UseVisualStyleBackColor = true;
            button10.Click += buttonNumber_Click;
            // 
            // buttonComa
            // 
            buttonComa.Location = new Point(136, 244);
            buttonComa.Name = "buttonComa";
            buttonComa.Size = new Size(75, 23);
            buttonComa.TabIndex = 11;
            buttonComa.Text = ",";
            buttonComa.UseVisualStyleBackColor = true;
            buttonComa.Click += buttonComa_Click;
            // 
            // buttonEqual
            // 
            buttonEqual.Location = new Point(232, 244);
            buttonEqual.Name = "buttonEqual";
            buttonEqual.Size = new Size(75, 23);
            buttonEqual.TabIndex = 12;
            buttonEqual.Text = "=";
            buttonEqual.UseVisualStyleBackColor = true;
            buttonEqual.Click += buttonEqual_Click;
            // 
            // buttonCleanAll
            // 
            buttonCleanAll.Location = new Point(336, 48);
            buttonCleanAll.Name = "buttonCleanAll";
            buttonCleanAll.Size = new Size(75, 23);
            buttonCleanAll.TabIndex = 13;
            buttonCleanAll.Text = "C";
            buttonCleanAll.UseVisualStyleBackColor = true;
            buttonCleanAll.Click += buttonCleanAll_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(336, 94);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 14;
            buttonAdd.Text = "+";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonOperator_Click;
            // 
            // buttonSubtract
            // 
            buttonSubtract.Location = new Point(336, 146);
            buttonSubtract.Name = "buttonSubtract";
            buttonSubtract.Size = new Size(75, 23);
            buttonSubtract.TabIndex = 15;
            buttonSubtract.Text = "-";
            buttonSubtract.UseVisualStyleBackColor = true;
            buttonSubtract.Click += buttonOperator_Click;
            // 
            // buttonMultiply
            // 
            buttonMultiply.Location = new Point(336, 195);
            buttonMultiply.Name = "buttonMultiply";
            buttonMultiply.Size = new Size(75, 23);
            buttonMultiply.TabIndex = 16;
            buttonMultiply.Text = "x";
            buttonMultiply.UseVisualStyleBackColor = true;
            buttonMultiply.Click += buttonOperator_Click;
            // 
            // buttonDivide
            // 
            buttonDivide.Location = new Point(336, 244);
            buttonDivide.Name = "buttonDivide";
            buttonDivide.Size = new Size(75, 23);
            buttonDivide.TabIndex = 17;
            buttonDivide.Text = "÷";
            buttonDivide.UseVisualStyleBackColor = true;
            buttonDivide.Click += buttonOperator_Click;
            // 
            // buttonLeftParenthesis
            // 
            buttonLeftParenthesis.Location = new Point(39, 283);
            buttonLeftParenthesis.Name = "buttonLeftParenthesis";
            buttonLeftParenthesis.Size = new Size(75, 23);
            buttonLeftParenthesis.TabIndex = 18;
            buttonLeftParenthesis.Text = "(";
            buttonLeftParenthesis.UseVisualStyleBackColor = true;
            buttonLeftParenthesis.Click += buttonLeftParenthesis_Click;
            // 
            // buttonRightParenthesis
            // 
            buttonRightParenthesis.Location = new Point(136, 283);
            buttonRightParenthesis.Name = "buttonRightParenthesis";
            buttonRightParenthesis.Size = new Size(75, 23);
            buttonRightParenthesis.TabIndex = 19;
            buttonRightParenthesis.Text = ")";
            buttonRightParenthesis.UseVisualStyleBackColor = true;
            buttonRightParenthesis.Click += buttonRightParenthesis_Click;
            // 
            // buttonFactorial
            // 
            buttonFactorial.Location = new Point(232, 283);
            buttonFactorial.Name = "buttonFactorial";
            buttonFactorial.Size = new Size(75, 23);
            buttonFactorial.TabIndex = 20;
            buttonFactorial.Text = "x!";
            buttonFactorial.UseVisualStyleBackColor = true;
            buttonFactorial.Click += buttonFactorial_Click;
            // 
            // buttonSqrt
            // 
            buttonSqrt.Location = new Point(336, 283);
            buttonSqrt.Name = "buttonSqrt";
            buttonSqrt.Size = new Size(75, 23);
            buttonSqrt.TabIndex = 21;
            buttonSqrt.Text = "2√x";
            buttonSqrt.UseVisualStyleBackColor = true;
            buttonSqrt.Click += buttonSqrt_Click;
            // 
            // buttonCleanEntry
            // 
            buttonCleanEntry.Location = new Point(336, 12);
            buttonCleanEntry.Name = "buttonCleanEntry";
            buttonCleanEntry.Size = new Size(75, 23);
            buttonCleanEntry.TabIndex = 22;
            buttonCleanEntry.Text = "CE";
            buttonCleanEntry.UseVisualStyleBackColor = true;
            buttonCleanEntry.Click += buttonCleanEntry_Click;
            // 
            // buttonPower
            // 
            buttonPower.Location = new Point(39, 324);
            buttonPower.Name = "buttonPower";
            buttonPower.Size = new Size(75, 23);
            buttonPower.TabIndex = 23;
            buttonPower.Text = "x^y";
            buttonPower.UseVisualStyleBackColor = true;
            buttonPower.Click += buttonPower_Click;
            // 
            // buttonSquare
            // 
            buttonSquare.Location = new Point(136, 324);
            buttonSquare.Name = "buttonSquare";
            buttonSquare.Size = new Size(75, 23);
            buttonSquare.TabIndex = 24;
            buttonSquare.Text = "x^2";
            buttonSquare.UseVisualStyleBackColor = true;
            buttonSquare.Click += buttonSquare_Click;
            // 
            // panelHistory
            // 
            panelHistory.Controls.Add(listHistory);
            panelHistory.Dock = DockStyle.Right;
            panelHistory.Location = new Point(427, 0);
            panelHistory.Name = "panelHistory";
            panelHistory.Size = new Size(294, 371);
            panelHistory.TabIndex = 25;
            panelHistory.Visible = false;
            // 
            // buttonHistory
            // 
            buttonHistory.Location = new Point(336, 326);
            buttonHistory.Name = "buttonHistory";
            buttonHistory.Size = new Size(75, 23);
            buttonHistory.TabIndex = 26;
            buttonHistory.Text = "History";
            buttonHistory.UseVisualStyleBackColor = true;
            buttonHistory.Click += buttonHistory_Click;
            // 
            // listHistory
            // 
            listHistory.Dock = DockStyle.Fill;
            listHistory.Location = new Point(0, 0);
            listHistory.Name = "listHistory";
            listHistory.Size = new Size(294, 371);
            listHistory.TabIndex = 0;
            listHistory.UseCompatibleStateImageBehavior = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(721, 371);
            Controls.Add(buttonHistory);
            Controls.Add(panelHistory);
            Controls.Add(buttonSquare);
            Controls.Add(buttonPower);
            Controls.Add(buttonCleanEntry);
            Controls.Add(buttonSqrt);
            Controls.Add(buttonFactorial);
            Controls.Add(buttonRightParenthesis);
            Controls.Add(buttonLeftParenthesis);
            Controls.Add(buttonDivide);
            Controls.Add(buttonMultiply);
            Controls.Add(buttonSubtract);
            Controls.Add(buttonAdd);
            Controls.Add(buttonCleanAll);
            Controls.Add(buttonEqual);
            Controls.Add(buttonComa);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(operationTextDisplay);
            Name = "MainForm";
            Text = "Form1";
            panelHistory.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox operationTextDisplay;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button buttonComa;
        private Button buttonEqual;
        private Button buttonCleanAll;
        private Button buttonAdd;
        private Button buttonSubtract;
        private Button buttonMultiply;
        private Button buttonDivide;
        private Button buttonLeftParenthesis;
        private Button buttonRightParenthesis;
        private Button buttonFactorial;
        private Button buttonSqrt;
        private Button buttonCleanEntry;
        private Button buttonPower;
        private Button buttonSquare;
        private Panel panelHistory;
        private Button buttonHistory;
        private ListView listHistory;
    }
}
