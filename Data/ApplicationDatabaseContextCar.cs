using Microsoft.EntityFrameworkCore;
using CarTracker.Models;

namespace CarTracker.Data;

public partial class ApplicationDatabaseContext
{
	public DbSet<Car> Car { get; set; }
	
	public async Task<List<Car>> GetAllCarsAsync()
	{
		return await this.Car.ToListAsync();
	}

	public async Task<Car> GetCarByVinAsync(string vin)
	{
		return await this.Car.FirstOrDefaultAsync(v => v.Vin == vin);
	}
}