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
    public partial class KMAPDRAW : Form
    {
        public KMAPDRAW()
        {
            InitializeComponent();
            DrawCol();
            DrawRow();
            tickBinary();
        }
        string[] labelDisplay = { "AB", "00", "01", "11", "10" };
        string[] labelDisplayRow = { "C", "0", "1" };
        bool isChecked = false;
        void DrawCol()
        {
            int previousHeight = 0;
            Button oldBtn = new Button() { Width = 0, Location = new Point(40, 60) };
            previousHeight = oldBtn.Height;
            for (int i = 0; i < 5; i++)
            {
                Button btn = new Button()
                {
                    Width = 50,
                    Height = 50,
                    Location = new Point(oldBtn.Location.X, oldBtn.Location.Y + oldBtn.Width),
                    Text = labelDisplay[i],
                    ForeColor = System.Drawing.Color.Black,
                    Font = new Font("Arial", 12, FontStyle.Bold)
                };
                Position.positionDefaultY.Add(oldBtn.Location.Y + oldBtn.Width);
                Controls.Add(btn);
                oldBtn = btn;
            }
        }

        void DrawRow()
        {
            int previousHeight = 0;
            Button oldBtn = new Button() { Width = 0, Location = new Point(86, 15)};
            previousHeight = oldBtn.Height;
            for (int i = 0; i < 3; i++)
            {
                Button btn = new Button()
                {
                    Width = 50,
                    Height = 50,
                    Location = new Point(oldBtn.Location.X + oldBtn.Width, oldBtn.Location.Y ),
                    Text = labelDisplayRow[i],
                    ForeColor = System.Drawing.Color.Black,
                    Font = new Font("Arial", 12, FontStyle.Bold)
                };
                Position.positionDefaultX.Add(oldBtn.Location.X + oldBtn.Width);
                Controls.Add(btn);
                oldBtn = btn;

            }
        }

        void tickBinary()
        {
            int previousHeight = 0;
            Button oldBtn = new Button() { Width = 0, Location = new Point(136, 112) };
            Button moveBtn = new Button() { Width = 0, Location = new Point(186, 112) };
            previousHeight = oldBtn.Height;
            int countTicked = 0;
            //Button btn = new Button()
            //{
            //    Width = 50,
            //    Height = 50,
            //    Location = new Point(oldBtn.Location.X, oldBtn.Location.Y + oldBtn.Width),
            //    Text = Position.binaryTicked.Count().ToString(),
            //    ForeColor = System.Drawing.Color.Black,
            //    Font = new Font("Arial", 12, FontStyle.Bold)
            //};
            //Controls.Add(btn);
            for (int i = 1; i < 3; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    isChecked = false;
                    countTicked = 0;
                    while (countTicked < Position.binaryTicked.Count())
                    {
                        if (String.Equals((labelDisplay[j] + labelDisplayRow[i]), Position.binaryTicked[countTicked]))
                        {
                            Button btn = new Button()
                            {
                                Width = 50,
                                Height = 50,
                                Location = new Point(oldBtn.Location.X, oldBtn.Location.Y + oldBtn.Width),
                                Text = "1",
                                ForeColor = System.Drawing.Color.Black,
                                Font = new Font("Arial", 12, FontStyle.Bold)
                            };
                            this.Controls.Add(btn);
                            Position.positionSafeX.Add(oldBtn.Location.X);
                            Position.positionSafeY.Add(oldBtn.Location.Y);
                            oldBtn = btn;
                            isChecked = true;
                            break;
                        }
                        countTicked++;
                    }
                    if (isChecked != true)
                    {
                        Button btnElse = new Button()
                        {
                            Width = 50,
                            Height = 50,
                            Location = new Point(oldBtn.Location.X, oldBtn.Location.Y + oldBtn.Width),
                            ForeColor = System.Drawing.Color.Black,
                            Font = new Font("Arial", 12, FontStyle.Bold)
                        };
                        this.Controls.Add(btnElse);
                        oldBtn = btnElse;
                    }
                    
                }
                oldBtn = moveBtn;
            }
            
        }
        private void KMAPDRAW_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int loopCount = Position.binaryTicked.Count();
            //string[] barNote = { "A'", "B'", "C'" };
            //string[] normalNote = { "A", "B", "C" };
            //List<string> formulaContain = new List<string>();
            //string singleContain;
            //string Container = "";
            //for(int i = 0; i < loopCount; i++)
            //{
            //    for(int j = 0; j < Position.binaryTicked[i].Length; j++)
            //    {
            //        string checkString = Position.binaryTicked[i];
            //        if (String.Equals(Position.binaryTicked[i].ToCharArray()[j], '0'))
            //        {
            //            singleContain = normalNote[j];
            //        }
            //        else
            //        {
            //            singleContain = barNote[j];
            //        }
            //        Container += singleContain;
            //    }
            //    formulaContain.Add(Container);

            //}
            //for(int i = 0; i < formulaContain.Count; i++)
            //{
            //    button2.Text = formulaContain[i];
            //}
            int positionX = 0;
            int positionY = 0;
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Position.positionDefaultX[i] == Position.positionSafeX[positionX] && Position.positionDefaultY[j] == Position.positionSafeY[positionY])
                    {
                        count++;
                        positionX++;
                        positionY++;
                        if(positionX >= Position.positionSafeX.Count)
                        {
                            positionX = Position.positionSafeX.Count - 1;
                        }
                        if (positionY >= Position.positionSafeY.Count)
                        {
                            positionY = Position.positionSafeY.Count - 1;
                        }
                    }
                }
            }
            button1.Text = count.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
