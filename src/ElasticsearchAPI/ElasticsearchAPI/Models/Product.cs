using ElasticsearchAPI.Enums;
using ElasticSearchCommon.Models;
using Nest;

namespace ElasticsearchAPI.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public Country Country { get; set; }
    }
}
