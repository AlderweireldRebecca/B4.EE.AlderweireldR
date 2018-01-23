using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B4.EE.AlderweireldR.AfsprakenApp.Models;
using B4.EE.AlderweireldR.AfsprakenApp.Services.Abstract;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(B4.EE.AlderweireldR.AfsprakenApp.iOS.Services.AppleDevicePhone))]
namespace B4.EE.AlderweireldR.AfsprakenApp.iOS.Services
{
    class AppleDevicePhone : IDevicePhone
    {
        public Task<bool> AddAppointment(DataAgendaTelefoon agendaAfspraak)
        {
            throw new NotImplementedException();
        }

        public bool DoDevicePhone(string nummer)
        {
            return UIApplication.SharedApplication.OpenUrl(
                new NSUrl("tel:" + nummer));
        }
    }
}