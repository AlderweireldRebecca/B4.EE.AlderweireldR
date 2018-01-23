using B4.EE.AlderweireldR.AfsprakenApp.Models;
using B4.EE.AlderweireldR.AfsprakenApp.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments;
using Windows.Foundation;
using Xamarin.Forms;

[assembly: Dependency(typeof(B4.EE.AlderweireldR.AfsprakenApp.UWP.Services.WindowsDevicePhone))]
namespace B4.EE.AlderweireldR.AfsprakenApp.UWP.Services
{
    class WindowsDevicePhone : IDevicePhone
    {
        public bool DoDevicePhone(string nummer)
        {
            Device.OpenUri(new Uri("tel:" + nummer));

            return true;
        }

        public async Task<bool> AddAppointment(DataAgendaTelefoon agendaAfspraak)
        {
            var appointmentRcd = new Windows.ApplicationModel.Appointments.Appointment();
            var date = agendaAfspraak.AgendaDatum;
            var time = agendaAfspraak.AgendaTijd;
            var timeZoneOffset = TimeZoneInfo.Local.GetUtcOffset(DateTime.Now);
            var startTime = new DateTimeOffset(date.Year, date.Month, date.Day, time.Hours, time.Minutes, 0, timeZoneOffset);
            appointmentRcd.StartTime = startTime;

            // Subject
            appointmentRcd.Subject = agendaAfspraak.Titel;
            // Location
            appointmentRcd.Location = agendaAfspraak.WaarEnWanneer;
            // Details
            appointmentRcd.Details = agendaAfspraak.Beschrijving;
            // Duration          
            appointmentRcd.Duration = TimeSpan.FromHours(1);
            // All Day
            appointmentRcd.AllDay = false;
            //Busy Status
            appointmentRcd.BusyStatus = Windows.ApplicationModel.Appointments.AppointmentBusyStatus.Busy;
            // Sensitivity
            appointmentRcd.Sensitivity = Windows.ApplicationModel.Appointments.AppointmentSensitivity.Public;
            Rect rect = new Rect(new Windows.Foundation.Point(10, 10), new Windows.Foundation.Size(100, 200));
            string retVal = await AppointmentManager.ShowAddAppointmentAsync(appointmentRcd, rect, Windows.UI.Popups.Placement.Default);
            return !string.IsNullOrEmpty(retVal);
        }
    }
}
