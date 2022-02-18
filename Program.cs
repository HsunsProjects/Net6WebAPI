using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
 {
 options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
 options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
 options.JsonSerializerOptions.WriteIndented = true;
 });
builder.Services.AddMvcCore().AddJsonOptions(options =>
{
 options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
 options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
 options.JsonSerializerOptions.WriteIndented = true;
});
builder.Services.AddMvc().AddJsonOptions(options =>
{
 options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
 options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
 options.JsonSerializerOptions.WriteIndented = true;
});
builder.Services.AddRazorPages().AddJsonOptions(options =>
{
 options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
 options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
 options.JsonSerializerOptions.WriteIndented = true;
});;


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
