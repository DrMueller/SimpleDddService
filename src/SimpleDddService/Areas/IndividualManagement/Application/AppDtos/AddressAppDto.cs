namespace SimpleDddService.Areas.IndividualManagement.Application.AppDtos
{
    public class AddressAppDto
    {
        public AddressTypeAppDto AddressType { get; set; }
        public string City { get; set; }
        public string Id { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
    }
}