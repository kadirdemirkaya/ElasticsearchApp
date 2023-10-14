using ElasticsearchAPI.Repository;
using ElasticsearchAPI.Services;
using ElasticSearchCommon.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddElasticSearchBuilder(conf =>
{
    conf.ApplicationName = builder.Configuration["ElasticSearch:ApplicationName"];
    conf.DefaultIndex = builder.Configuration["ElasticSearch:DefaultIndex"];
    conf.ElasticUrl = builder.Configuration["ElasticSearch:ElasticUrl"]!;
    conf.Password = builder.Configuration["ElasticSearch:Password"];
    conf.UserName = builder.Configuration["ElasticSearch:UserName"];
}, builder.Configuration);

builder.Services.AddElasticSearch(conf =>
{
    conf.ApplicationName = builder.Configuration["ElasticSearch:ApplicationName"];
    conf.DefaultIndex = builder.Configuration["ElasticSearch:DefaultIndex"];
    conf.ElasticUrl = builder.Configuration["ElasticSearch:ElasticUrl"]!;
    conf.Password = builder.Configuration["ElasticSearch:Password"];
    conf.UserName = builder.Configuration["ElasticSearch:UserName"];
});

builder.Services.AddScoped<IElasticReposiyory, ElasticReposiyory>();
builder.Services.AddScoped<IElasticService, ElasticService>();

var app = builder.Build();

app.AddElasticSearchApp(builder.Configuration);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();