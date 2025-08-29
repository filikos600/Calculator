using Calculator.Model;
using Calculator.Presenter;
using global::Calculator.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator.View
{
    public partial class BestRateHistory : UserControl
    {
        public event Action<ViewEnum>? RequestViewChange;
        private DatabaseManager databaseManager;
        private string currencyFrom;
        private string currencyTo;

        public BestRateHistory(string currencyFrom, string currencyTo)
        {
            this.currencyFrom = currencyFrom;
            this.currencyTo = currencyTo;
            databaseManager = new DatabaseManager();
            InitializeComponent();
            InitializePanels();
        }

        private void InitializePanels()
        {
            panelInput.Dock = DockStyle.Fill;
            panelInput.Visible = true;
            panelOutput.Dock = DockStyle.Fill;
            panelOutput.Visible = false;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            RequestViewChange?.Invoke(ViewEnum.ExchangeView);
        }

        private async void buttonOk_Click(object sender, EventArgs e)
        {
            var startPeriod = dateTimePickerStart.Value.Date;
            var endPeriod = dateTimePickerEnd.Value.Date;

            if (startPeriod > endPeriod)
            {
                MessageBox.Show("First date must be before second", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime time;
            string bestRate;
            (bestRate, time) = await databaseManager.GetBestRateFromPeriod(currencyFrom, currencyTo, startPeriod, endPeriod);
            panelInput.Visible = false;
            panelOutput.Visible = true;

            if (bestRate == null || bestRate == "")
            {
                labelDate.Visible = false;
                labelRate.Text = "Could not find the best rate from given period";
            }
            else
            {
                labelRate.Text = "Best exchange rate found on:";
                labelDate.Visible = true;
                labelDate.Text = time.Date.ToString();
                labelRate.Text = $"{bestRate.ToString()} {currencyFrom}/{currencyFrom}"; ;
            }
        }
    }
}

