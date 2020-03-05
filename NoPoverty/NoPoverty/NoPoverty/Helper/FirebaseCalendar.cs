using Firebase.Database;
using Firebase.Database.Query;

using NoPoverty.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoPoverty.Helper
{
    public class FirebaseCalendar
    {
        private readonly string Child4 = "Calendar";

        readonly FirebaseClient firebase = new FirebaseClient("https://nopoverty-66859.firebaseio.com/");

        public async Task<List<EventModel>> GetAllCalendar()
        {
            return (await firebase
                .Child(Child4)
                .OnceAsync<EventModel>()).Select(item => new EventModel
                {
                    DateTime = item.Object.DateTime,
                    DonorUserName = item.Object.DonorUserName,
                    Description = item.Object.Description,
                    InstName = item.Object.InstName
                }).ToList();
        }

        public async Task AddCalendar(string datetime, string donorusername, string description, string instname)
        {
            await firebase
                .Child(Child4)
                .PostAsync(new EventModel() { DateTime = datetime, DonorUserName = donorusername, Description = description, InstName = instname });
        }

        public async Task<EventModel> GetCalenderByInstitution(string instname)
        {
            var allRep = await GetAllCalendar();
            await firebase
                .Child(Child4)
                .OnceAsync<EventModel>();
            return allRep.FirstOrDefault(a => a.InstName == instname);
        }
    }
}
