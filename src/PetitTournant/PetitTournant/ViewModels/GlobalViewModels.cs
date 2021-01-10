using System;
using System.Collections.Generic;
using System.Text;

namespace PetitTournant.ViewModels
{
	public class GlobalViewModels:BaseViewModel
	{
		public System.Collections.ObjectModel.ObservableCollection<BookModelView> OpenBooks { get; } = new System.Collections.ObjectModel.ObservableCollection<BookModelView>();
		private GlobalViewModels() { }
		public static GlobalViewModels Instance { get; } = new GlobalViewModels();

		internal PetitTournant.Core.PetitTournantLib Library { get; } = new Core.PetitTournantLib();

	}
}
