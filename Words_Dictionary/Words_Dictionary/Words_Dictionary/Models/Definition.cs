using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WordsDictionary.Models
{
    public class Definition
    {
        public string Word { get; set; }
        public ObservableCollection<Item> Definitions { get; set; }
    }

}