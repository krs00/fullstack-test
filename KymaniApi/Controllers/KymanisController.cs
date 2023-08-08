using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KymaniApi.Models;

namespace KymaniApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KymanisController : ControllerBase
  {
    private readonly KymaniApiContext _db;

    public KymanisController(KymaniApiContext db)
    {
      _db = db;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Kymani>>> Get([FromQuery] string mood = null, [FromQuery] int powerLevel = 0)
    {
      IQueryable<Kymani> query = _db.Kymanis.AsQueryable();

      if (!string.IsNullOrEmpty(mood)) 
      {
        query = query.Where(entry => entry.Mood == mood);
      }

      if (powerLevel != 0)
      {
        query = query.Where(entry => entry.PowerLevel == powerLevel);
      }

      return await query.ToListAsync();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Kymani>> GetKymani(int id)
    {
      Kymani kymani = await _db.Kymanis.FindAsync(id);

      if (kymani == null)
      {
        return NotFound();
      }

      return kymani;
    }


    [HttpPost]
    public async Task<ActionResult<Kymani>> Post(Kymani kymani)
    {
      _db.Kymanis.Add(kymani);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetKymani), new { id = kymani.KymaniId }, kymani);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Kymani kymani)
    {
      if (id != kymani.KymaniId)
      {
        return BadRequest();
      }

      _db.Kymanis.Update(kymani);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!KymaniExists(id))
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


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteKymani(int id)
    {
      Kymani kymani = await _db.Kymanis.FindAsync(id);
      if (kymani == null)
      {
        return NotFound();
      }

      _db.Kymanis.Remove(kymani);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool KymaniExists(int id)
    {
      return _db.Kymanis.Any(e => e.KymaniId == id);
    }




  }
}