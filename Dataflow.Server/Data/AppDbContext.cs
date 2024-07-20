using Microsoft.EntityFrameworkCore;
using Dataflow.Shared.Models;

namespace Dataflow.Server.Data
{
	public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
	{
		public DbSet<User> Users { get; set; }
    }
}
