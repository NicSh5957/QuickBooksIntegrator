using QuickBooksIntegrator.Application.Interfaces;
using QuickBooksIntegrator.DTO.Bills;
using QuickBooksIntegrator.DTO.Checks;
using QuickBooksIntegrator.DTO.Companies;
using QuickBooksIntegrator.DTO.Invoices;
using QuickBooksIntegrator.DTO.ItemSales;
using QuickBooksIntegrator.Infrastructure.Configurations;
using QuickBooksIntegrator.Infrastructure.DataSources.QuickBooks;
using QuickBooksIntegrator.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var quickBooksConfig = builder.Configuration.GetSection("QuickBooksConfig").Get<QuickBooksConfig>();
builder.Services.AddSingleton(quickBooksConfig);

builder.Services.AddScoped<QuickBooksBaseService>(provider =>
{
    var config = provider.GetRequiredService<QuickBooksConfig>();
    var logger = provider.GetRequiredService<ILogger<QuickBooksBaseService>>();
    return new QuickBooksBaseService(config, logger);
});

builder.Services.AddScoped<IDataSource<CompanyDto>, QuickBooksCompanySource>();
builder.Services.AddScoped<IDataSource<InvoiceDto>, QuickBooksInvoiceSource>();
builder.Services.AddScoped<IDataSource<ItemSalesDto>, QuickBooksItemSalesSource>();
builder.Services.AddScoped<IDataSource<BillDto>, QuickBooksBillSource>();
builder.Services.AddScoped<IDataSource<CheckDto>, QuickBooksCheckSource>();

builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<BillService>();
builder.Services.AddScoped<CheckService>();
builder.Services.AddScoped<InvoiceService>();
builder.Services.AddScoped<ItemSalesService>();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();