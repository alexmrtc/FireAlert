using AutoMapper;
using FireAlert.Data;
using FireAlert.DTOs;
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
    }
}
