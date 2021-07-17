namespace MyRecipes.Web.ViewModels.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateRecipeInputModel
    {
        [Required(ErrorMessage = "Името трябва да бъде поне 4 символа.")]
        [MinLength(4, ErrorMessage = "Името трябва да бъде поне 4 символа.")]
        [Display(Name = "Име на рецептата:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Инструкциите трябва да бъдат най-малко 100 символа.")]
        [MinLength(100, ErrorMessage = "Инструкциите трябва да бъдат най-малко 100 символа.")]
        [Display(Name = "Инструкции:")]
        public string Instructions { get; set; }

        [Display(Name = "Време за подготовка:")]
        [Range(1, 24 * 60, ErrorMessage = "Времето за подготовка трябва да бъдe минимум 1 минута и максимум 1440 минути.")]
        public int PreparationTime { get; set; }

        [Display(Name = "Време за приготвяне:")]
        [Range(1, 24 * 60, ErrorMessage = "Времето за готвене трябва да бъдe минимум 1 минута и максимум 1440 минути.")]
        public int CookingTime { get; set; }

        [Required]
        [Display(Name = "Брой порции:")]
        [Range(1, 100, ErrorMessage = "Порциите трябва да бъдат между 1 и 100.")]
        public int PortionsCount { get; set; }

        [Display(Name = "Категория:")]
        public int CategoryId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }

        [Display(Name = "Съставки:")]
        public IEnumerable<RecipeIngredientInputModel> Ingredients { get; set; }
    }
}
