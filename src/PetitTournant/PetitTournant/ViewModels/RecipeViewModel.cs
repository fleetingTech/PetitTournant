using System;
using System.Collections.Generic;
using System.Text;
using PetitTournant.Core;

namespace PetitTournant.ViewModels
{
	class RecipeViewModel:BaseViewModel
	{
		IRecipe recipe;

		public RecipeViewModel(IRecipe recipeName) { this.recipe = recipeName; }

		public string recipeName
		{
			get { return this.recipe.Name; }
			set
			{
				this.recipe.Name = value;
				OnPropertyChanged(nameof(recipeName));
			}
		}

		public bool IsValidRecipe { get; internal set; }
	}
}
