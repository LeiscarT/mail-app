using System;
using System.Collections.Generic;
using System.Text;

namespace MailApp.Models
{
    public class Mail
    {
       
        public string Title { get; set; }
        public  string Description { get; set; }

        public string Date { get; set; }

        public string From { get; set; }

        public string Photo { get; set; }

        public Mail(string title, string description, string from, string photo)
        {
            
            Title = title;
            Description = description; 
            From = from;
            Date = DateTime.Now.ToString("h:mm tt");
            Photo = photo;
        }
    }
}
