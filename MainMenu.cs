using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_ChartVisualisation
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnReport1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report1 rep = new Report1();
            rep.ShowDialog();   
        }

        private void btnReport2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report2 rep = new Report2();
            rep.ShowDialog();
        }

        private void btnReport22_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report2 rep = new Report2();
            rep.ShowDialog();
        }
    }
}
