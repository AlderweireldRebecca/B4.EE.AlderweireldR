using B4.EE.AlderweireldR.AfsprakenApp.Models;
using B4.EE.AlderweireldR.AfsprakenApp.Services;
using B4.EE.AlderweireldR.AfsprakenApp.Services.Abstract;
using FreshMvvm;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace B4.EE.AlderweireldR.AfsprakenApp.PageModels
{
    public class AgendaPageModel : FreshBasePageModel
    {
        private readonly IAfsprakenService AfsprakenService;

        private DateTime _huidigeDatum;
        public DateTime HuidigeDatum
        {
            get { return _huidigeDatum; }
            set
            {
                _huidigeDatum = value;
                RaisePropertyChanged();
                GetAfspraken();
                RaisePropertyChanged(nameof(Afspraken));
            }
        }

        private ObservableCollection<Afspraak> _afspraken;
        public ObservableCollection<Afspraak> Afspraken
        {
            get { return _afspraken; }
            set
            {
                _afspraken = value;
                RaisePropertyChanged();
            }
        }

        public DateTime MinimumDatum { get { return DateTime.Now; } }

        public DateTime MaximumDatum { get { return DateTime.Now.AddDays(56); } }
            

        public AgendaPageModel()
        {
            AfsprakenService = new AfsprakenMemoryService();
            HuidigeDatum = DateTime.Today;
            GetAfspraken();
            //ObservableCollection<Afspraak>;
            //Afspraken = new ObservableCollection<Afspraak>(AfsprakenService.Get());
            //Afspraken = new ObservableCollection<Afspraak>();
        }

        private async void GetAfspraken()
        {
            Afspraken = new ObservableCollection<Afspraak>(await AfsprakenService.Get(HuidigeDatum));
        }

        public ICommand MaakAfspraakCommand
        {
            get
            {
                return new Command(async (afspraak) =>
                {
                    await CoreMethods.PushPageModel<AgendaDetailPageModel>(afspraak);
                }, (afspraak) =>
                {
                    var afspraakInfo = afspraak as Afspraak;
                    return !afspraakInfo.IsGereserveerd && !Weekend(afspraakInfo);
                });
            }
        }

        private bool Weekend(Afspraak afspraak)
        {
            return afspraak.AfspraakDatum.DayOfWeek == DayOfWeek.Saturday || afspraak.AfspraakDatum.DayOfWeek == DayOfWeek.Sunday;
        }

        public override void ReverseInit(object returnedData)
        {
            base.ReverseInit(returnedData);

            if(returnedData is Afspraak)
            {
                GetAfspraken();
            }
        }

        public string Contact
        {
            get { return "0498769128"; }
        }

        public ICommand Bel
        {
            get
            {
                return new Command(() => OnPhoneTapped());
            }
        }

        private async void OnPhoneTapped()
        {
            if (await CoreMethods.DisplayAlert(
                             "Telefoonnummer bellen",
                             "Bel " + Contact + "?",
                             "Ja",
                             "Nee"))
            {
                var dialer = DependencyService.Get<IDevicePhone>();
                if (dialer != null)
                {
                    dialer.DoDevicePhone(Contact);
                }
            }
        }
    }
}
