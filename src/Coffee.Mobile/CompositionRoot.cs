using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Coffee.Mobile.Models;
using Coffee.Mobile.Services;
using Coffee.Mobile.Services.Abstractions;
using Coffee.Mobile.ViewModels;
using LightInject;

namespace Coffee.Mobile
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.RegisterViews();
            serviceRegistry.RegisterServices();
            serviceRegistry.RegisterViewModels();
        }
    }

    public static class ServiceRegistryExtensions
    {
        public static void RegisterViews(this IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<MainPage>();
        }

        public static void RegisterViewModels(this IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<Method, MethodViewModel>((factory, method) => new MethodViewModel(method, factory.GetInstance<Func<Recipe, RecipeViewModel>>()));
            serviceRegistry.Register<Recipe, RecipeViewModel>((factory, recipe) => new RecipeViewModel(recipe));
            serviceRegistry.Register<MainViewModel>();
        }


        public static void RegisterServices(this IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<ICoffeeService, CoffeeService>();
        }

    }
}
