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
                string jsonBody = System.Text.Encoding.UTF8.GetString(Storage.Load("recipes"));
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
                recipes = List();
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

        public Recipe GetByName(string name) {
            recipes = List();
            foreach (Recipe recipe in recipes) 
            {
                if (recipe.Name == name)
                {
                    return recipe;
                }
            }
            throw new ExceptionRecipeNotFound($"recipe not found by name {name}");
        }
        public List<Recipe> DeleteByName(string name)
        {
            recipes = List();
            foreach (Recipe recipe in recipes)
            {
                if (recipe.Name == name)
                {
                    recipes.Remove(recipe);
                    string jsonBody = System.Text.Json.JsonSerializer.Serialize<List<Recipe>>(recipes);
                    Storage.Save("recipes", System.Text.Encoding.ASCII.GetBytes(jsonBody));
                    return recipes;
                }
            }
            throw new ExceptionRecipeNotFound($"recipe not found by name {name}");
        }
    }

    [Serializable]
    public class ExceptionRecipeNotFound : Exception
    {
        public ExceptionRecipeNotFound() : base() { }
        public ExceptionRecipeNotFound(string message) : base(message) { }
        public ExceptionRecipeNotFound(string message, Exception innerException) : base(message, innerException) { }
        protected ExceptionRecipeNotFound(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
