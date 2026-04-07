# Grocery Store Order Simulation (C#) Overview
This program is a digital grocery store simulation written in C#.
The user can enter input as if they were signing into a grocery store website.
The user enters fake personal information. They are presented with a list of what items they can pick from the grocery store, before they choose whether to Add or Remove items from the digital grocery cart.
Once the user is done, if they have anything in their cart it will print it to a file named SimulationShoppingList.txt, like a receipt.
## Program Features
The program asks for fake name, fake email and fake phone number. The program makes you re-enter your name if you enter an empty value or just enter spaces. It does the same for your email if it does not include the text @ and either .com or .net, and the phone number if it is not 10 digits and includes values other than digits(like letters). The program ends if any input is a null value, which can happen if something like the input stream closing happens. There is a while loop that uses two functions to make sure that the user input matches the items from the grocery store and gives you a warning message and makes you re-enter your input if it doesnt match. There is a warning message that is displayed if you do not type Add, Delete or Exit in the while loop containing them. The program does not print the results to the SimulationShoppingList.txt file if you have a empty grocery cart, instead giving you a thank you message. If you have items in your grocery cart when exiting the program it organizes them if you have multiple of one item it will display text such as (x3) if you have three of a item, etcetera. It will then print it to the file SimulationShoppingList.txt or create the file if it doesnt exist.
## Skills Demonstrated
- C# console application development
- Object-Oriented Programming
- User input validation
- Conditional logic and loops
- Debugging and troubleshooting
## Files
GroceryStoreOrder.cs
Main program logic for the grocery order simulation.
SimulationShoppingList.txt
Example input used to test the program.
TroubleShooting.txt
Notes documenting test input, bugs encountered and how they were solved.
README.md
Information and documentation of the program.
## How to Run
1. Open the solution file in Visual Studio, and if the terminal is not open type both ctrl and ` to open it.
2. Build the project by typing dotnet build inside the terminal
3. Run the console application by typing dotnet run.
## Example Output
The SimulationShoppingList.txt does not record your fake personal information, instead the inside of the SimulationShoppingList is the same as what is outputted at the end of the program: Your shopping list purchase is: Chicken (x2) Fish (x1) Oranges (x1) Strawberries (x2) Water (x1) . Thank you for using this simulator.
## Supporting Files
FormValidationProgram.csproj
FormValidationProgram.sln
TroubleShooting.txt
SimulationShoppingList.txt
