using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WordsDictionary.Models;
using WordsDictionary.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WordsDictionary.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        public ICommand GetWordCommand { get; set; }

        private IPageDialogService _dialogService;

        public string Word { get; set; }

        public string Category { get; set; }

        Category wordCategories = new Category();

        public CategoryViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            GetWordCommand = new Command(async () => await GetCategory());

            _dialogService = pageDialogService;
        }

        public async Task GetCategory()
        {
            WordsService wordCategoryApi = new WordsService(Config.ApiKey);

           
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                wordCategories = await wordCategoryApi.GetCategory(Word);

                Category = wordCategories.Categories[0];

                await _dialogService.DisplayAlertAsync(Messages.Category, $"This word belongs to the category: {Category}", Messages.OkOption);

            }
            else
            {
                await _dialogService.DisplayAlertAsync($"{Messages.NoConnection}", $"{Messages.NoConnectionMessage}", $"{Messages.OkOption}");
            }
        }
        
    }
}
