using System;
using System.ComponentModel.Design;
using System.Text.RegularExpressions;

namespace Lab02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Hitta tal i sträng med tecken 

            //1.Skapa en konsollapplikation som tar en textsträng(string) som argument till Main eller uppmanar användaren mata in en sträng i konsollen. 

            //either
            //2. Textsträngen ska sedan sökas igenom efter alla delsträngar som är tal som börjar
            //och slutar på samma siffra, utan att start/ slutsiffran, eller något annat tecken än
            //siffror förekommer där emellan.

            //ex. 3463 är ett korrekt sådant tal, men 34363 är det inte eftersom det finns
            //ytterligare en 3:a i talet, förutom start och slutsiffran. Strängar med bokstäver i
            //t.ex 95a9 är inte heller ett korrekt tal.

            //or
            //3. För varje sådan delsträng som matchar kriteriet ovan ska programmet skriva ut en rad med hela strängen, men där delsträngen är markerad i en annan färg. 


            string isntDone = "y";                                                                //Declarerara en string isntDone och sätter värdet till y

            while (isntDone == "y")                                                               //a while loop that contines for as long as isntDone is y
            {
                Console.Write("Please input a line of numbers and symbols: ");                      //Asks users to input a line of numbers and symbols.
                string input = Console.ReadLine();                                                  //Declares the string input and records the value from the user
                FindStringOfNumber(input);                                                          //Calls the method FindStringOfNumbers with the argument of input

                Console.WriteLine("continue loop? y/n");                                            //Asks the user if you want to go again
                isntDone = Console.ReadLine();                                                      //Records the new value of isntDone
                Console.Clear();                                                                    //Clears the console
            }


            static void FindStringOfNumber(string input)             //Declares the method FindStringOfNumbers with the paramater of input
            {
                int sum = 0;                                              //Declares the int sum with no value.
                for (int i = 0; i < input.Length; i++)                    //for loop that starts on 0 and runs thru the length of the input.
                {

                    for (int j = i + 1; j <= input.Length; j++)          //for loop that starts on the variable i + 1 position, and runs thru as long as j is less or equal to input length (Got AI help here..)
                    {
                        string substring = input.Substring(i, j - i);        //declare a Substring called substring and assigns the value i, j-i (Got AI help here.. I would like more practise with substing) 

                        if (int.TryParse(substring, out int result))             //if you can make a int out of the substring, continue. (Got AI help here.. But I have used TryParse before!)
                        {

                            if (substring.Length < 2)                                //if substring is less the (Got AI help here..)
                            {
                                continue;                                            //(Got AI help here..)
                            }
                            else                                                     //else run this.
                            {
                                int firstDiget = substring[0];                          //declares the int firstDiget and assigns it the first value of substring

                                int secondDiget = substring[substring.Length - 1];      //declares the int secondDiget and assigns the value of substrings length -1 to get the last char

                                if (firstDiget == secondDiget)                          //if firstDiget and secondDiget is the same.. 
                                {

                                    int count = 0;                                      //Found this little fix on StackOverflow.
                                    foreach (char c in substring)                       //for each char in substring
                                    {
                                        if (c == firstDiget)                            //if char is the same as firstDiget, add plus 1 to count.
                                        {
                                            count++;
                                        }
                                    }

                                    if (count <= 2)                                             //if count is less or equal to 2, run this.
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;           //Changes the color of the text to Green
                                        Console.WriteLine(substring);                           //Write out the number.
                                        Console.ForegroundColor = ConsoleColor.Gray;            //Changes the color of the text back to Gray
                                        int wholeNumber = int.Parse(substring);                 //Declare the int wholeNumber that makes sure its only numbers.. (Else, it crashes.. its not needed anymore but.. meh.)
                                        sum += wholeNumber;                                     //adds the value of wholeNumber to sum.
                                    }
                                }
                            }
                        }
                        else                                                    //if you cant make an int out of the substring, break the loop.
                        {
                            break;
                        }
                    }
                }
                Console.WriteLine("____________________________________");
                Console.ForegroundColor = ConsoleColor.Green;                   //Changes the color of the text to Green
                Console.WriteLine($"The sum total is: {sum}");                  //Writes out the sum total.
                Console.ForegroundColor = ConsoleColor.Gray;                    //Changes the color of the text to Gray
            }

        }
    }
}