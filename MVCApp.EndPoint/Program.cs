using App.Domain.AppServices.CardAggrigate;
using App.Domain.AppServices.TransactionAggrigate;
using App.Domain.Core.Bank.CardAggrigate.Contracts.AppService;
using App.Domain.Core.Bank.CardAggrigate.Contracts.Repository;
using App.Domain.Core.Bank.CardAggrigate.Contracts.Service;
using App.Domain.Core.Bank.TransactionAggrigate.AppService;
using App.Domain.Core.Bank.TransactionAggrigate.Contracts;
using App.Domain.Services.Bank.CardServices;
using App.Domain.Services.Bank.TranactionServices;
using App.Infra.DataAccess.EF.CardAggrigate;
using App.Infra.DataAccess.EF.TransactionAggrigate;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICardAppService, CardAppService>();
builder.Services.AddScoped<ITransactionAppService, TransactionAppService>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<ITransactionService, TransActionService>();
builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=LogIn}/{id?}");

app.Run();
