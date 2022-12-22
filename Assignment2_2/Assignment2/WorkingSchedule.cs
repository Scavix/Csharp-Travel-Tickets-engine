﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class WorkingSchedule
    {
        public void Start()
        {
            bool done; //variable for loop
            do
            {
                ShowMenu(); //show choices
                done = !RunAgain(); //runAgain() ? yes or no -> true of false
            } while (!done);
        }
        private bool RunAgain() // ask to run again
        {
            Console.WriteLine("Do you want to run this program again?(y/n)?");
            string? v = Console.ReadLine(); //input if y or yes it runs again
            if (!string.IsNullOrEmpty(v))
            {
                return (v.Trim().Equals("y") || v.Trim().Equals("yes"));
            }
            return false;
        }
        private void ShowMenu() //show choices
        {
            bool done = false;  //Flag to control when to exit the loop
            while (!done)
            {
                int choice = ReadMenuChoice(); //Show the menu text and retrieve the user's choice
                switch (choice) //Show results
                {
                    case 0: // case exit
                        done = true;
                        break;
                    case 1: // case C to F
                        ShowTableWeekends(); //Show table
                        done = true; //end loop
                        break;
                    case 2: // case F to C
                        ShowTableNights(); //Show table
                        done = true; //end loop
                        break; 
                } //switch
                if (!done)
                {
                    Console.WriteLine("\nThank you for trying this program.");
                } //if
            } //while
        }
        private int ReadMenuChoice() //asks for input scenario
        {
            bool done = false;
            int choice = -1;
            do
            {
                WriteMenuText(); // show menu
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if ((choice >= 0) && (choice <= 2)) // if input valid go on
                    {
                        done = true;
                    }
                }
                if (!done)
                {
                    Console.WriteLine("Invalid choice, try again!\n");
                }
            } while (!done);
            return choice;
        } //ReadMenutChoiche
        private void WriteMenuText()
        {
            Console.WriteLine("\n ***************** MENU *********************");
            Console.WriteLine(" ***** Show a list of the weekends to work [1]");
            Console.WriteLine(" ***** Show a list of nights to work [2]");
            Console.WriteLine(" ***** Exit [0]");
            Console.WriteLine(" *********************************************\n");
            Console.Write("What is your choice? ");
        } //WriteMenutText
        private static void ShowTableWeekends()
        {
            for (int i = 1; i<=52; i++) //loop over a year's weeks
            {
                for (int j = 0; j<4; j++) //show 4 column
                {
                    if (i%2!=0) // if has to work print
                    {
                        Console.Write("Week " + string.Format("{0,2}",i) + "  ");
                    }
                    else // else skip 1 column
                    {
                        j--; // useful to format table in 4 column
                        if (i>=52)
                        {
                            break;
                        }
                    }
                    i++;
                }
                Console.WriteLine();
            }
        }
        private static void ShowTableNights()
        {
            for (int i = 0; i<=51; i++) //loop over a year's weeks
            {
                for (int j = 0; j<4; j++) //show 4 column
                {
                    if (i%3==0) //if has to work -> print
                    {
                        Console.Write("Week " + string.Format("{0,2}",i+1) + "  ");
                    }
                    else //else skip 1 column
                    {
                        j--; // useful to format table in 4 column
                        if (i>=52)
                        {
                            break;
                        }
                    }
                    i++;
                }
                Console.WriteLine();
            }
        }
    }
}