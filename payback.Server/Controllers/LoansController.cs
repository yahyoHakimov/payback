using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using payback.Server.DB;
using payback.Server.Models;

namespace payback.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoansController : ControllerBase
    {
        private readonly PaybackContext _context;

        public LoansController(PaybackContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Loan>> CreateLoan(Loan loan)
        {
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();
            return Ok(loan);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loan>>> GetLoans()
        {
            return await _context.Loans.ToListAsync();
        }
    }

}
