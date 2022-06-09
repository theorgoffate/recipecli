using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return recipes;
        }

        public List<Recipe> Add(string name, string description)
        {
            recipes.Add(new Recipe(name, description));
            return recipes;
        }
    }
}
