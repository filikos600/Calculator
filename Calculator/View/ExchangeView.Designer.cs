namespace Calculator.View
{
    partial class ExchangeView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            textBoxValueA = new TextBox();
            textBoxValueB = new TextBox();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            button9 = new Button();
            button0 = new Button();
            buttonComa = new Button();
            buttonClearEntry = new Button();
            buttonClearAll = new Button();
            comboBoxA = new ComboBox();
            comboBoxB = new ComboBox();
            labelRate = new Label();
            labelLastUpdate = new Label();
            buttonUpdateRates = new Button();
            comboBoxView = new ComboBox();
            buttonSave = new Button();
            buttonHistory = new Button();
            panelHistory = new Panel();
            listHistory = new ListView();
            buttonBestRate = new Button();
            panelHistory.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(64, 176);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonNumber_Click;
            // 
            // textBoxValueA
            // 
            textBoxValueA.Location = new Point(64, 92);
            textBoxValueA.Name = "textBoxValueA";
            textBoxValueA.ReadOnly = true;
            textBoxValueA.Size = new Size(100, 23);
            textBoxValueA.TabIndex = 1;
            textBoxValueA.Text = "0";
            // 
            // textBoxValueB
            // 
            textBoxValueB.Location = new Point(252, 92);
            textBoxValueB.Name = "textBoxValueB";
            textBoxValueB.ReadOnly = true;
            textBoxValueB.Size = new Size(100, 23);
            textBoxValueB.TabIndex = 2;
            textBoxValueB.Text = "0";
            // 
            // button2
            // 
            button2.Location = new Point(155, 176);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonNumber_Click;
            // 
            // button3
            // 
            button3.Location = new Point(240, 176);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 4;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += buttonNumber_Click;
            // 
            // button4
            // 
            button4.Location = new Point(64, 219);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 5;
            button4.Text = "4";
            button4.UseVisualStyleBackColor = true;
            button4.Click += buttonNumber_Click;
            // 
            // button5
            // 
            button5.Location = new Point(155, 219);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 6;
            button5.Text = "5";
            button5.UseVisualStyleBackColor = true;
            button5.Click += buttonNumber_Click;
            // 
            // button6
            // 
            button6.Location = new Point(240, 219);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 7;
            button6.Text = "6";
            button6.UseVisualStyleBackColor = true;
            button6.Click += buttonNumber_Click;
            // 
            // button7
            // 
            button7.Location = new Point(64, 265);
            button7.Name = "button7";
            button7.Size = new Size(75, 23);
            button7.TabIndex = 8;
            button7.Text = "7";
            button7.UseVisualStyleBackColor = true;
            button7.Click += buttonNumber_Click;
            // 
            // button8
            // 
            button8.Location = new Point(155, 265);
            button8.Name = "button8";
            button8.Size = new Size(75, 23);
            button8.TabIndex = 9;
            button8.Text = "8";
            button8.UseVisualStyleBackColor = true;
            button8.Click += buttonNumber_Click;
            // 
            // button9
            // 
            button9.Location = new Point(240, 265);
            button9.Name = "button9";
            button9.Size = new Size(75, 23);
            button9.TabIndex = 10;
            button9.Text = "9";
            button9.UseVisualStyleBackColor = true;
            button9.Click += buttonNumber_Click;
            // 
            // button0
            // 
            button0.Location = new Point(64, 304);
            button0.Name = "button0";
            button0.Size = new Size(75, 23);
            button0.TabIndex = 11;
            button0.Text = "0";
            button0.UseVisualStyleBackColor = true;
            button0.Click += buttonNumber_Click;
            // 
            // buttonComa
            // 
            buttonComa.Location = new Point(240, 308);
            buttonComa.Name = "buttonComa";
            buttonComa.Size = new Size(75, 23);
            buttonComa.TabIndex = 12;
            buttonComa.Text = ",";
            buttonComa.UseVisualStyleBackColor = true;
            buttonComa.Click += buttonComa_Click;
            // 
            // buttonClearEntry
            // 
            buttonClearEntry.Location = new Point(321, 219);
            buttonClearEntry.Name = "buttonClearEntry";
            buttonClearEntry.Size = new Size(75, 23);
            buttonClearEntry.TabIndex = 13;
            buttonClearEntry.Text = "CE";
            buttonClearEntry.UseVisualStyleBackColor = true;
            buttonClearEntry.Click += buttonClearEntry_Click;
            // 
            // buttonClearAll
            // 
            buttonClearAll.Location = new Point(321, 176);
            buttonClearAll.Name = "buttonClearAll";
            buttonClearAll.Size = new Size(75, 23);
            buttonClearAll.TabIndex = 14;
            buttonClearAll.Text = "C";
            buttonClearAll.UseVisualStyleBackColor = true;
            buttonClearAll.Click += buttonClearAll_Click;
            // 
            // comboBoxA
            // 
            comboBoxA.FormattingEnabled = true;
            comboBoxA.Location = new Point(64, 123);
            comboBoxA.Name = "comboBoxA";
            comboBoxA.Size = new Size(121, 23);
            comboBoxA.TabIndex = 15;
            comboBoxA.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            // 
            // comboBoxB
            // 
            comboBoxB.FormattingEnabled = true;
            comboBoxB.Location = new Point(252, 123);
            comboBoxB.Name = "comboBoxB";
            comboBoxB.Size = new Size(121, 23);
            comboBoxB.TabIndex = 16;
            comboBoxB.SelectedIndexChanged += comboBox_SelectedIndexChanged;
            // 
            // labelRate
            // 
            labelRate.AutoSize = true;
            labelRate.Location = new Point(162, 355);
            labelRate.Name = "labelRate";
            labelRate.Size = new Size(68, 15);
            labelRate.TabIndex = 18;
            labelRate.Text = "last update:";
            // 
            // labelLastUpdate
            // 
            labelLastUpdate.AutoSize = true;
            labelLastUpdate.Location = new Point(174, 384);
            labelLastUpdate.Name = "labelLastUpdate";
            labelLastUpdate.Size = new Size(38, 15);
            labelLastUpdate.TabIndex = 19;
            labelLastUpdate.Text = "label2";
            // 
            // buttonUpdateRates
            // 
            buttonUpdateRates.Location = new Point(236, 365);
            buttonUpdateRates.Name = "buttonUpdateRates";
            buttonUpdateRates.Size = new Size(114, 23);
            buttonUpdateRates.TabIndex = 20;
            buttonUpdateRates.Text = "update rates";
            buttonUpdateRates.UseVisualStyleBackColor = true;
            buttonUpdateRates.Click += buttonUpdateRates_Click;
            // 
            // comboBoxView
            // 
            comboBoxView.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxView.FormattingEnabled = true;
            comboBoxView.Location = new Point(10, 35);
            comboBoxView.Name = "comboBoxView";
            comboBoxView.Size = new Size(121, 23);
            comboBoxView.TabIndex = 21;
            comboBoxView.SelectedIndexChanged += comboBoxView_SelectedIndexChanged;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(377, 92);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 22;
            buttonSave.Text = "buttonSaveExchange";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSaveExchange_Click;
            // 
            // buttonHistory
            // 
            buttonHistory.Location = new Point(395, 123);
            buttonHistory.Name = "buttonHistory";
            buttonHistory.Size = new Size(75, 23);
            buttonHistory.TabIndex = 27;
            buttonHistory.Text = "History";
            buttonHistory.UseVisualStyleBackColor = true;
            buttonHistory.Click += buttonHistory_Click;
            // 
            // panelHistory
            // 
            panelHistory.Controls.Add(listHistory);
            panelHistory.Dock = DockStyle.Right;
            panelHistory.Location = new Point(500, 0);
            panelHistory.Name = "panelHistory";
            panelHistory.Size = new Size(300, 450);
            panelHistory.TabIndex = 28;
            panelHistory.Visible = false;
            // 
            // listHistory
            // 
            listHistory.Dock = DockStyle.Fill;
            listHistory.Location = new Point(0, 0);
            listHistory.MinimumSize = new Size(200, 400);
            listHistory.Name = "listHistory";
            listHistory.Size = new Size(300, 450);
            listHistory.TabIndex = 0;
            listHistory.UseCompatibleStateImageBehavior = false;
            // 
            // buttonBestRate
            // 
            buttonBestRate.Location = new Point(162, 35);
            buttonBestRate.Name = "buttonBestRate";
            buttonBestRate.Size = new Size(178, 41);
            buttonBestRate.TabIndex = 29;
            buttonBestRate.Text = "Check Best Historical Rate";
            buttonBestRate.UseVisualStyleBackColor = true;
            buttonBestRate.Click += buttonBestRate_Click;
            // 
            // ExchangeView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonBestRate);
            Controls.Add(panelHistory);
            Controls.Add(buttonHistory);
            Controls.Add(buttonSave);
            Controls.Add(comboBoxView);
            Controls.Add(buttonUpdateRates);
            Controls.Add(labelLastUpdate);
            Controls.Add(labelRate);
            Controls.Add(comboBoxB);
            Controls.Add(comboBoxA);
            Controls.Add(buttonClearAll);
            Controls.Add(buttonClearEntry);
            Controls.Add(buttonComa);
            Controls.Add(button0);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(textBoxValueB);
            Controls.Add(textBoxValueA);
            Controls.Add(button1);
            MinimumSize = new Size(450, 400);
            Name = "ExchangeView";
            Size = new Size(800, 450);
            Load += ExchangeView_Load;
            panelHistory.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBoxValueA;
        private TextBox textBoxValueB;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button0;
        private Button buttonComa;
        private Button buttonClearEntry;
        private Button buttonClearAll;
        private ComboBox comboBoxA;
        private ComboBox comboBoxB;
        private Label labelRate;
        private Label labelLastUpdate;
        private Button buttonUpdateRates;
        private ComboBox comboBoxView;
        private Button buttonSave;
        private Button buttonHistory;
        private Panel panelHistory;
        private ListView listHistory;
        private Button buttonBestRate;
    }
}