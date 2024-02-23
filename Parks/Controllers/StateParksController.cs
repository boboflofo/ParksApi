using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parks.Models;

namespace Parks.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StateParksController : ControllerBase
  {
    private readonly ParksDbContext _db;

    public StateParksController(ParksDbContext db)
    {
      _db = db;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<StatePark>>> Get()
    {
      return await _db.StateParks.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StatePark>> GetStatePark(int id)
    {
      StatePark statepark = await _db.StateParks.FindAsync(id);

      if (statepark == null)
      {
        return NotFound();
      }

      return statepark;
    }
     [HttpPost]
    public async Task<ActionResult<StatePark>> Post(StatePark statepark)
    {
      _db.StateParks.Add(statepark);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetStatePark), new { id = statepark.StateParkId }, statepark);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, StatePark statepark)
    {
      if (id != statepark.StateParkId)
      {
        return BadRequest();
      }

      _db.StateParks.Update(statepark);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!StateParkExists(id))
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

    private bool StateParkExists(int id)
    {
      return _db.StateParks.Any(e => e.StateParkId == id);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStatePark(int id)
    {
      StatePark statepark = await _db.StateParks.FindAsync(id);
      if (statepark == null)
      {
        return NotFound();
      }

      _db.StateParks.Remove(statepark);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}