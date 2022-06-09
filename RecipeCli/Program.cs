namespace RecipeCli
{
    class Program
    {
        /*
         * Usage syntax:
         *  recipecli add <name> <description>
         *  recipecli list
         *  recipecli show <name>
         */
        static void Main(string[] args)
        {
            RecipeState state = new();
            try
            {
                ArgErrors(args, 1);
            }
            catch (System.Exception)
            {
                return;
            }
            string cmd = args[0];
            switch (cmd) {
                case "list":
                    foreach (Recipe recipe in state.List())
                    {
                        Console.WriteLine($"name: {recipe.Name}");
                    }
                    break;
                case "add":
                    try {
                        ArgErrors(args, 3);
                        state.Add(args[1], args[2]);
                        foreach (Recipe recipe in state.List())
                        {
                            Console.WriteLine($"name: {recipe.Name}");
                        }
                    }
                    catch (Exception)
                    {
                        return;
                    }
                    break;
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
    }
}