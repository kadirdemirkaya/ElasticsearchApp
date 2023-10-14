using Elastic.CommonSchema;
using ElasticsearchAPI.Models;
using ElasticSearchCommon.Repositories;
using Nest;

namespace ElasticsearchAPI.Repository
{
    public class ElasticReposiyory : IElasticReposiyory
    {
        private readonly IElasticSearchRepository<Product> _elasticSearchRepository;
        private readonly IElasticClient _elasticClient;

        public ElasticReposiyory(IElasticSearchRepository<Product> elasticSearchRepository, IElasticClient elasticClient)
        {
            _elasticSearchRepository = elasticSearchRepository;
            _elasticClient = elasticClient;
        }

        public async Task<bool> ChekIndex(string indexName)
        {
            bool result = await _elasticSearchRepository.ChekIndexAsync(indexName);
            if (result is false)
                await CreateIndexAsync();
            return result;
        }

        public async Task<bool> CreateIndexAsync()
        {
            bool result = await _elasticSearchRepository.CreateIndexAsync(nameof(Product));
            return result;
        }

        public async Task<bool> DeleteByIdAsync(string id)
        {
            bool result = await _elasticSearchRepository.DeleteByIdAsync(id);
            return result;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            var datas = await _elasticSearchRepository.GetAllAsync();
            return datas.ToList();
        }

        public async Task<Product> GetAsync(string id)
        {
            var data = await _elasticSearchRepository.GetAsync(id);
            return data;
        }

        public async Task<bool> InsertAsync(Product product)
        {
            product.Name.ToLower();
            bool result = await _elasticSearchRepository.InsertAsync(product);
            return result;
        }

        public async Task<bool> InsertAsync(List<Product> product)
        {
            product.ForEach(p => p.Name.ToLower());
            bool result = await _elasticSearchRepository.InsertManyAsync(product);
            return result;
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            bool result = await _elasticSearchRepository.UpdateAsync(product);
            return result;
        }
    }
}
