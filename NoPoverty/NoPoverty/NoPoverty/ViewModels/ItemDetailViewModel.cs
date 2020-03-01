using NoPoverty.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoPoverty.ViewModels
{
    class ItemDetailViewModel
    {   
        public Books Book { get; set;  }
        public Stationery stat { get; set; }
        public ItemDetailViewModel(Books book = null)
        {
            
            Book = book;
        }

    }
}
