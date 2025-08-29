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
            panelInput.BackColor = Color.FromArgb(40, 40, 40);
            panelInput.Controls.Add(buttonBack);
            panelInput.Controls.Add(buttonOk);
            panelInput.Controls.Add(labelTo);
            panelInput.Controls.Add(labelFrom);
            panelInput.Controls.Add(dateTimePickerEnd);
            panelInput.Controls.Add(dateTimePickerStart);
            panelInput.Controls.Add(labelInput);
            panelInput.Location = new Point(0, 0);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(400, 400);
            panelInput.TabIndex = 0;
            // 
            // buttonBack
            // 
            buttonBack.BackColor = Color.FromArgb(50, 50, 50);
            buttonBack.FlatAppearance.BorderSize = 0;
            buttonBack.FlatStyle = FlatStyle.Flat;
            buttonBack.Font = new Font("Arial Rounded MT Bold", 18F);
            buttonBack.ForeColor = SystemColors.ControlLightLight;
            buttonBack.Location = new Point(224, 300);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(96, 50);
            buttonBack.TabIndex = 6;
            buttonBack.Text = "BACK";
            buttonBack.UseVisualStyleBackColor = false;
            buttonBack.Click += buttonBack_Click;
            // 
            // buttonOk
            // 
            buttonOk.BackColor = Color.FromArgb(50, 50, 50);
            buttonOk.FlatAppearance.BorderSize = 0;
            buttonOk.FlatStyle = FlatStyle.Flat;
            buttonOk.Font = new Font("Arial Rounded MT Bold", 18F);
            buttonOk.ForeColor = SystemColors.ControlLightLight;
            buttonOk.Location = new Point(80, 300);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(96, 50);
            buttonOk.TabIndex = 5;
            buttonOk.Text = "OK";
            buttonOk.UseVisualStyleBackColor = false;
            buttonOk.Click += buttonOk_Click;
            // 
            // labelTo
            // 
            labelTo.Font = new Font("Arial Rounded MT Bold", 27.75F);
            labelTo.ForeColor = SystemColors.ControlLightLight;
            labelTo.Location = new Point(100, 204);
            labelTo.Name = "labelTo";
            labelTo.Size = new Size(200, 43);
            labelTo.TabIndex = 4;
            labelTo.Text = "To";
            labelTo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelFrom
            // 
            labelFrom.Font = new Font("Arial Rounded MT Bold", 27.75F);
            labelFrom.ForeColor = SystemColors.ControlLightLight;
            labelFrom.Location = new Point(100, 115);
            labelFrom.Name = "labelFrom";
            labelFrom.Size = new Size(200, 43);
            labelFrom.TabIndex = 3;
            labelFrom.Text = "From";
            labelFrom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dateTimePickerEnd
            // 
            dateTimePickerEnd.CalendarFont = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerEnd.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            dateTimePickerEnd.Format = DateTimePickerFormat.Short;
            dateTimePickerEnd.Location = new Point(100, 250);
            dateTimePickerEnd.Name = "dateTimePickerEnd";
            dateTimePickerEnd.Size = new Size(200, 35);
            dateTimePickerEnd.TabIndex = 2;
            // 
            // dateTimePickerStart
            // 
            dateTimePickerStart.Font = new Font("Arial Rounded MT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePickerStart.Format = DateTimePickerFormat.Short;
            dateTimePickerStart.Location = new Point(100, 174);
            dateTimePickerStart.Name = "dateTimePickerStart";
            dateTimePickerStart.Size = new Size(200, 32);
            dateTimePickerStart.TabIndex = 1;
            // 
            // labelInput
            // 
            labelInput.Font = new Font("Arial Rounded MT Bold", 27.75F);
            labelInput.ForeColor = SystemColors.ControlLightLight;
            labelInput.Location = new Point(0, 0);
            labelInput.Name = "labelInput";
            labelInput.Size = new Size(400, 106);
            labelInput.TabIndex = 0;
            labelInput.Text = "Check best exchange rate";
            labelInput.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelOutput
            // 
            panelOutput.BackColor = Color.FromArgb(40, 40, 40);
            panelOutput.Controls.Add(labelRate);
            panelOutput.Controls.Add(labelDate);
            panelOutput.Controls.Add(buttonOutput);
            panelOutput.Controls.Add(labelOutput);
            panelOutput.Location = new Point(400, 0);
            panelOutput.Name = "panelOutput";
            panelOutput.Size = new Size(400, 400);
            panelOutput.TabIndex = 1;
            // 
            // labelRate
            // 
            labelRate.Font = new Font("Arial Rounded MT Bold", 27.75F);
            labelRate.ForeColor = SystemColors.ControlLightLight;
            labelRate.Location = new Point(100, 224);
            labelRate.Name = "labelRate";
            labelRate.Size = new Size(200, 43);
            labelRate.TabIndex = 3;
            labelRate.Text = "label2";
            labelRate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelDate
            // 
            labelDate.Font = new Font("Arial Rounded MT Bold", 27.75F);
            labelDate.ForeColor = SystemColors.ControlLightLight;
            labelDate.Location = new Point(100, 135);
            labelDate.Name = "labelDate";
            labelDate.Size = new Size(200, 43);
            labelDate.TabIndex = 2;
            labelDate.Text = "label1";
            labelDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonOutput
            // 
            buttonOutput.BackColor = Color.FromArgb(50, 50, 50);
            buttonOutput.FlatAppearance.BorderSize = 0;
            buttonOutput.FlatStyle = FlatStyle.Flat;
            buttonOutput.Font = new Font("Arial Rounded MT Bold", 18F);
            buttonOutput.ForeColor = SystemColors.ControlLightLight;
            buttonOutput.Location = new Point(150, 300);
            buttonOutput.Name = "buttonOutput";
            buttonOutput.Size = new Size(96, 50);
            buttonOutput.TabIndex = 1;
            buttonOutput.Text = "OK";
            buttonOutput.UseVisualStyleBackColor = false;
            buttonOutput.Click += buttonBack_Click;
            // 
            // labelOutput
            // 
            labelOutput.Font = new Font("Arial Rounded MT Bold", 27.75F);
            labelOutput.ForeColor = SystemColors.ControlLightLight;
            labelOutput.Location = new Point(23, 11);
            labelOutput.Name = "labelOutput";
            labelOutput.Size = new Size(343, 103);
            labelOutput.TabIndex = 0;
            labelOutput.Text = "Best exchange rate found:";
            labelOutput.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BestRateHistory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelOutput);
            Controls.Add(panelInput);
            Name = "BestRateHistory";
            Size = new Size(800, 400);
            panelInput.ResumeLayout(false);
            panelOutput.ResumeLayout(false);
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