using Microsoft.EntityFrameworkCore;
using repo_name.Models;

var builder = WebApplication.CreateBuilder(args);
// After Add services to the container.

// Add services to the container.
builder.Services.AddDbContext<RoiDatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add after RoiDatabaseContext Service configuration

// Define CORS policies to allow access to our API
builder.Services.AddCors(options => {

    // Build a default CORS policy
    options.AddDefaultPolicy(policy => {

        // Allow ANY origin to access our API
        policy.AllowAnyOrigin();

        // Allow SPECIFIC origins to access our API
        //policy.WithOrigins("http://localhost:19006", "https://app.roi.com.au");

        // Allow any HTTP header
        policy.AllowAnyHeader();

        // Allow any HTTP method
        policy.AllowAnyMethod();

    });
});
builder.Services.AddControllers();
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
// Add between app.UseHttpsRedirection();  and app.UseAuthorization();

// Enable CORS (default policy)
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
