using System;
using System.Collections.Generic;
using System.Text;

namespace B4.EE.AlderweireldR.AfsprakenApp.Models
{
    public class DataAgendaTelefoon
    {
        public DateTime AgendaDatum { get; set; }

        public TimeSpan AgendaTijd { get; set; }

        public string Titel { get; set; }

        public string WaarEnWanneer { get; set; }

        public string Beschrijving { get; set; }
    }
}
