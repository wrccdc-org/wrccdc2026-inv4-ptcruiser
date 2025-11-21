using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CarTracker.Models;

public class Status
{
	[Required]
	public int Id { get; set; }
	[ForeignKey(nameof(Car))]
	public string Vin { get; set; }
	[Required]
	public bool WarrantyStatus { get; set; }
	public decimal? Latitude { get; set; }
	public decimal? Longitude { get; set; }
}