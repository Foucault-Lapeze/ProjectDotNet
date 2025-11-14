using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProjetDotNet.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Premier projet API en .NET",
        Description = "Premier projet API en .NET",
        TermsOfService = new Uri("https://google.com"),
        Contact = new OpenApiContact
        {
            Name = "Foucault",
            Email = "exemple@mail.com",
            Url = new Uri("https://google.com"),
        }
    });
    // Ajout de la lecture des commentaires XML
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddDbContext<BDDContext>(opt => opt.UseInMemoryDatabase("TodoListBDD"));
builder.Services.AddDbContext<BDDContext>(opt => opt.UseInMemoryDatabase("VoitureListBDD"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.MapControllers();
app.Run();
