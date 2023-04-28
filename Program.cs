namespace ConsoleApp1
{
    class Recipe
    {
        private int numOfIngredients;
        private string[] ingredientNames;
        private int[] ingredientQuantities;
        private string[] ingredientUnits;
        private int numOfSteps;
        private string[] steps;
        private string recipeName;

        public void EnterRecipe()
        {
            // Set console text color to blue
            Console.ForegroundColor = ConsoleColor.Blue;
            // Prompt user to enter recipe name
            Console.WriteLine("Enter recipe name");

            // Set console text color to white
            Console.ForegroundColor = ConsoleColor.White;
            // Read recipe name from user input and assign to recipeName variable
            recipeName = Console.ReadLine();

            // Prompt user to enter the number of ingredients and specify to only use whole numbers
            Console.WriteLine(
                "Please type only whole numbers as to be more specific with the recipe \nEnter the number of ingredients:");

            // Parse number of ingredients from user input and assign to numOfIngredients variable
            numOfIngredients = int.Parse(Console.ReadLine());

            // Initialize ingredientNames, ingredientQuantities, and ingredientUnits arrays with length of numOfIngredients
            ingredientNames = new string[numOfIngredients];
            ingredientQuantities = new int[numOfIngredients];
            ingredientUnits = new string[numOfIngredients];

            // Loop through each ingredient and prompt user to enter name, quantity, and unit of measurement
            for (int i = 0; i < numOfIngredients; i++)
            {
                // Set console text color to blue and prompt user to enter name of current ingredient
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Enter the name of ingredient {0}:", i + 1);
                // Set console text color to white and read ingredient name from user input and assign to ingredientNames array
                Console.ForegroundColor = ConsoleColor.White;
                ingredientNames[i] = Console.ReadLine();
                // Set console text color to blue and prompt user to enter quantity of current ingredient
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Enter the quantity of ingredient {0}:", i + 1);
                // Set console text color to white and loop until user enters a valid integer for quantity and assign to ingredientQuantities array
                while (!int.TryParse(Console.ReadLine(), out ingredientQuantities[i]))
                {
                    ErrorMessage(); // method call for displaying error message
                }

                // Set console text color to blue and prompt user to enter unit of measurement for current ingredient
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Enter the unit of measurement of ingredient {0}:", i + 1);
                // Set console text color to white and prompt user to choose a unit of measurement option from a list
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. Teaspoons \n2. Tablespoons \n3. Cups ");
                // Loop until user enters a valid integer for option and assign to option variable
                int option;
                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    ErrorMessage(); // method call for displaying error message
                }

                // Assign unit of measurement based on option selected by user to ingredientUnits array
                switch (option)
                {
                    case 1:
                        ingredientUnits[i] = "Teaspoons";
                        break;
                    case 2:
                        ingredientUnits[i] = "Tablespoons";
                        break;
                    case 3:
                        ingredientUnits[i] = "Cups";
                        break;
                }
            }

            // Set console text color to blue and prompt user to enter number of steps
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Enter the number of steps:");
            // Set console text color to white and loop until user enters a valid integer for number of steps and assign to numOfSteps variable
            Console.ForegroundColor = ConsoleColor.White;
            while (!int.TryParse(Console.ReadLine(), out numOfSteps))
            {
                ErrorMessage(); // method call for displaying error message
            }

            // Initialize steps array with length of numOfSteps
            steps = new string[numOfSteps];
            // Loop through each step and prompt user to enter
            for (int i = 0; i < numOfSteps; i++)
            {
                Console.WriteLine("Enter step {0}:", i + 1);
                steps[i] = Console.ReadLine();
            }
        }

        /*
        Displays the recipe with the recipe name, list of ingredients, and the steps required to make the recipe.
        The units of measurement for the ingredients are also converted to a more common unit.
        */
        public void DisplayRecipe()
        {
            // Set console text color to blue and display the recipe name and list of ingredients
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Recipe Name : " + recipeName + "\n Ingredients: ");

            // Set console text color to white and convert ingredient units of measurement
            Console.ForegroundColor = ConsoleColor.White;
            ConvertUnits();

            // Set console text color to green and display the list of steps required to make the recipe
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Steps:");

            // Set console text color to white and display each step one at a time
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < numOfSteps; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, steps[i]);
            }
        }

        // A method to display the original recipe ingredients without any unit conversion
        public void PlainDisplayRecipe()
        {
            // Set the console color to blue and display the message
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("This is the Original recipe ingredients without any conversion :");
            // Set the console color to white and display the recipe name and ingredients
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Recipe Name : " + recipeName + "\n Ingredients: ");
            // Loop through each ingredient and display the quantity, unit, and name
            for (int i = 0; i < numOfIngredients; i++)
            {
                Console.WriteLine("- {0} {1} {2}", ingredientQuantities[i], ingredientUnits[i], ingredientNames[i]);
            }
        }

        public void ScaleRecipe(double factor)
        {
            // Loop through each ingredient and scale its quantity according to the factor provided
            for (int i = 0; i < numOfIngredients; i++)
            {
                ingredientQuantities[i] = (int)Math.Round(ingredientQuantities[i] * factor);
            }
            // Print a message indicating that the recipe has been scaled and display the scaled recipe
            Console.WriteLine("Recipe has been scaled accordingly \n Here is the scaled recipe.");

            // Convert the units of the ingredients and display the recipe with the new units
            ConvertUnits();
        }


        // This method resets the quantities and units of the ingredients to their original values
        public void ResetQuantities()
        {
            // loop through all ingredients and reset their quantities and units
            for (int i = 0; i < numOfIngredients; i++)
            {
                ingredientQuantities[i] = originalQuantities[i];
                ingredientUnits[i] = originalUnits[i];
            } // print message to indicate that recipe has been reset
            Console.WriteLine("Recipe has been reset");
        }

        public void ClearRecipe()
        {
            // reset recipeName, numOfIngredients, and numOfSteps to their initial state
            recipeName = "";
            numOfIngredients = 0;
            numOfSteps = 0;
    
            // clear all the elements of ingredientNames, ingredientQuantities, ingredientUnits, and steps arrays
            Array.Clear(ingredientNames, 0, ingredientNames.Length);
            Array.Clear(ingredientQuantities, 0, ingredientQuantities.Length);
            Array.Clear(ingredientUnits, 0, ingredientUnits.Length);
            Array.Clear(steps, 0, steps.Length);
    
            // print out a message indicating that the recipe has been cleared
            Console.WriteLine("Recipe has been cleared");
        }


        // This creates two private fields to store the original quantities and units of ingredients.
        private int[] originalQuantities;
        private string[] originalUnits;

        // This method saves the original quantities and units of ingredients into the private fields above.
        public void SaveOriginalQuantities()
        {
            // It does this by using the Clone method to create a copy of the ingredientQuantities and ingredientUnits arrays,
            // and then assigning the copies to the private fields.
            originalQuantities = (int[])ingredientQuantities.Clone();
            originalUnits = (string[])ingredientUnits.Clone();
        }

        public void ConvertUnits()
        {   // The below variables are used to store the conversion amounts
            double teaspoonsToTablespoons = 1.0 / 3.0;
            double tablespoonsToCups = 1.0 / 16.0;
            double teaspoonsToCups = 1.0 / 48.0;
            //for loop is used to loop through the ingredientQuantities so that all amounts stored are converted if need be
            for (int i = 0; i < numOfIngredients; i++)
            {   //switch statement is used to convert different measurements
                switch (ingredientUnits[i])
                {   // 48 teaspoons makes a cup so it checks if teaspoons is more than a cup
                    case "Teaspoons" when ingredientQuantities[i] >= 48:
                    {    //converts teaspoons directly into cups
                        int cups = (int)(ingredientQuantities[i] * teaspoonsToCups);
                        //converts to teaspoons first then at the end converts to table spoons
                        int tablespoonsRemaining =
                            (int)((ingredientQuantities[i] - (cups * 48)) * teaspoonsToTablespoons); 
                        //converts cups and tablespoonsRemaining to teaspoons and minus to get remainder teaspoons
                        int teaspoonsRemaining =
                            (int)(((ingredientQuantities[i] - (cups * 48)) - (tablespoonsRemaining * 3)));
                        //Outputs all the units that  have been converted and gives the remainder
                        Console.WriteLine(cups + " Cups " + tablespoonsRemaining + " Tablespoons " +
                                          teaspoonsRemaining + " Teaspoons " + " of " + ingredientNames[i]);
                    }
                        break;
                    // 48 teaspoons makes a cup so it checks if teaspoons is less than a cup
                    case "Teaspoons" when ingredientQuantities[i] < 48:
                    {   //converts teaspoons directly into tablespoons
                        int tablespoons = (int)(ingredientQuantities[i] * teaspoonsToTablespoons);
                        //converts tablespoons to teaspoons and minuses the two to get remainder of teaspoons
                        int teaspoonsRemaining = (int)(ingredientQuantities[i] - (tablespoons * 3));
                        //Outputs to the console with the converted measurements
                        Console.WriteLine(tablespoons + " Tablespoons " + teaspoonsRemaining + " Teaspoons " +
                                          ingredientNames[i]);
                    }
                        break;
                    // 16 tablespoons are in a cup so a check is made to see if there are enough tablespoons to make a cup
                    case "Tablespoons" when ingredientQuantities[i] >= 16:
                    {
                        int cups = (int)(ingredientQuantities[i] * tablespoonsToCups);
                        int tablespoonsRemaining = (int)((ingredientQuantities[i] - (cups * 16)));
                        Console.WriteLine(cups + " Cups " + tablespoonsRemaining + " Tablespoons " +
                                          ingredientNames[i]);
                    }
                        break;
                    // 16 tablespoons are in a cup so a check is made to see if there are not enough tablespoons to make a cup
                    case "Tablespoons" when ingredientQuantities[i] < 16:
                    {
                        int tablespoonsRemaining = (int)(ingredientQuantities[i]);
                        Console.WriteLine(tablespoonsRemaining + " Tablespoons " + ingredientNames[i]);
                    }
                        break;
                    case "Cups": // No conversion is needed as cups is the highest measurement available
                        break;
                    default: // Handle invalid units here
                        Console.WriteLine("Invalid unit of measurement for ingredient {0}: {1}", ingredientNames[i],
                            ingredientUnits[i]);
                        break;
                }
            }
        }

        public static void ErrorMessage()
        {
            // Set console foreground color to red
            Console.ForegroundColor = ConsoleColor.Red;
            // Print the error message
            Console.WriteLine(
                "Invalid input. Please enter a valid number. E.G. an integer.\n or type a number that matches an option presented.");
            // Set console foreground color back to white
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    class Program
    {
        static void Main()
        {
            Recipe recipe = new Recipe();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(
                    "Select an option: \n 1. Enter recipe \n 2. Display recipe \n 3. Scale recipe \n 4. Reset quantities \n 5. Clear recipe \n 6. Exit");
                Console.ForegroundColor = ConsoleColor.White;
                int option;
                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Recipe.ErrorMessage();
                }

                switch (option)
                {
                    case 1:
                        recipe.EnterRecipe();
                        recipe.SaveOriginalQuantities();
                        break;
                    case 2:
                        recipe.DisplayRecipe();
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(
                            "Enter scale factor: \n 1 : 0.5 (half) \n 2 : 2 (double) \n 3 : 3(triple) \n type only the number");
                        Console.ForegroundColor = ConsoleColor.White;
                        double factor = 0;
                        int scale;
                        while (!int.TryParse(Console.ReadLine(), out scale))
                        {
                            Recipe.ErrorMessage();
                        }

                        switch (scale)
                        {
                            case 1:
                                factor = 0.5;
                                break;
                            case 2:
                                factor = 2;
                                break;
                            case 3:
                                factor = 3;
                                break;
                            default:
                                Console.WriteLine("Invalid option");
                                break;
                        }

                        recipe.ScaleRecipe(factor);
                        recipe.DisplayRecipe();
                        break;
                    case 4:
                        recipe.ResetQuantities();
                        recipe.PlainDisplayRecipe();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("This is the recipe with conversions : ");
                        Console.ForegroundColor = ConsoleColor.White;
                        recipe.DisplayRecipe();
                        break;
                    case 5:
                        recipe.ClearRecipe();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }
}