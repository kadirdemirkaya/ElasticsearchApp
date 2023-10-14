using ElasticsearchAPI.Enums;
using ElasticsearchAPI.Models;

namespace ElasticsearchAPI.Services
{
    public interface IElasticService
    {
        Task<List<Product>> AutoCompleteWithSearch(string indexName, string keyword);

        Task<List<Product>> AutoComplete(string indexName, string keyword);

        Task<List<Product>> CategoryFilter(string indexName, Category category);

        Task<List<Product>> CountryFilter(string indexName, Country country);
    }
}
