using ElasticsearchAPI.Models;

namespace ElasticsearchAPI.Repository
{
    public interface IElasticReposiyory
    {
        Task<bool> ChekIndex(string indexName);
        Task<bool> CreateIndexAsync();
        Task<bool> InsertAsync(Product product);
        Task<bool> InsertAsync(List<Product> product);
        Task<Product> GetAsync(string id);
        Task<List<Product>> GetAllAsync();
        Task<bool> UpdateAsync(Product product);
        Task<bool> DeleteByIdAsync(string id);
    }
}
