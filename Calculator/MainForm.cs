using System.ComponentModel;

namespace Calculator
{
    public partial class MainForm : Form
    {

        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public IEvaluator Evaluator {private get; set; }


        private ExpressionBuilder expressionBuilder;

        public MainForm()
        {
            InitializeComponent();
            expressionBuilder = new ExpressionBuilder();
            expressionBuilder.UpdateTextDisplay += ExpressionBuilderUpdateTextDisplay;

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

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            expressionBuilder.EvaluateExpression();
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
    }
}
