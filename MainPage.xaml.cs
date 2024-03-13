using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using SimpleTodo.Models;

namespace SimpleTodo
{
    public partial class MainPage : ContentPage
    {
        Models.TodoItemDatabase database;

        public MainPage()
        {
            InitializeComponent();
            database = new Models.TodoItemDatabase();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await database.GetItemsAsync(); 
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TodoItemPage(database)
                {
                    BindingContext = e.SelectedItem as Models.TodoItem
                });
            }
        }

        async void OnAddButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoItemPage(database)
            {
                BindingContext = new Models.TodoItem()
            });
        }
        public async Task<List<TodoItem>> GetItems()
        {
            return await database.GetItemsAsync();
        }
        public void SetItems(List<TodoItem> items)
        {
            listView.ItemsSource = items;
        }
    }
}