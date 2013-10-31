namespace TriviaGame.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using TriviaGame.Behavior;
    using TriviaGame.Data;
    using TriviaGame.Model;
    using Windows.UI.Xaml.Data;
    
    public class TriviaViewModel : ViewModelBase
    {
        private ObservableCollection<Category> categories;

        public IEnumerable<Category> Categories
        {
            get
            {
                if (this.categories == null)
                {
                    var categoriesQuery = DataPersister.GetAllCategories();
                    this.categories = new ObservableCollection<Category>();
                    this.categories.Add(new Category() { Name = "All" });
                    
                    foreach (var category in categoriesQuery)
                    {
                        if (!this.categories.Contains(category))
                        {
                            this.categories.Add(category);
                        }
                    }
                }

                return this.categories;
            }
        }

        private bool isCategorySelected;

        public bool IsCategorySelected
        {
            get
            {
                return isCategorySelected;
            }
            set
            {
                isCategorySelected = value;
                this.OnPropertyChanged("IsCategorySelected");
            }
        }

        private ICommand selectCategoryCommand;

        public ICommand SelectCategoryCommand
        {
            get
            {
                if (this.selectCategoryCommand == null)
                {
                    this.selectCategoryCommand = new RelayCommand(this.HandleSelectCategoryCommand);
                }

                return this.selectCategoryCommand;
            }
        }

        public Category SelectedCategory { get; }

        public IEnumerable<Question> Questions { get; set; }

        private bool isTriviaStarted;

        public bool IsTriviaStarted
        {
            get
            {
                return isTriviaStarted;
            }
            set
            {
                isTriviaStarted = value;
                this.OnPropertyChanged("IsTriviaStarted");
            }
        }
        
        private void HandleSelectCategoryCommand(object parameter)
        {
            if (this.SelectedCategory == null)
            {
                return;
            }

            this.IsCategorySelected = true;
            this.IsTriviaStarted = false;
            IEnumerable<Question> questionsQuery;

            if (this.SelectedCategory.Name != "All")
            {
                questionsQuery = DataPersister.GetQuestions();
            }
            else
            {
                questionsQuery = DataPersister.GetQuestions(this.SelectedCategory.Name);
            }

            foreach (var question in questionsQuery)
            {
                questions.Add(question);
            }
        }

        private Question currentQuestion;

        public Question CurrentQuestion
        {
            get
            {
                return currentQuestion;
            }
            set
            {
                currentQuestion = value;
            }
        }

        private ICommand nextQuestionCommand;

        public ICommand NextQuestionCommand
        {
            get
            {
                if (this.nextQuestionCommand == null)
                {
                    this.nextQuestionCommand = new RelayCommand(this.HandleNextQuestionCommand);
                }

                return this.nextQuestionCommand;
            }
        }

        private void HandleNextQuestionCommand(object parameter)
        {
            if ()
            {
            }
        }
        
        public TriviaViewModel()
        {
            this.isCategorySelected = false;
            this.isTriviaStarted = true;
        }
    }
}