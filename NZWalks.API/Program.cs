using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Mappings;
using NZWalks.API.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Injecting the DbContext
builder.Services.AddDbContext<NZWalksDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("NZWalksConnectionString")));

//Injecting Auth DbContext
builder.Services.AddDbContext<NZWalksAuthDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("NZWalksAuthConnectionString")));


builder.Services.AddScoped<IRegionRepositoy, SQLRegionRepository>();
//builder.Services.AddScoped<IRegionRepositoy, InMemoryRegionRepository>();

//Injecting SQLWalkRepository
builder.Services.AddScoped<IWalkRepository, SQLWalkRepository>();

//Injecting AutoMapper

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

//adds user authentication and authorization to your application
builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("NZWalks")
    .AddEntityFrameworkStores<NZWalksAuthDbContext>()
    .AddDefaultTokenProviders();


//configures the password policies
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

});

// Authontication 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer =true,
    ValidateAudience =true,
    ValidateLifetime =true,
    ValidateIssuerSigningKey =true,
    ValidIssuer = builder.Configuration["Jwt:Issuer"],
    ValidAudience = builder.Configuration["Jwt:Audience"],
    IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

});

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

// Authenticate User
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
