using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SimpleCalculator
{
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            InitializeComponent();

           textInput.Text = record.ToString();
            
        }
        
        private bool opFlag = false;
        private bool memFlag = false;



        string record = "0";//계산 결과를 히스토리에 넣는 변수
        public char checkLastChar(string record) // 히스토리 마지막 character 가져오는 메서드
        {
            char lastChar;
            if (record.Length >0)
            {
                lastChar = record[record.Length - 1];
                Console.WriteLine(lastChar);
                return lastChar;
            }
            lastChar = '0';
            return lastChar;
        }



     


        // 숫자 버튼 클릭시 숫자 구현
        private void btnNumber_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (textInput.Text == "0" || opFlag == true || memFlag == true)
            {
                textInput.Text = btn.Text;
         
            }
            else
                textInput.Text = textInput.Text + btn.Text;


        }

        // 맨 뒤의 한 글자를 지우기
        private void btnDelete_Click(object sender, EventArgs e)
        {
            textInput.Text = textInput.Text.Remove(textInput.Text.Length - 1);
            if (textInput.Text.Length == 0)
                textInput.Text = "0";

         }
            
            private void btnPlus_Click(object sender, EventArgs e)
          {
            if (checkLastChar(record) == '+' || checkLastChar(record) == '-' || checkLastChar(record) == '*' || checkLastChar(record) == '/' || checkLastChar(record) == '%')
            {
                textInput.Text = textInput.Text.Remove(textInput.Text.Length - 1);
                textInput.Text += "+";
                StringBuilder sb = new StringBuilder(record);
                sb.Length--;  // 마지막 문자 제거
                record += "+";
                Console.WriteLine(checkLastChar(record));
            }
            else
            {
                textInput.Text += "+";
                record += "+";
            }
            
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (checkLastChar(record) == '+' || checkLastChar(record) == '-' || checkLastChar(record) == '*' || checkLastChar(record) == '/' || checkLastChar(record) == '%')
            {
                textInput.Text = textInput.Text.Remove(textInput.Text.Length - 1);
                textInput.Text += "-";
                StringBuilder sb = new StringBuilder(record);
                sb.Length--;  // 마지막 문자 제거
                record += "-";
                Console.WriteLine(checkLastChar(record));
            }
            else
            {
                textInput.Text += "-";
                record += "-";
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (checkLastChar(record) == '+' || checkLastChar(record) == '-' || checkLastChar(record) == '*' || checkLastChar(record) == '/' || checkLastChar(record) == '%')
            {
                textInput.Text = textInput.Text.Remove(textInput.Text.Length - 1);
                textInput.Text += "*";
                StringBuilder sb = new StringBuilder(record);
                sb.Length--;  // 마지막 문자 제거
                record += "*";
                Console.WriteLine(checkLastChar(record));
            }
            else
            {
                textInput.Text += "*";
                record += "*";
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (checkLastChar(record) == '+' || checkLastChar(record) == '-' || checkLastChar(record) == '*' || checkLastChar(record) == '/' || checkLastChar(record) == '%')
            {
                textInput.Text = textInput.Text.Remove(textInput.Text.Length - 1);
                textInput.Text += "/";
                StringBuilder sb = new StringBuilder(record);
                sb.Length--;  // 마지막 문자 제거
                record += "/";
                Console.WriteLine(checkLastChar(record));
            }
            else
            {
                textInput.Text += "/";
                record += "/";
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (checkLastChar(record) == '+' || checkLastChar(record) == '-' || checkLastChar(record) == '*' || checkLastChar(record) == '/' || checkLastChar(record) == '%')
            {
                textInput.Text = textInput.Text.Remove(textInput.Text.Length - 1);
                textInput.Text += "%";
                StringBuilder sb = new StringBuilder(record);
                sb.Length--;  // 마지막 문자 제거
                record += "%";
                Console.WriteLine(checkLastChar(record));
            }
            else
            {
                textInput.Text += "%";
                record += "%";
            }
        }

        private void btnToggleSign_Click(object sender, EventArgs e)
        {

        }



    }
}
