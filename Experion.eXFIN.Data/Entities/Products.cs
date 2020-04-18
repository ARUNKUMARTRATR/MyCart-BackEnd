namespace Experion.MyCart.Data.Entities
{
    public partial class Products
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string LaunchDate { get; set; }
        public string PhotoUrl { get; set; }
        public bool? IsAvailable { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CatogoryId { get; set; }

    }
}
