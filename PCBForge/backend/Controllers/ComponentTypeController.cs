using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCBForge.backend.Data;

namespace PCBForge.backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComponentTypeController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ComponentTypeController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var types = await _context.ComponentTypes
                .Select(ct => new { ct.Id, ct.Name })
                .ToListAsync();

            return Ok(types);
        }
    }
}