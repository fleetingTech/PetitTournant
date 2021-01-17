using PetitTournant.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetitTournant.ViewModels
{
    public class BookModelView : BaseViewModel
    {
        public ICookBook Book { get; private set; }
        public bool IsValidBook { get { return this.ValidateBook(); } }

        public BookModelView(ICookBook toEdit)
        {
            this.Book = toEdit;
        }

        public string _bookName;
        public string BookName
        {
            get
            { return this.Book.Name; }
            set
            {
                this.Book.Name = value;
                OnPropertyChanged(nameof(BookName));
            }
        }


        public string BookPath
        {
            get
            { return this.Book.Path; }
            set
            {
                this.Book.Path = value;
                OnPropertyChanged(nameof(BookPath));
            }
        }

        private bool ValidateBook()
        {
            if(this.Book.Name.Length > 0 && this.Book.Path.Length > 0)
            {
                return true;
            }
            return false;
        }
    }
}
