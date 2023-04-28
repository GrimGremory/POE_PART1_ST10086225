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
            Console.WriteLine("Enter recipe name");
            recipeName = Console.ReadLine();
            Console.WriteLine(
                "Please type only whole numbers as to be more specific with the recipes \nEnter the number of ingredients:");
            numOfIngredients = int.Parse(Console.ReadLine());

            ingredientNames = new string[numOfIngredients];
            ingredientQuantities = new int[numOfIngredients];
            ingredientUnits = new string[numOfIngredients];

            for (int i = 0; i < numOfIngredients; i++)
            {
                Console.WriteLine("Enter the name of ingredient {0}:", i + 1);
                ingredientNames[i] = Console.ReadLine();

                Console.WriteLine("Enter the quantity of ingredient {0}:", i + 1);
                while (!int.TryParse(Console.ReadLine(), out ingredientQuantities[i]))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number. E.G. an integer");
                }

                Console.WriteLine("Enter the unit of measurement of ingredient {0}:", i + 1);
                Console.WriteLine("1. Teaspoons \n2. Tablespoons \n3. Cups ");
                int option;
                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number. E.G. an integer");
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

            Console.WriteLine("Enter the number of steps:");
            while (!int.TryParse(Console.ReadLine(), out numOfSteps))
            {
                Console.WriteLine("Invalid input. Please enter a valid number. E.G. an integer");
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
            Console.WriteLine("Recipe Name : " + recipeName + "\n Ingredients: ");
            ConvertUnits();

            Console.WriteLine("Steps:");
            for (int i = 0; i < numOfSteps; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, steps[i]);
            }
        }

        public void PlainDisplayRecipe()
        {
            Console.WriteLine("This is the Original recipe ingredients without any conversion :");
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
            numOfIngredients = 0;
            ingredientNames = null;
            ingredientQuantities = null;
            ingredientUnits = null;
            numOfSteps = 0;
            steps = null;

            Array.Clear(ingredientNames, 0, ingredientNames.Length);
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

                        Console.WriteLine(tablespoons + "Tablespoons" + teaspoonsRemaining + "Teaspoons" +
                                          ingredientNames[i]);
                    }
                        break;
                    case "Tablespoons" when ingredientQuantities[i] >= 16:
                    {
                        int cups = (int)(ingredientQuantities[i] * tablespoonsToCups);
                        int tablespoonsRemaining = (int)((ingredientQuantities[i] - (cups * 16)));
                        Console.WriteLine(cups + "Cups" + tablespoonsRemaining + "Tablespoons" + ingredientNames[i]);
                    }
                        break;
                    case "Tablespoons" when ingredientQuantities[i] < 16:
                    {
                        int tablespoonsRemaining = (int)(ingredientQuantities[i]);
                        Console.WriteLine(tablespoonsRemaining + "Tablespoons" + ingredientNames[i]);
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
    }

    class Program
    {
        static void Main()
        {
            Recipe recipe = new Recipe();

            while (true)
            {
                Console.WriteLine(
                    "Select an option: \n 1. Enter recipe \n 2. Display recipe \n 3. Scale recipe \n 4. Reset quantities \n 5. Clear recipe \n 6. Exit");

                int option;
                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer option.");
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
                        Console.WriteLine(
                            "Enter scale factor: \n 1 : 0.5 (half) \n 2 : 2 (double) \n 3 : 3(triple) \n type only the number");

                        double factor = 0;
                        int scale;
                        while (!int.TryParse(Console.ReadLine(), out scale))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer option.");
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
                        Console.WriteLine("This is the recipe with conversions : ");
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