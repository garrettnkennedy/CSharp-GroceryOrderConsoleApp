# Grocery Store Order Simulation (C#) Overview
This program is a digital grocery store simulation written in C#.
The user can enter input as if they were signing into a grocery store website.
The user enters fake personal information. They are presented with a list of what items they can pick from the grocery store, before they choose whether to Add or Remove items from the digital grocery cart.
Once the user is done, if they have anything in their cart it will print it to a file named SimulationShoppingList.txt, like a receipt.
## Program Features
The program asks for fake name, fake email and fake phone number. The program makes you re-enter your email if it does not include the text @ and either .com or .net, it also does this for the phone number which has to be both 10 digits and only be made up of digits. The program ends if any input is a null value


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
