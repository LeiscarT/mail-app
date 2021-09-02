using MailApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MailApp.ViewModels
{
    class AddMailViewModel : INotifyPropertyChanged
    {
        private string _title;
        public string Title { get { return _title; } set { _title = value; OnPropertyChanged(nameof(Title)); } }
        private string _description;
        public string Description { get { return _description; } set { _description = value; OnPropertyChanged(nameof(Description)); } }

        private DateTime _date;
        public DateTime Date { get { return _date; } set { _date = value; OnPropertyChanged(nameof(Date)); } }

        private string _from;
        public string From { get { return _from; } set { _from = value; OnPropertyChanged(nameof(From)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Mail> _mails;
        public ICommand AddCommand { get; }

        public AddMailViewModel(ObservableCollection<Mail> mails)
        {
            _mails = mails;
            AddCommand = new Command(async() => { 
                mails.Add(new Mail(Title, Description, From));
               await App.Current.MainPage.Navigation.PopAsync();
            } );
        }


        private void OnPropertyChanged(string properyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(properyName));
        }
      
       
    }
}
