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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
                

        }

        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 objKmapCalc = new Form2();
            objKmapCalc.Show();
            this.Hide();
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            QuineForm objQuineCalc = new QuineForm();
            objQuineCalc.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
