namespace projekt_blogic.Models.Products
{
    public class Product
    {
        public int ProductID { get; set; }
        public DateTime DateCreated { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateUpdated { get; set; }
        public int UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }

        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public string ImageUrl { get; set; }

        public IFormFile Image { get; set; }

        public Product () { }

        public Product (int productID, int createdBy, int updatedBy, bool isDeleted, string name, int price, int quantity, string imageUrl, IFormFile image)
        {
            ProductID = productID;
            DateCreated = DateTime.Now;
            CreatedBy = createdBy;
            IsDeleted = isDeleted;
            Name = name;
            Price = price;
            Quantity = quantity;
            ImageUrl = imageUrl;
            Image = image;
        }
    }
}
