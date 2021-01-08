using PetitTournant.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PetitTournant.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BooksPage : ContentPage
	{
		public BooksPage ()
		{
			InitializeComponent ();
            ViewModel = new ViewModels.BookModelView();
		}
        ViewModels.BookModelView ViewModel { get => BindingContext as ViewModels.BookModelView; set => BindingContext = value; }

        private void CreateCookBookClicked(object sender, EventArgs e)
        {
            ViewModel.CreateDummyBook();
        }

        private void CookBookSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ICookBook current = (e.CurrentSelection.FirstOrDefault() as ICookBook);
            ViewModel.SelectedCookBook = current;
        }
    }
}