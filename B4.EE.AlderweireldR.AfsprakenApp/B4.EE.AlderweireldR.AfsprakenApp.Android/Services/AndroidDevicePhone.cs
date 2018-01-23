using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Telephony;
using Android.Views;
using Android.Widget;
using B4.EE.AlderweireldR.AfsprakenApp.Models;
using B4.EE.AlderweireldR.AfsprakenApp.Services.Abstract;
using Xamarin.Forms;

[assembly: Dependency(typeof(B4.EE.AlderweireldR.AfsprakenApp.Droid.Services.AndroidDevicePhone))]
namespace B4.EE.AlderweireldR.AfsprakenApp.Droid.Services
{
    class AndroidDevicePhone : IDevicePhone
    {
        public bool DoDevicePhone(string nummer)
        {
            var context = Forms.Context;
            if (context == null)
                return false;

            var intent = new Intent(Intent.ActionCall);
            intent.SetData(Android.Net.Uri.Parse("tel:" + nummer));

            if (IsIntentAvailable(context, intent))
            {
                context.StartActivity(intent);
                return true;
            }

            return false;
        }

        public static bool IsIntentAvailable(Context context, Intent intent)
        {

            var packageManager = context.PackageManager;

            var list = packageManager.QueryIntentServices(intent, 0)
                .Union(packageManager.QueryIntentActivities(intent, 0));
            if (list.Any())
                return true;

            TelephonyManager mgr = TelephonyManager.FromContext(context);
            return mgr.PhoneType != PhoneType.None;
        }

        public Task<bool> AddAppointment(DataAgendaTelefoon agendaAfspraak)
        {
            //Intent intent = new Intent(Intent.ActionInsert);
            //intent.PutExtra(CalendarContract.Events.InterfaceConsts.Title, agendaAfspraak.Titel);
            //intent.PutExtra(CalendarContract.Events.InterfaceConsts.Description, agendaAfspraak.WaarEnWanneer + " " + agendaAfspraak.Beschrijving);
            //intent.PutExtra(CalendarContract.Events.InterfaceConsts.Dtstart, GetDateTimeMS(agendaAfspraak.ExpireDate.Value));
            //intent.PutExtra(CalendarContract.Events.InterfaceConsts.Dtend, GetDateTimeMS(appointment.ExpireDate.Value.AddHours(1)));
            //intent.PutExtra(CalendarContract.ExtraEventBeginTime, GetDateTimeMS(appointment.ExpireDate.Value));
            //intent.PutExtra(CalendarContract.ExtraEventEndTime, GetDateTimeMS(appointment.ExpireDate.Value.AddHours(1)));
            //intent.PutExtra(CalendarContract.Events.InterfaceConsts.EventTimezone, "UTC");
            //intent.PutExtra(CalendarContract.Events.InterfaceConsts.EventEndTimezone, "UTC");
            //intent.SetData(CalendarContract.Events.ContentUri);
            //((Activity)Forms.Context).StartActivity(intent);
            return new Task<bool>(() => { return true; });
        }
    }
}