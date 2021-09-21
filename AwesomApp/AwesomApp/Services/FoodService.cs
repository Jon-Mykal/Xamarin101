using AwesomApp.Models;

using SQLite;

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Essentials;

namespace AwesomApp.Services
{
    public static class FoodService
    {
        static SQLiteAsyncConnection db;
        static HttpClient client;
        static string BaseUrl = DeviceInfo.Platform == DevicePlatform.Android ?
            "https://10.0.2.2:5001" : "https://localhost:5001";

        static FoodService()
        {
#if DEBUG
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                {
                    return true;
                }
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            client = new HttpClient(handler)
            {
                BaseAddress = new Uri(BaseUrl)
            };
#else
            client = new HttpClient()
            {
                BaseAddress = new Uri(BaseUrl)
            };
#endif
        }


        static async Task Init()
        {
            if (db == null)
            {
                var dbPath = Path.Combine(FileSystem.AppDataDirectory, "Food.db");
                db = new SQLiteAsyncConnection(dbPath);
                await db.CreateTableAsync<Food>();
            }
        }

        public static async Task AddFood(string name, string kitchen)
        {
            await Init();
            var image = "https://www.eatthis.com/wp-content/uploads/sites/4//media/images/ext/966368714/kfc-original-chicken-recipe.jpg?quality=82&strip=1&resize=640%2C360";
            var food = new Food() { Kitchen = kitchen, Name = name, Image = image };
            var rowId = await db.InsertAsync(food);
        }

        public static async Task RemoveFood(int id)
        {
            await Init();
            await db.DeleteAsync<Food>(id);
        }

        public static async Task<IEnumerable<Food>> GetAllFood()
        {
            await Init();
            var food = await db.Table<Food>().ToListAsync();
            return food;
        }

        public static async Task<string> GetOwners()
        {
            var json = "";

            try
            {
                json = await client.GetStringAsync("weatherforecast");
            }
            catch (Exception ex)
            {

                var msg = ex.Message;
            }
            

            return json;
        }
    }

}
