using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_1
{
    class StringCalculator
    {
        public int Add(string numbers)
        {

            int sum = 0;
            int number;
            List<String> delimiters = new List<String> { ",", "\n" };

            if (numbers.Length > 2 && String.Equals(numbers.Substring(0, 2), "//"))
            {
                if (numbers[2].Equals('['))
                {
                    int i = 3;
                    while (!numbers[i].Equals(']'))
                        i++;
                    delimiters.Add(numbers.Substring(3, i - 3));
                    numbers = numbers.Substring(i + 1);
                }
                else
                {
                    delimiters.Add(numbers[2].ToString());
                    numbers = numbers.Substring(3);
                }
            }

            List<string> numbersList = numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

            if (numbersList.Count == 0)
                return 0;

            if (numbersList.Count == 1)
            {
                number = Int32.Parse(numbersList.First());
                if (number < 0)
                    throw new ArgumentException("Numbers can't be negative");
                else if (number > 1000)
                    return 0;
                return number;
            }

            else
            {
                foreach (string numberString in numbersList)
                {
                    number = Int32.Parse(numberString);
                    if (number < 0)
                        throw new ArgumentException("Numbers can't be negative");
                    else if (number > 1000)
                        number = 0;
                    sum += number;
                }
                return sum;
            }

        }
    }
}
