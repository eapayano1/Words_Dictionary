using System;
using System.Collections.Generic;
using System.Text;

namespace Words_Dictionary.Models
{
    public class Item
    {
        public Item(string definition, string partofspeech)
        {
            Definition = definition;

            PartOfSpeech = partofspeech;
        }
        public string Definition { get; set; }

        public string PartOfSpeech { get; set; }

    }
}