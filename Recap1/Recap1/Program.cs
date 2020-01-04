using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Recap1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert the number of exercise to run: ");
            string exercise = Console.ReadLine();

            // Conditionals
            /* 1.Write a program and ask the user to enter a number. The number should be between 1 to 10. If the user enters a
            valid number, display "Valid" on the console. Otherwise, display "Invalid". (This logic is used a lot in applications
            where values entered into input boxes need to be validated.) */
            if (exercise == "1")
            {
                Console.WriteLine("Enter a number between 1 and 10: ");
                int number = int.Parse(Console.ReadLine());
                if (number >= 1 && number <= 10)
                {
                    Console.WriteLine("Valid");
                }
                else
                {
                    Console.WriteLine("Invalid");
                }
            }

            // 2.Write a program which takes two numbers from the console and displays the maximum of the two.
            if (exercise == "2")
            {
                Console.WriteLine("Enter the first number: ");
                int firstNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the second number: ");
                int secondNumber = int.Parse(Console.ReadLine());
                if (firstNumber > secondNumber)
                {
                    Console.WriteLine("The maximum is {0}", firstNumber);
                }
                else
                {
                    Console.WriteLine("The maximum is {0}", secondNumber);
                }
            }

            /* 3.Write a program and ask the user to enter the width and height of an image. Then tell if the image 
            is landscape or portrait. Use an enum for in which to group the landscape and portrait orientations. */
            if (exercise == "3")
            {
                Console.WriteLine("Enter the width of the image: ");
                int width = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the height of the image: ");
                int height = int.Parse(Console.ReadLine());
                if (width > height)
                {
                    Console.WriteLine("The image is landscape.");
                }
                if (width < height)
                {
                    Console.WriteLine("The image is portrait.");
                }
                if (width == height)
                {
                    Console.WriteLine("The image is square.");
                }
            }

            /* 4.Your job is to write a program for a speed camera. For simplicity, ignore the details such as camera, sensors, 
            etc and focus purely on the logic. Write a program that asks the user to enter the speed limit. Once set, 
            the program asks for the speed of a car. If the user enters a value less than the speed limit, program should 
            display Ok on the console. If the value is above the speed limit, the program should calculate the number of 
            penalty points. For every 5km/hr above the speed limit, 1 penalty point should be incurred and displayed on 
            the console. If the number of penalty points is above 12, the program should display License Suspended. */
            if (exercise == "4")
            {
                Console.WriteLine("Enter the speed limit: ");
                int speedLimit = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the speed of the car: ");
                int carSpeed = int.Parse(Console.ReadLine());
                int penaltyPoints = (carSpeed - speedLimit) / 5 ;

                if (carSpeed <= speedLimit)
                {
                    Console.WriteLine("OK");
                }

                if (carSpeed > speedLimit)
                {
                    if (penaltyPoints >= 12)
                    {
                        Console.WriteLine("Since you have {0} penalty points, yor Licence is Suspended", penaltyPoints);
                    }
                    else
                    {
                        Console.WriteLine("You have {0} penalty points", penaltyPoints);
                    }
                }
            }

            // Lists
            /* 5.<pattern>
            1) John, Mary and 3 others like your post
            2) John and Mary like your post
            3) John likes your post
            </pattern>
            Write a program and continuously ask the user to enter different names, until the user presses Enter (without supplying a name).
            Depending on the number of names provided, display a message based on the above pattern. */
            if (exercise == "5")
            {
                var friendsList = new List<string>();
                Console.WriteLine("Enter names and when you finished press enter!");
                while (true)
                {                  
                    var friend = Console.ReadLine();
                    if (friend.Length<1)
                    {
                        break;
                    }
                    friendsList.Add(friend);
                }
                
                if (friendsList.Count<2)
                {
                    Console.WriteLine("{0} likes your post.", friendsList[0]);
                }
                if (friendsList.Count==2)
                {
                    Console.WriteLine("{0} and {1} like your post.", friendsList[0], friendsList[1]);
                }
                if (friendsList.Count > 2)
                {
                    Console.WriteLine("{0}, {1} and " + (friendsList.Count-2) + " others like your post.", friendsList[0], friendsList[1]);
                }
            }

            /* 6.Ask the user to enter their name. Use an array to reverse the name and then store the result in a new string. 
            Display the reversed name on the console. */
            if (exercise == "6")
            {
                Console.WriteLine("Please enter your name:");
                string name = Console.ReadLine();

                char[] reversedArray = new char[name.Length];

                for (int i = 0; i < reversedArray.Length; i++)
                {
                    reversedArray[i] = name[reversedArray.Length - i-1];
                }

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i<=reversedArray.Length-1;i++ )
                {
                    sb.Append(reversedArray[i].ToString());
                }
                Console.WriteLine(sb);
            }

            /* 7.Write a program and ask the user to enter 5 numbers. If a number has been previously entered, display 
            an error message and ask the user to re-try. Once the user successfully enters 5 unique numbers, sort them 
            and display the result on the console. */
            if (exercise == "7")
            {
                var numbersList = new List<int>();
                Console.WriteLine("Enter a number until you reach 5 different numbers!");
                
                while (numbersList.Count<5)
                {
                    int number = int.Parse(Console.ReadLine());

                    if (numbersList.Contains(number))
                    {
                        Console.WriteLine("Re-enter a number that you haven't entered before!");
                    }
                    else
                    {
                        numbersList.Add(number);
                    }
                }

                numbersList.Sort();

                foreach (var item in numbersList)
                {
                    Console.WriteLine(item);
                }
            }

            /* 8.Write a program and ask the user to continuously enter a number or type "Quit" to exit. The list of numbers may 
            include duplicates. Display the unique numbers that the user has entered. */
            if (exercise == "8")
            {
                var numbersList = new List<int>();

                int number;
                bool check;

                Console.WriteLine("Enter numbers, even duplicates, and if you want to exit, type Quit ");

                while (true)
                {
                    var input = Console.ReadLine();
                    check = int.TryParse(input, out number);

                    if (check==false && input.ToLower()=="quit")
                    {
                        Console.WriteLine("This is the list of unique numbers!");
                        List<int> distinctList = numbersList.Distinct().ToList();
                        foreach (var item in distinctList)
                            Console.WriteLine(item);
                        break;
                    }
                    
                    if (check == false)
                    {
                        Console.WriteLine("Enter a valid number, or enter quit");
                    }
                    else
                    {
                        numbersList.Add(number);
                    }
                }            
            }

            /* 9.Write a program and ask the user to supply a list of comma separated numbers (e.g 5, 1, 9, 2, 10). If the list is 
            empty or includes less than 5 numbers, display "Invalid List" and ask the user to re-try; otherwise, display 
            the 3 smallest numbers in the list. */
            if (exercise == "9")
            {

                Console.WriteLine("Enter a series of minimum 5 numbers, separated by a comma: ");
                string inputNumbers = Console.ReadLine();

                int[] intSplitNumbers = inputNumbers.Split(',').Select(s => int.Parse(s)).ToArray();
                int[] ascendingNumbers = intSplitNumbers.OrderBy(x => x).ToArray();

                if (intSplitNumbers.Length < 5)
                {
                    Console.WriteLine("Invalid list");
                }
                else
                {
                    Console.WriteLine("The 3 smallest numbers in the list are {0}, {1} and {2}", ascendingNumbers[0], ascendingNumbers[1], ascendingNumbers[2]);
                }
            }

            // Loops
            /* 10.Write a program to count how many numbers between 1 and 100 are divisible by 3 with no remainder. 
            Display the result on the console. */
            if (exercise == "10")
            {
                int count = 0;
                for (int i=1; i<=100; i++)
                {
                    if (i % 3 == 0)
                    {
                        count = count + 1;
                    }
                }
                Console.WriteLine("Between 1 and 100 there are {0} numbers divisible by 3", count);
            }

            /* 11.Write a program and continuously ask the user to enter a number. The loop terminates when the user 
            enters “ok". Calculate the sum of all the previously entered numbers and display it on the console. */
            if (exercise == "11")
            {
                var sum = 0;
                Console.WriteLine("You will be asked to continuously enter numbers, if you want to see their sum enter ok!");

                while (true)
                {
                    Console.WriteLine("Enter a number: ");
                    var input = Console.ReadLine();
                    if (input == "ok")
                    {
                        break;
                    }
                    else 
                    { 
                    var number = int.Parse(input);
                    sum = sum + number;
                    }
                }
                Console.WriteLine("The sum of numbers is: " + sum);
            }

            /* 12.Write a program which takes a single number from the user, calculates the factorial and prints the value on the console.
            For example, if the user enters 5, the program should calculate 5 x 4 x 3 x 2 x 1 
            and display it as 5! = 120(result of 5 x 4 x 3 x 2 x 1). */
            if (exercise == "12")
            {
                int factorial = 1;

                Console.WriteLine("Enter the number to calculate factorial: ");
                int number = int.Parse(Console.ReadLine());


                for (int i = 1; i <= number; i++)
                {
                    factorial = factorial * i;
                }

                Console.WriteLine("{0}! is {1}", number, factorial);
            }

            /* 13.Write a program that picks a random number between 1 and 10. Give the user 4 chances to guess the number. 
            If the user guesses the number, display “You won". Otherwise, display “You lost". */
            if (exercise == "13")
            {
                int randomNumber;

                Random rand = new Random();
                randomNumber = rand.Next(1, 11);
                Console.WriteLine(randomNumber); /*left to check the functionality*/

                Console.WriteLine("You have 4 chances to guess a number between 1 and 10, randomly picked by the program. Proceed: ");
                for (int i = 0; i<= 3; i++)
                {
                    int inputNumber = int.Parse(Console.ReadLine());
                    if (inputNumber==randomNumber)
                    {
                        Console.WriteLine("You guessed the number!");
                    }
                    else
                    {
                        Console.WriteLine("One more try or you finished the 4 chances!");
                    }
                }
            }

            /* 14.Write a program and ask the user to enter a series of numbers separated by comma. Find the maximum of the 
            numbers and display it on the result. For example, if the user enters “5, 3, 8, 1, 4", the program should 
            display 8 on the console. */
            if (exercise == "14")
            {
                Console.WriteLine("Enter a series of numbers separated by comma: ");
                var inputNumbers = Console.ReadLine();
                var numbers = inputNumbers.Split(',');
                Console.WriteLine(numbers.Max());
            }

            // Strings
            /* 15.Write a program and ask the user to enter a few numbers separated by a hyphen(minus). Work out 
            if the numbers are consecutive. For example, if the input is "5-6-7-8-9" or "20-19-18-17-16", 
            display a message: "Consecutive"; otherwise, display "Not Consecutive". */
            if (exercise == "15")
            {
                Console.WriteLine("Enter a series of numbers separated by a hyphen, consecutive or not consecutive: ");
                string inputNumbers = Console.ReadLine();

                int[] intSplitNumbers = inputNumbers.Split('-').Select(s => int.Parse(s)).ToArray();

                int count = 0;

                for (int i=0; i < intSplitNumbers.Length-1; i++)
                {
                    if (intSplitNumbers[i+1] - intSplitNumbers[i] == 1)
                    {
                        count++;
                    }
                }
                if (count == intSplitNumbers.Length-1)
                {
                    Console.WriteLine("Consecutive");
                }
                else
                {
                    Console.WriteLine("Not Consecutive");
                }
            }

            /* 16.Write a program and ask the user to enter a few numbers separated by a hyphen(minus). If the user simply 
            presses Enter without supplying an input, exit immediately; otherwise, check to see if there are 
            any duplicates. If so, display "Duplicate" on the console. */
            if (exercise == "16")
            {
                Console.WriteLine("Enter a series of numbers separated by a hyphen, even duplicates: ");
                string inputNumbers = Console.ReadLine();

                int[] intSplitNumbers = inputNumbers.Split('-').Select(s => int.Parse(s)).ToArray();

                int count = 0;

                for (int i = 0; i < intSplitNumbers.Length; i++)
                {
                    foreach (var item in intSplitNumbers)
                    {
                        if (item == intSplitNumbers[i])
                        {
                            count++;
                        }                           
                    }
                }             
                if (count > intSplitNumbers.Length)
                {
                    Console.WriteLine("Duplicate");
                }
            }

            /* 17.Write a program and ask the user to enter a time value in the 24-hour time format (e.g. 19:00).
            A valid time should be between 00:00 and 23:59. If the time is valid, display "Ok"; otherwise, 
            display "Invalid Time". If the user doesn't provide any values, consider it as invalid time. */
            if (exercise == "17")
            {
                Console.WriteLine("Enter a time value between 00:00 and 23:59!");
                string inputTime = Console.ReadLine();

                int hours = int.Parse(inputTime.Substring(0, 2));
                int minutes = int.Parse(inputTime.Substring(3, 2));

                if (((hours >= 00) && (hours <= 24)) && ((minutes >= 00) && (minutes <= 59)))
                {
                    Console.WriteLine("OK");
                }
                else
                {
                    Console.WriteLine("Invalid Time");
                }             
            }

            /* 18.Write a program and ask the user to enter a few words separated by a space. Use the words to create a variable name 
            with PascalCase convention. For example, if the user types: "number of students", display "NumberOfStudents". Make sure the
            program is not dependent on the casing of the input. So if the input is "NUMBER OF STUDENTS", it should still display 
            "NumberOfStudents". If the user doesn't supply any words, display "Error". */
            if (exercise == "18")
            {
                Console.WriteLine("Enter a few words separated by space: ");
                string input = Console.ReadLine();
                var wordsLowerCase = input.Split(' ').Select(word => word.ToLower().ToArray());

                foreach (var word in wordsLowerCase)
                {
                    var letters = word.ToArray();
                    letters[0] = char.ToUpper(letters[0]);
                    Console.Write(letters);
                }               
            }

            /* 19.Write a program and ask the user to enter an English word. Count the number of vowels (a, e, o, u, i) in the word. 
            So, if the user enters "inadequate", the program should display 6 on the console. Make sure the program calculates the number 
            of vowels irrespective of the casing of the word (eg "Inadequate", "inadequate" and "INADEQUATE" all include 6 vowels). */
            if (exercise == "19")
            {
                Console.WriteLine("Enter an English word: ");
                string wordGross = Console.ReadLine();
                string word = wordGross.ToLower();
                char[] vowels = { 'a','e','o','u','i' };
                var count = 0;
                foreach (var item in word)
                {
                    if (vowels.Contains(item))
                    {
                        count++;
                    }
                }
                Console.WriteLine("The word {0} contains {1} vowels.",wordGross, count);
            }
        }
    }
}

