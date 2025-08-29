using Calculator.Model;
using Calculator.Presenter;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator.View
{
    public partial class MathView : UserControl
    {
        private ExpressionBuilder expressionBuilder;
        private bool historyVisible = false;
        private MathEvaluator mathEvaluator;
        private List<string> operationsHistory;

        public event Action<ViewEnum>? RequestViewChange;

        public MathView()
        {
            InitializeComponent();
            expressionBuilder = new ExpressionBuilder();
            expressionBuilder.UpdateTextDisplay += ExpressionBuilderUpdateTextDisplay;
            operationsHistory = new List<string>();

            panelHistory.Visible = false;

            mathEvaluator = new MathEvaluator();

            comboBoxView.Items.Add("Mathematic");
            comboBoxView.Items.Add("Currency Exchange");
            comboBoxView.SelectedIndex = 0;

            UpdateHistory();

        }

        private void MathView_Load(object sender, EventArgs e)
        {
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
            //this.Size = new System.Drawing.Size(Convert.ToInt32(0.3 * workingRectangle.Width), Convert.ToInt32(0.3 * workingRectangle.Height));
            this.Location = new System.Drawing.Point(Convert.ToInt32(0.3 * workingRectangle.Width), Convert.ToInt32(0.3 * workingRectangle.Height));
        }

        private void ExpressionBuilderUpdateTextDisplay(string text)
        {
            if (operationTextDisplay.InvokeRequired)
                operationTextDisplay.Invoke(new Action(() => operationTextDisplay.Text = text));
            else
                operationTextDisplay.Text = text;
        }

        private void buttonOperator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            expressionBuilder.AddOperator(button.Text);
        }

        private void buttonNumber_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            expressionBuilder.AddDigit(button.Text);
        }

        private void buttonComa_Click(object sender, EventArgs e)
        {
            expressionBuilder.AddComa();
        }

        private void buttonCleanAll_Click(object sender, EventArgs e)
        {
            expressionBuilder.Reset();
        }

        private async void buttonEqual_Click(object sender, EventArgs e)
        {
            var old_expression = expressionBuilder.ValidateExpression();
            if (old_expression == null)
                return;
            var result = 0d;
            try
            {
                result = await Task.Run(() => mathEvaluator.Evaluate(old_expression));
                expressionBuilder.SetResult(result);
            }
            catch (Exception ex)
            {
                expressionBuilder.Reset();
                ExpressionBuilderUpdateTextDisplay(ex.ToString());
                return;
            }

            operationsHistory.Add(old_expression + "=" + result);
            if (historyVisible)
            {
                UpdateHistory(old_expression + "=" + result);
            }
        }

        private void buttonRightParenthesis_Click(object sender, EventArgs e)
        {
            expressionBuilder.AddRightParenthesis();
        }

        private void buttonLeftParenthesis_Click(object sender, EventArgs e)
        {
            expressionBuilder.AddLeftParenthesis();
        }

        private void buttonFactorial_Click(object sender, EventArgs e)
        {
            expressionBuilder.AddFunction("fact");
        }

        private void buttonSqrt_Click(object sender, EventArgs e)
        {
            expressionBuilder.AddFunction("sqrt");
        }

        private void buttonCleanEntry_Click(object sender, EventArgs e)
        {
            expressionBuilder.CleanEntry();
        }

        private void buttonPower_Click(object sender, EventArgs e)
        {
            expressionBuilder.AddPower();
        }

        private void buttonSquare_Click(object sender, EventArgs e)
        {
            expressionBuilder.AddPower(square: true);
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            historyVisible = !historyVisible;
            if (historyVisible)
            {
                this.MinimumSize = new Size(MinimumSize.Width + 300, MinimumSize.Height);
                UpdateHistory();
            }
            else
            {
                this.MinimumSize = new Size(MinimumSize.Width - 300, MinimumSize.Height);
                this.Width -= 300;
            }
            panelHistory.Visible = historyVisible;
        }
        private void UpdateHistory()
        {
            if (listHistory == null)
                return;
            listHistory.Items.Clear();
            foreach (var oper in operationsHistory)
            {
                listHistory.Items.Add(oper);
            }
        }

        private void UpdateHistory(string operation)
        {
            if (listHistory == null)
                return;
            listHistory.Items.Add(operation);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxView.SelectedIndex == 1)
            {
                RequestViewChange?.Invoke((ViewEnum)comboBoxView.SelectedIndex);
            }
        }
    }
}
