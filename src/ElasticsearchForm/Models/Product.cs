using ElasticsearchForm.Enums;

namespace ElasticsearchForm.Models
{
    public class Product 
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public Country Country { get; set; }
    }
}
