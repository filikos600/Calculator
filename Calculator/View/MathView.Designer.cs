namespace Calculator.View
{
    partial class MathView
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
            listHistory = new ListBox();
            buttonHistory = new Button();
            comboBoxView = new ComboBox();
            buttonExit = new Button();
            panelHistory.SuspendLayout();
            SuspendLayout();
            // 
            // operationTextDisplay
            // 
            operationTextDisplay.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            operationTextDisplay.BackColor = Color.FromArgb(40, 40, 40);
            operationTextDisplay.BorderStyle = BorderStyle.None;
            operationTextDisplay.Font = new Font("Arial Rounded MT Bold", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            operationTextDisplay.ForeColor = SystemColors.ControlLightLight;
            operationTextDisplay.Location = new Point(2, 64);
            operationTextDisplay.Name = "operationTextDisplay";
            operationTextDisplay.Size = new Size(496, 56);
            operationTextDisplay.TabIndex = 0;
            operationTextDisplay.Text = "0";
            operationTextDisplay.TextAlign = HorizontalAlignment.Right;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            button1.BackColor = Color.FromArgb(60, 60, 60);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Arial Rounded MT Bold", 18F);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(6, 290);
            button1.Name = "button1";
            button1.Size = new Size(96, 50);
            button1.TabIndex = 1;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = false;
            button1.Click += buttonNumber_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(60, 60, 60);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Arial Rounded MT Bold", 18F);
            button2.ForeColor = SystemColors.ControlLightLight;
            button2.Location = new Point(104, 290);
            button2.Name = "button2";
            button2.Size = new Size(96, 50);
            button2.TabIndex = 2;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = false;
            button2.Click += buttonNumber_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(60, 60, 60);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Arial Rounded MT Bold", 18F);
            button3.ForeColor = SystemColors.ControlLightLight;
            button3.Location = new Point(202, 290);
            button3.Name = "button3";
            button3.Size = new Size(96, 50);
            button3.TabIndex = 3;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = false;
            button3.Click += buttonNumber_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            button4.BackColor = Color.FromArgb(60, 60, 60);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Arial Rounded MT Bold", 18F);
            button4.ForeColor = SystemColors.ControlLightLight;
            button4.Location = new Point(6, 237);
            button4.Name = "button4";
            button4.Size = new Size(96, 50);
            button4.TabIndex = 4;
            button4.Text = "4";
            button4.UseVisualStyleBackColor = false;
            button4.Click += buttonNumber_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(60, 60, 60);
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Arial Rounded MT Bold", 18F);
            button5.ForeColor = SystemColors.ControlLightLight;
            button5.Location = new Point(104, 237);
            button5.Name = "button5";
            button5.Size = new Size(96, 50);
            button5.TabIndex = 5;
            button5.Text = "5";
            button5.UseVisualStyleBackColor = false;
            button5.Click += buttonNumber_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(60, 60, 60);
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Arial Rounded MT Bold", 18F);
            button6.ForeColor = SystemColors.ControlLightLight;
            button6.Location = new Point(202, 237);
            button6.Name = "button6";
            button6.Size = new Size(96, 50);
            button6.TabIndex = 6;
            button6.Text = "6";
            button6.UseVisualStyleBackColor = false;
            button6.Click += buttonNumber_Click;
            // 
            // button7
            // 
            button7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            button7.BackColor = Color.FromArgb(60, 60, 60);
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Arial Rounded MT Bold", 18F);
            button7.ForeColor = SystemColors.ControlLightLight;
            button7.Location = new Point(6, 184);
            button7.Name = "button7";
            button7.Size = new Size(96, 50);
            button7.TabIndex = 7;
            button7.Text = "7";
            button7.UseVisualStyleBackColor = false;
            button7.Click += buttonNumber_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.FromArgb(60, 60, 60);
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Arial Rounded MT Bold", 18F);
            button8.ForeColor = SystemColors.ControlLightLight;
            button8.Location = new Point(104, 184);
            button8.Name = "button8";
            button8.Size = new Size(96, 50);
            button8.TabIndex = 8;
            button8.Text = "8";
            button8.UseVisualStyleBackColor = false;
            button8.Click += buttonNumber_Click;
            // 
            // button9
            // 
            button9.BackColor = Color.FromArgb(60, 60, 60);
            button9.FlatAppearance.BorderSize = 0;
            button9.FlatStyle = FlatStyle.Flat;
            button9.Font = new Font("Arial Rounded MT Bold", 18F);
            button9.ForeColor = SystemColors.ControlLightLight;
            button9.Location = new Point(202, 184);
            button9.Name = "button9";
            button9.Size = new Size(96, 50);
            button9.TabIndex = 9;
            button9.Text = "9";
            button9.UseVisualStyleBackColor = false;
            button9.Click += buttonNumber_Click;
            // 
            // button10
            // 
            button10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            button10.BackColor = Color.FromArgb(60, 60, 60);
            button10.FlatAppearance.BorderSize = 0;
            button10.FlatStyle = FlatStyle.Flat;
            button10.Font = new Font("Arial Rounded MT Bold", 18F);
            button10.ForeColor = SystemColors.ControlLightLight;
            button10.Location = new Point(104, 343);
            button10.Name = "button10";
            button10.Size = new Size(96, 50);
            button10.TabIndex = 10;
            button10.Text = "0";
            button10.UseVisualStyleBackColor = false;
            button10.Click += buttonNumber_Click;
            // 
            // buttonComa
            // 
            buttonComa.BackColor = Color.FromArgb(60, 60, 60);
            buttonComa.FlatAppearance.BorderSize = 0;
            buttonComa.FlatStyle = FlatStyle.Flat;
            buttonComa.Font = new Font("Arial Rounded MT Bold", 18F);
            buttonComa.ForeColor = SystemColors.ControlLightLight;
            buttonComa.Location = new Point(6, 343);
            buttonComa.Name = "buttonComa";
            buttonComa.Size = new Size(96, 50);
            buttonComa.TabIndex = 11;
            buttonComa.Text = ",";
            buttonComa.UseVisualStyleBackColor = false;
            buttonComa.Click += buttonComa_Click;
            // 
            // buttonEqual
            // 
            buttonEqual.BackColor = Color.CornflowerBlue;
            buttonEqual.FlatAppearance.BorderSize = 0;
            buttonEqual.FlatStyle = FlatStyle.Flat;
            buttonEqual.Font = new Font("Arial Rounded MT Bold", 18F);
            buttonEqual.ForeColor = SystemColors.ControlLightLight;
            buttonEqual.Location = new Point(398, 131);
            buttonEqual.Name = "buttonEqual";
            buttonEqual.Size = new Size(96, 50);
            buttonEqual.TabIndex = 12;
            buttonEqual.Text = "=";
            buttonEqual.UseVisualStyleBackColor = false;
            buttonEqual.Click += buttonEqual_Click;
            // 
            // buttonCleanAll
            // 
            buttonCleanAll.BackColor = Color.FromArgb(50, 50, 50);
            buttonCleanAll.FlatAppearance.BorderSize = 0;
            buttonCleanAll.FlatStyle = FlatStyle.Flat;
            buttonCleanAll.Font = new Font("Arial Rounded MT Bold", 18F);
            buttonCleanAll.ForeColor = SystemColors.ControlLightLight;
            buttonCleanAll.Location = new Point(202, 131);
            buttonCleanAll.Name = "buttonCleanAll";
            buttonCleanAll.Size = new Size(96, 50);
            buttonCleanAll.TabIndex = 13;
            buttonCleanAll.Text = "C";
            buttonCleanAll.UseVisualStyleBackColor = false;
            buttonCleanAll.Click += buttonCleanAll_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.BackColor = Color.FromArgb(50, 50, 50);
            buttonAdd.FlatAppearance.BorderSize = 0;
            buttonAdd.FlatStyle = FlatStyle.Flat;
            buttonAdd.Font = new Font("Arial Rounded MT Bold", 18F);
            buttonAdd.ForeColor = SystemColors.ControlLightLight;
            buttonAdd.Location = new Point(300, 343);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(96, 50);
            buttonAdd.TabIndex = 14;
            buttonAdd.Text = "+";
            buttonAdd.UseVisualStyleBackColor = false;
            buttonAdd.Click += buttonOperator_Click;
            // 
            // buttonSubtract
            // 
            buttonSubtract.BackColor = Color.FromArgb(50, 50, 50);
            buttonSubtract.FlatAppearance.BorderSize = 0;
            buttonSubtract.FlatStyle = FlatStyle.Flat;
            buttonSubtract.Font = new Font("Arial Rounded MT Bold", 18F);
            buttonSubtract.ForeColor = SystemColors.ControlLightLight;
            buttonSubtract.Location = new Point(300, 184);
            buttonSubtract.Name = "buttonSubtract";
            buttonSubtract.Size = new Size(96, 50);
            buttonSubtract.TabIndex = 15;
            buttonSubtract.Text = "-";
            buttonSubtract.UseVisualStyleBackColor = false;
            buttonSubtract.Click += buttonOperator_Click;
            // 
            // buttonMultiply
            // 
            buttonMultiply.BackColor = Color.FromArgb(50, 50, 50);
            buttonMultiply.FlatAppearance.BorderSize = 0;
            buttonMultiply.FlatStyle = FlatStyle.Flat;
            buttonMultiply.Font = new Font("Arial Rounded MT Bold", 18F);
            buttonMultiply.ForeColor = SystemColors.ControlLightLight;
            buttonMultiply.Location = new Point(300, 237);
            buttonMultiply.Name = "buttonMultiply";
            buttonMultiply.Size = new Size(96, 50);
            buttonMultiply.TabIndex = 16;
            buttonMultiply.Text = "x";
            buttonMultiply.UseVisualStyleBackColor = false;
            buttonMultiply.Click += buttonOperator_Click;
            // 
            // buttonDivide
            // 
            buttonDivide.BackColor = Color.FromArgb(50, 50, 50);
            buttonDivide.FlatAppearance.BorderSize = 0;
            buttonDivide.FlatStyle = FlatStyle.Flat;
            buttonDivide.Font = new Font("Arial Rounded MT Bold", 18F);
            buttonDivide.ForeColor = SystemColors.ControlLightLight;
            buttonDivide.Location = new Point(300, 290);
            buttonDivide.Name = "buttonDivide";
            buttonDivide.Size = new Size(96, 50);
            buttonDivide.TabIndex = 17;
            buttonDivide.Text = "÷";
            buttonDivide.UseVisualStyleBackColor = false;
            buttonDivide.Click += buttonOperator_Click;
            // 
            // buttonLeftParenthesis
            // 
            buttonLeftParenthesis.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            buttonLeftParenthesis.BackColor = Color.FromArgb(50, 50, 50);
            buttonLeftParenthesis.FlatAppearance.BorderSize = 0;
            buttonLeftParenthesis.FlatStyle = FlatStyle.Flat;
            buttonLeftParenthesis.Font = new Font("Arial Rounded MT Bold", 18F);
            buttonLeftParenthesis.ForeColor = SystemColors.ControlLightLight;
            buttonLeftParenthesis.Location = new Point(6, 131);
            buttonLeftParenthesis.Name = "buttonLeftParenthesis";
            buttonLeftParenthesis.Size = new Size(96, 50);
            buttonLeftParenthesis.TabIndex = 18;
            buttonLeftParenthesis.Text = "(";
            buttonLeftParenthesis.UseVisualStyleBackColor = false;
            buttonLeftParenthesis.Click += buttonLeftParenthesis_Click;
            // 
            // buttonRightParenthesis
            // 
            buttonRightParenthesis.BackColor = Color.FromArgb(50, 50, 50);
            buttonRightParenthesis.FlatAppearance.BorderSize = 0;
            buttonRightParenthesis.FlatStyle = FlatStyle.Flat;
            buttonRightParenthesis.Font = new Font("Arial Rounded MT Bold", 18F);
            buttonRightParenthesis.ForeColor = SystemColors.ControlLightLight;
            buttonRightParenthesis.Location = new Point(104, 131);
            buttonRightParenthesis.Name = "buttonRightParenthesis";
            buttonRightParenthesis.Size = new Size(96, 50);
            buttonRightParenthesis.TabIndex = 19;
            buttonRightParenthesis.Text = ")";
            buttonRightParenthesis.UseVisualStyleBackColor = false;
            buttonRightParenthesis.Click += buttonRightParenthesis_Click;
            // 
            // buttonFactorial
            // 
            buttonFactorial.BackColor = Color.FromArgb(50, 50, 50);
            buttonFactorial.FlatAppearance.BorderSize = 0;
            buttonFactorial.FlatStyle = FlatStyle.Flat;
            buttonFactorial.Font = new Font("Arial Rounded MT Bold", 18F);
            buttonFactorial.ForeColor = SystemColors.ControlLightLight;
            buttonFactorial.Location = new Point(398, 290);
            buttonFactorial.Name = "buttonFactorial";
            buttonFactorial.Size = new Size(96, 50);
            buttonFactorial.TabIndex = 20;
            buttonFactorial.Text = "x!";
            buttonFactorial.UseVisualStyleBackColor = false;
            buttonFactorial.Click += buttonFactorial_Click;
            // 
            // buttonSqrt
            // 
            buttonSqrt.BackColor = Color.FromArgb(50, 50, 50);
            buttonSqrt.FlatAppearance.BorderSize = 0;
            buttonSqrt.FlatStyle = FlatStyle.Flat;
            buttonSqrt.Font = new Font("Arial Rounded MT Bold", 18F);
            buttonSqrt.ForeColor = SystemColors.ControlLightLight;
            buttonSqrt.Location = new Point(398, 184);
            buttonSqrt.Name = "buttonSqrt";
            buttonSqrt.Size = new Size(96, 50);
            buttonSqrt.TabIndex = 21;
            buttonSqrt.Text = "2√x";
            buttonSqrt.UseVisualStyleBackColor = false;
            buttonSqrt.Click += buttonSqrt_Click;
            // 
            // buttonCleanEntry
            // 
            buttonCleanEntry.BackColor = Color.FromArgb(50, 50, 50);
            buttonCleanEntry.FlatAppearance.BorderSize = 0;
            buttonCleanEntry.FlatStyle = FlatStyle.Flat;
            buttonCleanEntry.Font = new Font("Arial Rounded MT Bold", 18F);
            buttonCleanEntry.ForeColor = SystemColors.ControlLightLight;
            buttonCleanEntry.Location = new Point(300, 131);
            buttonCleanEntry.Name = "buttonCleanEntry";
            buttonCleanEntry.Size = new Size(96, 50);
            buttonCleanEntry.TabIndex = 22;
            buttonCleanEntry.Text = "CE";
            buttonCleanEntry.UseVisualStyleBackColor = false;
            buttonCleanEntry.Click += buttonCleanEntry_Click;
            // 
            // buttonPower
            // 
            buttonPower.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            buttonPower.BackColor = Color.FromArgb(50, 50, 50);
            buttonPower.FlatAppearance.BorderSize = 0;
            buttonPower.FlatStyle = FlatStyle.Flat;
            buttonPower.Font = new Font("Arial Rounded MT Bold", 18F);
            buttonPower.ForeColor = SystemColors.ControlLightLight;
            buttonPower.Location = new Point(398, 343);
            buttonPower.Name = "buttonPower";
            buttonPower.Size = new Size(96, 50);
            buttonPower.TabIndex = 23;
            buttonPower.Text = "x^y";
            buttonPower.UseVisualStyleBackColor = false;
            buttonPower.Click += buttonPower_Click;
            // 
            // buttonSquare
            // 
            buttonSquare.BackColor = Color.FromArgb(50, 50, 50);
            buttonSquare.FlatAppearance.BorderSize = 0;
            buttonSquare.FlatStyle = FlatStyle.Flat;
            buttonSquare.Font = new Font("Arial Rounded MT Bold", 18F);
            buttonSquare.ForeColor = SystemColors.ControlLightLight;
            buttonSquare.Location = new Point(398, 237);
            buttonSquare.Name = "buttonSquare";
            buttonSquare.Size = new Size(96, 50);
            buttonSquare.TabIndex = 24;
            buttonSquare.Text = "x^2";
            buttonSquare.UseVisualStyleBackColor = false;
            buttonSquare.Click += buttonSquare_Click;
            // 
            // panelHistory
            // 
            panelHistory.Controls.Add(listHistory);
            panelHistory.Dock = DockStyle.Right;
            panelHistory.Location = new Point(500, 0);
            panelHistory.Name = "panelHistory";
            panelHistory.Size = new Size(300, 400);
            panelHistory.TabIndex = 25;
            panelHistory.Visible = false;
            // 
            // listHistory
            // 
            listHistory.BackColor = Color.FromArgb(40, 40, 40);
            listHistory.BorderStyle = BorderStyle.None;
            listHistory.Dock = DockStyle.Fill;
            listHistory.Font = new Font("Arial Rounded MT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listHistory.ForeColor = SystemColors.ControlLightLight;
            listHistory.FormattingEnabled = true;
            listHistory.Location = new Point(0, 0);
            listHistory.Name = "listHistory";
            listHistory.Size = new Size(300, 400);
            listHistory.TabIndex = 1;
            // 
            // buttonHistory
            // 
            buttonHistory.BackColor = Color.FromArgb(50, 50, 50);
            buttonHistory.FlatAppearance.BorderSize = 0;
            buttonHistory.FlatStyle = FlatStyle.Flat;
            buttonHistory.Font = new Font("Arial Rounded MT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonHistory.ForeColor = SystemColors.ControlLightLight;
            buttonHistory.Location = new Point(300, 9);
            buttonHistory.Name = "buttonHistory";
            buttonHistory.Size = new Size(96, 50);
            buttonHistory.TabIndex = 26;
            buttonHistory.Text = "History";
            buttonHistory.UseVisualStyleBackColor = false;
            buttonHistory.Click += buttonHistory_Click;
            // 
            // comboBoxView
            // 
            comboBoxView.BackColor = Color.FromArgb(50, 50, 50);
            comboBoxView.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxView.Font = new Font("Arial Rounded MT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxView.ForeColor = SystemColors.ControlLightLight;
            comboBoxView.FormattingEnabled = true;
            comboBoxView.Location = new Point(10, 16);
            comboBoxView.Name = "comboBoxView";
            comboBoxView.Size = new Size(288, 32);
            comboBoxView.TabIndex = 27;
            comboBoxView.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // buttonExit
            // 
            buttonExit.BackColor = Color.FromArgb(60, 60, 60);
            buttonExit.FlatAppearance.BorderSize = 0;
            buttonExit.FlatStyle = FlatStyle.Flat;
            buttonExit.Font = new Font("Arial Rounded MT Bold", 18F);
            buttonExit.ForeColor = SystemColors.ControlLightLight;
            buttonExit.Location = new Point(398, 9);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(96, 50);
            buttonExit.TabIndex = 31;
            buttonExit.Text = "Exit";
            buttonExit.UseVisualStyleBackColor = false;
            buttonExit.Click += buttonExit_Click;
            // 
            // MathView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(40, 40, 40);
            Controls.Add(buttonExit);
            Controls.Add(comboBoxView);
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
            Name = "MathView";
            Size = new Size(800, 400);
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
        private ComboBox comboBoxView;
        private Button buttonExit;
        private ListBox listHistory;
    }
}
