using FinalProjectWithRepositoryDesignPattern.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectWithRepositoryDesignPattern.DAL;

public class AppDbContext:IdentityDbContext<AppUser>
{
	public AppDbContext(DbContextOptions<AppDbContext> options):base(options)		{}
	public DbSet<Slider> Sliders { get; set; }
	public DbSet<Contact> Contacts { get; set; }
	public DbSet<Statistic> Statistics { get; set; }
	public DbSet<AboutUs> AboutUs { get; set; }
	public DbSet<AboutAction> AboutActions { get; set; }
	public DbSet<Setting> Settings { get; set; }
	public DbSet<Developer> Developers { get; set; }
	public DbSet<Project> Projects { get; set; }
	public DbSet<ChooseUs> ChooseUs { get; set; }
	public DbSet<ChooseUsActions> ChooseUsActions { get; set; }
	public DbSet<User> Users { get; set; }
	public DbSet<Quote> Quotes { get; set; }
	public DbSet<Service> Services { get; set; }
	public DbSet<Comment> Comments { get; set; }

}
