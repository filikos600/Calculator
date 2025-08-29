using Calculator.Data;
using Calculator.Model;
using Calculator.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace Calculator.View
{

    /// <summary>
    /// UserControl that correspond to currency rate exchange calulator view.
    /// </summary>
    public partial class ExchangeView : UserControl
    {
        private readonly IExchangeEvaluator exchangeEvaluator;
        private readonly IExpressionBuilder expressionBuilderA;
        private readonly IExpressionBuilder expressionBuilderB;

        private bool historyVisible = false;
        private List<string> operationsHistory;

        public event Action<ViewEnum>? RequestViewChange;
        public event Action<string, string>? RequestBestRateViewChange;

        public event Action<bool> RequestHistoryPanel;

        public ExchangeView(IExchangeEvaluator exchangeEvaluator, IExpressionBuilder expressionBuilderA, IExpressionBuilder expressionBuilderB)
        {
            InitializeComponent();
            this.VisibleChanged += ExchangeView_VisibleChanged;

            this.exchangeEvaluator = exchangeEvaluator;
            this.expressionBuilderA = expressionBuilderA;
            this.expressionBuilderB = expressionBuilderB;

            expressionBuilderA.onlyTwoDecimal = true;
            expressionBuilderA.UpdateTextDisplay += EBUpdateTextDisplayA;

            expressionBuilderB.onlyTwoDecimal = true;
            expressionBuilderB.UpdateTextDisplay += EBUpdateTextDisplayB;

            comboBoxView.Items.Add("Mathematical");
            comboBoxView.Items.Add("Currency Exchange");
            comboBoxView.SelectedIndex = 1;

            operationsHistory = new List<string>();
            panelHistory.Visible = false;
        }

        private async void ExchangeView_Load(object sender, EventArgs e)
        {
            SetupComboBoxes(exchangeEvaluator.GetRates());
            UpdateRateLabel();
            if (exchangeEvaluator.GetLastRateDate() != null)
                UpdateLastUpdateDateLabel(exchangeEvaluator.GetLastRateDate());

            UpdateRates();
            UpdateRateLabel();

        }

        private void ExchangeView_VisibleChanged(object? sender, EventArgs e)
        {
            if (this.Visible)
            {
                expressionBuilderA.Reset();
                expressionBuilderB.Reset();
                comboBoxView.SelectedIndex = 1;
            }
        }

        private void UpdateLastUpdateDateLabel(DateTime time)
        {

            labelLastUpdate.Text = $"updated: {time.Day.ToString()}.{time.Month.ToString()}.{time.Year.ToString()}";
        }

        private void UpdateRateLabel()
        {
            var firstCurr = comboBoxA.SelectedItem.ToString();
            var secondCurr = comboBoxB.SelectedItem.ToString();
            var rate = exchangeEvaluator.GetRate(firstCurr, secondCurr);
            labelRate.Text = $"1 {firstCurr} = {rate.ToString("F2")} {secondCurr}";
        }

        private void UpdateComboBoxes(List<CurrencyRate> currencies)
        {

            var selectedA = comboBoxA.SelectedIndex;
            var selectedTo = comboBoxB.SelectedIndex;
            comboBoxA.Items.Clear();
            comboBoxB.Items.Clear();
            foreach (var currency in currencies)
            {
                comboBoxA.Items.Add(currency.CurrencyRateCode.rateCode);
                comboBoxB.Items.Add(currency.CurrencyRateCode.rateCode);
            }
            comboBoxA.SelectedIndex = selectedA;
            comboBoxB.SelectedIndex = selectedTo;
        }

        private void SetupComboBoxes(Dictionary<string, double> currencies)
        {
            var selectedA = comboBoxA.SelectedIndex;
            var selectedTo = comboBoxB.SelectedIndex;
            comboBoxA.Items.Clear();
            comboBoxB.Items.Clear();
            foreach (var currency in currencies)
            {
                comboBoxA.Items.Add(currency.Key);
                comboBoxB.Items.Add(currency.Key);
            }
            comboBoxA.SelectedIndex = 0;
            comboBoxB.SelectedIndex = 2;
        }

        private void EBUpdateTextDisplayA(string text)
        {

            if (textBoxValueA.InvokeRequired)
                textBoxValueA.Invoke(new Action(() => textBoxValueA.Text = text));
            else
                textBoxValueA.Text = text;

            UpdateTextDisplayB(exchangeEvaluator.Evaluate(text, comboBoxA.SelectedItem.ToString(), comboBoxB.SelectedItem.ToString()).ToString());
        }

        private void EBUpdateTextDisplayB(string text)
        {
            var formattedString = Double.Parse(text).ToString("F2");
            if (textBoxValueB.InvokeRequired)
                textBoxValueB.Invoke(new Action(() => textBoxValueB.Text = formattedString));
            else
                textBoxValueB.Text = formattedString;

        }

        private void UpdateTextDisplayB(string text)
        {
            var formattedString = Double.Parse(text).ToString("F2");
            if (textBoxValueB.InvokeRequired)
                textBoxValueB.Invoke(new Action(() => textBoxValueB.Text = formattedString));
            else
                textBoxValueB.Text = formattedString;
        }

        private void comboBoxView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxView.SelectedIndex == 0)
            {
                RequestViewChange?.Invoke((ViewEnum)comboBoxView.SelectedIndex);
            }
        }

        private void buttonNumber_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            expressionBuilderA.AddDigit(button.Text);
        }

        private void buttonComa_Click(object sender, EventArgs e)
        {
            expressionBuilderA.AddComa();
        }

        private void buttonClearEntry_Click(object sender, EventArgs e)
        {
            expressionBuilderA.CleanEntry();
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            expressionBuilderA.Reset();
            expressionBuilderB.Reset();
        }

        private async void UpdateRates()
        {
            List<CurrencyRate> currencies;
            try
            {
                currencies = await Task.Run(() => exchangeEvaluator.GetUpdatedExchangesFromDbOrApi());
            }
            catch (Exception HttpRequestException)
            {
                MessageBox.Show($"Failed to fetch accurate exchange rates", "Failed to reach API", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                currencies = await Task.Run(() => exchangeEvaluator.GetUpdatesFromDB());

            }
            if (currencies.Count > 0)
            {
                UpdateComboBoxes(currencies);
                UpdateLastUpdateDateLabel(currencies[0].CurrencyRateDate.rateDate);
            }
        }

        private void buttonUpdateRates_Click(object sender, EventArgs e)
        {
            UpdateRates();
            UpdateRateLabel();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxA.SelectedItem == null || comboBoxB.SelectedItem == null)
                return;
            var resultB = exchangeEvaluator.Evaluate(
                textBoxValueA.Text,
                comboBoxA.SelectedItem.ToString(),
                comboBoxB.SelectedItem.ToString()
                ).ToString("F2");
            UpdateTextDisplayB(resultB);
            UpdateRateLabel();
        }

        private async void buttonSaveExchange_Click(object sender, EventArgs e)
        {
            var textFrom = textBoxValueA.Text;
            var curFrom = comboBoxA.SelectedItem.ToString();
            var curTo = comboBoxB.SelectedItem.ToString();
            var textTo = textBoxValueB.Text;

            await Task.Run(() => exchangeEvaluator.SaveExchangeToDb(textFrom, curFrom, curTo, textTo));
            operationsHistory.Add($"{textFrom} {curFrom} => {textTo} {curTo}");

            expressionBuilderA.Reset();
            expressionBuilderB.Reset();

            UpdateHistory();
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            historyVisible = !historyVisible;
            if (historyVisible)
            {
                RequestHistoryPanel(true);
                UpdateHistory();
            }
            else
            {
                RequestHistoryPanel(false);
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
                listHistory.Items.Add($"  {oper}");
            }
            if (operationsHistory.Count == 0)
                listHistory.Items.Add("  history is empty");
        }

        private void buttonBestRate_Click(object sender, EventArgs e)
        {
            string from = comboBoxA.SelectedItem.ToString();
            string to = comboBoxB.SelectedItem.ToString();

            RequestBestRateViewChange?.Invoke(from, to);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
