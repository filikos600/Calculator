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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator.View
{
    public partial class MainForm : Form
    {
        private readonly MathView mathView;
        private readonly ExchangeView exchangeView;
        private readonly BestRateHistory bestRateHistory;
        public MainForm(MathView mathView, ExchangeView exchangeView, BestRateHistory bestRateHistory)
        {
            InitializeComponent();
            this.mathView = mathView;
            this.exchangeView = exchangeView;
            this.bestRateHistory = bestRateHistory;

            panel1.Controls.Add(mathView);
            HandleViewChange(ViewEnum.MathView);
        }

        private void ChangeView(UserControl view)
        {
            panel1.Controls.Clear();
            view.Dock = DockStyle.Fill;
            panel1.Controls.Add(view);

            if (view is MathView v1)
                v1.RequestViewChange += HandleViewChange;
            if (view is ExchangeView v2)
            {
                v2.RequestViewChange += HandleViewChange;
                v2.RequestBestRateViewChange += HandleBestRateViewChange;
            }
            if (view is BestRateHistory v3)
                v3.RequestViewChange += HandleViewChange;
        }

        private void HandleViewChange(ViewEnum viewName)
        {
            switch (viewName)
            {
                case ViewEnum.MathView:
                    ChangeView(mathView);
                    break;
                case ViewEnum.ExchangeView:
                    ChangeView(exchangeView);
                    break;
                default:
                    ChangeView(mathView);
                    break;
            }
        }

        private void HandleBestRateViewChange(string curFrom, string curTo)
        {
            bestRateHistory.CurrencyFrom = curFrom;
            bestRateHistory.CurrencyTo = curTo;
            ChangeView(bestRateHistory);
        }
    }
}
