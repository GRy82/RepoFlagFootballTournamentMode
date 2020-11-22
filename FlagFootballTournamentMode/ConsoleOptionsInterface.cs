using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving1
{
    class ConsoleOptionsInterface
    {
        List<string> optionsMenu = new List<string> { };
        int optionsCount;
        int printedOptions;
        int counter;
        string inputString;
        bool includeExitOption;
        bool stringProtected;

        public ConsoleOptionsInterface(List<string> optionsMenu, bool includeExitOption, bool stringProtected)
        {
            this.optionsMenu = optionsMenu;
            this.includeExitOption = includeExitOption;
            this.printedOptions = optionsMenu.Count;
            this.stringProtected = stringProtected;
        }
        //-------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------
        public void SetExitOption()
        {
            if (this.includeExitOption)
            {
                this.optionsCount = this.printedOptions + 1;
            }
            else
            {
                this.optionsCount = this.printedOptions;
            }
        }
        
        public int Launch()
        {
            SetExitOption();
            DisplayOptions(); //Display options in form "1. option"
            bool valid = true;
            do
            {
                if (!stringProtected) {
                    inputString = Console.ReadLine();
                }
                else {
                    inputString = ProtectedTyping();
                }
                valid = CheckValidity();
                if (!valid) {
                    Console.WriteLine("\nInvalid input. Enter number of option or number of option with a period.\n");
                }
            } while (!valid);

            return int.Parse(inputString);
        }
        //-------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------
        void DisplayOptions()
        {
            counter = 0;
            Console.WriteLine("\nPlease select from the following options:");//Always begin with prompt
            while (counter < printedOptions) 
            {
                Console.Write(Convert.ToString(counter + 1) + ". ");
                Console.WriteLine(optionsMenu[counter]);
                counter++;
            }
            //End with an option to exit if preferred.
            if (includeExitOption) {
                Console.WriteLine(Convert.ToString(counter + 1) + ". Exit program");
            }
            //leave extra space between options and input.
            Console.Write("\n");
            return;
        }
        //-------------------------------------------------------------------------------------
        bool CheckValidity()
        {
            if (inputString == "") {
                return false;
            }
            for (int i = 0; i < inputString.Length; i++)
            {
                char charac = inputString[i];
                //boolean conditions
                bool acceptedChar = (charac > 47 && charac < 58) || charac == 46;
                bool unacceptableDecimal = ((charac == 46 && i != inputString.Length - 1) || (charac == 46 && i ==0));
                //input can be in any number in the form "1" or "1." with unlimited number of digits.
                //as long as number input does not exceed number of options.
                if (unacceptableDecimal || !acceptedChar || inputString == "") {
                    return false;
                }
            }
            //if string is valid so far and has decimal, remove it to assess it as an int.
            if (LookForDecimal()) {
                inputString = RemoveDecimal();
            }
            //if option input exceeds number of options.
            if (int.Parse(inputString) > optionsCount) {
                return false;
            }
            return true;
        }
        //-------------------------------------------------------------------------------------
        bool LookForDecimal()
        {            
            if (inputString[(inputString.Length) - 1] == '.') {
                return true;
            }
            return false;
        }
        //-------------------------------------------------------------------------------------
        string RemoveDecimal()
        {
            string newString = "";
            for (int i = 0; i < ((inputString.Length) - 1); i++)
            {
                newString += Convert.ToString(inputString[i]);
            }

            return newString;
        }
        //-------------------------------------------------------------------------------------

        string ProtectedTyping()
        {
            //Help from:
            //https://stackoverflow.com/questions/3404421/password-masking-console-application
            ConsoleKey keyPressed;
            string optionInput = "";
            do
            {
                var keyIntercepted = Console.ReadKey(intercept: true);
                keyPressed = keyIntercepted.Key;

                if (keyPressed == ConsoleKey.Backspace && optionInput.Length > 0)
                {
                    Console.Write("\b \b");
                    int lastIndex = optionInput.Length - 1;
                    if (optionInput.Length == 1) {
                        optionInput = "";
                    }
                    else {
                        optionInput.Remove(lastIndex, 1);
                    }
                }
                else if (!char.IsControl(keyIntercepted.KeyChar))
                {
                    Console.Write("*");
                    optionInput += keyIntercepted.KeyChar;//intercept is a boolean that selects for non-display.
                }
            } while (keyPressed != ConsoleKey.Enter);

            Console.WriteLine();//skip a line

            return optionInput;
        }
        //-------------------------------------------------------------------------------------
    }
}
