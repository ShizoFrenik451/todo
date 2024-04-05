using Firebase.Auth;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTodo
{
    public class DbHandler
    {
        public async void AddToDb(string name, string notes)
        {
            string apiKey = "AIzaSyCYC97Nnk6Qb2a9gZv7nyyVhu6LINXYnoY";
            FirebaseAuthProvider firebaseAuthProvider = new FirebaseAuthProvider(new FirebaseConfig(apiKey));

            //FirebaseAuthLink link = await firebaseAuthProvider.CreateUserWithEmailAndPasswordAsync("4egorjopawe@g.com", "4piуpisa1we"); // создание нового акка для входа
            FirebaseAuthLink link1 = await firebaseAuthProvider.SignInWithEmailAndPasswordAsync("4egorjopawe@g.com", "4piуpisa1we");

            IFirebaseConfig config = new FireSharp.Config.FirebaseConfig
            {
                AuthSecret = "7PchP8n9L4rHrhX1PyXF5chEk5Z6QsVc3Bm1jPGf",
                BasePath = "https://sosa-152d4-default-rtdb.europe-west1.firebasedatabase.app/"
            };

            IFirebaseClient firebaseClient = new FireSharp.FirebaseClient(config);

            FirebaseResponse response = firebaseClient.Set($"{name}", $"{notes}");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Успешно записано");
            }
            else
            {
                Console.WriteLine("Ошибка при записи данных: " + response.StatusCode);
            }
        }

        public async void DeleteToDb(string name)
        {
            string apiKey = "AIzaSyCYC97Nnk6Qb2a9gZv7nyyVhu6LINXYnoY";
            FirebaseAuthProvider firebaseAuthProvider = new FirebaseAuthProvider(new FirebaseConfig(apiKey));

            //FirebaseAuthLink link = await firebaseAuthProvider.CreateUserWithEmailAndPasswordAsync("4egorjopawe@g.com", "4piуpisa1we"); // создание нового акка для входа
            FirebaseAuthLink link1 = await firebaseAuthProvider.SignInWithEmailAndPasswordAsync("4egorjopawe@g.com", "4piуpisa1we");

            IFirebaseConfig config = new FireSharp.Config.FirebaseConfig
            {
                AuthSecret = "7PchP8n9L4rHrhX1PyXF5chEk5Z6QsVc3Bm1jPGf",
                BasePath = "https://sosa-152d4-default-rtdb.europe-west1.firebasedatabase.app/"
            };

            IFirebaseClient firebaseClient = new FireSharp.FirebaseClient(config);

            FirebaseResponse response1 = firebaseClient.Delete($"{name}");
            if (response1.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Успешно удалено!");
            }
            else
            {
                Console.WriteLine("Ошибка при удалении данных: ");
            }
        }
    }
}
