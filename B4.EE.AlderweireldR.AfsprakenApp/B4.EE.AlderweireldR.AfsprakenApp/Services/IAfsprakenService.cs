using B4.EE.AlderweireldR.AfsprakenApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace B4.EE.AlderweireldR.AfsprakenApp.Services
{
    public interface IAfsprakenService
    {
        //IEnumerable<Afspraak> Get();
        Task<IEnumerable<Afspraak>> Get(DateTime datum);
        Task<bool> Bewaar(Afspraak afspraak);
    }
}
