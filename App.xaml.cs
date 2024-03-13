using Microsoft.Maui.Storage;
using Newtonsoft.Json;
using SimpleTodo.Models;
using Microsoft.Maui.Controls;


namespace SimpleTodo
{
    public partial class App : Application
    {
        
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
        protected override void OnSleep()
        {
            base.OnSleep();

            var todoItems = (Application.Current.MainPage as MainPage)?.GetItems();
            if (todoItems != null)
            {
                var serializedItems = JsonConvert.SerializeObject(todoItems);
                Preferences.Set("TodoItems", serializedItems);
            }
        }
        protected override void OnStart()
        {
            base.OnStart();

            if (Preferences.ContainsKey("TodoItems"))
            {
                var serializedItems = Preferences.Get("TodoItems", string.Empty);
                var todoItems = JsonConvert.DeserializeObject<List<TodoItem>>(serializedItems);
                (Application.Current.MainPage as MainPage)?.SetItems(todoItems);
            }
        }
    }
}