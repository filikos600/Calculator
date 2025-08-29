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
    /// <summary>
    /// UserControl that can be switched to only from ExchangeView, it allows to view the highest exchange rate in given time.
    /// </summary>
    public partial class BestRateHistory : UserControl
    {
        private IDatabaseManager databaseManager;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CurrencyFrom { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CurrencyTo { get; set; }

        public event Action<ViewEnum>? RequestViewChange;

        public BestRateHistory(IDatabaseManager databaseManager)
        {
            InitializeComponent();
            this.VisibleChanged += ExchangeView_VisibleChanged;

            this.databaseManager = databaseManager;

            InitializePanels();
        }

        private void ExchangeView_VisibleChanged(object? sender, EventArgs e)
        {
            if (this.Visible)
            {
                dateTimePickerStart.Value = DateTime.Now.Date;
                dateTimePickerEnd.Value = DateTime.Now.Date;
            }
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
            (bestRate, time) = await databaseManager.GetBestRateFromPeriod(CurrencyFrom, CurrencyTo, startPeriod, endPeriod);
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
                labelRate.Text = $"{bestRate.ToString()} {CurrencyFrom} => {CurrencyTo}"; ;
            }
        }
    }
}

