using System.ComponentModel;

namespace Calculator
{
    public partial class MainForm : Form
    {

        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public IEvaluator Evaluator {private get; set; }


        private ExpressionBuilder expressionBuilder;
        private bool historyVisible = false;
        private DatabaseManager databaseManager;
        private List<string> operationsHistory;

        public MainForm()
        {
            InitializeComponent();
            expressionBuilder = new ExpressionBuilder();
            expressionBuilder.UpdateTextDisplay += ExpressionBuilderUpdateTextDisplay;

            databaseManager = new DatabaseManager();
            operationsHistory = new List<string>();

            panelHistory.Visible = false;
            //panelHistory.Controls.Add(listHistory);

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
            var old_expression = expressionBuilder.expression;
            var result = expressionBuilder.EvaluateExpression();
            if (result == null)
                return;
            try
            {
                databaseManager.AddOperation(old_expression, result.Value, "math");
            }
            catch (Exception exDB)
            {
                MessageBox.Show("DataBase Error:\n" + exDB.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            operationsHistory.Add(old_expression + "=" + result.Value);
            if (historyVisible)
            {
                UpdateHistory(old_expression + "=" + result.Value);
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
            panelHistory.Visible = historyVisible;
            if (historyVisible)
            {
                UpdateHistory();
            }
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

    }
}
