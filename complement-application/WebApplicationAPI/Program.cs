using System.Text.Json.Serialization;
using WebApplicationAPI.Configurations;
using WebApplicationPersistence.DbContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    // convert all enums to their string representation
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddSqlite<PcrContext>(builder.Configuration.GetConnectionString("PcrDatabase"));
builder.Services.AddAutoMapper(typeof(DtosAutoMapperConfigurations).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "WebApplicationAPI.xml"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();