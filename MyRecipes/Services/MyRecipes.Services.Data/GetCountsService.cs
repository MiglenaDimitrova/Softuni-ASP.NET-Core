namespace MyRecipes.Services.Data
{
    using System.Linq;

    using MyRecipes.Data.Common.Repositories;
    using MyRecipes.Data.Models;
    using MyRecipes.Web.ViewModels.Home;

    public class GetCountsService : IGetCountsService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepository;
        private readonly IRepository<Image> imageRepository;
        private readonly IDeletableEntityRepository<Recipe> recipeRepository;
        private readonly IDeletableEntityRepository<Ingredient> ingredientRepository;

        public GetCountsService(
            IDeletableEntityRepository<Category> categoryRepository,
            IRepository<Image> imageRepository,
            IDeletableEntityRepository<Recipe> recipeRepository,
            IDeletableEntityRepository<Ingredient> ingredientRepository)
        {
            this.categoryRepository = categoryRepository;
            this.imageRepository = imageRepository;
            this.recipeRepository = recipeRepository;
            this.ingredientRepository = ingredientRepository;
        }

        public IndexViewModel GetCounts()
        {
            return new IndexViewModel()
            {
                CategoryCount = this.categoryRepository.All().Count(),
                RecipesCount = this.recipeRepository.All().Count(),
                IngredientsCount = this.ingredientRepository.All().Count(),
                ImagesCount = this.imageRepository.All().Count(),
            };
        }
    }
}
