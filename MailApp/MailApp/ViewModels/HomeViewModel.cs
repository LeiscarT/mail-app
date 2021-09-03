using MailApp.Models;
using MailApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MailApp.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public ICommand AddCommand { get; }
        private ICommand SelectedMailCommand { get; }

        public ICommand DeleteCommand { get; }

        private Mail _selectedMail;

        public event PropertyChangedEventHandler PropertyChanged;

        public Mail SelectedMail {
            get {
                return _selectedMail;
            }
            set
            {

                _selectedMail = value;

                if (_selectedMail != null)
                {
                    SelectedMailCommand.Execute(_selectedMail);
                }
            } }

        public ObservableCollection<Mail> Mails { get; set; } = new ObservableCollection<Mail>();

        /*
        public ObservableCollection<Mail> Mails
        {
            get
            {

                var mails = JsonConvert.DeserializeObject<ObservableCollection<Mail>>(Preferences.Get(nameof(Mails), null));
                return mails ?? new ObservableCollection<Mail>();

            }
            set { var serializeMails = JsonConvert.SerializeObject(value); Preferences.Set(nameof(Mails), serializeMails); }
        }*/
        public HomeViewModel()
        {
        //    Preferences.Get(nameof(Mails),null);
            AddCommand = new Command(AddMail);          
            SelectedMailCommand = new Command<Mail>(OnMailSelected);
            DeleteCommand = new Command<Mail>(DeleteMail);
        }

        private void AddMail()
        {
           App.Current.MainPage.Navigation.PushAsync(new AddMailPage(Mails));
           
        }

        private async void OnMailSelected(Mail mail)
        {
            await App.Current.MainPage.Navigation.PushAsync(new DetailPage(mail));
        }


        private void DeleteMail(Mail mail)
        {
            Mails.Remove(mail);
        }

        private void OnPropertyChanged(string properyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(properyName));
        }


    }
}
