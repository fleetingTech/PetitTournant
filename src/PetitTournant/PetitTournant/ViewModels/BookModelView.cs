using PetitTournant.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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

        private PetitTournantLib Lib; 

        public BookModelView()
        {
            this.OpenBooks = new System.Collections.ObjectModel.ObservableCollection<ICookBook>();
            this.Lib = new PetitTournantLib();
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
            var book = this.Lib.CreateCookBook("test" + a.ToString(),CultureInfo.CurrentCulture, "path" + a.ToString());
            this.OpenBooks.Add(book);            
        }
    }
}
