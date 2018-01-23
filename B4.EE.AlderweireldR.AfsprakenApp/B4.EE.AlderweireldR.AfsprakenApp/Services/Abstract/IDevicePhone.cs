using B4.EE.AlderweireldR.AfsprakenApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace B4.EE.AlderweireldR.AfsprakenApp.Services.Abstract
{
    public interface IDevicePhone
    {
        bool DoDevicePhone(string nummer);

        Task<bool> AddAppointment(DataAgendaTelefoon agendaAfspraak);
    }
}
