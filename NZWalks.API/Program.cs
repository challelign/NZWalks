using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Mappings;
using NZWalks.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Injecting the DbContext
builder.Services.AddDbContext<NZWalksDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("NZWalksConnectionString")));


builder.Services.AddScoped<IRegionRepositoy, SQLRegionRepository>();
//builder.Services.AddScoped<IRegionRepositoy, InMemoryRegionRepository>();

//Injecting SQLWalkRepository
builder.Services.AddScoped<IWalkRepository, SQLWalkRepository>();

//Injecting AutoMapper

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();



///*    using (var scope = app.Services.CreateScope())
//    {
//        var dbContext = scope.ServiceProvider.GetRequiredService<NZWalksDbContext>();
//        dbContext.Walks.RemoveRange(dbContext.Walks);
//        dbContext.Regions.RemoveRange(dbContext.Regions);
//        dbContext.Difficulties.RemoveRange(dbContext.Difficulties);
//        dbContext.SaveChanges();
//    }*/
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
