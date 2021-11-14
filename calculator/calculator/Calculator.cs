using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{

    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        string[] ops = { "+", "-", "*", "/" };

        //muss public sein, da er in einem Funktionsaufruf von außen arbeitet
        public enum Operator
        {
            Plus,
            Minus,
            Mult,
            Div
        }


        public enum calcState
        {
            WaitingFor1stNum,
            WaitingFor2ndNum,
            ResultComputing,
            ResultComputingOperator
        }

        private float memory = 0;
        private float firstNumber = 0;
        private float secondNumber = 0;

        calcState currentState = calcState.WaitingFor1stNum;
        Operator currentOperator = Operator.Plus;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void debugPrint()
        {
            Console.WriteLine("currentOp:" + currentOperator);
            Console.WriteLine("currentState:" + currentState);
            Console.WriteLine("1stnum:" + firstNumber);
            Console.WriteLine("2ndnum"+ secondNumber);
        }

        private void numberButton_Click(string s)
        {
            debugPrint();
            //Depending on what state we are currently in, the press of a a digit button
            //will produce different results
            switch (currentState)
            {
                case calcState.WaitingFor1stNum:
                {
                    textBox1.Text = textBox1.Text + s;
                    firstNumber = float.Parse(textBox1.Text, CultureInfo.InvariantCulture.NumberFormat);
                    break;
                }

                case calcState.WaitingFor2ndNum:
                {
                        textBox1.Text = textBox1.Text + s;
                        secondNumber = float.Parse(textBox1.Text, CultureInfo.InvariantCulture.NumberFormat);
                        break;
                }

                case calcState.ResultComputing:
                {
                        textBox1.Text =  s;
                        firstNumber = float.Parse(textBox1.Text, CultureInfo.InvariantCulture.NumberFormat);
                        currentState = calcState.WaitingFor1stNum;
                        break;
                }
                case calcState.ResultComputingOperator:
                {       //resetting the textField
                        textBox1.Text = s;
                        secondNumber = float.Parse(textBox1.Text, CultureInfo.InvariantCulture.NumberFormat);
                        currentState = calcState.WaitingFor2ndNum;
                        break;
                }
            }
            

        }

        public void operatorButton_Click(Operator i)
        {
            debugPrint();
            switch (currentState)
            {
                case calcState.WaitingFor1stNum:
                    {
                        currentOperator = i;
                        currentState = calcState.WaitingFor2ndNum;
                        textBox1.Text = "";
                        break;
                    }

                case calcState.WaitingFor2ndNum:
                    {
                        float res = 0;
                        res = ComputeResult();
                        currentOperator = i;
                        
                        textBox1.Text = res.ToString();
                        firstNumber = res;
                        currentState = calcState.ResultComputingOperator;
                        break;
                    }

                case calcState.ResultComputing:
                    {
                        currentOperator = i;
                        textBox1.Text = "";
                        currentState = calcState.WaitingFor2ndNum;
                        break;
                    }
            }
        }


        public float ComputeResult()
        {
            debugPrint();
            float res = 0;
            switch (currentOperator)
            {
                
                case Operator.Plus:
                {
                    res =  firstNumber + secondNumber;
                    break;
                }
                case Operator.Minus:
                {
                    res =  firstNumber - secondNumber;
                    break;
                }
                case Operator.Mult:
                {
                    res =  firstNumber * secondNumber;
                break;
                }
                case Operator.Div:
                {
                    res=  firstNumber / secondNumber;
                    break;
                }
            }
            listBox1.Items.Add(firstNumber.ToString() + " " + ops[(int)currentOperator] + " " + secondNumber.ToString() + " = " + res.ToString());
            firstNumber = res;
            //secondNumber = 0;
            return res;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //equal button
            debugPrint();
            switch (currentState)
            {
                //no need to implement case "firstNumber" because we NumberEntered = NumberEntered
                case calcState.WaitingFor2ndNum:
                    {
                        float res = 0;
                        res = ComputeResult();
                        textBox1.Text = res.ToString();
                        firstNumber = res;
                        currentState = calcState.ResultComputing;
                        break;
                    }

                case calcState.ResultComputing:
                    {
                        float res = 0;
                        res = ComputeResult();
                        textBox1.Text = res.ToString();
                        firstNumber = res;
                        break;
                    }
            }
        }


        #region ButtonNumber
        private void button1_Click(object sender, EventArgs e)
        {
            numberButton_Click("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numberButton_Click("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numberButton_Click("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            numberButton_Click("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            numberButton_Click("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            numberButton_Click("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            numberButton_Click("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            numberButton_Click("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            numberButton_Click("9");
        }

        private void button0_Click(object sender, EventArgs e)
        {
            numberButton_Click("0");
        }
        #endregion ButtonNumber
        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + ".";
        }
        #region Operators
        private void button12_Click(object sender, EventArgs e)
        {
            //Division
            operatorButton_Click(Operator.Div);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            operatorButton_Click(Operator.Plus);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            operatorButton_Click(Operator.Minus);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            operatorButton_Click(Operator.Mult);
        }


        #endregion Operators



        private void button16_Click(object sender, EventArgs e)
        {
            //memory

            //exception block
            //try:

            //memory = float.Parse(textBox1.Text, CultureInfo.InvariantCulture.NumberFormat);
            var didparseSucceed = float.TryParse(textBox1.Text,out var memoryParsed);
         
            if(didparseSucceed)
            {
                memory = memoryParsed;
                textBox2.Text = "in memory:" + memory.ToString();
            }
            
        }

  
       

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = memory.ToString();
            numberButton_Click("");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            textBox1.Text = "";
            currentState = calcState.WaitingFor1stNum;
            currentOperator = Operator.Plus;

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string s = checkBox1.CheckState.ToString();

            if (listBox1.Visible)
            {
                listBox1.Visible = false;
                //tableLayoutPane1.ColumnStyles[4].Width = width;
                tableLayoutPanel1.ColumnStyles[4].Width = 1;
            }
            else
            {
                listBox1.Visible = true;
                tableLayoutPanel1.ColumnStyles[4].Width = 20;
            }
            Console.WriteLine(checkBox1.CheckState);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }
    }
}
