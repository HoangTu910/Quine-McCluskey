using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace CalculatorProject
{
    public partial class QuineForm : Form
    {
        public QuineForm()
        {
            InitializeComponent();
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
        }

        Hashtable Hash = new Hashtable();
        private int StringtoInt(string text)
        {
            int result = Int16.Parse(text);
            return result;
        }
        private string InttoBinary(int num)
        {
            string binary;
            binary = Convert.ToString(num, 2).PadLeft(QuineVariables.variablesList.Count,'0');
            return binary;
        }

        private void removeDuplicateAll(List<String> values, List<String> compare)
        {
            int loopTime = values.Count;
            int count = 0;
            List<int> indexPos = new List<int>();
            for (int i = 0; i < values.Count - 1; i++)
            {
                for (int j = i + 1; j < values.Count; j++)
                {
                    if (values[i].Equals(values[j]))
                    {
                        indexPos.Add(i);
                        indexPos.Add(j);
                    }
                }
            }

            List<int> distinct = indexPos.Distinct().ToList();
            distinct.Sort();  

            for (int i = distinct.Count - 1; i >= 0; i--)
            {
                int indexToRemove = distinct[i];
                values.RemoveAt(indexToRemove);
            }

            int countAppear = 0;
            for (int i = 0; i < compare.Count; i++)
            {
                countAppear = 0;
                List<int> index = new List<int>();
                string[] substrings = compare[i].Split(',');
                List<String> splitValues = new List<string>(substrings);

                //for (int k = 0; k < splitValues.Count; k++)
                //{
                //    MessageBox.Show("TEST: " + splitValues[k]);
                //}

                for (int j = 0; j < values.Count; j++)
                {
                    if (splitValues.Contains(values[j]))
                    {
                        //MessageBox.Show("TEST: " + compare[i]);
                        //MessageBox.Show("TEST: " + values[j]);
                        countAppear++;
                        //MessageBox.Show("TEST: " + countAppear.ToString());
                        index.Add(j);
                        //MessageBox.Show("TEST: " + index.ToString());
                    }
                }
                if (countAppear >= 2)
                {
                    for (int k = index.Count-1; k > 0 ; k--)
                    {
                        values.RemoveAt(index[k]);
                    }
                }
                splitValues.Clear();
                index.Clear();
            }


        }
        private void removeDuplicate(List<String> values)
        {
            int pos = 0;
            for (int i = 0; i < values.Count; i += 2, pos++)
            {
                values[pos] = values[i];
            }
            values.RemoveRange(pos, values.Count - pos);
        }

        private void upperAllElements(List<String> values)
        {
            for(int i = 0; i < values.Count; i++)
            {
                values[i] = values[i].ToUpper();
            }
        }
        private void printList(List<String> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                MessageBox.Show("TEST: "+ list[i].ToString());
            }
        }

        private bool checkMinimal(string bin1, string bin2, string num1, string num2)
        {
            int lenght = QuineVariables.variablesList.Count;
            int countBit = 0;
            int countTest = 0;
            StringBuilder tempBinary = new StringBuilder(bin1);

            for (int i = 0; i < lenght; i++)
            {
                if (bin1[i] != bin2[i])
                {
                    countBit++;
                    tempBinary[i] = '-';
                }
            }
            if (countBit == 1)
            {
                countTest = 1;
                return true;
            }
            else
            {
                return false;
            }
            
        }
        private bool checkGreyCode(string bin1, string bin2, string num1, string num2)
        {
            int lenght = QuineVariables.variablesList.Count;
            int countBit = 0;
            int countTest = 0;
            StringBuilder tempBinary = new StringBuilder(bin1);

            for (int i = 0; i < lenght; i++)
            {
                if(bin1[i] != bin2[i])
                {
                    countBit++;
                    tempBinary[i] = '-';
                }
            }
            if(countBit == 1)
            {
                countTest = 1;
                QuineVariables.findBinaryList.Add(new StringBuilder(tempBinary.ToString()));
                QuineVariables.findNumList.Add(num1 +',' + num2);
                //printList(QuineVariables.findBinaryList);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private void testing()
        {
            for (int i = 0; i < QuineVariables.binaryList.Count; i++)
            {
                MessageBox.Show(QuineVariables.binaryList[i].ToString());
            }
            //for (int i = 0; i < QuineVariables.numbersList.Count; i++)
            //{
            //    MessageBox.Show(QuineVariables.numbersList[i].ToString());
            //}
            //for (int i = 0; i < QuineVariables.formulaList.Count; i++)
            //{
            //    MessageBox.Show(QuineVariables.formulaList[i].ToString());
            //}
        }
        private void getLogicFormula(List<String> binaryList, List<String> varList)
        {
            String formula = "";
            for(int i = 0; i < binaryList.Count; i++)
            {
                for(int j = 0; j < varList.Count; j++)
                {
                    if (binaryList[i][j].Equals('1'))
                    {
                        formula += varList[j];
                    }
                    else if (binaryList[i][j].Equals('0'))
                    {
                        formula = formula + varList[j] + '`';
                    }
                    else
                    {
                        continue;
                    }
                }
                QuineVariables.formulaList.Add(formula);
                formula = "";
            }
        }

        private void compareColumns(List<String> numList)
        {
            List<String> numParts= new List<string>();
            
            for (int i = 0; i < numList.Count; i++)
            {
                numParts = QuineVariables.numbersList[i].Split(',').ToList();
                for(int j = 0; j < numParts.Count; j++)
                {
                    QuineVariables.compareList.Add(numParts[j]);
                }
            }
            QuineVariables.mintermList.AddRange(QuineVariables.compareList);
            QuineVariables.mintermList = QuineVariables.mintermList.Distinct().ToList();
            //for (int i = 0; i < QuineVariables.compareList.Count(); i++)
            //{
            //    MessageBox.Show("TEST: " + QuineVariables.compareList[i].ToString());
            //}
            removeDuplicateAll(QuineVariables.compareList, QuineVariables.numbersList);
            //Add list chứa num sau khi remove  j
        }

        private void removePLS(string numbersList)
        {
            
            string[] substring = numbersList.Split(',');
            List<String> elementsToRemove = new List<String>(substring);
            //for(int i = 0; i < numbersList.Length; i++)
            //{
            //    string[] substring = numbersList[i].Split(',');
            //    List<String> numParts = new List<String>(substring);
            //    elementsToRemove.AddRange(numParts);         
            //}
            QuineVariables.mintermList.RemoveAll(x => elementsToRemove.Contains(x));
        }

        private void checkMinTermNumList()
        {
            //QuineVariables.mintermNumList.Clear();
            for (int i = 0; i < QuineVariables.numbersList.Count; i++)
            {
                int countMintermNum = 0;
                string[] substrings = QuineVariables.numbersList[i].Split(',');
                List<string> splitValues = new List<string>(substrings);
                for (int j = 0; j < splitValues.Count; j++)
                {
                    if (QuineVariables.mintermList.Contains(splitValues[j]))
                    {
                        countMintermNum++;
                    }
                }
                if (countMintermNum == splitValues.Count)
                {
                    QuineVariables.mintermNumList.Add(QuineVariables.numbersList[i]);
                }
            }
        }

       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 objMainFrame = new Form1();
            objMainFrame.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int countStep = 0;
            int stepTime = 3;

            QuineVariables.numbersList = textBox2.Text.Split(',').ToList();
            QuineVariables.variablesList = textBox1.Text.Split(',').ToList();
            upperAllElements(QuineVariables.variablesList);
            for(int i = 0; i < QuineVariables.numbersList.Count; i++)
            {
                QuineVariables.binaryList.Add(InttoBinary(StringtoInt(QuineVariables.numbersList[i])));
            }
            
            while (countStep < stepTime)
            {
                for (int i = 0; i < QuineVariables.binaryList.Count; i++)
                {
                    int countMinimal = 0;
                    for (int j = i + 1; j < QuineVariables.binaryList.Count; j++)
                    {
                        checkGreyCode(QuineVariables.binaryList[i], QuineVariables.binaryList[j], 
                                        QuineVariables.numbersList[i], QuineVariables.numbersList[j]);
                    }

                    for (int k = 0; k < QuineVariables.binaryList.Count; k++)
                    {
                        bool isGrey = checkMinimal(QuineVariables.binaryList[i], QuineVariables.binaryList[k],
                                        QuineVariables.numbersList[i], QuineVariables.numbersList[k]);
                        //MessageBox.Show("NUM: " + QuineVariables.numbersList[i].ToString());
                        if (isGrey == false)
                        {
                            countMinimal++;
                        }
                        //MessageBox.Show("COUNT: " + countMinimal.ToString());
                    }
                    if (countMinimal >= QuineVariables.binaryList.Count)
                    {
                        QuineVariables.minimalList.Add(QuineVariables.binaryList[i]);
                        QuineVariables.minimalNumList.Add(QuineVariables.numbersList[i]);
                    }

                }

                QuineVariables.binaryList.Clear();
                QuineVariables.numbersList.Clear();

                for (int i = 0; i < QuineVariables.findBinaryList.Count; i++)
                {
                    string binaryString = QuineVariables.findBinaryList[i].ToString();
                    string numString = QuineVariables.findNumList[i].ToString();

                    if (!QuineVariables.binaryList.Contains(binaryString))
                    {
                        QuineVariables.binaryList.Add(binaryString);
                        QuineVariables.numbersList.Add(numString);
                    }
                }

                QuineVariables.findBinaryList.Clear();
                QuineVariables.findNumList.Clear();
                countStep++;
                
            }
            
            //QuineVariables.minimalList = QuineVariables.minimalList.Distinct().ToList();
            //removeDuplicate(QuineVariables.binaryList);
            //removeDuplicate(QuineVariables.numbersList);
            QuineVariables.binaryList.AddRange(QuineVariables.minimalList);
            QuineVariables.numbersList.AddRange(QuineVariables.minimalNumList);
            //testing();
            getLogicFormula(QuineVariables.binaryList, QuineVariables.variablesList);
            compareColumns(QuineVariables.numbersList);
            QuineVariables.formulaList = QuineVariables.formulaList.Distinct().ToList();
            //for (int i = 0; i < QuineVariables.compareList.Count(); i++)
            //{
            //    MessageBox.Show("TEST: " + QuineVariables.compareList[i].ToString());
            //}
            //for (int i = 0; i < QuineVariables.compareList.Count(); i++)
            //{
            //    MessageBox.Show("TEST: " + QuineVariables.compareList[i].ToString());
            //}
            int minLength = Math.Min(QuineVariables.numbersList.Count, Math.Min(QuineVariables.compareList.Count, QuineVariables.formulaList.Count));
            int indexPos = 0;
            int indexPosMinTerm = 0;
            List<int> indexFormulaList = new List<int>();
            for (int i = 0; i < QuineVariables.numbersList.Count; i++)
            {
                //List<String> numParts = QuineVariables.numbersList[i].Split(',').ToList();
                //for (int j = 0; j < numParts.Count; j++)
                //{
                //    if (QuineVariables.compareList[i].Equals(numParts[j]))
                //    {
                //        QuineVariables.resultList.Add(QuineVariables.formulaList[i]);
                //    }
                //}
                //numParts.Clear();
                string[] substrings = QuineVariables.numbersList[i].Split(',');
                List<string> splitValues = new List<string>(substrings);

                if (indexPos < QuineVariables.compareList.Count && splitValues.Contains(QuineVariables.compareList[indexPos]))
                {
                    QuineVariables.resultList.Add(QuineVariables.formulaList[i]);
                    indexFormulaList.Add(i);
                    MessageBox.Show("NUMBER: " + QuineVariables.numbersList[i].ToString());
                    removePLS(QuineVariables.numbersList[i]);
                    //for(int j = 0; j < QuineVariables.mintermList.Count; j++)
                    //{
                    //    MessageBox.Show("MINTERM: " + QuineVariables.mintermList[j].ToString());
                    //}
                    indexPos++;
                }
                splitValues.Clear();
            }
            int loopC = 0;

            for(int i = 0; i < QuineVariables.numbersList.Count; i++)
            {
                int countMintermNum = 0;
                string[] substrings = QuineVariables.numbersList[i].Split(',');
                List<string> splitValues = new List<string>(substrings);
                for(int j = 0; j < splitValues.Count; j++)
                {
                    if (QuineVariables.mintermList.Contains(splitValues[j]))
                    {
                        countMintermNum++;
                    }
                }
                if(countMintermNum == splitValues.Count)
                {
                    QuineVariables.mintermNumList.Add(QuineVariables.numbersList[i]); 
                }

            }
            int indexMintermList = 0;
            while (QuineVariables.mintermList.Count != 0) {
                checkMinTermNumList();
                MessageBox.Show("COUNT: " + QuineVariables.mintermList.Count.ToString());
                for (int m = 0; m < QuineVariables.mintermNumList.Count(); m++)
                {

                    MessageBox.Show("MINTERM-NUM: " + QuineVariables.mintermNumList[m].ToString());

                }

                if (QuineVariables.mintermNumList.Count >= 1)
                {
                    string[] substrings = QuineVariables.mintermNumList[0].Split(',');
                    List<string> splitValues = new List<string>(substrings);

                    //if (indexPosMinTerm < QuineVariables.mintermList.Count)
                    //{
                    //    if (splitValues.Contains(QuineVariables.mintermList[indexPosMinTerm]))
                    //    {
                    //        QuineVariables.resultList.Add(QuineVariables.formulaList[i]);
                    //        indexFormulaList.Add(i);
                    //        indexPosMinTerm++;
                    //    }
                    //}
                    if (QuineVariables.mintermList.Count >= 1)
                    {
                        MessageBox.Show("IF 1");
                        MessageBox.Show("MINTERMLIST: " + QuineVariables.mintermList[0]);
                        try
                        {
                            if (splitValues.Contains(QuineVariables.mintermList[indexMintermList]))
                            {
                                MessageBox.Show("IF 2");
                                for (int i = 0; i < QuineVariables.numbersList.Count; i++)
                                {
                                    if (QuineVariables.mintermNumList[0].Equals(QuineVariables.numbersList[i]))
                                    {
                                        MessageBox.Show("NUMBER: IN");
                                        QuineVariables.resultList.Add(QuineVariables.formulaList[i]);
                                        QuineVariables.mintermList.RemoveAll(x => splitValues.Contains(x));
                                        for (int m = 0; m < QuineVariables.mintermList.Count(); m++)
                                        {
                                            //MessageBox.Show("NUMBER: " + QuineVariables.formulaList[m]);
                                            //MessageBox.Show("MINTERM: " + QuineVariables.mintermList[m].ToString());
                                            //MessageBox.Show("LOOP: " + loopC.ToString());
                                        }
                                        splitValues.Clear();
                                        break;
                                    }
                                }
                                indexMintermList = -1;
                            }
                        }
                        catch
                        {

                        }
                        indexMintermList++;
                    }
                }
                else { break; }
                QuineVariables.mintermNumList.Clear();
            }
            //NUMBERLIST PHAI CHUA MINTERM, KHONG DUOC CHUA SO KHONG PHAI MINTERM


            //for (int i = 0; i < QuineVariables.numbersList.Count(); i++)
            //{
            //    MessageBox.Show(QuineVariables.numbersList[i].ToString());
            //}
            for (int i = 0; i < QuineVariables.resultList.Count(); i++)
            {
                MessageBox.Show("MINTERM: " + QuineVariables.resultList[i].ToString());
            }
            //testing();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
