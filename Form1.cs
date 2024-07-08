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

        private bool newButton;   // 새로 숫자가 시작되어야 하는 것을 말하는 flag
        private char myOperator;  // 현재 계산할 Operator


        string record = "0";//계산 결과를 히스토리에 넣는 변수
        public char checkLastChar(string record) // 히스토리 마지막 character 가져오는 메서드
        {
            char lastChar;
            if (record.Length > 0)
            {
                lastChar = record[record.Length - 1];
                Console.WriteLine(lastChar);
                return lastChar;
            }
            lastChar = '0';
            return lastChar;
        }
        // 숫자 버튼 클릭 이벤트
        private void btnNumber_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (textInput.Text == "0" || newButton)
            {
                textInput.Text = btn.Text;
                newButton = false; // 새로운 숫자 입력이 시작됨을 표시
            }
            else
            {
                textInput.Text += btn.Text; 
            }
            record += btn.Text;
            FormatNumber(); // 포맷팅 적용
        }

    
        // 맨 뒤의 한 글자를 지우기
        private void btnDelete_Click(object sender, EventArgs e)
        {
            textInput.Text = textInput.Text.Remove(textInput.Text.Length - 1);
            if (textInput.Text.Length == 0)
                textInput.Text = "0";
         
        }
            
        // 초기화
        private void btnClear_Click(object sender, EventArgs e)
        {
            textInput.Text = "0";// 입력창 초기화
            textResult.Text = ""; // 결과값 초기화
            
        }


            private void btnPlus_Click(object sender, EventArgs e)
          {
            if (checkLastChar(record) == '+' || checkLastChar(record) == '-' || checkLastChar(record) == '*' || checkLastChar(record) == '/' || checkLastChar(record) == '%')
            {
                textInput.Text = textInput.Text.Remove(textInput.Text.Length - 1);
                textInput.Text += "+";
                StringBuilder sb = new StringBuilder(record);
                sb.Length--;  // 마지막 문자 제거
                sb.Length--;  // 마지막 문자 제거
                record += "@+";
                Console.WriteLine(checkLastChar(record));
              
            }
            else
            {
                textInput.Text += "+";
                record += "@+";
            }
            newButton = true;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (checkLastChar(record) == '+' || checkLastChar(record) == '-' || checkLastChar(record) == '*' || checkLastChar(record) == '/' || checkLastChar(record) == '%')
            {
                textInput.Text = textInput.Text.Remove(textInput.Text.Length - 1);
                textInput.Text += "-";
                StringBuilder sb = new StringBuilder(record);
                sb.Length--;  // 마지막 문자 제거
                sb.Length--;  // 마지막 문자 제거
                record += "@-";
                Console.WriteLine(checkLastChar(record));
            }
            else
            {
                textInput.Text += "-";
                record += "@-";
            }
            newButton = true;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (checkLastChar(record) == '+' || checkLastChar(record) == '-' || checkLastChar(record) == '*' || checkLastChar(record) == '/' || checkLastChar(record) == '%')
            {
                textInput.Text = textInput.Text.Remove(textInput.Text.Length - 1);
                textInput.Text += "*";
                StringBuilder sb = new StringBuilder(record);
                sb.Length--;  // 마지막 문자 제거
                sb.Length--;  // 마지막 문자 제거
                record += "@*";
                Console.WriteLine(checkLastChar(record));
            }
            else
            {
                textInput.Text += "*";
                record += "@*";
            }
            newButton = true;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (checkLastChar(record) == '+' || checkLastChar(record) == '-' || checkLastChar(record) == '*' || checkLastChar(record) == '/' || checkLastChar(record) == '%')
            {
                textInput.Text = textInput.Text.Remove(textInput.Text.Length - 1);
                textInput.Text += "/";
                StringBuilder sb = new StringBuilder(record);
                sb.Length--;  // 마지막 문자 제거
                sb.Length--;  // 마지막 문자 제거
                record += "@/";
                Console.WriteLine(checkLastChar(record));
            }
            else
            {
                textInput.Text += "/";
                record += "@/";
            }
            newButton = true;
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            if (checkLastChar(record) == '+' || checkLastChar(record) == '-' || checkLastChar(record) == '*' || checkLastChar(record) == '/' || checkLastChar(record) == '%')
            {
                textInput.Text = textInput.Text.Remove(textInput.Text.Length - 1);
                textInput.Text += "%";
                StringBuilder sb = new StringBuilder(record);
                sb.Length--;  // 마지막 문자 제거
                sb.Length--;  // 마지막 문자 제거
                record += "@%";
                Console.WriteLine(checkLastChar(record));
            }
            else
            {
                textInput.Text += "%";
                record += "@%";
            }
            newButton = true;
        }

        private void btnToggleSign_Click(object sender, EventArgs e)
        {

        }



        // 포맷팅 이벤트 핸들러 추가
        private void InitializeFormatNumberHandlers()
        {
            foreach (var control in this.Controls)
            {
                if (control is Button btn)
                {
                    if (char.IsDigit(btn.Text, 0))
                    {
                        btn.Click += (sender, e) =>
                        {
                            FormatNumber();
                        };
                    }
                    else if (btn.Text == "Delete")
                    {
                        btn.Click += (sender, e) =>
                        {
                            FormatNumber();
                        };
                    }
                    else if (btn.Text == "Clear")
                    {
                        btn.Click += (sender, e) =>
                        {
                            FormatNumber();
                        };
                    }
                }
            }
        }

        // 숫자 3자리마다 쉼표 구현
        private void FormatNumber()
        {
            if (decimal.TryParse(textInput.Text.Replace(",", ""), out decimal number))
            {
                textInput.Text = string.Format("{0:n0}", number);
            }
        }



















        
    }
}
