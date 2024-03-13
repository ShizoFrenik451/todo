using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using SimpleTodo.Models;

namespace SimpleTodo
{
    public partial class CategoryPage : ContentPage
    {
        TodoCategoryDatabase database;

        public CategoryPage()
        {
            InitializeComponent();
            database = new TodoCategoryDatabase();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await database.GetCategoriesAsync();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TodoCategoryPage(database)
                {
                    BindingContext = e.SelectedItem as TodoItem
                });
            }
        }

        async void OnAddButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoCategoryPage(database)
            {
                BindingContext = new TodoItem()
            });
        }
    }
}

