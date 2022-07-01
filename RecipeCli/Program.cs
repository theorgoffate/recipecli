namespace RecipeCli
{
    class Program
    {
        /*
         * Usage syntax:
         *  recipecli add <name> <description>
         *  recipecli list
         *  recipecli getByName <name>
         *  recipecli delByName <name>
         */
        static void Main(string[] args)
        {
            RecipeState state = new();
            try
            {
                ArgErrors(args, 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            string cmd = args[0];
            switch (cmd) {
                case "list":
                    DisplayRecipes(state.List());
                    break;
                case "add":
                    try {
                        ArgErrors(args, 3);
                        state.Add(
                            args[1],
                            description: String.Join(" ", args[2..args.Length])
                            );
                        DisplayRecipes(state.List());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                    break;
                case "getByName":
                    try
                    {
                        ArgErrors(args, 2);
                        try
                        {
                            Recipe recipe = state.GetByName(args[1]);
                            Console.WriteLine($"name: {recipe.Name}, description: {recipe.Description}");
                            return;
                        }
                        catch (ExceptionRecipeNotFound ex)
                        {
                            Console.WriteLine(ex.Message);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                case "delByName":
                    try
                    {
                        ArgErrors(args, 2);
                        try
                        {
                            state.DeleteByName(args[1]);
                            DisplayRecipes(state.List());
                            return;
                        }
                        catch (ExceptionRecipeNotFound ex)
                        {
                            Console.WriteLine(ex.Message);
                            return;
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                default:
                    Console.WriteLine("No command sent");
                    break;
            }
        }

        static void ArgErrors(string[] args, int length)
        {
            if (args.Length < length)
            {
                Console.WriteLine($"Not enough arguments sent: {args}");
                throw new Exception("MissingArguments");
            }
            return;
        }
        static void DisplayRecipes(List<Recipe> recipes)
        {
            foreach (Recipe recipe in recipes)
            {
                Console.WriteLine($"name: {recipe.Name}, description: {recipe.Description}");
            }
        }
    }
}