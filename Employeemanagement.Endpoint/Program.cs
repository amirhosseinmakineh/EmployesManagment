using EmpeloyeeManagment.ApplicationnService.Services;
using EmployeeManagment.Domain.IRpositories;
using EployeeManagemnt.InfraStracture.Context;
using EployeeManagemnt.InfraStracture.Repositories;
using EployeeManagment.ApplicationService.Contract.IService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EmployeeManagmentContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeManagment"));
});
#region RegisterRepository
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IWorkHourRepository, WorkHourRepository>();
builder.Services.AddScoped<ISalaryRepository, SalaryRepository>();
#endregion
#region RegisterService
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IWorkHourService,WorkHourService>();
builder.Services.AddScoped<ISalaryService,SalaryService>();
#endregion
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
