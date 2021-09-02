using MailApp.Models;
using MailApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MailApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddMailPage : ContentPage
    {
        public AddMailPage(ObservableCollection<Mail> mails )
        {
            InitializeComponent();
            BindingContext = new AddMailViewModel(mails);
        }
    }
}