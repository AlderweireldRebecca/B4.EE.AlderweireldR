using B4.EE.AlderweireldR.AfsprakenApp.Models;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace B4.EE.AlderweireldR.AfsprakenApp.PageModels
{
    public class MainPageModel //: FreshBasePageModel
    {
        //public List<Dokter> Dokters { get; set; }

        //public MainPageModel()
        //{

        //}

        //public override void Init(object initData)
        //{
        //    base.Init(initData);
        //    Dokters = new List<Dokter>
        //    {
        //        new Dokter {Titel = "Dokter", Naam  = "Alderweireld", Voornaam="Rebecca" }
        //    };
        //}

        //public Dokter GeselecteerdeDokter
        //{
        //    get { return null; }
        //    set
        //    {
        //        CoreMethods.PushPageModel<AgendaPageModel>(value);
        //        //RaisePropertyChanged();
        //    }
        //}

    //    private Dokter _geselecteerdeDokter = null;
    //    private Dokter _returnDokter = null;

    //    public ObservableCollection<Dokter> Dokters { get; private set; }

    //    public Dokter GeselecteerdeDokter
    //    {
    //        get { return _geselecteerdeDokter; }
    //        set
    //        {
    //            _geselecteerdeDokter = value;
    //            if (value != null) ZieAgendaCommand.Execute(value);
    //        }
    //    }

    //    public MainPageModel()
    //    {
    //        Dokters = new ObservableCollection<Dokter>();
    //    }

    //    //public override void Init(object initData)
    //    //{
    //    //    base.Init(initData);
    //    //}


    //    public override void ReverseInit(object returnedData)
    //    {
    //        _returnDokter = returnedData as Dokter;
    //        if (_returnDokter != _geselecteerdeDokter)
    //        {
    //            Dokters.Add(_returnDokter);
    //        }
    //        base.ReverseInit(returnedData);
    //    }

    //    public ICommand ZieAgendaCommand
    //    {
    //        get
    //        {
    //            return new Command(async (dokter) =>
    //            {
    //                await CoreMethods.PushPageModel<AgendaPageModel>(dokter);
    //            });
    //        }
    //    }

    //    private void LaadDokters()
    //    {
    //        Dokters.Clear();
    //        Dokters.Add(new Dokter()
    //        {
    //            Titel = "Dokter",
    //            Naam = "Alderweireld",
    //            Voornaam = "Rebecca"
    //        });
    //    }
    }
}
