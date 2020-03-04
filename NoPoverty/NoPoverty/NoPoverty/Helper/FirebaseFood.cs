using Firebase.Database;
using Firebase.Database.Query;
using NoPoverty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoPoverty.Helper
{
    public class FirebaseFood
    {
        private readonly string Child3 = "Meal";
        readonly FirebaseClient firebase = new FirebaseClient("https://nopoverty-66859.firebaseio.com/");
        public async Task<List<Meal>> GetAllMeal()
        {
            return (await firebase
                .Child(Child3)
                .OnceAsync<Meal>()).Select(item => new Meal
                {
                    Title= item.Object.Title,
                    Description = item.Object.Description,
                    Donator = item.Object.Donator,
                    Calorie = item.Object.Calorie,
                    Healthiness = item.Object.Healthiness,
                    Quantity = item.Object.Quantity,
                    //ImageUrl = item.Object.ImageUrl
                }).ToList();
        }
        public async Task AddMeal(string title, string description, string donator, string calorie, string healthiness, string qty, string imgurl )
        {
            await firebase
                .Child(Child3)
                .PostAsync(new Meal() { MealId = Guid.NewGuid(), Title=title, Description=description,Donator=donator, Calorie=calorie,Healthiness=healthiness, Quantity=qty,ImageUrl=""});
        }

        public async Task<List<Meal>> GetMealsByInstitution(string institutionName)
        {
            return (await firebase
                .Child(Child3)
                .Child("InstitutionName")
                .OrderByKey()
                .EqualTo(()=>institutionName)
                .OnceAsync<Meal>()).Select(item => new Meal
                {
                    Title = item.Object.Title,
                    Description = item.Object.Description,
                    Donator = item.Object.Donator,
                    Calorie = item.Object.Calorie,
                    Healthiness = item.Object.Healthiness,
                    Quantity = item.Object.Quantity,
                    //ImageUrl = item.Object.ImageUrl
                }).ToList();
        }
    }
}
