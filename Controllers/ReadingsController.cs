using Microsoft.AspNetCore.Mvc;

namespace InGazAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ReadingsController : ControllerBase
    {

        private static List<Reading> _readings = new List<Reading>();



        [HttpGet("GET_READING_C")]
        public async Task<ActionResult<IEnumerable<Reading>>> GetReadings()
        {

            return await Task.FromResult(_readings);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Reading>> GetReading(int id)
        {
            var reading = await Task.FromResult(_readings.FirstOrDefault(r => r.ReadingId == id));
            if (reading == null)
                return NotFound();

            return reading;
        }


        [HttpPost("POST_READING_C")]
        public async Task<ActionResult<Reading>> CreateReading(Reading reading)
        {
            _readings.Add(reading);
            return CreatedAtAction(nameof(GetReading), new { id = reading.ReadingId }, reading);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReading(int id, Reading reading)
        {
            if (id != reading.ReadingId)
                return BadRequest();

            var existingReading = _readings.FirstOrDefault(r => r.ReadingId == id);
            if (existingReading == null)
                return NotFound();


            existingReading.Value = reading.Value;
            existingReading.Unit = reading.Unit;

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReading(int id)
        {
            var reading = await Task.FromResult(_readings.FirstOrDefault(r => r.ReadingId == id));
            if (reading == null)
                return NotFound();

            _readings.Remove(reading);
            return NoContent();
        }
    }
}
