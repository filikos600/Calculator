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

namespace Calculator.View
{
    public partial class ExchangeView : UserControl
    {
        private ExchangeEvaluator exchangeEvaluator;
        private ExpressionBuilder expressionBuilderA;
        private ExpressionBuilder expressionBuilderB;

        public event Action<ViewEnum>? RequestViewChange;

        public ExchangeView()
        {
            InitializeComponent();
            //currencyRates = new Dictionary<string, double>();
            exchangeEvaluator = new ExchangeEvaluator();
            expressionBuilderA = new ExpressionBuilder(onlyTwoDecimal: true);
            expressionBuilderA.UpdateTextDisplay += EBUpdateTextDisplayA;
            expressionBuilderB = new ExpressionBuilder(onlyTwoDecimal: true);
            expressionBuilderB.UpdateTextDisplay += EBUpdateTextDisplayB;
            comboBoxView.Items.Add("Mathematic");
            comboBoxView.Items.Add("Currency Exchange");
            comboBoxView.SelectedIndex = 1;
        }

        private void UpdateLastUpdateDate(DateTime time)
        {
            labelLastUpdate.Text = time.ToString();
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
            comboBoxA.SelectedIndex = 1;
            comboBoxB.SelectedIndex = 7;
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

            //UpdateTextDisplayA(exchangeEvaluator.Evaluate(text, comboBoxB.SelectedItem.ToString(), comboBoxA.SelectedItem.ToString()).ToString());
        }

        private async void ExchangeView_Load(object sender, EventArgs e)
        {
            SetupComboBoxes(exchangeEvaluator.rates);
            if (exchangeEvaluator.lastRate != null)
                UpdateLastUpdateDate(exchangeEvaluator.lastRate.Value);

            var currencies = await Task.Run(() => exchangeEvaluator.GetUpdatedExchanges());
            UpdateComboBoxes(currencies);
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

        private async void buttonUpdateRates_Click(object sender, EventArgs e)
        {
            var currencies = await Task.Run(() => exchangeEvaluator.GetUpdatedExchanges());
            UpdateComboBoxes(currencies);
            UpdateLastUpdateDate(currencies[0].CurrencyRateDate.rateDate);
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
        }

        private async void buttonSaveExchange_Click(object sender, EventArgs e)
        {
            await Task.Run(() => exchangeEvaluator.SaveExchangeToDb());
            expressionBuilderA.Reset();
            expressionBuilderB.Reset();
        }
    }
}
