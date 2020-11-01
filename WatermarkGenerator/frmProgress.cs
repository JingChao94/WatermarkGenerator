using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WatermarkGenerator
{
    public partial class frmProgress : Form
    {
        public frmProgress()
        {
            InitializeComponent();
        }

        public void RefreshView(int currentNumber, int count, int x, int y, int w, int h)
        {
            this.Bounds = new Rectangle(x + (w / 3), y + (h / 3), this.Width, this.Height);
            progressBar1.Maximum = count * 10;
            label1.Text = string.Format(label1.Text, currentNumber, count);
            progressBar1.PerformStep();
        }
    }
}
