using GymApp.API;
using GymApp.API.Interfaces;
using GymApp.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IMembersService, MembersService>();
builder.Services.AddScoped<IMemberBmiRecordService, MemberBmiRecordService>();
builder.Services.AddScoped<IMemberHrRecordService, MemberHrRecordService>();
builder.Services.AddScoped<ITrainersService, TrainersService>();
builder.Services.AddScoped<IMemberTrainerLinkService, MemberTrainerLinkService>();
builder.Services.AddScoped<IResponseHelperService, ResponseHelperService>();

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
