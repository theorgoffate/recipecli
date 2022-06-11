using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeCli
{
    internal class Recipe
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Recipe(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }

    internal class RecipeState
    {
        private List<Recipe> recipes = new();

        public List<Recipe> List()
        {
            try {
                string jsonBody = Storage.Load("recipes").ToString();
                recipes = System.Text.Json.JsonSerializer.Deserialize<List<Recipe>>(jsonBody);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return recipes;
        }

        public List<Recipe> Add(string name, string description)
        {
            try
            {
                recipes.Add(new Recipe(name, description));
                string jsonBody = System.Text.Json.JsonSerializer.Serialize<List<Recipe>>(recipes);
                Storage.Save("recipes", System.Text.Encoding.ASCII.GetBytes(jsonBody));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return recipes;
        }
    }
}
