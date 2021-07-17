namespace MyRecipes.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using MyRecipes.Data;
    using MyRecipes.Data.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class RecipeApiController : BaseController
    {
        private readonly ApplicationDbContext db;

        public RecipeApiController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<Recipe> GetAll()
        {
            return this.db.Recipes.ToList();
        }

        [HttpDelete]
        public ActionResult<string> TestDelete()
        {
            return "Deleted!";
        }

        // if we have id:
        // [HttpPost("{id}")] - from QueryString
        // /api/recipeApi/{id}
        [HttpPost]
        public string TestPost()
        {
            return "Posted";
        }
    }
}
