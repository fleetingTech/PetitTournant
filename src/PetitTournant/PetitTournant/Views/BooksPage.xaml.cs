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
            //ViewModel = new ViewModels.BookModelView();
		}
        //ViewModels.BooksModelView ViewModel { get => BindingContext as ViewModels.BooksModelView; set => BindingContext = value; }
       
    }
}