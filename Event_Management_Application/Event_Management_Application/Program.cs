using Event_Management_Application_Controllers.Controllers;
using Event_Management_Application_Controllers.Services;
using Event_Management_Application_Models.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EventManagmentDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbcs")));

builder.Services.AddTransient<IAttendee , AttendeeController>();
builder.Services.AddTransient<IEvent, EventController>();
builder.Services.AddTransient<IRegistration, RegisterationController>();

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
