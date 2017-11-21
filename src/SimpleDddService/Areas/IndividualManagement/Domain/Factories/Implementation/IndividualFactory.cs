using System;
using Microsoft.AspNetCore.Http;
using SimpleDddService.Areas.IndividualManagement.Domain.Models;

namespace SimpleDddService.Areas.IndividualManagement.Domain.Factories.Implementation
{
    public class IndividualFactory : IIndividualFactory
    {
        private readonly IHttpContextAccessor _http;

        public IndividualFactory(IHttpContextAccessor http)
        {
            _http = http;
        }

        public Individual CreateIndividual(string firstName, string lastName, IndividualGender gender, DateTime birthDate)
        {
            var result = new Individual(firstName, lastName, gender, birthDate);
            return result;
        }
    }
}