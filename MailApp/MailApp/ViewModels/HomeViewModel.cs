using MailApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailApp.ViewModels
{
    public class HomeViewModel
    {
        public IList<Mail> Mails { get; } = new List<Mail>()
        {
            new Mail("Correo prueba", "Este es un correo prueba a ver si esta funcionando ", "Leiscar" ),
             new Mail("Hola", "Hola", "Leiscar" ),
              new Mail("Hola", "Hola", "Leiscar" ),

        };

        public HomeViewModel()
        {

        }


    }
}
