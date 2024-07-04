using AutoMapper;
using FireAlert.Data;
using FireAlert.DTOs;
using FireAlert.DTOs.Create;
using FireAlert.DTOs.Update;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FireAlert.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FireAlertController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FireAlertController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<FireAlertDto>>> GetAllFireAlerts()
        {
            var fireAlerts = await _context.FireAlerts.ToListAsync();

            var fireAlertDto = _mapper.Map<List<FireAlertDto>>(fireAlerts);

            return Ok(fireAlertDto);
        }

        [HttpPost]
        public async Task<ActionResult<FireAlertDto>> CreateFireAlert(CreateFireAlertDto createFireAlertDto)
        {
            var fireAlert = _mapper.Map<Models.FireAlert>(createFireAlertDto);
            _context.Add(fireAlert);
            await _context.SaveChangesAsync();

            return Ok(fireAlert);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateFireAlert(int id, [FromBody] UpdateFireAlertDto updateFireAlertDto)
        {
            var doesExist = await _context.FireAlerts.AnyAsync(fireAlert => fireAlert.Id == id);

            if (!doesExist)
            {
                return NotFound();
            }

            var fireAlertData = _mapper.Map<Models.FireAlert>(updateFireAlertDto);
            fireAlertData.Id = id;

            _context.Update(fireAlertData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteFireAlert(int id)
        {
            var fireAlert = await _context.FireAlerts.FindAsync(id);

            if (fireAlert == null)
            {
                return NotFound();
            }

            _context.Remove(fireAlert);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}
