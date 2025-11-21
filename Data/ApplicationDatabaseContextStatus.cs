using Microsoft.EntityFrameworkCore;
using CarTracker.Models;

namespace CarTracker.Data;

public partial class ApplicationDatabaseContext
{
	public DbSet<Status> Status { get; set; }

	public async Task<List<Status>> GetAllStatusesAsync()
	{
		return await this.Status.ToListAsync();
	}
	
	public async Task<Status> GetStatusByVinAsync(string vin)
	{
		return await this.Status.FirstOrDefaultAsync(v => v.Vin == vin);
	}

	public void ChangeStatusByVin(string vin, bool warrantyStatus)
	{
		var status = new Status
		{
			Vin = vin
		};

		this.Attach(status);
		status.WarrantyStatus = warrantyStatus;
		this.Entry(status).Property(w => w.WarrantyStatus).IsModified = true;

		this.SaveChanges();
	}
}