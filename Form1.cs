using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            InitializeComponent();
           textInput.Text = record.ToString();
            
        }

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
