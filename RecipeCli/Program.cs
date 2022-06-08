namespace RecipeCli
{
    class Program
    {
        /*
         * Usage:
         *  recipecli add <name> <description>
         *  recipecli list
         *  recipecli show <name>
         */
        static void Main(string[] args)
        {
            bool run = true;
            Console.WriteLine("Hello, world!");
            Console.WriteLine("Press the Escape key to end the program...");
            while (run)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                var key = consoleKeyInfo.Key;

                if (key == ConsoleKey.Escape)
                {
                    run = false;
                }
            }
        }
    }
}