using Food_Rescue;
using FoodRescue.Core;
using FoodRescue.Core.Repositories;
using FoodRescue.Core.Services;
using FoodRescue.Data;
using FoodRescue.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
	options.JsonSerializerOptions.WriteIndented = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<DataContext>();

builder.Services.AddScoped<IBusinessRepository,BusinessRepository>();
builder.Services.AddScoped<IBusinessService,BusinessService>();

builder.Services.AddScoped<ICharityRepository,CharityRepository>();
builder.Services.AddScoped<ICharityService, CharityService>();


builder.Services.AddScoped<IDonationRepository, DonationRepository>();
builder.Services.AddScoped<IDonationService, DonationService>();

builder.Services.AddAutoMapper(typeof(MappingProfile), typeof(Mapping));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
