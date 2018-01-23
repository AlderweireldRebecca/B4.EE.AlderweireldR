using System;
using System.Collections.Generic;
using System.Text;

namespace B4.EE.AlderweireldR.AfsprakenApp.Models
{
    public class Dokter
    {
        public Guid Id { get; set; }
        public string Titel { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
    }
}
