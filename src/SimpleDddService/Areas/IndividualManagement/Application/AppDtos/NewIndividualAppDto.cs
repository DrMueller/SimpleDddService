using System;

namespace SimpleDddService.Areas.IndividualManagement.Application.AppDtos
{
    public class NewIndividualAppDto
    {
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public IndividualGenderAppDto Gender { get; set; }
        public string LastName { get; set; }
    }
}