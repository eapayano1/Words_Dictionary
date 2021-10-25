using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using WordsDictionary.Models;
using WordsDictionary.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WordsDictionary.ViewModels
{
    public class SynonymsViewModel : BaseViewModel
    {
        public string Word { get; set; }
        public ICommand InstanceCommand { get; set; }

        private IPageDialogService _dialogService;

        Synonym synonym = new Synonym();
       
        public SynonymsViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            InstanceCommand = new Command(OnInstanceCommand);

            _dialogService = pageDialogService;

        }

        public async void OnInstanceCommand()
        {
            WordsService instanceApiService = new WordsService(Config.ApiKey);

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                synonym = await instanceApiService.GetInstanceAsync(Word);

                await _dialogService.DisplayAlertAsync(Messages.Synonym, $"{synonym.Synonyms[0]}", Messages.OkOption);    

            }
            else 
            {
                await _dialogService.DisplayAlertAsync($"{Messages.NoConnection}", $"{Messages.NoConnectionMessage}", $"{Messages.OkOption}");
            }
        }
    }
}
