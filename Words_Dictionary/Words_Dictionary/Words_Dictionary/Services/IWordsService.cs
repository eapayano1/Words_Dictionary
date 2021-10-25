using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WordsDictionary.Models;

namespace WordsDictionary.Services
{
    interface IWordsService
    {
        Task<Synonym> GetInstanceAsync(string word);
        Task<Category> GetCategory(string word);
        Task<Definition> GetDefinitionAsync(string word);
    }
}
