using MailApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MailApp.ViewModels
{
    class DetailViewModel
    {
        //   private ObservableCollection<Mail> _mail;

        // public ObservableCollection<Mail> Mails { get { return _mail; } }

        private Mail _mail;
        public Mail Mail { get { return _mail; } }
       
        public DetailViewModel(Mail mail)
        {
            _mail = mail;
            
        }
    }
}
