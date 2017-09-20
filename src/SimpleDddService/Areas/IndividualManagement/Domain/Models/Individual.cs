using System;
using System.Collections.Generic;
using SimpleDddService.Infrastructure.DomainExtensions.Invariance;
using SimpleDddService.Infrastructure.DomainExtensions.ModelAbstractions;

namespace SimpleDddService.Areas.IndividualManagement.Domain.Models
{
    public class Individual : AggregateRoot
    {
        private Addresses _addresses;

        public Individual(string firstName, string lastName, IndividualGender gender, DateTime birthDate) : this()
        {
            Guard.StringNotNullorEmpty(() => firstName);
            Guard.StringNotNullorEmpty(() => lastName);
            Guard.ObjectNotNull(() => birthDate);

            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            BirthDate = birthDate;
        }

        protected Individual() 
        {
            _addresses = new Addresses();
        }

        public IReadOnlyCollection<Address> Addresses => _addresses.Entries;
        public DateTime BirthDate { get; private set; }
        public string FirstName { get; private set; }
        public IndividualGender Gender { get; private set; }
        public string LastName { get; private set; }

        public void AddOrUpdateAddress(Address address)
        {
            _addresses.AddOrUpdateAddress(address);
        }
    }
}