//using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace B4.EE.AlderweireldR.AfsprakenApp.Models
{
    public class Afspraak
    {
        //[PrimaryKey]
        public int Id { get; set; }
        //[NotNull, MaxLength(30)]
        public string Naam { get; set; }
        //[NotNull, MaxLength(30)]
        public string Voornaam { get; set; }
        //[NotNull]
        public DateTime Geboortedatum { get; set; }
        //[NotNull]
        public string Telefoonnummer { get; set; }
        //[MaxLength(40)]
        public string EmailAdres { get; set; }
        //Om aan te duiden of patiënt gekend is of niet
        //[NotNull]
        public string GekendePatient { get; set; }
        //[MaxLength(80)]
        public string ExtraInfo { get; set; }

        //[NotNull]
        public DateTime AfspraakDatum { get; set; }

        //[Ignore]
        public string Uur
        {
            get
            {
                return AfspraakDatum.ToString("HH:mm");
            }
        }

        //[Ignore]
        public bool IsGereserveerd { get { return Id != 0; } }

        //[Ignore]
        public string StatusDisplay { get { return PlaatsDisplay(); } }

        private string PlaatsDisplay()
        {
            if(AfspraakDatum.DayOfWeek == DayOfWeek.Saturday || AfspraakDatum.DayOfWeek == DayOfWeek.Sunday)
            {
                return "Weekend";
            }
            if(IsGereserveerd)
            {
                return "Afspraak werd reeds geboekt!";
            }
            return "";
        }

        public Afspraak(DateTime tijd)
        {
            AfspraakDatum = tijd;
        }
    }
}
