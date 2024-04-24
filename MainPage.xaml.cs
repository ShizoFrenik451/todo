﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using SimpleTodo.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.ObjectModel;
using Firebase.Auth;
using System.IO;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace SimpleTodo
{
    
    public partial class MainPage : ContentPage
    {
        private bool isFlashlightOn = false;
        Models.TodoItemDatabase database;
        FirebaseClient firebaseClient = new FirebaseClient(baseUrl: "https://study-maui-default-rtdb.europe-west1.firebasedatabase.app/");
        public ObservableCollection<TodoItem> TodoItems { get; set; } = new ObservableCollection<TodoItem>();

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
        public void SetItems(List<TodoItem> items) //
        {
            listView.ItemsSource = items;
        }
        
        private async void ToggleFlashlight(object sender, EventArgs e)
        {

            try
            {
                if (isFlashlightOn)
                {
                    await Flashlight.TurnOffAsync();
                    isFlashlightOn = !isFlashlightOn;
                }
                else
                {
                    await Flashlight.TurnOnAsync();
                    isFlashlightOn = !isFlashlightOn;
                }
            }
            catch (FeatureNotSupportedException)
            {
                // Функция не поддерживается на данном устройстве
                await DisplayAlert("Ошибка", "Функция не поддерживается на вашем устройстве", "OK");
            }
            catch (PermissionException)
            {
                // Отсутствует разрешение на доступ к камере
                await DisplayAlert("Ошибка", "Отсутствует разрешение на доступ к камере", "OK");
            }
            catch (Exception)
            {
                // Общая ошибка
                await DisplayAlert("Ошибка", "Что-то пошло не так", "OK");
            }
        }
    }
}