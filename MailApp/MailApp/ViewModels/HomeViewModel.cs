﻿using MailApp.Models;
using MailApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MailApp.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public ICommand AddCommand { get; }
        private ICommand SelectedMailCommand { get; }

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

        public HomeViewModel()
        {
            AddCommand = new Command(AddMail);
           
            SelectedMailCommand = new Command<Mail>(OnMailSelected);
        }

        private void AddMail()
        {
            App.Current.MainPage.Navigation.PushAsync(new AddMailPage(Mails));
        }

        private async void OnMailSelected(Mail mail)
        {
            await App.Current.MainPage.Navigation.PushAsync(new DetailPage(mail));
        }

        private void OnPropertyChanged(string properyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(properyName));
        }


    }
}
