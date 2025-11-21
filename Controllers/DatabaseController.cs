using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using CarTracker.Data;
using CarTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace CarTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DatabaseController : Controller
{
	private readonly ApplicationDatabaseContext _context;
	public DatabaseController(ApplicationDatabaseContext context)
	{
		_context = context;
	}
	
	// GET: api/Status
	[HttpGet]
	public async Task<ActionResult<IEnumerable<Status>>> WarrantyStatus()
	{
		return await _context.Status.ToListAsync();
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<Status>> GetStatus(int id)
	{
		var status = await _context.Status.FindAsync(id);
		if (status == null)
		{
			return NotFound();
		}
		return status;
	}

	[HttpPost]
	public ActionResult<Status> ChangeStatus(Status status)
	{
		if (ModelState.IsValid)
		{
			_context.Status.Update(status);
			_context.SaveChanges();
			return RedirectToAction(nameof(WarrantyStatus));
		}
		
		return BadRequest(ModelState);
	}

	private bool CarExists(int id)
	{
		return _context.Car.Any(e => e.Id == id);
	}
}