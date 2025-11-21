using Microsoft.EntityFrameworkCore;
using CarTracker.Models;

namespace CarTracker.Data;

public partial class ApplicationDatabaseContext : DbContext
{
	public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options)
	{
		
	}
}