using System;

namespace CsharpBasics.basics
{
    /*creating extension methods:
     1. create a static class
     2. create a static method
     3. The first parameter of the method should be this followed by the type of extension method
     */
    public static class StringExtensions
    {
        public static int CountVowels(this string input)
        {
            if (String.IsNullOrEmpty(input)) return 0;
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'a' || 
                    input[i] == 'e' ||
                    input[i] == 'i' || 
                    input[i] == 'o' || 
                    input[i] == 'u') sum++;
            }

            return sum;
        }

    }

   

}
