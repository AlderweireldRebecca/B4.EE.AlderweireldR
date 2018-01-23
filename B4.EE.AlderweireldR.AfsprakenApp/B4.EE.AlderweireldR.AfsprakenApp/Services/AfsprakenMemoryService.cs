using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using B4.EE.AlderweireldR.AfsprakenApp.Models;
//using Newtonsoft.Json;

namespace B4.EE.AlderweireldR.AfsprakenApp.Services
{
    public class AfsprakenMemoryService : IAfsprakenService
    {
        private List<Afspraak> _afspraken;
        private static List<Afspraak> _dbAfspraken = new List<Afspraak>();

        public AfsprakenMemoryService()
        {
            if(!_dbAfspraken.Any())
            {
                VulData();
            }
        }

        public async Task<IEnumerable<Afspraak>> Get(DateTime datum)
        {
            InitMemoryLijst(datum);
            return await ControleerDatum(datum);
        }

        public async Task<bool> Bewaar(Afspraak afspraak)
        {
            try
            {
                afspraak.Id = AutoIncrement();
                await Task.Run(() => _dbAfspraken.Add(afspraak));
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private int AutoIncrement()
        {
            return _dbAfspraken.Max(a => a.Id) + 1;
        }

        private async Task<IEnumerable<Afspraak>> ControleerDatum(DateTime datum)
        {
            //HttpClient httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri("http://localhost:56748/api/afspraak");
            //var result = await httpClient.GetAsync($"?datet={datum}");
            //var json = await result.Content.ReadAsStringAsync();

            //SplitsJson(json);
            //_dbAfspraken = JsonConvert.DeserializeObject<IEnumerable<Afspraak>>(json).ToList();

            if (_dbAfspraken == null) //.Any())
            {
                return _afspraken;
            }
            else
            {
                foreach (var afspraak in _dbAfspraken.Where(a => a.AfspraakDatum.ToShortDateString() == datum.ToShortDateString()))
                {
                    _afspraken.RemoveAll(a => a.AfspraakDatum == afspraak.AfspraakDatum);
                    _afspraken.Add(afspraak);
                }
                _afspraken = _afspraken.OrderBy(t => t.AfspraakDatum).ToList();
            }
            return _afspraken;
        }

        private void InitMemoryLijst(DateTime datum)
        {
            int uur = 8;
            int minuten = 0;
            _afspraken = new List<Afspraak>();

            _afspraken.Add(new Afspraak(new DateTime(datum.Year, datum.Month, datum.Day, uur, minuten, 0)));
            for (int i = 0; i < 15; i++)
            {
                if (i % 2 == 0)
                {
                    minuten = 30;
                }
                else
                {
                    uur++;
                    minuten = 0;
                }

                _afspraken.Add(new Afspraak(new DateTime(datum.Year, datum.Month, datum.Day, uur, minuten, 0)));
            }
        }

        private void VulData()
        {
            _dbAfspraken = new List<Afspraak>
            {
                new Afspraak(new DateTime(2018,1,25,8,0,0))
                {
                    Id = 1,
                    Naam = "Vandevelde",
                    Voornaam = "Joris",
                    Geboortedatum = new DateTime(1997,6,14),
                    Telefoonnummer = "0497514962",
                    EmailAdres = "joris.vandevelde@gmail.com",
                    GekendePatient = "Gekend",
                    ExtraInfo = "bloedname"
                },
                new Afspraak(new DateTime(2018,1,25,10,30,0))
                {
                    Id = 2,
                    Naam = "Vandamme",
                    Voornaam = "Yvtte",
                    Geboortedatum = new DateTime(1945,3,30),
                    Telefoonnummer = "058514962",
                    GekendePatient = "Gekend",
                    ExtraInfo = "medicatie"
                },
                new Afspraak(new DateTime(2018,1,26,11,30,0))
                {
                    Id =3,
                    Naam = "Daams",
                    Voornaam = "Patrick",
                    Geboortedatum = new DateTime(1971,11,11),
                    Telefoonnummer = "0496971482",
                    EmailAdres = "patrick@telenet.be",
                    GekendePatient = "Nieuw",
                    ExtraInfo = "CVS"
                }
            };
        }

        //code voor Web API:

        //private void ConvertJsonToAfspraak(string json)
        //{
        //    Debug.WriteLine("== Test ==");
        //    Debug.WriteLine(json);
        //    var dicts = json.Split(',');

        //    Dictionary<string, object> dictionary = new Dictionary<string, object>();
        //    foreach (var item in dicts)
        //    {
        //        var values = item.Split(':');
        //        if (values[0] == "\"Geboortedatum\"" || values[1] == "\"AfspraakDatum\"")
        //        {
        //            values[1] += ":" + values[2] + ":" + values[3];
        //        }
        //        dictionary.Add(values[0], values[1]);
        //    }

        //    var afspraak = new Afspraak(new DateTime());
        //    foreach (var item in dictionary)
        //    {
        //        if (item.Key == "\"Id\"")
        //        {
        //            afspraak.Id = (int)item.Value;
        //        }
        //        if (item.Key == "\"Naam\"")
        //        {
        //            afspraak.Naam = VerwijderQuotes(item.Value.ToString());
        //        }
        //        if (item.Key == "\"Voornaam\"")
        //        {
        //            afspraak.Voornaam = VerwijderQuotes(item.Value.ToString());
        //        }
        //        if (item.Key == "\"Geboortedatum\"")
        //        {
        //            Debug.WriteLine("== Date ==");
        //            Debug.WriteLine(item.Value.ToString());
        //            Debug.WriteLine(VerwijderQuotes(item.Value.ToString()));
        //            afspraak.Geboortedatum = DateTime.Parse(VerwijderQuotes(item.Value.ToString()));
        //        }
        //        if (item.Key == "\"Telefoonnummer\"")
        //        {
        //            afspraak.Telefoonnummer = VerwijderQuotes(item.Value.ToString());
        //        }
        //        if (item.Key == "\"EmailAdres\"")
        //        {
        //            afspraak.EmailAdres = VerwijderQuotes(item.Value.ToString());
        //        }
        //        if (item.Key == "\"GekendePatient\"")
        //        {
        //            afspraak.GekendePatient = VerwijderQuotes(item.Value.ToString());
        //        }
        //        if (item.Key == "\"ExtraInfo\"")
        //        {
        //            afspraak.ExtraInfo = VerwijderQuotes(item.Value.ToString());
        //        }
        //        if (item.Key == "\"AfspraakDatum\"")
        //        {
        //            afspraak.AfspraakDatum = DateTime.Parse(VerwijderQuotes(item.Value.ToString()));
        //        }
        //    }
        //    Debug.WriteLine(afspraak.Naam);
        //    _dbAfspraken.Add(afspraak);
        //}

        //private string VerwijderQuotes(string waarde)
        //{
        //    var resultaat = waarde.Remove(0, 1);
        //    resultaat = resultaat.Remove(resultaat.Length - 1);
        //    return resultaat;
        //}

        //private void SplitsJson(string json)
        //{
        //    var resultaat = json.Remove(0, 1);
        //    resultaat = resultaat.Remove(resultaat.Length - 1);

        //    var aantalObjecten = resultaat.Count(a => a == '{');
        //    if (aantalObjecten > 1)
        //    {
        //        var objecten = resultaat.Split(',');

        //        foreach (var obj in objecten)
        //        {
        //            var @object = obj.Remove(0, 1);
        //            @object = @object.Remove(@object.Length - 1);

        //            ConvertJsonToAfspraak(@object);
        //        }
        //    }
        //    else if(aantalObjecten == 1)
        //    {
        //        ConvertJsonToAfspraak(resultaat);
        //    }
        //    else
        //    {

        //    }
        //}
    }
}
