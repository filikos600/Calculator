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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Calculator.View
{
    /// <summary>
    /// Main Form of applciation, it holds and switches different UserControl Views.
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly MathView mathView;
        private readonly ExchangeView exchangeView;
        private readonly BestRateHistory bestRateHistory;

        private bool mathHistory = false;
        private bool exchangeHistory = false;
        private bool bestRate = false;
        public MainForm(MathView mathView, ExchangeView exchangeView, BestRateHistory bestRateHistory)
        {
            InitializeComponent();
            this.mathView = mathView;
            this.mathView.RequestHistoryPanel += HandleHistoryMath;
            this.mathView.RequestViewChange += HandleViewChange;
            this.exchangeView = exchangeView;
            this.exchangeView.RequestHistoryPanel += HandleHistoryExchange;
            this.exchangeView.RequestViewChange += HandleViewChange;
            this.exchangeView.RequestBestRateViewChange += HandleBestRateViewChange;
            this.bestRateHistory = bestRateHistory;
            this.bestRateHistory.RequestViewChange += HandleViewChange;

            this.Width -= 300;

            panel1.Controls.Add(mathView);
            HandleViewChange(ViewEnum.MathView);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;
             this.Location = new System.Drawing.Point(Convert.ToInt32(0.3 * workingRectangle.Width), Convert.ToInt32(0.3 * workingRectangle.Height));
        }

        private void ChangeView(UserControl view)
        {
            panel1.Controls.Clear();
            view.Dock = DockStyle.Fill;
            panel1.Controls.Add(view);

            if (view is MathView v1)
            {
                if (mathHistory && !exchangeHistory)
                    this.Width += 300;
                if (!mathHistory && exchangeHistory)
                    this.Width -= 300;
            }
            if (view is ExchangeView v2)
            {
                if (bestRate)
                {
                    bestRate = false;
                    this.Width += 400;
                }
                else if (exchangeHistory && !mathHistory)
                    this.Width += 300;
                else if (!exchangeHistory && mathHistory)
                    this.Width -= 300;
            }
            if (view is BestRateHistory v3)
            {
                this.Width -= 400;
                bestRate = true;    
            }
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

        private void HandleHistoryMath(bool history)
        {
            if (history)
            {
                this.Width += 300;
            }
            else
            {
                this.Width -= 300;
            }
            mathHistory = !mathHistory;
        }

        private void HandleHistoryExchange(bool history)
        {
            if (history)
            {
                this.Width += 300;
            }
            else
            {
                this.Width -= 300;
            }
            exchangeHistory = !exchangeHistory;
        }

        private void HandleBestRateViewChange(string curFrom, string curTo)
        {
            bestRateHistory.CurrencyFrom = curFrom;
            bestRateHistory.CurrencyTo = curTo;
            ChangeView(bestRateHistory);
        }

    }
}
