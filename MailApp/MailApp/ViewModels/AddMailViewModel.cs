using MailApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
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

        public ICommand LoadPhotoCommand { get; }

        private string _photoPath;
        public string PhotoPath { get { return _photoPath; } set { _photoPath = value; OnPropertyChanged(nameof(PhotoPath)); } }

        public AddMailViewModel(ObservableCollection<Mail> mails)
        {
            _mails = mails;
            LoadPhotoCommand = new Command(async(e) =>
            { var photo = await MediaPicker.PickPhotoAsync();
              var stream = await LoadPhotoAsync(photo);
            });
            AddCommand = new Command(async() => { 
              
                mails.Add(new Mail(Title, Description, From, PhotoPath));

               await App.Current.MainPage.Navigation.PopAsync();
            } );
        }

        async Task<Stream> LoadPhotoAsync(FileResult photo)
        {

            if (photo == null)
            {
                return null;
            }

            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            var stream = await photo.OpenReadAsync();
            PhotoPath = photo.FullPath;
            return stream;
        }


        private void OnPropertyChanged(string properyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(properyName));
        }
      
       
    }
}
