using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculator
{
    internal class Clac
    {
        private CalculatorForm form;
        public Clac(CalculatorForm formInstance)
        {
            form = formInstance;
        }





        public double getResult() // 계산하는 함수
        {

            bool listEmpty = true;
            List<double> numberList = new List<double>();
            List<string> operationList = new List<string>();
            string recordFrom = form.record;

            string[] resultArray = recordFrom.Split('@');

            foreach (string result in resultArray)
            {
                // 숫자와 연산자가 혼합된 경우 처리
                string tempNumber = "";
                foreach (char c in result)
                {
                    if (char.IsDigit(c))
                    {
                        tempNumber += c;
                    }
                    else
                    {
                        // tempNumber가 비어있지 않은 경우 숫자로 변환하여 numberList에 추가
                        if (!string.IsNullOrEmpty(tempNumber))
                        {
                            numberList.Add(double.Parse(tempNumber));
                            tempNumber = ""; // 초기화
                        }
                        // 연산자를 operationList에 추가
                        operationList.Add(c.ToString());
                    }
                }
                // 남아있는 숫자가 있는 경우 numberList에 추가
                if (!string.IsNullOrEmpty(tempNumber))
                {
                    numberList.Add(double.Parse(tempNumber));
                }
            }

            // 숫자 리스트 출력
            foreach (double number in numberList)
            {
                Console.WriteLine(number + "\r\n여기는 숫자 리스트 목록입니다.\r\n");
            }
            while (listEmpty)
            {
                // 연산자 리스트 출력
                for (int i = 0; i < operationList.Count; i++)
                {
                    string operation = operationList[i];
                    Console.WriteLine(operation + "\r\n여기는 연산자 리스트 목록입니다.\r\n");

                    double result = 0;

                    if (operation == "*" || operation == "/" || operation == "%")
                    {

                        switch (operation)
                        {
                            case "*":
                                result = numberList[i] * numberList[i + 1];
                                numberList[i] = result;
                                numberList.RemoveAt(i + 1);
                                operationList.RemoveAt(i);
                                break;
                            case "/":
                                result = numberList[i] / numberList[i + 1];
                                numberList[i] = result;
                                numberList.RemoveAt(i + 1);
                                operationList.RemoveAt(i);
                                break;
                            case "%":
                                result = numberList[i] % numberList[i + 1];
                                numberList[i] = result;
                                numberList.RemoveAt(i + 1);
                                operationList.RemoveAt(i);
                                break;
                            default:
                                Console.WriteLine("*/% 전용 연산 로직 연산 끝");
                                break;
                        }



                    }

                }

                for (int i = 0; i < operationList.Count; i++)
                {

                    string operation = operationList[0];
                    double result = 0;
                    switch (operation)
                    {

                        case "+":
                            result = numberList[0] + numberList[1];
                            numberList[0] = result;
                            numberList.RemoveAt(1);
                            operationList.RemoveAt(0);
                            break;
                        case "-":
                            result = numberList[0] - numberList[1];
                            numberList[0] = result;
                            numberList.RemoveAt(1);
                            operationList.RemoveAt(0);
                            break;
                        default:
                            Console.WriteLine("*/% 전용 연산 로직에 문제가 생김");
                            break;
                    }

                }

                if (operationList.Count == 0)
                {
                    listEmpty = false;

                }

            }//end of while문

            double finalResult = numberList[0];
            Console.WriteLine(finalResult + "이게 최종 연산 결과다!");
            recordFrom = "0";
            return finalResult;


        }//end of getResult method


        public string[] history (string record)//계산할 때마다 result값이 history 배열로 들어가게 하는 함수
        {
            string[] history = form.historyArray;
            if (history.Length == 5 && IsArrayFullyPopulated(history))
            {
                
                Console.WriteLine("삭제 전 배열:");
                PrintArray(history);

                // 배열의 첫 번째 요소를 삭제
                history = RemoveFirstElement(history);

                Console.WriteLine("삭제 후 배열:");
                PrintArray(history);
            }

            history = AppendToLastElement(record, history);

            foreach (string item in history)
            {
                Console.WriteLine($"{item}"+"history 배열에 들어간 요소들");
            }

            return history;

            string[] RemoveFirstElement(string[] array)//array[0]을 삭제하는 메서드
            {
                if (array.Length == 0)
                {
                    throw new InvalidOperationException("배열이 비어 있습니다.");
                }

                for (int i = 1; i < array.Length; i++)
                {
                    array[i - 1] = array[i];
                }

                // 마지막 인덱스를 null 또는 기본 값으로 설정
                array[array.Length - 1] = null;

                return array;
            }

            void PrintArray(string[] array)//배열의 요소들을 출력하는 메서드
            {
                foreach (string item in array)
                {
                    Console.WriteLine(item + " ");
                }
                Console.WriteLine();
            }

        }

        public string[] AppendToLastElement(string result, string[] history) //배열의 마지막 요소에 문자열 추가하는 메서드
        {
            for (int i = 0; i<history.Length; i++)
            {
                if (string.IsNullOrEmpty(history[i]))
                {
                    history[i] = result;
                    return history;
                }
            }
            return history;
        }

        public string deleteLastElement(string element)
        {
           

            Console.WriteLine($"{element}"+"한글자 지우기 element와 result");

            if (string.IsNullOrEmpty(element))
            {
                return element;
            }

            // 문자열을 문자 배열로 변환
            char[] charArray = element.ToCharArray();

            // 마지막 요소를 제거한 새로운 문자 배열 생성
            char[] newArray = new char[charArray.Length - 1];
            Array.Copy(charArray, newArray, charArray.Length - 1);

            // 새로운 문자 배열을 문자열로 변환
            string result = new string(newArray);

            // 변환된 문자열의 마지막 요소가 '@'인 경우 '@'도 제거
            if (result.EndsWith("@"))
            {
                result = result.Remove(result.Length - 1);
            }

            return result;
        }

        public void showHistory(string[] historyArray)
        {
            foreach(string item in historyArray)
            {
            Console.WriteLine(item + "history item 목록 "); 
            }
        }

        bool IsArrayFullyPopulated(string[] array)//배열에 있는 모든 인덱스가 차있는지 확인하는 메서드
        {
            foreach (var element in array)
            {
                if (element == null)
                {
                    return false;
                }
            }
            return true;
        }

        public string zeroCheck(string input)
        {

            // 입력된 문자열이 null 또는 빈 문자열인 경우 그대로 반환
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            Console.WriteLine(input.Substring(1)+"\r\nsubstring(1)한 결과");

            // 첫 번째 문자가 '0'인 경우
            if (input[0] == '0')
            {
                // 첫 번째 문자를 제외한 나머지 문자열을 반환
                return input.Substring(1);
            }

            // 그 외의 경우에는 입력된 문자열 그대로 반환
            return input;

        }

    }
}
