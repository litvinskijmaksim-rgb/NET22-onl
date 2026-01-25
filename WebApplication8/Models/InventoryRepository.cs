namespace WebApplication8.Models
{
    public static class InventoryRepository
    {
        private static List<Product> products = new List<Product>();
        private static int nextId = 1;

      
        public static List<Product> GetAll()
        {
            return products;
        }

        
        public static Product GetById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }

        
        public static void Add(Product product)
        {
            product.Id = nextId;
            nextId++;
            products.Add(product);
        }

        
        public static void Update(Product product)
        {
            var oldProduct = GetById(product.Id);
            if (oldProduct != null)
            {
                oldProduct.Name = product.Name;
                oldProduct.Category = product.Category;
                oldProduct.Price = product.Price;
                oldProduct.Quantity = product.Quantity;
            }
        }

       
        public static void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                products.Remove(product);
            }
        }
    }
}