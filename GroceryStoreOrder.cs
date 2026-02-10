using System.Diagnostics.Tracing;
using System;
using System.Collections.Generic;

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
static string wrongItemReselect(string itemSelection, bool itemSelectionMatch)
{
    if (itemSelectionMatch != true)
    {
        Console.WriteLine(itemSelection + " does not match any item on the list. Please enter what you want again");
        
        return Console.ReadLine();
    } else
    {
        return itemSelection;
    }
}

static void main()
{
    string userName, Email;
    int phoneNumber;
    string[] productNames = ["Beef", "Pork", "Chicken", "Fish", "Milk", "Water", "Juice", "Soda", "Cabbage", "Lettuce", "Onion", "Garlic", "Broccoli", "Apples", "Bananas", "Pineapples", "Oranges", "Strawberries", "Grapes", "Nuts"];
    List<string> digitalGroceryCart = [];
    string itemSelection;
    string itemDeletion;
    string optionSelection = "Add";
    bool itemSelectionMatch = false;
    Dictionary<string, int> digitalGroceryCartCount = [];

    Console.WriteLine("Welcome to this Online Grocery Shopping App Simulation, to be displayed to future employers.\nIn this app the user will enter fake personal information and order groceries by typing the names of products.\nPlease hit the enter key to continue.");
    Console.ReadLine();

    Console.WriteLine("Please enter your name:\n");
    userName = Console.ReadLine();

    Console.WriteLine("Hello " + userName + " please enter your email:");

    Email = Console.ReadLine();
    bool containsAt = Email.Contains("@");
    bool containsDotCom = Email.Contains(".com");
    bool containsDotNet = Email.Contains(".net");//originally I wanted to combine all these into a method but after I typed it I realized that I would still have to write bool containsAt = checkEmailString(Email, "@");, etcetera for each anyway so it would only create extra code for the same functionality, so I reverted the changes.

    while ((containsAt != true) && (containsDotCom != true || containsDotNet != true))
    {
        Console.WriteLine("Error, the email needs to contain a @ and either a .com or .net\nPlease enter your email again: ");
        Email = Console.ReadLine();
    }
    
    Console.WriteLine("Please enter your phone number: ");
    phoneNumber = Console.ReadLine();
    while (phoneNumber > 10 || phoneNumber < 10)
    {
        Console.WriteLine(
            
            "Phone numbers have 10 digits, please enter your phone number again: ");
        phoneNumber = Console.ReadLine();
    }
    
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
    while (optionSelection != "Exit" || optionSelection != "exit")
    {
        int firstLoop = 0;
        Console.WriteLine("You can type Add, Delete or Exit to respectively Add or Delete items from your digital grocery cart or Exit the program simulation");
        optionSelection = Console.ReadLine();

        if (optionSelection == "Delete" || optionSelection == "delete")
        {
            itemSelection = Console.ReadLine();

            while (itemSelectionMatch != true || digitalGroceryCart == 0)
            {
                itemSelectionMatch = ItemSelectionExists(itemSelection, digitalGroceryCart);

                itemSelection = wrongItemReselect(itemSelectionMatch);
            }
            if (digitalGroceryCart.Count == 0)
            {
                Console.WriteLine("Your Digital Grocery Cart is empty, you cannot delete anything.");
            } else {
                digitalGroceryCart.Remove(itemSelection);
                Console.WriteLine();
            }

            itemSelectionMatch = false;

        } else if (optionSelection == "Add" || optionSelection == "add") 
        {
            itemSelection = Console.ReadLine();
            
            while (itemSelectionMatch != true)
            {
                itemSelectionMatch = ItemSelectionExists(itemSelection, productNames);
                
                itemSelection = wrongItemReselect(itemSelectionMatch);
            }
            
            digitalGroceryCart.Add(itemSelection);
            Console.WriteLine(itemSelection + " was added to your cart.");
            
            itemSelectionMatch = false;
        } else {
            Console.WriteLine("Error. Incorrect Input. You have to write Add, Delete, or Exit.");
        }

        firstLoop++;

    }



    if (digitalGroceryCart.Count == 0)
    {
        Console.WriteLine("You did not order anything.\nThank you for using this Simulator");
    } else
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