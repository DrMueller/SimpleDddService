using System;

namespace SimpleDddService.Areas.IndividualManagement.Application.Dtos
{
    public class NewIndividualDto
    {
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public IndividualGenderDto Gender { get; set; }
        public string LastName { get; set; }
    }
}