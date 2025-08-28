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
            expressionBuilderA = new ExpressionBuilder();
            expressionBuilderA.UpdateTextDisplay += EBUpdateTextDisplayA;
            expressionBuilderB = new ExpressionBuilder();
            expressionBuilderB.UpdateTextDisplay += EBUpdateTextDisplayB;
            comboBoxView.Items.Add("Mathematic");
            comboBoxView.Items.Add("Currency Exchange");
            comboBoxView.SelectedIndex = 1;
        }

        private void UpdateComboBoxes(List<CurrencyRate> currencies)
        {
            var selectedA = comboBoxA.SelectedIndex;
            var selectedTo = comboBoxB.SelectedIndex;
            comboBoxA.Items.Clear();
            comboBoxB.Items.Clear();
            foreach (var currency in currencies)
            {
                comboBoxA.Items.Add(currency.currencyCode);
                comboBoxB.Items.Add(currency.currencyCode);
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
            if (textBoxValueB.InvokeRequired)
                textBoxValueB.Invoke(new Action(() => textBoxValueB.Text = text));
            else
                textBoxValueB.Text = text;

        }

        private void UpdateTextDisplayA(string text)
        {
            if (textBoxValueA.InvokeRequired)
                textBoxValueA.Invoke(new Action(() => textBoxValueA.Text = text));
            else
                textBoxValueA.Text = text;
        }

        private void UpdateTextDisplayB(string text)
        {
            if (textBoxValueB.InvokeRequired)
                textBoxValueB.Invoke(new Action(() => textBoxValueB.Text = text));
            else
                textBoxValueB.Text = text;

            //UpdateTextDisplayA(exchangeEvaluator.Evaluate(text, comboBoxB.SelectedItem.ToString(), comboBoxA.SelectedItem.ToString()).ToString());
        }

        private async void ExchangeView_Load(object sender, EventArgs e)
        {
            SetupComboBoxes(exchangeEvaluator.rates);

            var currencies = await Task.Run(() => exchangeEvaluator.UpdateExchanges());
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
            var currencies = await Task.Run(() => exchangeEvaluator.UpdateExchanges());
            UpdateComboBoxes(currencies);
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxA.SelectedItem == null || comboBoxB.SelectedItem == null)
                return;
            var resultB = exchangeEvaluator.Evaluate(
                textBoxValueA.Text,
                comboBoxA.SelectedItem.ToString(),
                comboBoxB.SelectedItem.ToString()
                ).ToString();
            UpdateTextDisplayB(resultB);
        }

    }
}
