using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorProject
{
    public partial class Result : Form
    {
        public Result()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            label2.AutoSize = true;
            label2.MaximumSize = new Size(420, 0);

        }

        private void Result_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = string.Join(" + ", QuineVariables.resultList);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuineForm objQuineCalc = new QuineForm();
            objQuineCalc.Show();
            QuineVariables method = new QuineVariables();
            method.resetAllList();
        }
    }
}
