using MailApp.Models;
using MailApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MailApp.ViewModels
{
    public class HomeViewModel
    {
        public ICommand AddCommand { get; }
        public ObservableCollection<Mail> Mails { get; } = new ObservableCollection<Mail>()
        {
            new Mail("Correo prueba", "Este es un correo prueba a ver si esta funcionando ", "Leiscar" ),
             new Mail("Hola", "Hola", "Leiscar" ),
              new Mail("Hola", "Hola", "Leiscar" ),

        };

        public HomeViewModel()
        {
            AddCommand = new Command(AddMail);
        }

        private void AddMail()
        {
            App.Current.MainPage.Navigation.PushAsync(new AddMailPage(Mails));
        }


    }
}
