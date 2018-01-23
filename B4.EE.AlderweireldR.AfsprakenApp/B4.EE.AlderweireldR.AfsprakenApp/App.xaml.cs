using B4.EE.AlderweireldR.AfsprakenApp.Domain.Validators;
using B4.EE.AlderweireldR.AfsprakenApp.PageModels;
using B4.EE.AlderweireldR.AfsprakenApp.Services;
using FluentValidation;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace B4.EE.AlderweireldR.AfsprakenApp
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            //FreshIOC.Container.Register<IValidator, AfspraakValidator>();
            //FreshIOC.Container.Register<IAfsprakenService, AfsprakenMemoryService>();

            //MainPage = new B4.EE.AlderweireldR.AfsprakenApp.MainPage();
            var pagina = FreshPageModelResolver.ResolvePageModel<AgendaPageModel>();
            var houder = new FreshNavigationContainer(pagina);
            MainPage = houder;
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
