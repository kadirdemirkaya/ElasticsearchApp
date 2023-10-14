using ElasticsearchAPI.Enums;
using ElasticsearchAPI.Models;
using ElasticsearchAPI.Repository;
using ElasticsearchAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElasticsearchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly ILogger<FoodController> _logger;
        private readonly IElasticReposiyory _elasticReposiyory;
        private readonly IElasticService _elasticService;

        public FoodController(ILogger<FoodController> logger, IElasticReposiyory elasticReposiyory, IElasticService elasticService)
        {
            _logger = logger;
            _elasticReposiyory = elasticReposiyory;
            _elasticService = elasticService;
        }

        [HttpGet]
        [Route("ApplySeedData")]
        public async Task<IActionResult> ApplySeedData()
        {
            await SeedDatas();
            return Ok();
        }

        [HttpGet]
        [Route("AllProduct")]
        public async Task<IActionResult> AllProduct()
        {
            var datas = await _elasticReposiyory.GetAllAsync();
            return Ok(datas);
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            bool result = await _elasticReposiyory.InsertAsync(product);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromQuery] string id)
        {
            bool result = await _elasticReposiyory.DeleteByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetProduct")]
        public async Task<IActionResult> GetProduct([FromQuery] string id)
        {
            var data = await _elasticReposiyory.GetAsync(id);
            return Ok(data ?? null);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody]Product product)
        {
            bool result = await _elasticReposiyory.UpdateAsync(product);
            return Ok(result);
        }

        [HttpGet]
        [Route("AutoCompleteWithSearch")]
        public async Task<IActionResult> AutoCompleteWithSearch([FromQuery] string keyword)
        {
            var datas = await _elasticService.AutoComplete(nameof(Product), keyword);
            return datas is not null ? Ok(datas) : BadRequest(null);
        }

        [HttpGet]
        [Route("AutoComplete")]
        public async Task<IActionResult> AutoComplete([FromQuery] string keyword)
        {
            var datas = await _elasticService.AutoCompleteWithSearch(nameof(Product), keyword);
            return datas is not null ? Ok(datas) : BadRequest(null);
        }

        [HttpGet]
        [Route("CountryFilter")]
        public async Task<IActionResult> CountryFilter([FromQuery]Country country)
        {
            var datas = await _elasticService.CountryFilter(nameof(Product), country);
            return datas is not null ? Ok(datas) : BadRequest(null);
        }

        [HttpGet]
        [Route("CategoryFilter")]
        public async Task<IActionResult> CategoryFilter([FromQuery] Category category)
        {
            var datas = await _elasticService.CategoryFilter(nameof(Product), category);
            return datas is not null ? Ok(datas) : BadRequest(null);
        }

        private async Task SeedDatas()
        {
            var products = new List<Product>
            {
                new Product { Name = "Beijing Duck", Category = Category.CinMutfagi, Country = Country.Cin },
                new Product { Name = "Biryani", Category = Category.HintMutfagi, Country = Country.Hindistan },
                new Product { Name = "Burger", Category = Category.AmerikanMutfagi, Country = Country.Amerika },
                new Product { Name = "Butter Chicken", Category = Category.IspanyolMutfagi, Country = Country.Hindistan },
                new Product { Name = "Chimichanga", Category = Category.MeksikaMutfagi, Country = Country.Meksika },
                new Product { Name = "Churros", Category = Category.IspanyolMutfagi, Country = Country.Ispanya },
                new Product { Name = "Clam Chowder", Category = Category.AmerikanMutfagi, Country = Country.Amerika },
                new Product { Name = "Coq au Vin", Category = Category.FransizMutfagi, Country = Country.Fransa },
                new Product { Name = "Creme Brulee", Category = Category.FransizMutfagi, Country = Country.Fransa },
                new Product { Name = "Dim Sum", Category = Category.JaponMutfagi, Country = Country.Cin },
                new Product { Name = "Enchilada", Category = Category.MeksikaMutfagi, Country = Country.Meksika },
                new Product { Name = "Escargot", Category = Category.FransizMutfagi, Country = Country.Fransa },
                new Product { Name = "Fried Chicken", Category = Category.AmerikanMutfagi, Country = Country.Amerika },
                new Product { Name = "Gazpacho", Category = Category.IspanyolMutfagi, Country = Country.Ispanya },
                new Product { Name = "General Tsos Chicken", Category = Category.JaponMutfagi, Country = Country.Cin },
                new Product { Name = "Hot Dog", Category = Category.AmerikanMutfagi, Country = Country.Amerika },
                new Product { Name = "Kung Pao Chicken", Category = Category.JaponMutfagi, Country = Country.Cin },
                new Product { Name = "Lasagna", Category = Category.İtalyanMutfagi, Country = Country.Italya },
                new Product { Name = "Lahmacun", Category = Category.TurkMutfagi, Country = Country.Türkiye },
                new Product { Name = "Masala Dosa", Category = Category.IspanyolMutfagi, Country = Country.Hindistan },
                new Product { Name = "Paella", Category = Category.IspanyolMutfagi, Country = Country.Ispanya },
                new Product { Name = "Pizza", Category = Category.İtalyanMutfagi, Country = Country.Italya },
                new Product { Name = "Pulpo a la Gallega", Category = Category.IspanyolMutfagi, Country = Country.Ispanya },
                new Product { Name = "Ravioli", Category = Category.İtalyanMutfagi, Country = Country.Italya },
                new Product { Name = "Sashimi", Category = Category.JaponMutfagi, Country = Country.Japonya },
                new Product { Name = "Spaghetti Carbonara", Category = Category.İtalyanMutfagi, Country = Country.Italya },
                new Product { Name = "Sushi", Category = Category.JaponMutfagi, Country = Country.Japonya },
                new Product { Name = "Taco", Category = Category.MeksikaMutfagi, Country = Country.Meksika },
                new Product { Name = "Tempura", Category = Category.JaponMutfagi, Country = Country.Japonya },
                new Product { Name = "Tostada", Category = Category.MeksikaMutfagi, Country = Country.Meksika },
                new Product { Name = "Udon Noodles", Category = Category.JaponMutfagi, Country = Country.Japonya },
                new Product { Name = "Vindaloo", Category = Category.HintMutfagi, Country = Country.Hindistan }
            };
            products.ForEach(p => p.Name = p.Name.ToLower());
            if (await _elasticReposiyory.ChekIndex(nameof(Product).ToString()) is true ||
                        await _elasticReposiyory.ChekIndex(nameof(Product).ToString()) is false)
                await _elasticReposiyory.InsertAsync(products);
        }
    }
}
