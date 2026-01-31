namespace FoodRescue.Core.Entities
{
	public class Donation
    {
        public int Id { get; set; }
        public int BusinessID { get; set; } 
        public Business Business { get; set; }
        public string FoodType { get; set; }
        public double Quantity { get; set; } // כמות ב-ק"ג
        public DateTime dateTime { get; set; }
        public bool IsClaimed { get; set; }
        public List<Charity> Charities { get; set; }
    }
}
