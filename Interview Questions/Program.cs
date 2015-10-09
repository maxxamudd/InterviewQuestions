using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Interview_Questions
{
    class Program
    {
        static void Main(string[] args)
        {
            // create and populate questions list
            List<Question> qList = new List<Question>();
            qList = createList();

            // choice variable
            int choice;

            // greet user
            greet();

            // loop while user wants to view questions
            while (true)
            {
                displayMenu(qList);

                choice = getChoice();

                openFile(choice, qList);
            }  
        }
        public static List<Question> createList()
        {
            // create question objects
            Question question1 = new Question("reverseString.txt", 1, "1. Reverse a string");
            Question question2 = new Question("fizzBuzz.txt", 2, "2. Fizz Buzz");
            Question question3 = new Question("checkIfPalindrome.txt", 3, "3. Check if palindrome");
            Question question4 = new Question("reverseWordsInAString.txt", 4, "4. Reverse words in a string");
            Question question5 = new Question("missingNumber.txt", 5, "5. Missing number in an array");
            Question question6 = new Question("bubbleSort.txt", 6, "6. Bubble sort");
            Question question7 = new Question("fisherYatesShuffle.txt", 7, "7. Fisher-Yates shuffle");
            Question question8 = new Question("convertLetterToUppercase.txt", 8, "8. Convert letter to uppercase without ToUpper");
            Question question9 = new Question("checkIfPrimeNumber.txt", 9, "9. Check if a number is a prime number");
            Question question10 = new Question("findLargestValueInArray.txt", 10, "10. Find the largest value in an array");
            Question question11 = new Question("writeAndReadFile.txt", 11, "11. Write to and read from a file");
            Question question12 = new Question("wolfGoatSalad.txt", 12, "12. Wolf, goat, and salad puzzle");
            Question question13 = new Question("lengthOfLastWord.txt", 13, "13. Length of last word in a string");
            Question question14 = new Question("staircase.txt", 14, "14. Print a staircase");
            Question question15 = new Question("astronautPairings.txt", 15, "15. Astronaut birthdays");

            // create and populate list of questions
            List<Question> qList = new List<Question>();
            qList.Add(question1);
            qList.Add(question2);
            qList.Add(question3);
            qList.Add(question4);
            qList.Add(question5);
            qList.Add(question6);
            qList.Add(question7);
            qList.Add(question8);
            qList.Add(question9);
            qList.Add(question10);
            qList.Add(question11);
            qList.Add(question12);
            qList.Add(question13);
            qList.Add(question14);
            qList.Add(question15);

            return qList;
        }
        public static void greet()
        {
            Console.WriteLine("I have compiled a list of whiteboard questions for programming interviews.");
            Console.WriteLine("Hopefully these will be useful to you in your next interview!\n");
        }
        public static void displayMenu(List<Question> qList)
        {
            Console.WriteLine("Choose a question: ");

            foreach (var q in qList)
            {
                Console.WriteLine(q.Name);
            }
        }
        public static int getChoice()
        {
            // variables
            string input = "";
            int choice = 0;

            // get question user wants to see
            Console.Write("\nWhich question would you like to review? Type QUIT to quit. >> ");
            input = Console.ReadLine();

            // exit if user enters QUIT
            if (input == "QUIT")
            {
                Console.WriteLine("\nGoodbye!");
                System.Environment.Exit(1);
            }

            // input validation
            int.TryParse(input, out choice);
            if (!int.TryParse(input, out choice) || choice > 15 || choice < 1)
            {
                choice = -1;
                while (choice == -1)
                {
                    Console.WriteLine("\nPlease enter a valid choice.");
                    Console.Write("\nWhich question would you like to review? Type QUIT to quit. >> ");
                    input = Console.ReadLine();

                    // exit if user enters QUIT
                    if (input == "QUIT")
                    {
                        Console.WriteLine("\nGoodbye!");
                        System.Environment.Exit(1);
                    }

                    // input validation
                    int.TryParse(input, out choice);
                    if (!int.TryParse(input, out choice) || choice > 15 || choice < 1)
                    {
                        choice = -1;
                    }
                }
            }

            return choice;
        }
        public static void openFile(int choice,  List<Question> qList)
        {
            // loop through questions list to find chosen question
            foreach (var q in qList)
            {
                if (q.ListNum == choice)
                {
                    // open file
                    Question chosenQuestion = new Question(q.File, q.ListNum, q.Name);
                    Console.WriteLine("\nOpening file...\n");

                    // attempt to open file and if it does not exist, throw exception
                    try
                    {
                        if(!File.Exists(chosenQuestion.File))
                        {
                            throw new Exception();
                        }
                        Process.Start("notepad.exe", chosenQuestion.File);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Error: File not found.\n");
                    }
                }
            }
        }
    }
    class Question
    {
        public string File { get; set; }
        public int ListNum { get; set; }
        public string Name { get; set; }

        public Question(string file, int listNum, string name)
        {
            File = file;
            ListNum = listNum;
            Name = name;
        }
    }
}
