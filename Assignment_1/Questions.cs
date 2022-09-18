using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Questions
    {
        private int[] intArrayInput;
        private double[] dubArray;
        private int runningTotal = 0;
        private int dubRunningTotal = 0;

        public void QuestionUser()
        {
            Question();
        }
        private void Question()
        {
            // creating a custom strong to be the borders within the console app
            string star = new string('*', Console.WindowWidth),  _userInput = "";
            //creating the int variable to hold the converted string
            int convertedInt = 0;
            // creating a double variable to hold the converted string
            double convertedDouble = 0.0;
            //creating a boolean for the while loop
            bool keepRun = true;
            // creating a boolean for the do while loop
            bool keepAdding = true;
            //using a while loop to check if the boolean is false
            while (keepRun != false)
            {//reseting the boolean to true
                keepAdding = true;
                //using a do while loop
                do
                {//clearing the console
                    Console.Clear();
                    //telling the user to enter a numeric value
                    Console.WriteLine($"\n{star}\nEnter the numeric value that is either a whole number or decimal:");
                    //catching the input
                    _userInput = Console.ReadLine();
                    //TESTING to see if it can be parsed 
                    if (int.TryParse(_userInput, out convertedInt))
                    {//setting the boolan to quit the loop
                        keepAdding = false;
                    }
                    else if (double.TryParse(_userInput,out convertedDouble))
                    {//setting the boolan to quit the loop
                     keepAdding = false;
                    }
                } while (keepAdding != false);

                //making a call to the method to assign the values given
                AssignValueToArray(convertedInt, convertedDouble);
                
                //asking if they want to continue
                Console.WriteLine("Wanna enter another value if so enter y or n?");
                // collecting the input and setting it to lowercase
                string answer = Console.ReadLine().ToLower();
                //testing to see if they said yes or no 
                if (answer.Equals("n"))
                {// setting the boolean to false to quit the loop
                    keepRun = false;
                    //clearing the console
                    Console.Clear();
                    //asking if they would want to see the results of them entering values
                    Console.WriteLine($"{star}\nWould you like to see the values entered?" +
                                       "\nIf so enter y for yes or n for no.");
                    // using an if loop to see compare if the user wants to see the results
                    if (Console.ReadLine().ToLower() =="y")
                    {// creating a boolean variable for the while loop 
                        bool keepGoing = true;
                        //using a while loop checking to make sure the boolean is still true
                        while (keepGoing == true)
                        {//clearing the console 
                            Console.Clear();
                            //presenting a menu to the user
                            Console.WriteLine($"{star}\n[2] View decimal Array\n" +
                                              "[1] View whole number Array\n" +
                                              "[0] back");
                            //capturing the users response and lowering it 
                            string strA = Console.ReadLine().ToLower();
                            keepRun = ChangeBoolean(strA, "0", keepRun);
                            if (keepRun == true)
                            {
                                break;
                            }
                            //making a call to show the method to show the selected results
                            ShowResults(strA);
                            //presenting the option to quit or go back
                            Console.WriteLine("\n[0] Back" +
                                "              \n[1] Quit");
                            //changing the boolean by the functions return
                            keepGoing = ChangeBoolean(Console.ReadLine(), "1", keepGoing);
                        }
                    }
                }
            }
                
        }
        bool ChangeBoolean(string answer, string check, Boolean currentBool)
        {
            if (answer == check)
            {
                currentBool = !currentBool;
            }
            return currentBool;
        }
        
       private void AssignValueToArray(int cnvtdInt, double cnvtdDub)
        {//using an if to see if the number is more or less then0 
            if ((cnvtdInt > 0 || cnvtdInt < 0))
            {//checking to see if the array is empty or not
                if ((intArrayInput == null || intArrayInput != null))
                {//adding to the total that is suppose to be the new array
                    runningTotal += 1;
                    //creating a temp array to hold the old values pluse the new enter
                    int[] tempIntArray = new int[runningTotal];
                    //using a for loop to set the right values of the temp int array
                    for (int i = 0; i < runningTotal; i++)
                    {//checking if i is close to the end of the for loop
                        if (i == tempIntArray.Length - 1)
                        {//assigning the new input to the array
                            tempIntArray[i] = cnvtdInt;
                            //creating new array within the intArrayInput
                            intArrayInput = new int[runningTotal];
                            //using the for loop to put the values back in to the intArrayInput
                            for (int x = 0; x < tempIntArray.Length; x++)
                            {//assigning the values of the int array from the tem int values
                                intArrayInput[x] = tempIntArray[x];
                            }
                        }
                        else
                        {//assigning the temp array values from the int array
                            tempIntArray[i] = intArrayInput[i];
                        }
                    }
                }

            }
            else
            {// addign a one to the double running total since a new value has been entered
                dubRunningTotal += 1;
                //creating a tem array to hold the double arrays item
                double[] tempfltArray = new double[dubRunningTotal];
                //running a foor loop 
                for (int i = 0; i < dubRunningTotal; i++)
                {//using an if to see if i is getting close the end of total
                    if (i == tempfltArray.Length - 1)
                    {//assigning the converted double value to the temp array value
                        tempfltArray[i] = cnvtdDub;
                        // creating a new array within the double array
                        dubArray = new double[dubRunningTotal];
                        // using for loop to assign the values back plus the new value entered
                        for (int x = 0; x < tempfltArray.Length; x++)
                        {//assigning the values
                            dubArray[x] = tempfltArray[x];
                        }
                    }
                    else
                    {//assigning the temp array values from the int array
                        tempfltArray[i] = dubArray[i];
                    }
                }
            }
        }

       private void ShowResults(string selection)
        {//using a while loop checking if the selection is other then 1 or 0 
               while(!(selection == "0"|| selection == "1" || selection == "2"))
                {//letting the user know that they need to make a proper selection
                    Console.WriteLine("Please make a selection shown only.");
                    selection = Console.ReadLine();
                }
               //if the selection is 1  and the array has more then 0 
            if (selection == "2" && dubArray.Length > 0)
            {//using the for loop to cycle through the array to show the user
                for (int i = 0; i < dubArray.Length; i++)
                {//writing to the console what the entered user 
                    Console.Write($" {dubArray[i]}");
                }
            }// if the selction is not 1 then this will trigger making sure the selection is 0 and the array has more then 0 
            else if (selection == "1" && intArrayInput.Length > 0)
            {//using the for loop to cycle through the array 
                for (int i = 0; i < intArrayInput.Length; i++)
                {//writting the users inputs to the console
                    Console.Write(" " + intArrayInput[i]);
                }
            }
            
        }

    }

}
