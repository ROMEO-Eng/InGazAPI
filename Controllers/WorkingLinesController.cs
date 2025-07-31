using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using InGazAPI.Models;

namespace InGazAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkingLinesController : ControllerBase
    {
        private static List<WorkingLine> _workingLines = new List<WorkingLine>
        {
            new WorkingLine { WorkingLineId = 1, Name = "A", IsActive = true },
            new WorkingLine { WorkingLineId = 2, Name = "B", IsActive = true },
            new WorkingLine { WorkingLineId = 3, Name = "C", IsActive = true }
        };

        // GET: api/WorkingLines
        [HttpGet]
        public ActionResult<IEnumerable<WorkingLine>> Get()
        {
            return Ok(_workingLines);
        }

        // GET: api/WorkingLines/5
        [HttpGet("{id}")]
        public ActionResult<WorkingLine> Get(int id)
        {
            var line = _workingLines.FirstOrDefault(w => w.WorkingLineId == id);
            if (line == null) return NotFound();
            return Ok(line);
        }

        // POST: api/WorkingLines
        [HttpPost]
        public ActionResult<WorkingLine> Post([FromBody] WorkingLine newLine)
        {
            if (_workingLines.Any(w => w.WorkingLineId == newLine.WorkingLineId))
                return Conflict("WorkingLine with the same Id already exists.");

            newLine.WorkingLineId = _workingLines.Any() ? _workingLines.Max(w => w.WorkingLineId) + 1 : 1;
            _workingLines.Add(newLine);
            return CreatedAtAction(nameof(Get), new { id = newLine.WorkingLineId }, newLine);
        }

        // PUT: api/WorkingLines/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] WorkingLine updatedLine)
        {
            var existing = _workingLines.FirstOrDefault(w => w.WorkingLineId == id);
            if (existing == null) return NotFound();

            existing.Name = updatedLine.Name;
            existing.IsActive = updatedLine.IsActive;

            return NoContent();
        }

        // DELETE: api/WorkingLines/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var line = _workingLines.FirstOrDefault(w => w.WorkingLineId == id);
            if (line == null) return NotFound();

            _workingLines.Remove(line);
            return NoContent();
        }
    }
}
