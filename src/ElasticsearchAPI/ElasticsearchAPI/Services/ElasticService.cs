using ElasticsearchAPI.Enums;
using ElasticsearchAPI.Models;
using Nest;

namespace ElasticsearchAPI.Services
{
    public class ElasticService : IElasticService
    {
        private readonly IConfiguration _configuration;
        private readonly IElasticClient _elasticClient;

        public ElasticService(IConfiguration configuration, IElasticClient elasticClient)
        {
            _configuration = configuration;
            _elasticClient = new ElasticClient(ElasticSetting());
        }

        public ConnectionSettings ElasticSetting() => new ConnectionSettings(new Uri(_configuration["ElasticSearch:ElasticUrl"]));

        public async Task<List<Product>> AutoCompleteWithSearch(string indexName, string keyword)
        {
            var response = await _elasticClient.SearchAsync<Product>(s => s
                .Index(indexName.ToLower())
                .Query(q => q
                    .MatchPhrasePrefix(mp => mp
                        .Field(f => f.Name)
                        .Query(keyword.ToLower())
                        .MaxExpansions(10)))
                .Size(1));
            if (response.IsValid)
                return response.Documents.ToList();
            return null;
        }

        public async Task<List<Product>> AutoComplete(string indexName, string keyword)
        {
            var response = await _elasticClient.SearchAsync<Product>(s => s
                      .From(0)
                      .Take(10)
                      .Index(indexName.ToLower())
                      .Query(q => q
                      .Bool(b => b
                      .Should(m => m
                      .Wildcard(w => w
                      .Field(f => f.Name)
                      .Value(keyword.ToLower() + "*"))))));
            if (response.IsValid)
                return response.Documents.ToList();
            return default;
        }

        public async Task<List<Product>> CategoryFilter(string indexName, Category category)
        {
            var response = await _elasticClient.SearchAsync<Product>(s => s
                 .Index(indexName.ToLower())
                 .Query(q => q
                     .Bool(b => b
                         .Must(
                             st => st.Match(m => m
                                 .Field(f => f.Category)
                                 .Query(((int)category).ToString())
                             )
                         )
                     )
                 )
             );
            if (response.IsValid)
                return response.Documents.ToList();
            return default;
        }

        public async Task<List<Product>> CountryFilter(string indexName, Country country)
        {
            var response = await _elasticClient.SearchAsync<Product>(s => s
                .Index(indexName.ToLower())
                .Query(q => q
                    .Bool(b => b
                        .Must(
                            st => st.Term(t => t.
                                Field(f => f.Country)
                                .Value(country))
                        )
                    )
                )
            );
            if (response.IsValid)
                return response.Documents.ToList();
            return default;
        }
    }
}
