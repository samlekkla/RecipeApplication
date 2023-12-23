// See https://aka.ms/new-console-template for more information
using Database;
using MongoDB.Bson.IO;

Console.WriteLine("Welcome to Recipe Admin");

Console.WriteLine("Create recipe");

Console.Write("Name: ");
string name = Console.ReadLine();

Console.Write("Summary: ");
string summary = Console.ReadLine();

Console.Write("Description: ");
string description = Console.ReadLine();

Console.Write("Image Path: ");
string imagePath = Console.ReadLine();  


Recipe newRecipe = new Recipe() //Skapa ett recept
{ Name = name, Summary = summary, Description = description, ImagePath = imagePath };

Database.Database db = new Database.Database();

await db.SaveRecipe(newRecipe);

var recipes = await db.GetAllRecipes();

foreach (var recipe in recipes)
{
    Console.WriteLine(recipe.Name);
}