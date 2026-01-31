namespace FoodRescue.Core.Entities
{
    public class Business
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Donation> donations { get; set; }
    }
}
