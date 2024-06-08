using System;

public class Program
{
    public static void Main(string[] args)
    {
        string userChoice = "Y";
        do
        {
            Console.WriteLine("********* Roman Numeral To Integer Conversion *********");
            Console.WriteLine("Enter the roman numeral to convert");
            try
            {
                string userInputRoman = Console.ReadLine();
                int numeralResult = RomanConversion.ConvertRomanToInt(userInputRoman);
                Console.WriteLine($"The integer equivalent is {numeralResult} ");
                Console.WriteLine("Do you want to continue: Y or N");
                userChoice = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        } while (userChoice.ToUpper() == "Y");
    }
}


public class RomanConversion
{
    /* 
    <summary> 
    Convert Roman to Integer Equivalent  
    </summary>
    <param name="roman">The roman input given by the userr</param>
    <returns>Number Equivalent of given roman letter</returns>
    */
    public static int ConvertRomanToInt(string roman)
    {
        int numeralEquivalent = 0;

        //Dictionary initialization as <string, int> to get key value pair
        Dictionary<char, int> romanletterDictionary = new Dictionary<char, int>
        {
            {'M', 1000},
            {'D', 500},
            {'C', 100},
            {'L', 50},
            {'X', 10},
            {'V', 5},
            {'I', 1}
        };     
        

        //Iterating through each roman letter in the input
        for (int i = 0; i < roman.Length;i++)
        {
            //checking ivalid input characters
            if ((!romanletterDictionary.ContainsKey(roman[i])))
            {
                throw new Exception("Roman Numerals with letters M,D,C,L,X,V,I only accepted");
            }

            //Checking if i is last character in the string and simply adding the value of that roman and exiting the loop for not taking i+1 value
            if (i == roman.Length - 1)
            {
                numeralEquivalent += romanletterDictionary[roman[i]];
                break;
            }  
                                                                        
            // checking if next value is greater than current value 
            if (romanletterDictionary[roman[i+1]] > romanletterDictionary[roman[i]])
            {
                // substracting the current value from next value to handle the edge cases
                numeralEquivalent += romanletterDictionary[roman[i+1]] - romanletterDictionary[roman[i]];
                i++; // Incrementing i to skip one position
            }
            else
            {
                // Adding value of the corresponding roman letter 
                numeralEquivalent += romanletterDictionary[roman[i]];                
            }
        }
        return numeralEquivalent;
    }
}