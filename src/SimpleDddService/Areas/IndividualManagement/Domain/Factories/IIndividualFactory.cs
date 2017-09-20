using System;
using SimpleDddService.Areas.IndividualManagement.Domain.Models;

namespace SimpleDddService.Areas.IndividualManagement.Domain.Factories
{
    public interface IIndividualFactory
    {
        Individual CreateIndividual(string firstName, string lastName, IndividualGender gender, DateTime birthDate);
    }
}