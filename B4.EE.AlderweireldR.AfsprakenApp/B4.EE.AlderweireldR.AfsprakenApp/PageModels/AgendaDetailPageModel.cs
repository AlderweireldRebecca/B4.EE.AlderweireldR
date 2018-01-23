using B4.EE.AlderweireldR.AfsprakenApp.Domain.Validators;
using B4.EE.AlderweireldR.AfsprakenApp.Models;
using B4.EE.AlderweireldR.AfsprakenApp.Services;
using B4.EE.AlderweireldR.AfsprakenApp.Services.Abstract;
using FluentValidation;
using FreshMvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace B4.EE.AlderweireldR.AfsprakenApp.PageModels
{
    public class AgendaDetailPageModel : FreshBasePageModel
    {
        private readonly IAfsprakenService AfsprakenService;
        private IValidator afspraakValidator;
        private Afspraak huidigeAfspraak;

        public AgendaDetailPageModel() //(Afspraak afspraak)
        {
            AfsprakenService = new AfsprakenMemoryService();
            afspraakValidator = new AfspraakValidator();
        }

        private string afspraakNaam;
        public string AfspraakNaam
        {
            get { return afspraakNaam; }
            set
            {
                afspraakNaam = value;
                RaisePropertyChanged(nameof(AfspraakNaam));
            }
        }

        private string afspraakNaamError;
        public string AfspraakNaamError
        {
            get { return afspraakNaamError; }
            set
            {
                afspraakNaamError = value;
                RaisePropertyChanged(nameof(AfspraakNaamError));
                RaisePropertyChanged(nameof(AfspraakNaamErrorVisible));
            }
        }

        public bool AfspraakNaamErrorVisible
        {
            get
            {
                return !string.IsNullOrWhiteSpace(AfspraakNaamError);
            }
        }

        private string afspraakVoornaam;
        public string AfspraakVoornaam
        {
            get { return afspraakVoornaam; }
            set
            {
                afspraakVoornaam = value;
                RaisePropertyChanged(nameof(AfspraakVoornaam));
            }
        }

        private string afspraakVoornaamError;
        public string AfspraakVoornaamError
        {
            get { return afspraakVoornaamError; }
            set
            {
                afspraakVoornaamError = value;
                RaisePropertyChanged(nameof(AfspraakVoornaamError));
                RaisePropertyChanged(nameof(AfspraakVoornaamErrorVisible));
            }
        }

        public bool AfspraakVoornaamErrorVisible
        {
            get
            {
                return !string.IsNullOrWhiteSpace(AfspraakNaamError);
            }
        }

        private DateTime afspraakGeboortedatum;
        public DateTime AfspraakGeboortedatum
        {
            get { return afspraakGeboortedatum; }
            set
            {
                afspraakGeboortedatum = value;
                RaisePropertyChanged(nameof(AfspraakGeboortedatum));
            }
        }

        //private DateTime afspraakGeboortedatumError;
        //public DateTime AfspraakGeboortedatumError
        //{
        //    get { return afspraakGeboortedatumError; }
        //    set
        //    {
        //        afspraakGeboortedatumError = value;
        //        RaisePropertyChanged(nameof(AfspraakGeboortedatumError));
        //        RaisePropertyChanged(nameof(AfspraakGeboortedatumErrorVisible));
        //    }
        //}

        //public bool AfspraakGeboortedatumErrorVisible
        //{
        //    get
        //    {
        //        return AfspraakGeboortedatumError;
        //    }
        //}

        private string afspraakTelefoon;
        public string AfspraakTelefoon
        {
            get { return afspraakTelefoon; }
            set
            {
                afspraakTelefoon = value;
                RaisePropertyChanged(nameof(AfspraakTelefoon));
            }
        }

        private string afspraakTelefoonError;
        public string AfspraakTelefoonError
        {
            get { return afspraakTelefoonError; }
            set
            {
                afspraakTelefoonError = value;
                RaisePropertyChanged(nameof(AfspraakTelefoonError));
            }
        }

        public bool AfspraakTelefoonErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(AfspraakTelefoonError); }
        }

        private string afspraakEmail;
        public string AfspraakEmail
        {
            get { return afspraakEmail; }
            set
            {
                afspraakEmail = value;
                RaisePropertyChanged(nameof(AfspraakEmail));
            }
        }

        private string afspraakEmailError;
        public string AfspraakEmailError
        {
            get { return afspraakEmailError; }
            set
            {
                afspraakEmailError = value;
                RaisePropertyChanged(nameof(AfspraakEmailError));
            }
        }

        public bool AfspraakEmailErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(AfspraakEmailError); }
        }

        private string afspraakGekend;
        public string AfspraakGekend
        {
            get { return afspraakGekend; }
            set
            {
                afspraakGekend = value;
                RaisePropertyChanged(nameof(AfspraakGekend));
            }
        }

        private string afspraakGekendError;
        public string AfspraakGekendError
        {
            get { return afspraakGekendError; }
            set
            {
                afspraakGekendError = value;
                RaisePropertyChanged(nameof(AfspraakGekendError));
            }
        }

        public bool AfspraakGekendErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(AfspraakGekendError); }
        }

        private string afspraakExtra;
        public string AfspraakExtra
        {
            get { return afspraakExtra; }
            set
            {
                afspraakExtra = value;
                RaisePropertyChanged(nameof(AfspraakExtra));
            }
        }

        private string afspraakExtraError;
        public string AfspraakExtraError
        {
            get { return afspraakExtraError; }
            set
            {
                afspraakExtraError = value;
                RaisePropertyChanged(nameof(AfspraakExtraError));
            }
        }

        public bool AfspraakExtraErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(AfspraakExtraError); }
        }

        private DateTime afspraakDatum;
        public DateTime AfspraakDatum
        {
            get { return afspraakDatum; }
            set { afspraakDatum = value; }
        }

        public override void Init(object initData) //async
        {
            base.Init(initData);

            huidigeAfspraak = initData as Afspraak;
            LoadItemState();
            AfspraakGeboortedatum = DateTime.Now;
        }

        private bool Validate(Afspraak afspraak)
        {

            var validationResult = afspraakValidator.Validate(afspraak);
            foreach (var error in validationResult.Errors)
            {
                if (error.PropertyName == nameof(afspraak.Naam))
                {
                    AfspraakNaamError = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(afspraak.Voornaam))
                {
                    AfspraakVoornaamError = error.ErrorMessage;
                }
                //if (error.PropertyName == nameof(afspraak.Geboortedatum))
                //{
                //    //AfspraakGeboortedatumEror == error.ErrorMessage;
                //}
                if (error.PropertyName == nameof(afspraak.Telefoonnummer))
                {
                    AfspraakTelefoonError = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(afspraak.EmailAdres))
                {
                    AfspraakEmailError = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(afspraak.GekendePatient))
                {
                    AfspraakGekendError = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(afspraak.ExtraInfo))
                {
                    AfspraakExtraError = error.ErrorMessage;
                }

            }
            return validationResult.IsValid;
        }

        public ICommand BewaarAfspraakCommand
        {
            get
            {
                return new Command(async () =>
                {
                    SaveItemState();
                    if (Validate(huidigeAfspraak))
                    {
                        if (await AfsprakenService.Bewaar(huidigeAfspraak))
                        {
                            VoegAfspraakToeAgenda();
                        }
                        await CoreMethods.PopPageModel(huidigeAfspraak);
                    }
                });
            }
        }

        private void LoadItemState()
        {
            AfspraakNaam = huidigeAfspraak.Naam;
            AfspraakVoornaam = huidigeAfspraak.Voornaam;
            AfspraakGeboortedatum = huidigeAfspraak.Geboortedatum;
            AfspraakTelefoon = huidigeAfspraak.Telefoonnummer; //.ToString();
            afspraakEmail = huidigeAfspraak.EmailAdres;
            AfspraakGekend = huidigeAfspraak.GekendePatient;
            AfspraakExtra = huidigeAfspraak.ExtraInfo;
            AfspraakDatum = huidigeAfspraak.AfspraakDatum;
        }

        private void SaveItemState()
        {
            huidigeAfspraak.Naam = AfspraakNaam;
            huidigeAfspraak.Voornaam = AfspraakVoornaam;
            huidigeAfspraak.Geboortedatum = AfspraakGeboortedatum;
            huidigeAfspraak.Telefoonnummer = AfspraakTelefoon; //int.Parse(AfspraakTelefoon);
            huidigeAfspraak.EmailAdres = AfspraakEmail;
            huidigeAfspraak.GekendePatient = AfspraakGekend;
            huidigeAfspraak.ExtraInfo = AfspraakExtra;
            huidigeAfspraak.AfspraakDatum = AfspraakDatum;
        }

        private void VoegAfspraakToeAgenda()
        {
            var afspraakMaker = DependencyService.Get<IDevicePhone>();

            if (afspraakMaker != null)
            {
                var afspraak = new DataAgendaTelefoon
                {
                    AgendaDatum = huidigeAfspraak.AfspraakDatum.Date,
                    AgendaTijd = huidigeAfspraak.AfspraakDatum.TimeOfDay,
                    Beschrijving = huidigeAfspraak.ExtraInfo,
                    Titel = "Afspraak bij Dr. Alderweireld",
                    WaarEnWanneer = "De praktijk"
                };
                afspraakMaker.AddAppointment(afspraak);
            }
        }
    }
}
