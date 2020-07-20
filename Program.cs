using System;
using System.IO;

namespace Lab4._1
{
    class Program
    {
        public static int counter = 1;  //declare a glocal counter variable for ease of use
        static int[] DiceRoller(int sidesChoice) //method for creating the random numbers(die faces) within the user defined scope
        {
            int[] diceArray = new int[2];  //an array with 2 indexes to store the dice face favlues

            Random rand1 = new Random();
            
            diceArray[0] = rand1.Next(1, sidesChoice + 1); //fill the array indexes with the desired values
            diceArray[1] = rand1.Next(1, sidesChoice + 1);                      

            return diceArray; //return the entire array with the stored values

        }

        static void Output(int[] diceArray2, int sides)
        {           
            int notNeccesary = diceArray2[0] + diceArray2[1]; //creating the total value of dice rolls from the stored indexes
            
            Console.WriteLine($"Dice Roll Number {counter}"); //using the global counter to display which roll youre on
            string finalOutput1 = ($"You rolled {diceArray2.GetValue(0)} and {diceArray2.GetValue(1)} for a total of {notNeccesary}");
            Console.WriteLine(finalOutput1);

            if (sides == 6) //a series of If statements to display the dice combinations, assuming you rolled 6 siders
            {
                if (notNeccesary == 2)
                {
                    Console.WriteLine("Snake-Eyes!");
                    Console.WriteLine("Craps! (Total of 2)");
                }
                else if (notNeccesary == 3)
                {
                    Console.WriteLine("Ace Duece! (1, 2 Combo");
                    Console.WriteLine("Craps! (Total of 3)");
                }
                else if (notNeccesary == 12)
                {
                    Console.WriteLine("Box Cars! (Double 6 Combo");
                    Console.WriteLine("Craps! (Total of 12)");
                }
                else if (notNeccesary == 7 || notNeccesary == 11)
                {
                    Console.WriteLine("Win! (Total of 7 or 11)");
                }
            }
            Console.WriteLine("------------------");
            doAgain();
        }
        static int doAgain()
        {
            
            Console.WriteLine("Would you like to continue? (y/n)");
            string doAgainChoice = Console.ReadLine();
            doAgainChoice.ToLower();

            if (doAgainChoice == "y")
            {
                counter++;
                Main();
            }
            else if (doAgainChoice == "n")
            {
                Console.Clear();
                Console.WriteLine("Thanks for playing");
            }
            else
            {
                Console.WriteLine("This is not valid input please try again");
                doAgain();
            }
            return (counter);
        }//a method to repeat the program
        static void Main()
        {
            
            int[] diceRolls = new int[2];

            Console.WriteLine("Please enter the number of sides for your Dice: ");
            string sides = Console.ReadLine();           
            Console.WriteLine("------------------");

            if (int.TryParse(sides, out int numberOfSides)) //input validation - ensuring we're using an integer
            {
                diceRolls = DiceRoller(numberOfSides);
                Output(diceRolls, numberOfSides);
            }
            else
            {
                Console.WriteLine("This is not a valid integer - please try again");
                Console.WriteLine("------------------");
                Main();
            }

        }
    }
}
