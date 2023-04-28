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
    }

    class Program
    {
        static void Main()
        {
        }
    }
}