using Calculator.Model;
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
        public MainForm()
        {
            InitializeComponent();
            var view = new MathView();
            panel1.Controls.Add(view);
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
                v2.RequestViewChange += HandleViewChange;
        }

        private void HandleViewChange(ViewEnum viewName)
        {
            switch (viewName)
            {
                case ViewEnum.MathView:
                    ChangeView(new MathView());
                    break;
                case ViewEnum.ExchangeView:
                    ChangeView(new ExchangeView());
                    break;
            }
        }

        //private void comboBoxView_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    panel1.Controls.Clear();
        //    UserControl view = null;
        //    switch (comboBoxView.SelectedIndex)
        //    {
        //        case 0:
        //            view = new MathView();
        //            break;
        //        case 1:
        //            view = new ExchangeView();
        //            break;
        //    }

        //    if (view != null)
        //    {
        //        view.Dock = DockStyle.Fill;
        //        panel1.Controls.Add(view);
        //    }
        //}
    }
}
