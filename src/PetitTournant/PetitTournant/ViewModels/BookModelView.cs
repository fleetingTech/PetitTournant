using PetitTournant.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetitTournant.ViewModels
{
    public class BookModelView : BaseViewModel
    {
        public string PageTitle => Localisation.StringLocalisation.BookSelector;
        public string CreateCookBookText => Localisation.StringLocalisation.CreateCookBook;

        public BookModelView()
        {
            this.OpenBooks = new System.Collections.ObjectModel.ObservableCollection<ICookBook>();
        }
        public System.Collections.ObjectModel.ObservableCollection<ICookBook> OpenBooks { get; private set; }
        public void AddBookToList(ICookBook book)
        {
            this.OpenBooks.Add(book);
            OnPropertyChanged(nameof(OpenBooks));
        }


        private ICookBook _selectedCookBook = null;
        public ICookBook SelectedCookBook
        {
            get
            { return this._selectedCookBook; }
            set
            {
                this._selectedCookBook = value;
                OnPropertyChanged(nameof(SelectedCookBook));
            }
        }

        private int a = 0;
        public void CreateDummyBook()
        {
            a++;
            var book = new CookBook();
            book.Name = "dummy book" + a.ToString();
            book.Path = "dummy path" + a.ToString();
            book.ImagePath = "";
            this.AddBookToList(book);
        }
    }
}
