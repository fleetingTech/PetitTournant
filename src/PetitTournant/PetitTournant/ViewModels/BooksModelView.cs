using PetitTournant.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetitTournant.ViewModels
{
    public class BooksModelView : BaseViewModel
    {
        public string PageTitle => Localisation.StringLocalisation.BookSelector;
        public string CreateCookBookText => Localisation.StringLocalisation.CreateCookBook;

        public ICommand CreateCookBookCommand { get; private set; }
        public ICommand EditCookBookCommand { get; private set; }
        public ICommand SubmitCoockBookCommand { private set; get; }
        public ICommand CancelCoockBookCommand { private set; get; }
        public ICommand CookBookSelectionChangedCommand { get; private set; } 

        public BookModelView CookBookEditView { get; private set; }

        private bool _isEditing;
        public bool IsEditing
        {
            private set
            {
                this._isEditing = value;
                OnPropertyChanged(nameof(IsEditing));
                this.IsEditVisible = value;
            }
            get { return _isEditing; }
        }
        private bool _isEditVisible;
        public bool IsEditVisible
        {
            private set { this._isEditVisible = value; OnPropertyChanged(nameof(IsEditVisible)); }
            get { return this._isEditVisible; }
        }

        private PetitTournantLib Lib; 

        public BooksModelView()
        {
            this.Lib = new PetitTournantLib();

            this.IsEditing = false;
            this.CreateCookBookCommand = this.NewCreateCookBookCommand();
            this.EditCookBookCommand = this.NewEditCookBookCommand();
            this.SubmitCoockBookCommand = this.NewSubmitCookBookCommand();
            this.CancelCoockBookCommand = this.NewCancelCommand();
        }
        public System.Collections.ObjectModel.ObservableCollection<BookModelView> OpenBooks { get; } = new System.Collections.ObjectModel.ObservableCollection<BookModelView>();

        private BookModelView _selectedCookBook = null;
        public BookModelView SelectedCookBook
        {
            get
            { return this._selectedCookBook; }
            set
            {
                this._selectedCookBook = value;
                this.IsCookBookSelected = true;
                OnPropertyChanged(nameof(SelectedCookBook));
            }
        }
        private bool _isCookBookSelected;
        public bool IsCookBookSelected
        {
            private set
            {
                this._isCookBookSelected = value;
                OnPropertyChanged(nameof(IsCookBookSelected));
            }
            get { return _isCookBookSelected; }
        }

        private Command NewCreateCookBookCommand()
        {
            return new Command(
               execute: () =>
               {
                   this.CookBookEditView = new BookModelView(this.Lib.GetEmptyCookBook());
                   this.CookBookEditView.PropertyChanged += OnBookEditPorpertyChanged;
                   IsEditing = true;
                   RefreshCanExecutes();
               },
            canExecute: () =>
            {
                return true;
            });
        }
        private Command NewEditCookBookCommand()
        {
            return new Command(
               execute: () =>
               {
                   this.CookBookEditView = this.SelectedCookBook;
                   this.CookBookEditView.PropertyChanged += OnBookEditPorpertyChanged;
                   IsEditing = true;
                   OnPropertyChanged(nameof(CookBookEditView));
                   RefreshCanExecutes();
               },
            canExecute: () =>
            {
                return true;
            });
        }
        private Command NewSubmitCookBookCommand()
        {
            return new Command(
            execute: () =>
            {
                if(this.OpenBooks.Contains(this.CookBookEditView) == false)
                {
                    this.OpenBooks.Add(this.CookBookEditView);
                }

                this.DestroyBookEditView();
                this.RefreshCanExecutes();
            },
            canExecute: () =>
            {
                bool? isValidBook = this.CookBookEditView?.IsValidBook;
                return isValidBook.HasValue ? isValidBook.Value : false;
            });
        }
        private Command NewCancelCommand()
        {
            return new Command(
            execute: () =>
            {
                this.DestroyBookEditView();
                this.RefreshCanExecutes();
            },
            canExecute: () =>
            {
                return IsEditing;
            });
        }

        private void DestroyBookEditView()
        {
            this.CookBookEditView.PropertyChanged -= OnBookEditPorpertyChanged;
            this.CookBookEditView = null;
            OnPropertyChanged(nameof(CookBookEditView));
            IsEditing = false;
            RefreshCanExecutes();
        }
        void OnBookEditPorpertyChanged(object sender, PropertyChangedEventArgs args)
        {
            (this.SubmitCoockBookCommand as Command).ChangeCanExecute();
        }

        void RefreshCanExecutes()
        {
            (this.CreateCookBookCommand as Command).ChangeCanExecute();
            (this.EditCookBookCommand as Command).ChangeCanExecute();
            (this.SubmitCoockBookCommand as Command).ChangeCanExecute();
            (this.CancelCoockBookCommand as Command).ChangeCanExecute();
        }

    }
}
