using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetBiblio.Models;

namespace ProjetBiblio.Pages.Borrowings
{
    public class IndexModel : PageModel
    {
        private readonly ProjetBiblio.Models.OnlineLibraryDbContext _context;

        public IndexModel(ProjetBiblio.Models.OnlineLibraryDbContext context)
        {
            _context = context;
        }

        public List<Borrowing> borrowings = new List<Borrowing>();

        public void OnGet()
        {
            borrowings = _context.Borrowings.Include(b => b.User).Include(b => b.Book).ToList();
        }
    }
}
