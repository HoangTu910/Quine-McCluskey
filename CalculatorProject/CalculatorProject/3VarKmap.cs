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
    public partial class _3VarKmap : Form
    {
        public _3VarKmap()
        {
            InitializeComponent();
            DrawTable();
            DrawBinary();
            DrawCheckBox();
        }

        string[] textArray = {"A", "B", "C", "0", "1", "X"};
        string binary = "000011110011001101010101";
        string[] binaryList = { "000", "001", "010", "011", "100", "101", "110", "111" };
            
        List<int> positionY = new List<int>();

        int previousHeight = 0;
        void DrawTable()
        {

            Button oldBtn = new Button() {Width = 50, Location = new Point(0, 20) };
            previousHeight = oldBtn.Height;
            for(int i = 0; i < 6; i++)
            {
                Button btn = new Button()
                {
                    Width = 50,
                    Height = 50,
                    Location = new Point(oldBtn.Location.X + oldBtn.Width, oldBtn.Location.Y),
                    Text = textArray[i],
                    ForeColor = System.Drawing.Color.White,
                    Font = new Font("Arial", 12, FontStyle.Bold)

                };
                Controls.Add(btn);
                oldBtn = btn;

            }
            
            
        }

        void DrawBinary()
        {
            Button oldBtn = new Button() { Width = 50, Location = new Point(0, 47) };
            Button resetBtn = new Button() { Width = 50, Location = new Point(0, 47) };
            int locationX = oldBtn.Location.X + oldBtn.Width;
            int locationY = oldBtn.Location.Y;
            int resetLocationY = oldBtn.Location.Y;
            int countBinary = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Button btnCol = new Button()
                    {
                        Width = 50,
                        Height = 50,
                        Location = new Point(locationX, oldBtn.Location.Y + oldBtn.Height),
                        Text = binary[countBinary].ToString(),
                        ForeColor = System.Drawing.Color.White,
                        Font = new Font("Arial", 12, FontStyle.Bold)

                    };
                    Controls.Add(btnCol);
                    oldBtn = btnCol;
                    countBinary++;
                }
                locationX = oldBtn.Location.X + oldBtn.Width;
                oldBtn = resetBtn;
            }
        }

        void DrawCheckBox()
        {
            CheckBox oldCheckBox = new CheckBox() { Width = 50, Location = new Point(220, 47) };
            CheckBox resetCheckBox = new CheckBox() { Width = 50, Location = new Point(220, 47) };
            int locationX = oldCheckBox.Location.X + oldCheckBox.Width;
            int locationY = oldCheckBox.Location.Y;
            int resetLocationY = oldCheckBox.Location.Y;
            int positionStop = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    CheckBox checkBoxCol = new CheckBox()
                    {
                        Width = 50,
                        Height = 50,
                        Location = new Point(locationX, oldCheckBox.Location.Y + oldCheckBox.Height)                       
                    };

                    checkBoxCol.Click += tickCheck;
                    Controls.Add(checkBoxCol);
                    oldCheckBox = checkBoxCol;
                    if(positionStop < 8)
                    {
                        positionY.Add(checkBoxCol.Location.Y);
                    }
                    positionStop++;
                }
                locationX = oldCheckBox.Location.X + oldCheckBox.Width;
                oldCheckBox = resetCheckBox;
            }
        }

        void tickCheck(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            int x = checkBox.Location.X;
            int y = checkBox.Location.Y;
            
            for (int i = 0; i < positionY.Count() + 1; i++)
            {
                try
                {
                    if (y == positionY[i])
                    {
                        Position.binaryTicked.Add(binaryList[i]);
                    }
                }
                catch(Exception loi)
                {
                    break;
                }
                
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void _3VarKmap_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            KMAPDRAW objKmapDraw = new KMAPDRAW();
            objKmapDraw.Show();
            this.Hide();

         
        }
    }
}
