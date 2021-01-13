using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using PetitTournant.Lib;

namespace PetitTournant.ViewModels
{
    class RecipeViewModel : BaseViewModel
    {
        public IRecipe Recipe { get { return this.UpdateRecipe(); } }

        private IRecipe recipe;
        GlobalViewModels GVM { get; set; }
        public RecipeViewModel(GlobalViewModels gvm) 
        { 
            this.GVM = gvm;
            this.InitFieldsFromRecipe(this.GVM.Library.GetEmptyRecipe());
        }
        public RecipeViewModel(IRecipe source, GlobalViewModels gvm)
        {
            this.GVM = gvm;
            this.InitFieldsFromRecipe(source);
        }

        private void InitFieldsFromRecipe(IRecipe source)
        {
            this.isDirty = false;
            this.RecipeName = source.Name;
            this.Parent = source.Parent;
            this.Culture = source.Culture;
            this.Servings = source.Servings;
            this.servingName = source.ServingName;
            this.Ingredients = new ObservableCollection<Tuple<decimal, string, string>>(source.Ingredients);
            this.Diets = new ObservableCollection<IDiet>(source.Diets);
            this.steps = source.Steps;
            this.recipe = source;
        }
        private string recipeName;
        public string RecipeName
        {
            get { return this.recipeName; }
            set
            {
                this.recipeName = value;
                OnPropertyChanged(nameof(RecipeName));
                isDirty = true;
            }
        }

        private TimeSpan preperationTime;
        private TimeSpan cookingTime;
        private TimeSpan restingTime;
        private ICookBook parent;
        private int servings;
        private string servingName;
        private ObservableCollection<Tuple<decimal, string, string>> ingredients;
        private ObservableCollection<IDiet> diets;
        private string steps;
        private CultureInfo culture;

        private bool isDirty;

        public TimeSpan PreperationTime
        {
            get
            { return this.preperationTime; }
            set
            {
                this.preperationTime = value;
                OnPropertyChanged(nameof(PreperationTime));
                isDirty = true;
            }
        }
        public TimeSpan CookingTime 
        { 
            get => cookingTime;
            set 
            { 
                cookingTime = value; 
                OnPropertyChanged(nameof(CookingTime));
                OnPropertyChanged(nameof(TotalTime));
                isDirty = true;
            }
        }
        public TimeSpan RestingTime 
        { 
            get => restingTime; 
            set 
            { 
                restingTime = value;
                OnPropertyChanged(nameof(RestingTime));
                OnPropertyChanged(nameof(TotalTime));
                isDirty = true;
            }
        }
        public TimeSpan TotalTime => (cookingTime + preperationTime + restingTime);

        public ICookBook Parent
        {
            get => parent;
            set
            {
                parent = value;
                OnPropertyChanged(nameof(Parent));
                isDirty = true;
            }
        }
        public int Servings
        {
            get => servings;
            set
            {
                servings = value;
                OnPropertyChanged(nameof(Servings));
                isDirty = true;
            }
        }
        public string ServingName
        {
            get => servingName;
            set
            {
                servingName = value;
                OnPropertyChanged(nameof(ServingName));
                isDirty = true;
            }
        }
        public ObservableCollection<Tuple<Decimal, string, string>> Ingredients
        {
            get => ingredients;
            set
            {
                ingredients = value;
                OnPropertyChanged(nameof(Ingredients));
                isDirty = true;
            }
        }
        public void AddIngredient(Tuple<Decimal, string, string> Ingredient)
        {
            if(this.ingredients.Contains(Ingredient))
            {
                throw new ArgumentException("Ingredient is already part of List");
            }
            this.ingredients.Add(Ingredient);
            OnPropertyChanged(nameof(Ingredients));
            isDirty = true;
        }
        public ObservableCollection<IDiet> Diets
        {
            get => diets;
            set
            {
                diets = value;
                OnPropertyChanged(nameof(Diets));
                isDirty = true;
            }
        }
        public string Steps
        {
            get => steps;
            set
            {
                steps = value;
                OnPropertyChanged(nameof(Steps));
                isDirty = true;
            }
        }

        public CultureInfo Culture
        {
            get => culture;
            set
            {
                culture = value;
                OnPropertyChanged(nameof(Culture));
                isDirty = true;
            }
        }

        public string LabelIngredientsName => Localisation.StringLocalisation.LabelIngredientsName + ":";
        public bool IsValidRecipe 
        {
            get 
            {
                return (
                    Parent != null 
                    && RecipeName.Length > 0
                    && Ingredients.Count > 0
                    && Steps.Length > 0);
            }
        }

        private IRecipe UpdateRecipe()
        {
            if(this.isDirty == true)
            {
                this.recipe.Parent = Parent;
                this.recipe.Name = RecipeName;
                this.recipe.Culture = Culture;
                this.recipe.Servings = Servings;
                this.recipe.ServingName = ServingName;
                this.recipe.Ingredients = new List<Tuple<Decimal, string, string>>(Ingredients);
                this.recipe.Diets = new List<IDiet>(Diets);
                this.recipe.Steps = Steps;
                this.recipe.PreperationTime = PreperationTime;
                this.recipe.CookingTime = CookingTime;
                this.recipe.RestingTime = RestingTime;

                this.isDirty = false;
            }
            return this.recipe;
        }
    }
}
