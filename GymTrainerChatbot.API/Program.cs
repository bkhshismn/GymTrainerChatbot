﻿using GymTrainerChatbot.Infrastructure;
using GymTrainerChatbot.Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddHttpClient();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Gym Trainer Chatbot API", Version = "v1" });
});

builder.Services.AddScoped<OpenAiService>();
builder.Services.AddScoped<QuestionFilterService>();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gym Trainer Chatbot API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
