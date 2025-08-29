namespace Calculator.View
{
    partial class BestRateHistory
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
            panelInput = new Panel();
            buttonBack = new Button();
            buttonOk = new Button();
            labelTo = new Label();
            labelFrom = new Label();
            dateTimePickerEnd = new DateTimePicker();
            dateTimePickerStart = new DateTimePicker();
            labelInput = new Label();
            panelOutput = new Panel();
            labelRate = new Label();
            labelDate = new Label();
            buttonOutput = new Button();
            labelOutput = new Label();
            panelInput.SuspendLayout();
            panelOutput.SuspendLayout();
            SuspendLayout();
            // 
            // panelInput
            // 
            panelInput.Controls.Add(buttonBack);
            panelInput.Controls.Add(buttonOk);
            panelInput.Controls.Add(labelTo);
            panelInput.Controls.Add(labelFrom);
            panelInput.Controls.Add(dateTimePickerEnd);
            panelInput.Controls.Add(dateTimePickerStart);
            panelInput.Controls.Add(labelInput);
            panelInput.Location = new Point(89, 93);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(300, 200);
            panelInput.TabIndex = 0;
            // 
            // buttonBack
            // 
            buttonBack.Location = new Point(166, 174);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(75, 23);
            buttonBack.TabIndex = 6;
            buttonBack.Text = "BACK";
            buttonBack.UseVisualStyleBackColor = true;
            buttonBack.Click += buttonBack_Click;
            // 
            // buttonOk
            // 
            buttonOk.Location = new Point(41, 174);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(75, 23);
            buttonOk.TabIndex = 5;
            buttonOk.Text = "OK";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // labelTo
            // 
            labelTo.AutoSize = true;
            labelTo.Location = new Point(41, 117);
            labelTo.Name = "labelTo";
            labelTo.Size = new Size(19, 15);
            labelTo.TabIndex = 4;
            labelTo.Text = "To";
            // 
            // labelFrom
            // 
            labelFrom.AutoSize = true;
            labelFrom.Location = new Point(41, 58);
            labelFrom.Name = "labelFrom";
            labelFrom.Size = new Size(35, 15);
            labelFrom.TabIndex = 3;
            labelFrom.Text = "From";
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.Location = new Point(41, 135);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(200, 23);
            dateTimePickerEnd.TabIndex = 2;
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Location = new Point(41, 76);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(200, 23);
            dateTimePickerStart.TabIndex = 1;
            // 
            // labelInput
            // 
            labelInput.AutoSize = true;
            labelInput.Location = new Point(26, 23);
            labelInput.Name = "labelInput";
            labelInput.Size = new Size(250, 15);
            labelInput.TabIndex = 0;
            labelInput.Text = "Check best exchange rate in given data frame:";
            // 
            // panelOutput
            // 
            panelOutput.Controls.Add(labelRate);
            panelOutput.Controls.Add(labelDate);
            panelOutput.Controls.Add(buttonOutput);
            panelOutput.Controls.Add(labelOutput);
            panelOutput.Location = new Point(462, 92);
            panelOutput.Name = "panelOutput";
            panelOutput.Size = new Size(300, 200);
            panelOutput.TabIndex = 1;
            // 
            // labelRate
            // 
            labelRate.AutoSize = true;
            labelRate.Location = new Point(126, 127);
            labelRate.Name = "labelRate";
            labelRate.Size = new Size(38, 15);
            labelRate.TabIndex = 3;
            labelRate.Text = "label2";
            // 
            // labelDate
            // 
            labelDate.AutoSize = true;
            labelDate.Location = new Point(126, 77);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(38, 15);
            labelDate.TabIndex = 2;
            labelDate.Text = "label1";
            // 
            // buttonOutput
            // 
            buttonOutput.Location = new Point(104, 174);
            buttonOutput.Name = "buttonOutput";
            buttonOutput.Size = new Size(75, 23);
            buttonOutput.TabIndex = 1;
            buttonOutput.Text = "OK";
            buttonOutput.UseVisualStyleBackColor = true;
            buttonOutput.Click += buttonBack_Click;
            // 
            // labelOutput
            // 
            labelOutput.AutoSize = true;
            labelOutput.Location = new Point(87, 24);
            labelOutput.Name = "labelOutput";
            labelOutput.Size = new Size(144, 15);
            labelOutput.TabIndex = 0;
            labelOutput.Text = "Best exchange rate found:";
            // 
            // BestRateHistoryView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelOutput);
            Controls.Add(panelInput);
            Name = "BestRateHistoryView";
            Text = "BestRateHistoryView";
            panelInput.ResumeLayout(false);
            panelInput.PerformLayout();
            panelOutput.ResumeLayout(false);
            panelOutput.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelInput;
        private Panel panelOutput;
        private Label labelInput;
        private DateTimePicker dateTimePickerStart;
        private Label labelTo;
        private Label labelFrom;
        private DateTimePicker dateTimePickerEnd;
        private Button buttonBack;
        private Button buttonOk;
        private Label labelOutput;
        private Button buttonOutput;
        private Label labelDate;
        private Label labelRate;
    }
}