using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using admin_dashboard.Data;
using admin_dashboard.Models;

namespace admin_dashboard.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly admin_dashboard.Data.ApplicationDbContext _context;

        public IndexModel(admin_dashboard.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Books != null)
            {
                Book = await _context.Books
                .Include(b => b.Category).ToListAsync();
            }
        }
    }
}
