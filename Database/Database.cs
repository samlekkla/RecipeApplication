using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Database
    {
        private IMongoDatabase GetDb()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("RecipeDB"); 
            return db; //Låt oss gå till databasen
        }

        public async Task SaveRecipe(Recipe recipe) //Spara recept
        {
            await GetDb().GetCollection<Recipe>("Recipes")
                .InsertOneAsync(recipe);
        }

        public async Task<List<Recipe>> GetAllRecipes() //Hämta alla recept
        {
            var recipes = await GetDb().GetCollection<Recipe>("Recipes")
                .Find(r => true)
                .ToListAsync();

            return recipes;
        }

        public async Task<Recipe> GetRecipeById(string id) //Hämta en specifik recept
        {
            ObjectId _id = new ObjectId(id);

            var recipe = await GetDb().GetCollection<Recipe>("Recipes")
                .Find(r => r.Id == _id)
                .SingleOrDefaultAsync();

            return recipe;
        }

    }
}
