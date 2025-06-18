using FirebaseAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Firebase.Database;
using System.Windows.Forms;
using System.Reactive;
using Firebase.Database.Query;

namespace Lab5
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
           
            Console.WriteLine("FireSharp installed successfully !");
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("C:\\Dev\\K24GD03Ha\\serviceAccountKey.json")
            });
            Console.WriteLine("Firebase Admin SDK da duoc khoi tao thanh cong");
            await AddTestData();
            await ReadTestData();
            await UpdateTestData();
            await ReadTestData();
            await DeleteTestData();
            Console.ReadLine();
        }
        private static string firebaseDB_URL = "https://project-1-d4f90-default-rtdb.asia-southeast1.firebasedatabase.app/";

        public static async Task AddTestData()
        {
            var firebase = new FirebaseClient(firebaseDB_URL);

            var testData = new
            {
                Message = "Hello Firebase !",
                Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
            };
            await firebase.Child("test").PutAsync(testData);
            Console.WriteLine("Du lieu da duoc them vao Firebase !");
            
        }

        public static async Task ReadTestData()
        {
            var firebase = new FirebaseClient("https://project-1-d4f90-default-rtdb.asia-southeast1.firebasedatabase.app/");
            var testData = await firebase.Child("test").OnceSingleAsync<dynamic>();

            Console.WriteLine($"Message: {testData.Message}");
            Console.WriteLine($"Timestamp: {testData.Timestamp}");
        }

        public static async Task UpdateTestData()
        {
            var firebase = new FirebaseClient("https://project-1-d4f90-default-rtdb.asia-southeast1.firebasedatabase.app/");
            var updatedData = new
            {
                Message = "Updated Message !",
                Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
            };
            await firebase.Child("test").PatchAsync(updatedData);
            Console.WriteLine("Du lieu da duoc cap nhat trong Firebase !");
        }

        public static async Task DeleteTestData()
        {
            var firebase = new FirebaseClient("https://project-1-d4f90-default-rtdb.asia-southeast1.firebasedatabase.app/");
            await firebase.Child("test").DeleteAsync();
            Console.WriteLine("Du lieu da bi xoa khoi Firebase !")
        }
    }
}
