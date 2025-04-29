namespace ApiProjectCamp.WebApi.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategorName { get; set; }
        public List<Product> Products { get; set; }
        
    }
}
