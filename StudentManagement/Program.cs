using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.DLL.Entity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("StudentManagementContextConnection");
builder.Services.AddDbContext<StudentManagementContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<StudentIdentity, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<StudentManagementContext>()
    .AddTokenProvider<DataProtectorTokenProvider<StudentIdentity>>(TokenOptions.DefaultProvider);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc(mvcOtions => mvcOtions.EnableEndpointRouting = false)
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddMvc().AddRazorPagesOptions(options => { options.Conventions.AddAreaPageRoute("Identity", "/Account/Login","");});

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
app.UseAuthentication();
app.UseAuthorization();


//    //app.UseEndpoints(endpoints =>
//    //{
//    //    endpoints.MapControllerRoute(
//    //      name: "areas",
//    //      pattern: "{area:Identity}/{controller=Login}/{action=Login}/{id?}"
//    //    );
//    //});

app.UseMvc(routes =>
{
    routes.MapAreaRoute(
                name: "default",
                areaName: "Identity",
                template: "{controller=Account}/{action=Login}");

    routes.MapAreaRoute(
               name: "Account",
               areaName: "StudentDetails",
               template: "{controller=Account}/{action=Index}/{id?}");
});

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
