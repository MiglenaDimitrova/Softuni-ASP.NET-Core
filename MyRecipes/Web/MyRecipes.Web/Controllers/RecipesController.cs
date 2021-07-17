namespace MyRecipes.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MyRecipes.Services.Data;
    using MyRecipes.Web.ViewModels.Recipes;

    public class RecipesController : Controller
    {
        private readonly ICategoriesService categorieService;
        private readonly IRecipesService recipesService;

        public RecipesController(
            ICategoriesService categorieService,
            IRecipesService recipesService)
        {
            this.categorieService = categorieService;
            this.recipesService = recipesService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateRecipeInputModel
            {
                CategoriesItems = this.categorieService.GetAllKeyValuePairs(),
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRecipeInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                var viewModel = new CreateRecipeInputModel
                {
                    CategoriesItems = this.categorieService.GetAllKeyValuePairs(),
                };
                return this.View(viewModel);
            }

            await this.recipesService.AddRecipeAsync(input);

            // Redirect to recipe
            return this.Redirect("/");
        }
    }
}
