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
	public partial class KnowledgePage : ContentPage
	{
		private KnowledgePage ()
		{
			InitializeComponent ();
		}
        private void SetBindingContext(ViewModels.KnowledgeViewModel model)
        {
            this.BindingContext = model;
        }
        public static KnowledgePage GetKitchenKnowledgePage()
        {
            KnowledgePage page = new KnowledgePage();
            page.SetBindingContext(new ViewModels.KitchenKnowledgeViewModel());
            return page;
        }
        public static KnowledgePage GetWaresKnowledgePage()
        {
            KnowledgePage page = new KnowledgePage();
            page.SetBindingContext(new ViewModels.WaresKnowledgeViewModel());
            return page;
        }
    }
}