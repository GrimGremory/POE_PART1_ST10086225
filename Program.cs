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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Enter recipe name");
            Console.ForegroundColor = ConsoleColor.White;
            recipeName = Console.ReadLine();
            Console.WriteLine(
                "Please type only whole numbers as to be more specific with the recipe \nEnter the number of ingredients:");
            numOfIngredients = int.Parse(Console.ReadLine());

            ingredientNames = new string[numOfIngredients];
            ingredientQuantities = new int[numOfIngredients];
            ingredientUnits = new string[numOfIngredients];

            for (int i = 0; i < numOfIngredients; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Enter the name of ingredient {0}:", i + 1);
                Console.ForegroundColor = ConsoleColor.White;
                ingredientNames[i] = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Enter the quantity of ingredient {0}:", i + 1);
                Console.ForegroundColor = ConsoleColor.White;
                while (!int.TryParse(Console.ReadLine(), out ingredientQuantities[i]))
                {
                    ErrorMessage();
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Enter the unit of measurement of ingredient {0}:", i + 1);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. Teaspoons \n2. Tablespoons \n3. Cups ");
                int option;
                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    ErrorMessage();
                }

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

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Enter the number of steps:");
            Console.ForegroundColor = ConsoleColor.White;
            while (!int.TryParse(Console.ReadLine(), out numOfSteps))
            {
                ErrorMessage();
            }

            steps = new string[numOfSteps];

            for (int i = 0; i < numOfSteps; i++)
            {
                Console.WriteLine("Enter step {0}:", i + 1);
                steps[i] = Console.ReadLine();
            }
        }

        public void DisplayRecipe()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Recipe Name : " + recipeName + "\n Ingredients: ");
            Console.ForegroundColor = ConsoleColor.White;
            ConvertUnits();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Steps:");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < numOfSteps; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, steps[i]);
            }
        }

        public void PlainDisplayRecipe()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("This is the Original recipe ingredients without any conversion :");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Recipe Name : " + recipeName + "\n Ingredients: ");
            for (int i = 0; i < numOfIngredients; i++)
            {
                Console.WriteLine("- {0} {1} {2}", ingredientQuantities[i], ingredientUnits[i], ingredientNames[i]);
            }
        }

        public void ScaleRecipe(double factor)
        {
            for (int i = 0; i < numOfIngredients; i++)
            {
                ingredientQuantities[i] = (int)Math.Round(ingredientQuantities[i] * factor);
            }

            Console.WriteLine("Recipe has been scaled accordingly \n Here is the scaled recipe.");
            ConvertUnits();
        }

        public void ResetQuantities()
        {
            for (int i = 0; i < numOfIngredients; i++)
            {
                ingredientQuantities[i] = originalQuantities[i];
                ingredientUnits[i] = originalUnits[i];
            }

            Console.WriteLine("Recipe has been reset");
        }

        public void ClearRecipe()
        {
            recipeName = "";
            numOfIngredients = 0;
            numOfSteps = 0;
            Array.Clear(ingredientNames, 0, ingredientNames.Length);
            Array.Clear(ingredientQuantities, 0, ingredientQuantities.Length);
            Array.Clear(ingredientUnits, 0, ingredientUnits.Length);
            Array.Clear(steps, 0, steps.Length);
            Console.WriteLine("Recipe has been cleared");
        }

        private int[] originalQuantities;
        private string[] originalUnits;

        public void SaveOriginalQuantities()
        {
            originalQuantities = (int[])ingredientQuantities.Clone();
            originalUnits = (string[])ingredientUnits.Clone();
        }

        public void ConvertUnits()
        {
            double teaspoonsToTablespoons = 1.0 / 3.0;
            double tablespoonsToCups = 1.0 / 16.0;
            double teaspoonsToCups = 1.0 / 48.0;

            for (int i = 0; i < numOfIngredients; i++)
            {
                switch (ingredientUnits[i])
                {
                    case "Teaspoons" when ingredientQuantities[i] >= 48:
                    {
                        int cups = (int)(ingredientQuantities[i] * teaspoonsToCups);
                        int tablespoonsRemaining =
                            (int)((ingredientQuantities[i] - (cups * 48)) * teaspoonsToTablespoons);
                        int teaspoonsRemaining =
                            (int)(((ingredientQuantities[i] - (cups * 48)) - (tablespoonsRemaining * 3)));

                        Console.WriteLine(cups + " Cups " + tablespoonsRemaining + " Tablespoons " +
                                          teaspoonsRemaining + " Teaspoons " + " of " + ingredientNames[i]);
                    }
                        break;
                    case "Teaspoons" when ingredientQuantities[i] < 48:
                    {
                        int tablespoons = (int)(ingredientQuantities[i] * teaspoonsToTablespoons);
                        int teaspoonsRemaining = (int)(ingredientQuantities[i] - (tablespoons * 3));

                        Console.WriteLine(tablespoons + " Tablespoons " + teaspoonsRemaining + " Teaspoons " +
                                          ingredientNames[i]);
                    }
                        break;
                    case "Tablespoons" when ingredientQuantities[i] >= 16:
                    {
                        int cups = (int)(ingredientQuantities[i] * tablespoonsToCups);
                        int tablespoonsRemaining = (int)((ingredientQuantities[i] - (cups * 16)));
                        Console.WriteLine(cups + " Cups " + tablespoonsRemaining + " Tablespoons " +
                                          ingredientNames[i]);
                    }
                        break;
                    case "Tablespoons" when ingredientQuantities[i] < 16:
                    {
                        int tablespoonsRemaining = (int)(ingredientQuantities[i]);
                        Console.WriteLine(tablespoonsRemaining + " Tablespoons " + ingredientNames[i]);
                    }
                        break;
                    case "Cups": // Add custom logic for handling "Cups" case here using lambda functions, if needed
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(
                "Invalid input. Please enter a valid number. E.G. an integer.\n or type a number that matches an option presented.");
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