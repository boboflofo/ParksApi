using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parks.Models;

namespace Parks.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class NationalParksController : ControllerBase
  {
    private readonly ParksDbContext _db;

    public NationalParksController(ParksDbContext db)
    {
      _db = db;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<NationalPark>>> Get()
    {
      return await _db.NationalParks.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<NationalPark>> GetNationalPark(int id)
    {
      NationalPark nationalpark = await _db.NationalParks.FindAsync(id);

      if (nationalpark == null)
      {
        return NotFound();
      }

      return nationalpark;
    }
     [HttpPost]
    public async Task<ActionResult<NationalPark>> Post(NationalPark nationalpark)
    {
      _db.NationalParks.Add(nationalpark);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetNationalPark), new { id = nationalpark.NationalParkId }, nationalpark);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, NationalPark nationalpark)
    {
      if (id != nationalpark.NationalParkId)
      {
        return BadRequest();
      }

      _db.NationalParks.Update(nationalpark);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!NationalParkExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    private bool NationalParkExists(int id)
    {
      return _db.NationalParks.Any(e => e.NationalParkId == id);
    }
  }
}