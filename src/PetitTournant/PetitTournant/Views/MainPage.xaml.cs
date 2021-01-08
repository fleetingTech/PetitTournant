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
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            Children.Add(new RecipesPage());
            Children.Add(KnowledgePage.GetKitchenKnowledgePage());
            Children.Add(KnowledgePage.GetWaresKnowledgePage());
            Children.Add(new BooksPage());
        }
    }
}