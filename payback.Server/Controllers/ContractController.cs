using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using payback.Server.DB;
using payback.Server.Models;

namespace payback.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractsController : ControllerBase
    {
        private readonly PaybackContext _context;

        public ContractsController(PaybackContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Contract>> CreateContract(Contract contract)
        {
            _context.Contracts.Add(contract);
            await _context.SaveChangesAsync();
            return Ok(contract);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contract>>> GetContracts()
        {
            return await _context.Contracts.ToListAsync();
        }
    }

}
