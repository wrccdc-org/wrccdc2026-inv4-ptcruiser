using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarTracker.Models;
using CarTracker.Data;

namespace CarTracker.Controllers;

public class HomeController : Controller
{
	private readonly ILogger<HomeController> _logger;
	private ApplicationDatabaseContext _dbcontext;

	public HomeController(ILogger<HomeController> logger, ApplicationDatabaseContext dbcontext)
	{
		_logger = logger;
		_dbcontext = dbcontext;
	}
	
	public IActionResult Index()
	{
		return View();
	}

	public IActionResult AllCars()
	{
		List<Car> cars = _dbcontext.Car.ToList();
		return View(cars);
	}
	
	public IActionResult Status()
	{
		List<Status> status = _dbcontext.Status.ToList();
		return View(status);
	}

	public IActionResult Privacy()
	{
		return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}