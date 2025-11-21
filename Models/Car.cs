using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CarTracker.Models;

public class Car
{
	[Required]
	public int Id { get; set; }
	[Required]
	public string Vin { get; set; }
	[Required]
	public int Year { get; set; }
	[Required]
	public string Make { get; set; }
	public string? Model { get; set; }
	
}