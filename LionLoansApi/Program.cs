using System;
using LionLoansApi.DAL;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<SQLDAL>()
    .AddDefaultTokenProviders();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UserService>();
builder.Services.AddSingleton<VerificationService>();
builder.Services.AddSingleton<StorageService>();
//builder.Services.AddHttpClient<SmsService>();

builder.Services.AddTransient<EmailService>();

// Register SmsService
builder.Services.AddTransient<SmsService>();

// Register BlockchainService
//builder.Services.AddSingleton<BlockchainService>(new BlockchainService(
//    rpcUrl: builder.Configuration["Blockchain:RpcUrl"],
//    contractAddress: builder.Configuration["Blockchain:ContractAddress"],
//    abi: builder.Configuration["Blockchain:Abi"]
//));
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
