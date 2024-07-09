using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SimpleCalculator
{
    public partial class CalculatorForm : Form
    {

        bool solveCheck = false;
        public string record = "0";//계산 결과를 히스토리에 넣는 변수
        public string historyRecord = "0";
        private Clac calculator;
        public string[] historyArray = new string[5];//히스토리를 담는 배열
        public CalculatorForm()
        {
            
            InitializeComponent();

            
            textInput.Text = record.ToString();
  

            calculator = new Clac(this);
           

        }

        private bool newButton;   // 새로 숫자가 시작되어야 하는 것을 말하는 flag
        private char myOperator;  // 현재 계산할 Operator
        private void textInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자와 백스페이스를 제외한 모든 키 입력을 막음
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '+' && e.KeyChar != '-' && e.KeyChar != '*' && e.KeyChar != '/' && e.KeyChar != '%')
            {
                e.Handled = true; // 이벤트 처리 여부를 true로 설정하여 입력을 거부
            }
            if(solveCheck == true)
            {
                if (char.IsDigit(e.KeyChar) || (e.KeyChar != '+' && e.KeyChar != '-' && e.KeyChar != '*' && e.KeyChar != '/' && e.KeyChar != '%'))
                {
                    e.Handled = true;
                }
            }
        }
        private void textResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자와 백스페이스를 제외한 모든 키 입력을 막음
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // 이벤트 처리 여부를 true로 설정하여 입력을 거부
            }
        }



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
            if(solveCheck == false)
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
                historyRecord += btn.Text;
                Console.WriteLine(btn.Text + "btn");
                Console.WriteLine(record + "record");
            }
            FormatNumber(); // 포맷팅 적용

        }

    
        // 맨 뒤의 한 글자를 지우기
        private void btnDelete_Click(object sender, EventArgs e)
        {
            textInput.Text = textInput.Text.Remove(textInput.Text.Length - 1);
            if (textInput.Text.Length == 0)
                textInput.Text = "0";
            record = calculator.deleteLastElement(record);
            Console.WriteLine(record+"record 한글자 지운 결과\r\n");
            historyRecord = calculator.deleteLastElement(historyRecord);
            Console.WriteLine("historyRecord 한글자 지운 결과\r\n");
            Console.WriteLine($"{historyRecord}");
        }
            
        // 초기화
        private void btnClear_Click(object sender, EventArgs e)
        {
            textInput.Text = "0";// 입력창 초기화
            textResult.Text = ""; // 결과값 초기화
            record = "0";
            historyRecord = "0";
            solveCheck = false;
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
                StringBuilder sb2 = new StringBuilder(historyRecord);
                sb2.Length--;
                historyRecord += "+";
                Console.WriteLine(checkLastChar(record));
              
            }
            else
            {
                textInput.Text += "+";
                record += "@+";
                historyRecord += "+";
            }
            newButton = true;
            solveCheck = false;
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
                StringBuilder sb2 = new StringBuilder(historyRecord);
                sb2.Length--;
                historyRecord += "-";
                Console.WriteLine(checkLastChar(record));
            }
            else
            {
                textInput.Text += "-";
                record += "@-";
                historyRecord += "-";
            }
            newButton = true;
            solveCheck = false;
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
                StringBuilder sb2 = new StringBuilder(historyRecord);
                sb2.Length--;
                historyRecord += "*";
                Console.WriteLine(checkLastChar(record));
            }
            else
            {
                textInput.Text += "*";
                record += "@*";
                historyRecord += "*";
            }
            newButton = true;
            solveCheck = false;
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
                StringBuilder sb2 = new StringBuilder(historyRecord);
                sb2.Length--;
                historyRecord += "/";
                Console.WriteLine(checkLastChar(record));
            }
            else
            {
                textInput.Text += "/";
                record += "@/";
                historyRecord += "/";
            }
            newButton = true;
            solveCheck = false;
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
                StringBuilder sb2 = new StringBuilder(historyRecord);
                sb2.Length--;
                historyRecord += "%";
                Console.WriteLine(checkLastChar(record));
            }
            else
            {
                textInput.Text += "%";
                record += "@%";
                historyRecord += "%";
            }
            newButton = true;
            solveCheck = false;
        }
        // +/- 버튼 : -기호 붙이기/빼기
        private void btnToggleSign_Click(object sender, EventArgs e)

        {
            double v = Double.Parse(textInput.Text);
            textInput.Text = (-v).ToString();
            FormatNumber(); // 포맷팅 적용
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

        // 입력값 숫자 3자리마다 쉼표 구현
        private void FormatNumber()
        {
            if (decimal.TryParse(textInput.Text.Replace(",", ""), out decimal number))
            {
                textInput.Text = string.Format("{0:n0}", number);
            }
          

        }

        // 결과값 3자리마다 쉼표 삽입   
        private string FormatNumber(double number)
        {
            return string.Format("{0:N0}", number);
        }

        private bool IsDivideByZero(string record)
        {
            // 수식을 연산자 기준으로 분리하여 분할
            string[] parts = record.Split('@');

            // 분할된 각 부분에 대해 검사
            foreach (string part in parts)
            {
                // 나눗셈 연산이 포함되어 있는 경우
                if (part.Contains("/"))
                {
                    // 연산자를 기준으로 분리하여 오른쪽 피연산자가 0인지 확인
                    string[] operands = part.Split('/');
                    if (operands.Length == 2 && operands[1] == "0")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            // 0으로 나누기를 체크하는 부분 추가
            if (IsDivideByZero(record))
            {
                MessageBox.Show("0으로 나눌 수 없습니다", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double finalResult = calculator.getResult();
            string stringResult = finalResult.ToString();
            Console.WriteLine(finalResult + "성공적으로 넘어온 계산 결과");

            // 포맷팅 적용
            textResult.Text = FormatNumber(finalResult);

            record = stringResult;
            record = stringResult;
            historyRecord = calculator.zeroCheck(historyRecord);
            historyRecord += " = " + stringResult;
            historyArray = calculator.history(historyRecord);
            stringResult = null;
            solveCheck = true;

        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            calculator.showHistory(historyArray);

            string message = "";

            // 배열의 모든 요소를 message에 추가합니다.
            foreach (string item in historyArray)
            {
                message += item + Environment.NewLine; // 각 요소를 새 줄에 출력하기 위해 Environment.NewLine 추가
            }

            // 메시지 박스에 출력합니다.
            MessageBox.Show(message, "연산 기록");
        }





    }
}


