using CRUDHistory.DataAccess.Data;
using CRUDHistory.DataAccess.Repository;
using CRUDHistory.DataAccess.Repository.IRepository;
using CRUDHistory.Utility.SendingEmails;
using CRUDHistoryWeb.Hubs;
using Microsoft.EntityFrameworkCore;
using CRUDHistory.Utility.SendingEmails;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddCors(opt => {
    opt.AddPolicy("reactApp", policyBuilder => {
        policyBuilder.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddSignalR();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()){
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
    pattern: "{area=Admin}/{controller=Home}/{action=Index}/{id?}");

// end-point
app.MapHub<ChatHub>("/Chat");

app.UseCors("reactApp");

app.Run();