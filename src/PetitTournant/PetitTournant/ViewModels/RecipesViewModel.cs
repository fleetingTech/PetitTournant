using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using PetitTournant.Core;
using Xamarin.Forms;

namespace PetitTournant.ViewModels
{
	class RecipesViewModel : BaseViewModel
	{
		public string PageTitle => Localisation.StringLocalisation.RecipesName;

		public ICookBook selectedBook { get; set; }
		public RecipeViewModel RecipeEditView { get; set; }

		public GlobalViewModels GVM { get; } = GlobalViewModels.Instance;

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

		public System.Collections.ObjectModel.ObservableCollection<RecipeViewModel> OpenRecipes { get; private set; }
		public RecipesViewModel()
		{
			this.OpenRecipes = new System.Collections.ObjectModel.ObservableCollection<RecipeViewModel>();
			var lib = new PetitTournant.Core.PetitTournantLib();
			this.AddNewRecipeToSelectedBook = this.NewAddNewRecipeToSelectedBook();
			this.SubmitRecipeCommand = this.NewSubmitRecipeCommand();
		}
		void OnRecipeEditPorpertyChanged(object sender, PropertyChangedEventArgs args)
		{
			(this.SubmitRecipeCommand as Command).ChangeCanExecute();
		}

		void RefreshCanExecutes()
		{
			(this.AddNewRecipeToSelectedBook as Command).ChangeCanExecute();
			//(this.EditCookBookCommand as Command).ChangeCanExecute();
			(this.SubmitRecipeCommand as Command).ChangeCanExecute();
			//(this.CancelCoockBookCommand as Command).ChangeCanExecute();
		}
		public ICommand AddNewRecipeToSelectedBook { get; private set; }
		public ICommand SubmitRecipeCommand { get; private set; }


		private Command NewAddNewRecipeToSelectedBook()
		{
			return new Command(
			   execute: () =>
			   {
				   this.RecipeEditView = new RecipeViewModel(this.GVM.Library.getRecipe());
				   this.RecipeEditView.PropertyChanged += OnRecipeEditPorpertyChanged;
				   IsEditing = true;
				   RefreshCanExecutes();
			   },
			canExecute: () =>
			{
				return true;
			});
		}

		private Command NewSubmitRecipeCommand()
		{
			return new Command(
			execute: () =>
			{
				if (this.OpenRecipes.Contains(this.RecipeEditView) == false)
				{
					this.OpenRecipes.Add(this.RecipeEditView);
				}

				this.DestroyRecipeEditView();
				this.RefreshCanExecutes();
			},
			canExecute: () =>
			{
				bool? isValidBook = this.RecipeEditView?.IsValidRecipe;
				return isValidBook.HasValue ? isValidBook.Value : false;
			});
		}

		private void DestroyRecipeEditView()
		{
			this.RecipeEditView.PropertyChanged -= OnRecipeEditPorpertyChanged;
			this.RecipeEditView = null;
			OnPropertyChanged(nameof(RecipeEditView));
			IsEditing = false;
			RefreshCanExecutes();
		}

	}

}
