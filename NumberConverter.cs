using System;

namespace SimpleCalculator
{
    public static class NumberConverter
    {
        public static string ConvertToBinary(double number)
        {
            return Convert.ToString((long)number, 2);
        }

        public static string ConvertToHexadecimal(double number)
        {
            return Convert.ToString((long)number, 16);
        }
    }
}
