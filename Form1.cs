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
            textInput.Text = "0"; // 입력창을 0으로 초기화
        }

        private bool opFlag = false;
        private bool memFlag = false;

     

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



    }
}
