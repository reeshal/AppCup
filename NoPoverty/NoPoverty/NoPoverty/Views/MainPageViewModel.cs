using Xamarin.Plugin.Calendar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace NoPoverty.Views
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ICommand DayTappedCommand => new Command<DateTime>(DayTapped);

        public MainPageViewModel()
        {
            Culture = CultureInfo.CreateSpecificCulture("en-US");

            // testing all kinds of adding events
            // when initializing collection
            Events = new EventCollection();


            //Add Event
            AddEvent("03/08/2020 08:00:34", "Wa xD", "Ene ler pu leV sa?");
            AddEvent("03/09/2020 18:00:34", "Waaaooooa xD", "Ene ler pu drmi sa?");
        }








        protected IEnumerable<EventModel> AddEvents(string name, string desc)
        {
            return Enumerable.Range(1,1).Select(x => new EventModel
            {
                Name = $"{name}",
                Description = $"{desc}"
            });
        }
        public void AddEvent(string datetime, string name, string desc)
        {
            DateTime dt = new DateTime();
            dt = DateTime.Parse(datetime);
            Events.Add(dt, new List<EventModel>(AddEvents(name, desc)));
        }
        public EventCollection Events { get; }
        public int Month { get; set; } = DateTime.Now.Month;
        public int Year { get; set; } = DateTime.Now.Year;

        private DateTime _selectedDate = DateTime.Today;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set => SetProperty(ref _selectedDate, value);
        }

        private DateTime _minimumDate = new DateTime(2019, 4, 29);
        public DateTime MinimumDate
        {
            get => _minimumDate;
            set => SetProperty(ref _minimumDate, value);
        }

        private DateTime _maximumDate = DateTime.Today.AddMonths(5);
        public DateTime MaximumDate
        {
            get => _maximumDate;
            set => SetProperty(ref _maximumDate, value);
        }

        private CultureInfo _culture = CultureInfo.InvariantCulture;
        public CultureInfo Culture
        {
            get => _culture;
            set => SetProperty(ref _culture, value);
        }

        private static void DayTapped(DateTime date)
        {
            Console.WriteLine($"Received tap event from date: {date}");
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void SetProperty<TData>(ref TData storage, TData value, [CallerMemberName] string propertyName = "")
        {
            if (storage.Equals(value))
                return;

            storage = value;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
