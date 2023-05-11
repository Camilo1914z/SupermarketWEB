namespace SupermarketWEB.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public string Document_Number { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birhtday { get; set; }

        public ICollection<Provider>? Providers { get; set;}


    }
}
