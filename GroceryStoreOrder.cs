using System.Diagnostics.Tracing;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string userName, Email, itemSelection, phoneNumber;
        string[] productNames = ["Beef", "Pork", "Chicken", "Fish", "Milk", "Water", "Juice", "Soda", "Cabbage", "Lettuce", "Onion", "Garlic", "Broccoli", "Apples", "Bananas", "Pineapples", "Oranges", "Strawberries", "Grapes", "Nuts"];
        List<string> digitalGroceryCart = [];
        string optionSelection = "Add";
        bool itemSelectionMatch = false;
        Dictionary<string, int> digitalGroceryCartCount = [];

        Console.WriteLine("Welcome to this Online Grocery Shopping App Simulation, to be displayed to future employers.\nIn this app the user will enter fake personal information and order groceries by typing the names of products.\nPlease hit the enter key to continue.");
        Console.ReadLine();

        userName = ReadRequiredString("Please enter your name: ");

        Email = ReadRequiredString($"Hello {userName}, please enter your email:");

        while (!IsValidEmail(Email))/*in the while loops parameters it calls the IsValidEmail method to figure out if the parameter is true or false*/
        {
            Email = ReadRequiredString(
                "Error, the email needs to contain a @ and either a .com or .net\nPlease enter your email again: ");
        }

        phoneNumber = ReadPhoneNumber("Please enter your 10-digit phone number(do not include digits like - ( or ) ): ");

        Console.WriteLine("Phone number accepted: " + phoneNumber); ;

        Console.WriteLine("In this Online Grocery Store App Simulation you can can simulate selecting our products which are: ");

        for (int i = 0; i < productNames.Length; i++)
        {
            if (i != 0)
            {
                Console.Write(" ");//gives a space between each grocery cart item without having a extra space at the beginning or end of the output
            }
            Console.Write(productNames[i]);
        }
        Console.WriteLine("\nYou can enter what items you want to put into your grocery cart by typing one of the product names previously listed.\nNote that it is case sensitive: ");//later add option to exit before even adding an item and create a message at the end of the program that tells the user that they exited without ordering anything and thank you
        while (optionSelection != "Exit" && optionSelection != "exit")
        {
            int firstLoop = 0;

            optionSelection = ReadRequiredString("You can type Add, Delete or Exit to respectively Add or Delete items from your digital grocery cart or Exit the program simulation\n");

            if (optionSelection == "Delete" || optionSelection == "delete")
            {
                if (digitalGroceryCart.Count == 0)
                {
                    Console.WriteLine("Your Digital Grocery Cart is empty, you cannot delete anything.");
                }
                else
                {
                    itemSelection = ReadRequiredString("Please select an item:\n" + string.Join(", ", digitalGroceryCart) + "\n ");

                    while (!itemSelectionMatch)
                    {
                        itemSelectionMatch = ItemSelectionExists(itemSelection, digitalGroceryCart);

                        itemSelection = WrongItemReselect(itemSelection, itemSelectionMatch);
                    }

                    digitalGroceryCart.Remove(itemSelection);
                    Console.WriteLine();

                    itemSelectionMatch = false;
                }
            }
            else if (optionSelection == "Add" || optionSelection == "add")
            {
                itemSelection = ReadRequiredString("Please select an item:\n" + string.Join(", ", productNames) + "\n ");

                while (itemSelectionMatch == false)
                {
                    itemSelectionMatch = ItemSelectionExists(itemSelection, productNames);

                    itemSelection = WrongItemReselect(itemSelection, itemSelectionMatch);
                }

                digitalGroceryCart.Add(itemSelection);
                Console.WriteLine(itemSelection + " was added to your cart.");

                Console.WriteLine("Here are your current digital grocery cart items:");
                Console.WriteLine(string.Join(", ", digitalGroceryCart));

                itemSelectionMatch = false;
            }
            else if (optionSelection != "Exit" && optionSelection != "exit")
            {
                Console.WriteLine("Error. Incorrect Input. You have to write Add, Delete, or Exit.");
            }

            firstLoop++;

        }


        if (digitalGroceryCart.Count == 0)
        {
            Console.WriteLine("You did not order anything.\nThank you for using this Simulator");
        }
        else
        {
            //digitalGroceryCartCount
            foreach (string item in digitalGroceryCart)
            {
                if (digitalGroceryCartCount.ContainsKey(item))//the first time this runs for each different item, digitalGroceryCartCount does not contain it, thus in the else statement, it is assigned item and 1 as a key and a value(the item is the key and the number is the value) as written in the <> in Dictionary<string, int> digitalGroceryCartCount = [];
                {
                    digitalGroceryCartCount[item]++;
                }
                else
                {
                    digitalGroceryCartCount[item] = 1;
                }
            }

            string toTextFile = "Your shopping list purchase is: ";

            foreach (var pair in digitalGroceryCartCount)
            {
                toTextFile += $"{pair.Key} (x{pair.Value}) ";
            }

            toTextFile += ". Thank you for using this simulator.";

            Console.WriteLine(toTextFile);
            File.WriteAllText("SimulationShoppingList.txt", toTextFile);

        }

    }

    static bool ItemSelectionExists(string itemSelection, IEnumerable<string> items)
    {
        foreach (string item in items)
        {
            if (itemSelection == item)
            {
                return true;
            }
        }

        return false;
    }
    static string WrongItemReselect(string itemSelection, bool itemSelectionMatch)
    {
        if (itemSelectionMatch != true)
        {
            Console.WriteLine(itemSelection + " does not match any item on the list. Please enter what you want again");

            return Console.ReadLine() ?? "NullString";
        }

        return itemSelection;
    }

    static string ReadRequiredString(string message)
    {
        Console.Write(message);

        string? input = Console.ReadLine();/* the ? in string? means the input is
     allowed be null unlike string input */

        if (input is null)/*"is" is different than == in that unlike == it cannot be 
    overloaded */
        {
            Console.WriteLine("Unexpected end of input. Exiting...");
            Environment.Exit(1);/*1 is an exit code, 0 would be typed if program exited 
        normally while 1 means it exited due to an error*/
        }

        return input;
    }
    static string ReadPhoneNumber(string message)
    {
        while (true)/*I know this is an infinite loop but it can exit if the user enters the correct input*/
        {
            string input = ReadRequiredString(message);

            if (input.Length != 10)
            {
                Console.WriteLine("Phone number must be exactly 10 digits.");
                continue;
            }

            if (!input.All(char.IsDigit))
            {
                Console.WriteLine("Phone number must contain only digits.");
                continue;
            }

            return input;
        }
    }
    static bool IsValidEmail(string email)
    {
        bool containsAt = email.Contains("@");
        bool containsDotCom = email.Contains(".com");
        bool containsDotNet = email.Contains(".net");//originally I wanted to combine all these into a method but after I typed it I realized that I would still have to write bool containsAt = checkEmailString(Email, "@");, etcetera for each anyway so it would only create extra code for the same functionality, so I reverted the changes. Only later did I find out that you could return multiple statements

        return containsAt && (containsDotCom || containsDotNet);
    }

}