    using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using WordsDictionary.Services;
using WordsDictionary.ViewModels;
using WordsDictionary.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WordsDictionary
{
    public partial class App : PrismApplication
    {

        public App(IPlatformInitializer platformInitializer = null) : base(platformInitializer) { }
        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync($"{Config.HomePage}");
      
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IWordsService, WordsService>();
            containerRegistry.RegisterForNavigation<NavigationPage>(Config.NavigationPage);
            containerRegistry.RegisterForNavigation<HomePage>(Config.HomePage);
            containerRegistry.RegisterForNavigation<SearchPage>(Config.SearchPage);
            containerRegistry.RegisterForNavigation<SynonymsPage>(Config.SynonymsPage);
            containerRegistry.RegisterForNavigation<CategoryPage>(Config.CategoryPage);
            containerRegistry.RegisterForNavigation<SearchPage, SearchViewModel>();
            containerRegistry.RegisterForNavigation<SynonymsPage, SynonymsViewModel>();
            containerRegistry.RegisterForNavigation<CategoryPage, CategoryViewModel>();
            
            
        }
    }
}
