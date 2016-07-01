namespace SuperZapatos.Models
{
    public class Article
    {
        public int id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long Price { get; set; }

        public int Total_in_shelf { get; set; }

        public int Total_in_vault { get; set; }

        public int StoreId { get; set; }

        public Store Store { get; set; }
    }
}