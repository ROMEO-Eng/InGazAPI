using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using InGazAPI.Models;

namespace InGazAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitsController : ControllerBase
    {
        private static List<Unit> _units = new List<Unit>
        {
            new Unit { Id = 1, Name = "Filtration Unit", IsActive = true },
            new Unit { Id = 2, Name = "Heating Unit", IsActive = true },
            new Unit { Id = 3, Name = "Measuring Unit", IsActive = true },
            new Unit { Id = 4, Name = "Reduction Unit", IsActive = true },
            new Unit { Id = 5, Name = "HSE Unit", IsActive = true }
        };

        // GET: api/Units
        [HttpGet]
        public ActionResult<IEnumerable<Unit>> GetUnits()
        {
            return Ok(_units);
        }

        // GET: api/Units/5
        [HttpGet("{id}")]
        public ActionResult<Unit> GetUnit(int id)
        {
            var unit = _units.FirstOrDefault(u => u.Id == id);
            if (unit == null)
                return NotFound();

            return Ok(unit);
        }

        // POST: api/Units
        [HttpPost]
        public ActionResult<Unit> CreateUnit([FromBody] Unit unit)
        {
            if (_units.Any(u => u.Id == unit.Id))
                return Conflict("Unit with the same ID already exists.");

            unit.Id = _units.Count > 0 ? _units.Max(u => u.Id) + 1 : 1;
            _units.Add(unit);
            return CreatedAtAction(nameof(GetUnit), new { id = unit.Id }, unit);
        }

        // PUT: api/Units/5
        [HttpPut("{id}")]
        public IActionResult UpdateUnit(int id, [FromBody] Unit updated)
        {
            var existing = _units.FirstOrDefault(u => u.Id == id);
            if (existing == null)
                return NotFound();

            existing.Name = updated.Name;
            existing.IsActive = updated.IsActive;
            return NoContent();
        }

        // DELETE: api/Units/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUnit(int id)
        {
            var unit = _units.FirstOrDefault(u => u.Id == id);
            if (unit == null)
                return NotFound();

            _units.Remove(unit);
            return NoContent();
        }
    }
}
