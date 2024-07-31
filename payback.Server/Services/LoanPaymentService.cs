using Microsoft.EntityFrameworkCore;
using payback.Server.DB;

namespace payback.Server.Services
{
    public class LoanPaymentService
    {
        private readonly PaybackContext _context;

        public LoanPaymentService(PaybackContext context)
        {
            _context = context;
        }

        public async Task ProcessPayments()
        {
            var loansDue = await _context.Loans.Where(l => l.DueDate <= DateTime.Now && !l.IsRepaid).ToListAsync();
            foreach (var loan in loansDue)
            {
                // Bank to'lovi amalga oshiriladi (dummy code)
                bool paymentSuccessful = true;
                if (paymentSuccessful)
                {
                    loan.IsRepaid = true;
                    _context.Update(loan);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }

}
