using System;
using System.Collections.ObjectModel;
using Coffee.Mobile.Models;

namespace Coffee.Mobile.ViewModels
{
    public class MethodViewModel
    {
        private readonly Method m_method;

        public MethodViewModel(Method method, Func<Recipe, RecipeViewModel> recipeViewModelFactory)
        {
            m_method = method;
            foreach (var recipe in m_method.Recipes)
            {
                Recipes.Add(recipeViewModelFactory.Invoke(recipe));
            }
        }

        public string Name => m_method.Name;

        public string Img => m_method.Img;

        public ObservableCollection<RecipeViewModel> Recipes { get; } = new ObservableCollection<RecipeViewModel>();
    }

    public class RecipeViewModel
    {
        private Recipe m_recipe;

        public RecipeViewModel(Recipe recipe)
        {
            m_recipe = recipe;
        }

        public string Name => m_recipe.Name;

        public string Introduction => m_recipe.Introduction;

        public string Grind => m_recipe.Grind;

        public long Coffee =>  m_recipe.Coffee;

        public long Water => m_recipe.Water;

        public long Bloom => m_recipe.Bloom;

        public string Instructions => m_recipe.Instructions;

        public string Note => m_recipe.Note;
    }
}
