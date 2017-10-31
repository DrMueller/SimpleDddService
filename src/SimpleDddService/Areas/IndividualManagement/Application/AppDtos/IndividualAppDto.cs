using System;

namespace SimpleDddService.Areas.IndividualManagement.Application.AppDtos
{
    public class IndividualAppDto
    {
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public IndividualGenderAppDto Gender { get; set; }
        public string Id { get; set; }
        public string LastName { get; set; }
    }
}