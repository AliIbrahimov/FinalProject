using FinalProjectWithRepositoryDesignPattern.DAL;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Concrete.EntityFramework;
using FinalProjectWithRepositoryDesignPattern.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration["ConnectionStrings:Default"]);
});
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<ISliderRepository, EFSliderRepository>();
builder.Services.AddScoped<IContactRepository, EFContactRepository>();
builder.Services.AddScoped<IStatisticRepository, EFStatisticRepository>();
builder.Services.AddScoped<IAboutRepository,EFAboutRepository>();
builder.Services.AddScoped<ISettingRepository,EFSettingRepository>();
builder.Services.AddScoped<IChooseUsRepository,EFChooseUsRepository>();
builder.Services.AddScoped<IDeveloperRepository,EFDeveloperRepository>();
builder.Services.AddScoped<IUserRepository,EFUserRepository>();
builder.Services.AddScoped<IQuoteRepository,EFQuoteRepository>();
builder.Services.AddScoped<IProfileRepository,EFProfileRepository>();
builder.Services.AddScoped<IProjectRepository,EFProjectRepository>();
builder.Services.AddScoped<IServiceRepository,EFServiceRepository>();
builder.Services.AddScoped<ICommentRepository,EFCommentRepository>();
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
    options.User.RequireUniqueEmail = false;
}).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();
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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Account}/{action=Login}/{id?}"
    );
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.Run();
