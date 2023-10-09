using Azure.Storage.Blobs;
using FluentValidation;
using GymApp.API;
using GymApp.API.Interfaces;
using GymApp.API.Services;
using GymApp.API.Validators;
using Microsoft.EntityFrameworkCore;
using Models.Models;

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

builder.Services.AddSingleton(_ => new BlobServiceClient(builder.Configuration.GetValue<string>("AzureBlobStorageConnectionString")));
builder.Services.AddSingleton<IBlobService, BlobService>();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});

//builder.Services.AddScoped<IValidator<MembersValidator, Members>>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
