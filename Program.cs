using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo input;
            do
            {
                Console.Write("Key in your value: $");

                string number = Console.ReadLine();
                decimal value = 0;

                string outputValue = "";
                //converts string to decimal
                try
                {
                    value = Convert.ToDecimal(number);

                    //Calls the convert function
                    outputValue = ConvertNumberToText(value);

                    //display output to console
                    Console.WriteLine("Output: " + outputValue.ToUpper());
                }
                catch (FormatException)
                {
                    Console.WriteLine("UNABLE TO CONVERT {0} TO DECIMAL.", number);
                }

                Console.WriteLine("\nPress ESC key to quit OR any key to continue.");
                input = Console.ReadKey();
            } while(input.Key != ConsoleKey.Escape);   
        }

        //convert positive value that a less than a trillion to text
        public static string ConvertNumberToText(decimal value)
        {
            if (value < 0)
                return "Cannot write a negative cheque.";
            else if (value == 0)
                return "";
            else if (value <= (decimal)0.99)
            {
                return convertToCents(value);
            }
            else if (value <= (decimal)9.99)
            {
                int temp = (int)value;
                return convertToOnes(value) + " " + ConvertNumberToText(value - temp);
            }
            else if (value <= (decimal)19.99)
            {
                int temp = (int)value;
                return convertToTeens(value) + " " + ConvertNumberToText(value - temp);
            }
            else if (value <= (decimal)99.99)
            {
                int temp = (int)(value - (value % 10));
                return convertToTens(value) + ConvertNumberToText(value - temp);
            }
            else if (value <= (decimal)999.99)
            {
                int temp = (int)(value - (value % 100));
                return convertToHundreds(value) + " " + ConvertNumberToText(value - temp);
            }
            else if (value <= (decimal)9999.99)
            {
                int temp = (int)(value - (value % 1000));
                return convertToThousands(value) + " " + ConvertNumberToText(value - temp);
            }
            else if (value <= (decimal)19999.99)
            {
                int temp = (int)(value - (value % 1000));
                return convertToTeenThousands(value) + " " + ConvertNumberToText(value - temp);
            }
            else if (value <= (decimal)99999.99)
            {
                int temp = (int)(value - (value % 10000));
                return convertToTenThousands(value) + ConvertNumberToText(value - temp);
            }
            else if (value <= (decimal)999999.99)
            {
                int temp = (int)(value - (value % 100000));
                return convertToHundredThousands(value) + " " + ConvertNumberToText(value - temp);
            }
            else if (value <= (decimal)9999999.99)
            {
                int temp = (int)(value - (value % 1000000));
                return convertToMillions(value) + " " + ConvertNumberToText(value - temp);
            }
            else if (value <= (decimal)19999999.99)
            {
                int temp = (int)(value - (value % 1000000));
                return convertToTeenMillions(value) + " " + ConvertNumberToText(value - temp);
            }
            else if (value <= (decimal)99999999.99)
            {
                int temp = (int)(value - (value % 10000000));
                return convertToTenMillions(value) + ConvertNumberToText(value - temp);
            }
            else if (value <= (decimal)999999999.99)
            {
                int temp = (int)(value - (value % 100000000));
                return convertToHundredMillions(value) + " " + ConvertNumberToText(value - temp);
            }
            else if (value <= (decimal)9999999999.99)
            {
                long temp = (long)(value - (value % 1000000000));
                return convertToBillions(value) + " " + ConvertNumberToText(value - temp);
            }
            else if (value <= (decimal)19999999999.99)
            {
                long temp = (long)(value - (value % 1000000000));
                return convertToTeenBillions(value) + " " + ConvertNumberToText(value - temp);
            }
            else if (value <= (decimal)99999999999.99)
            {
                long temp = (long)(value - (value % 10000000000));
                return convertToTenBillions(value) + ConvertNumberToText(value - temp);
            }
            else if (value <= (decimal)999999999999.99)
            {
                long temp = (long)(value - (value % 100000000000));
                return convertToHundredBillions(value) + " " + ConvertNumberToText(value - temp);
            }
            else
            {
                return "This value is out of range.";
            }
        }

        //find add-on words for hundred billions
        public static string convertToHundredBillions(decimal value)
        {
            string output = "";
            long temp = (long)(value - (value % 100000000000));
            int num = (int)(temp / 1000000000);
            output = output + findWordForHundreds(num);
            if (value - temp <= 0)
            {
                output = output + " billion dollars";
            }
            else if (value - temp < 1000000000)
            {
                output = output + " billion and ";
            }
            else
            {
                output = output + " ";
            }
            return output;
        }

        //find add-on words for ten billions
        public static string convertToTenBillions(decimal value)
        {
            string output = "";
            long temp = (long)(value - (value % 10000000000));
            int num = (int)(temp / 1000000000);
            output = output + findWordForTens(num);
            if (value - temp <= 0)
            {
                output = output + " billion dollars";
            }
            else if (value - temp < 1)
            {
                output = output + " billion and ";
            }
            else
            {
                output = output + "-";
            }
            return output;
        }

        //find add-on words for teen billions
        public static string convertToTeenBillions(decimal value)
        {
            string output = "";
            long temp = (long)(value - (value % 1000000000));
            int num = (int)(temp / 1000000000);
            output = output + findWordForTeens(num) + " billion";
            if (value - temp <= 0)
            {
                output = output + " dollars";
            }
            else if (value - temp < 1)
            {
                output = output + " and ";
            }
            else
            {
                output = output + " ";
            }
            return output;
        }

        //find add-on words for billions
        public static string convertToBillions(decimal value)
        {
            string output = "";
            long temp = (long)(value - (value % 1000000000));
            int num = (int)(temp / 1000000000);
            output = output + findWordForDigits(num) + " billion";
            if (value - temp <= 0)
            {
                output = output + " dollars";
            }
            else if (value - temp < 1)
            {
                output = output + " and ";
            }
            else
            {
                output = output + " ";
            }
            return output;
        }

        //find add-on words for hundred millions
        public static string convertToHundredMillions(decimal value)
        {
            string output = "";
            int temp = (int)(value - (value % 100000000));
            output = output + findWordForHundreds(temp / 1000000);
            if (value - temp <= 0)
            {
                output = output + "million dollars";
            }
            else if (value - temp < 1000000)
            {
                output = output + " million and ";
            }
            else
            {
                output = output + " ";
            }
            return output;
        }

        //find add-on words for ten millions
        public static string convertToTenMillions(decimal value)
        {
            string output = "";
            int temp = (int)(value - (value % 10000000));
            output = output + findWordForTens(temp / 1000000);
            if (value - temp <= 0)
            {
                output = output + " million dollars";
            }
            else if (value - temp < 1)
            {
                output = output + " million and ";
            }
            else
            {
                output = output + "-";
            }
            return output;
        }

        //find add-on words for teen millions
        public static string convertToTeenMillions(decimal value)
        {
            string output = "";
            int temp = (int)(value - (value % 1000000));
            output = output + findWordForTeens(temp / 1000000) + " million";
            if (value - temp > 0 && value - temp < 1)
            {
                output = output + " dollars and ";
            }
            else if (value - temp >= 1)
            {
                output = output + " ";
            }
            else
            {
                output = output + " dollars";
            }
            return output;
        }

        //find add-on words for millions
        public static string convertToMillions(decimal value)
        {
            string output = "";
            int temp = (int)(value - (value % 1000000));
            output = output + findWordForDigits(temp / 1000000) + " million";
            if (value - temp > 0 && value - temp < 1)
            {
                output = output + " dollars and ";
            }
            else if (value - temp >= 1)
            {
                output = output + " ";
            }
            else
            {
                output = output + " dollars";
            }
            return output;
        }

        //find add-on words for hundred thousands
        public static string convertToHundredThousands(decimal value)
        {
            string output = "";
            int temp = (int)(value - (value % 100000));
            output = output + findWordForHundreds(temp / 1000); 
            if (value - temp <= 0)
            {
                output = output + "thousand dollars";
            }
            else if (value - temp < 1000)
            {
                output = output + " thousand and ";
            }
            else
            {
                output = output + " ";
            }
            return output;
        }

        //find add-on words for ten thousands
        public static string convertToTenThousands(decimal value)
        {
            string output = "";
            int temp = (int)(value - (value % 10000));
            output = output + findWordForTens(temp / 1000);
            if (value - temp > 0 && value - temp < 1)
            {
                output = output + " thousand dollars and ";
            } 
            else if (value - temp >= 1)
            {
                output = output + "-";
            }
            else
            {
                output = output + " thousand dollars";
            }
            return output;
        }

        //find add-on words for teen thousands
        public static string convertToTeenThousands(decimal value)
        {
            string output = "";
            int temp = (int)(value - (value % 1000));
            output = output + findWordForTeens(temp / 1000) + " thousand";
            if (value - temp > 0 && value - temp < 1)
            {
                output = output + " dollars and ";
            } 
            else if (value - temp >= 1)
            {
                output = output + " ";
            }
            else if (value - temp >= 1)
            {
                output = output + " dollars";
            }
            return output;
        }

        //find add-on words for thousands
        public static string convertToThousands(decimal value)
        {
            string output = "";
            int temp = (int)(value - (value % 1000));
            output = output + findWordForDigits(temp / 1000) + " thousand";
            if (value - temp > 0 && value - temp < 1)
            {
                output = output + " dollars and ";
            }
            else if (value - temp >= 1)
            {
                output = output + " ";
            }
            else
            {
                output = output + " dollars";
            }
            return output;
        }

        //find add-on words for hundreds
        public static string convertToHundreds(decimal value)
        {
            string output = "";
            int temp = (int)(value - (value % 100));
            output = output + findWordForHundreds(temp);
            if (value - temp > 0)
            {
                output = output + " and";
            }
            else
            {
                output = output + " dollars";
            }
            return output;
        }

        //find add-on words for ten
        public static string convertToTens(decimal value)
        {
            string output = "";
            int temp = (int)(value - (value % 10));
            output = output + findWordForTens(temp);
            if (value - temp <= 0)
            {
                output = output + " dollars";
            }
            else if (value - temp < 1)
            {
                output = output + " dollars and ";
            }
            else
            {
                output = output + "-";
            }
            return output;
        }

        //find add-on words for teens
        public static string convertToTeens(decimal value)
        {
            string output = "";
            int temp = (int)value;
            output = output + findWordForTeens(temp);
            if (value - temp > 0)
            {
                output = output + " dollars and ";
            }
            else
            {
                output = output + " dollars";
            }
            return output;
        }

        //find add-on words for ones
        public static string convertToOnes(decimal value)
        {
            string output = "";
            int temp = (int)value;
            output = output + findWordForDigits(temp);
            if (value - temp > 0)
            {
                output = output + " dollars and ";
            }
            else
            {
                output = output + " dollars";
            }
            return output;
        }

        //find add-on words for decimal
        public static string convertToCents(decimal value)
        {
            string output = "";
            int temp;
            int tempValue = (int)(value * 100);

            if (tempValue < 100 && tempValue > 19)
            {
                temp = tempValue - (tempValue % 10);
                output = output + findWordForTens(temp);
                if (tempValue - temp > 0)
                {
                    output = output + "-";
                }
                else
                {
                    output = output + " cents";
                }
                tempValue = tempValue - temp;
            }
            if (tempValue < 20 && tempValue >= 10)
            {
                temp = tempValue;
                output = output + findWordForTeens(temp) + " cents";
                tempValue = tempValue - temp;
            }
            if (tempValue < 10 && tempValue > 0)
            {
                temp = tempValue;
                output = output + findWordForDigits(temp) + " cents";
                tempValue = tempValue - temp;
            }
            return output;
        }

        //function to find the word for single digits
        public static string findWordForDigits(int value)
        {
            string output = "";
            if (value == 1)
            {
                return "one";
            }
            else if (value == 2)
            {
                return "two";
            }
            else if (value == 3)
            {
                return "three";
            }
            else if (value == 4)
            {
                return "four";
            }
            else if (value == 5)
            {
                return "five";
            }
            else if (value == 6)
            {
                return "six";
            }
            else if (value == 7)
            {
                return "seven";
            }
            else if (value == 8)
            {
                return "eight";
            }
            else if (value == 9)
            {
                return "nine";
            }
            return output;
        }

        //function to find the word for teens
        public static string findWordForTeens(int value)
        {
            string output = "";
            if (value == 10)
            {
                return "ten";
            }
            else if (value == 11)
            {
                return "eleven";
            }
            else if (value == 12)
            {
                return "twelve";
            }
            else if (value == 13)
            {
                return "thirteen";
            }
            else if (value == 14)
            {
                return "fourteen";
            }
            else if (value == 15)
            {
                return "fifteen";
            }
            else if (value == 16)
            {
                return "sixteen";
            }
            else if (value == 17)
            {
                return "seventeen";
            }
            else if (value == 18)
            {
                return "eighteen";
            }
            else if (value == 19)
            {
                return "nineteen";
            }
            return output;
        }

        //function to find the word for tens
        public static string findWordForTens(int value)
        {
            string output = "";
            if (value == 20)
            {
                return "twenty";
            }
            else if (value == 30)
            {
                return "thirty";
            }
            else if (value == 40)
            {
                return "forty";
            }
            else if (value == 50)
            {
                return "fifty";
            }
            else if (value == 60)
            {
                return "sixty";
            }
            else if (value == 70)
            {
                return "seventy";
            }
            else if (value == 80)
            {
                return "eighty";
            }
            else if (value == 90)
            {
                return "ninety";
            }
            return output;
        }

        //function to find the word for hundreds
        public static string findWordForHundreds(int value)
        {
            string output = "";
            if (value == 100)
            {
                return "one hundred";
            }
            else if (value == 200)
            {
                return "two hundred";
            }
            else if (value == 300)
            {
                return "three hundred";
            }
            else if (value == 400)
            {
                return "four hundred";
            }
            else if (value == 500)
            {
                return "five hundred";
            }
            else if (value == 600)
            {
                return "six hundred";
            }
            else if (value == 700)
            {
                return "seven hundred";
            }
            else if (value == 800)
            {
                return "eight hundred";
            }
            else if (value == 900)
            {
                return "nine hundred";
            }
            return output;
        }
    }
}
