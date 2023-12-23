using Microsoft.AspNetCore.Mvc;
using Database;

namespace RecipeApplication.Controllers
{
    public class RecipesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            Database.Database db = new Database.Database();
            List<Recipe> recipes = await db.GetAllRecipes();
            return View(recipes);
        }

        public async Task<IActionResult> Details(string id)
        {
            Database.Database db = new Database.Database();
            Recipe recipe = await db.GetRecipeById(id);
            return View(recipe);
        }
    }
}
