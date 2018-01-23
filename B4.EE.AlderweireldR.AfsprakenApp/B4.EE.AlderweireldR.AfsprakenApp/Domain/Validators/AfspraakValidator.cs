using B4.EE.AlderweireldR.AfsprakenApp.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace B4.EE.AlderweireldR.AfsprakenApp.Domain.Validators
{
    public class AfspraakValidator : AbstractValidator<Afspraak>
    {
        public AfspraakValidator()
        {
            RuleFor(afspraak => afspraak.Naam)
                .NotEmpty()
                .WithMessage("Naam mag niet leeg zijn!")
                .Length(3, 20)
                .WithMessage("Lengte moet tussen 3 en 30 liggen!");

            RuleFor(afspraak => afspraak.Voornaam)
                .NotEmpty()
                .WithMessage("Voornaam mag niet leeg zijn!")
                .Length(3, 15)
                .WithMessage("Lengte moet tussen 2 en 30 liggen!");

            RuleFor(afspraak => afspraak.Geboortedatum)
                .NotEmpty()
                .WithMessage("Geboortedatum moet ingevuld zijn!");

            RuleFor(afspraak => afspraak.Telefoonnummer)
                .NotEmpty()
                .WithMessage("Telefoonnummer mag niet leeg zijn!")
                .Length(9, 10)
                .WithMessage("Telefoonnummer moet 9 of 10 cijfers bevatten!");

            RuleFor(afspraak => afspraak.EmailAdres)
                //.NotEmpty()
                //.WithMessage("E-mailadres mag niet leeg zijn!");
                .Length(12, 40)
                .WithMessage("E-mailadres moet tussen 12 en 40 karakters liggen!");

            //gekende patiënt
            RuleFor(afspraak => afspraak.GekendePatient)
                .NotEmpty()
                .WithMessage("Dit veld mag niet leeg zijn!");

            RuleFor(afspraak => afspraak.ExtraInfo)
                //.NotEmpty()
                //.WithMessage("Extra info mag niet leeg zijn! Voorbeeld: reden van afspraak.")
                .Length(2, 80)
                .WithMessage("Bericht moet tussen 2 en 80 karakters liggen!");
        }
    }
}
