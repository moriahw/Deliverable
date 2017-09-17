using System;


//To bypass writing console.
using static System.Console;

namespace Deliverable1
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber, secondNumber;
            bool result;
            bool repeat = false;
            string userRepeat = string.Empty;

            WriteLine("Welcome to the Math Challenge");

            do
            {
                //gets the input, passes a string and an optional parameter returning a integer
                firstNumber = GetInput("Input the First Number");
                secondNumber = GetInput("Input the Second Number", firstNumber);

                //gets the boolean true or false result
                result = GetResult(firstNumber, secondNumber);

                WriteLine("The Result is " + result);

                WriteLine("Would you like to go again?");

                userRepeat = ReadLine();

                //allows you to repeat without restarting the program if desired
                if (userRepeat.ToUpper() == "Y" || userRepeat.ToUpper() == "YES" || userRepeat.ToLower() == "y" || userRepeat.ToLower() == "yes")
                {
                    repeat = true;
                }
                else if (userRepeat.ToUpper() == "N" || userRepeat.ToUpper() == "NO" || userRepeat.ToLower() == "n" || userRepeat.ToLower() == "no")
                {
                    repeat = false;
                }
                else
                {
                    repeat = false;
                }
            } while (repeat);


            //Means it'll only stop once a random key is put in at the end
            ReadKey();
        }

        /// <summary>
        /// Inputs the first and second number and goes through them one by one, if any of the numbers don't equal the sum number
        /// after the first number, it will return false, otherwise will return true. Looks at the smallest number first (i.e in 123, looks at 3 first)).
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns></returns>
        private static bool GetResult(int firstNumber, int secondNumber)
        {

            int numberCheckFirst, numberCheckSecond;
            int? sumNumber = null;
            //For loop that gets the numbers in backwards sequence (starting at 3 in a 123 etc), for the first loop it finds the sum number
            // for each loop next it finds the next number (i.e second loop it'll find 2 in 123, and then it checks the sum, if the sum is the same it keeps going, until the end, in which it'll either return true or false)
            for (int i = 0; i <= firstNumber.ToString().Length; ++i)
            {
                if (i == 0)
                {
                    numberCheckFirst = firstNumber % 10;
                    numberCheckSecond = secondNumber % 10;
                    sumNumber = numberCheckSecond + numberCheckFirst;
                }
                else
                {
                    numberCheckFirst = (firstNumber) % 10;
                    numberCheckSecond = (secondNumber) % 10;
                    if (!(sumNumber != null && sumNumber == (numberCheckSecond + numberCheckFirst)))
                    {
                        return false;
                    }
                }
                firstNumber = firstNumber / 10;
                secondNumber = secondNumber / 10;

            }
            return true;
        }

        /// <summary>
        /// Gets the input and returns an integer, makes sure that the user inputs the correct data.
        /// The second parameter is optional, if it passed into the function it will do a length check between that and the new inputted number
        /// </summary>
        /// <param name="writeString"></param>
        /// <param name="firstNumber"></param>
        /// <returns></returns>
        private static int GetInput(String writeString, int? firstNumber = null)
        {
            int number = 0;
            bool inputCheck = false;
            while (!inputCheck)
            {
                WriteLine(writeString);

                //This trys to parse the string input to an integer number, if the result is not a number it will say it is incorrect input
                if (!(Int32.TryParse(ReadLine(), out number)))
                {
                    WriteLine("Incorrect Input");
                }
                //If the optional parameter is passed into the method it will check the length
                else if (firstNumber != null && (firstNumber.ToString().Length != number.ToString().Length))
                {
                    WriteLine("Incorrect Input, The number has to be the same length as the first number which is of Length " + firstNumber.ToString().Length);
                }
                //If both the previous things work that means that the input was a number and if its the second number inputted its the same length as the first number
                else
                {
                    inputCheck = true;
                }
            }
            return number;
        }
    }
}
