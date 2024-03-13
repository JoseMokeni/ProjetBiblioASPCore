using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetBiblio.Models;

namespace ProjetBiblio.Pages.Borrowings
{
    public class UserModel : PageModel
    {
        private readonly ProjetBiblio.Models.OnlineLibraryDbContext _context;

        public UserModel(ProjetBiblio.Models.OnlineLibraryDbContext context)
        {
            _context = context;
        }

        public List<Borrowing> borrowings = new List<Borrowing>();

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                // Redirect to Index page if id is null
                return RedirectToPage("./Index");
            }
            borrowings = _context.Borrowings.Where(b => b.UserId == id).Include(b => b.Book).Include(b => b.User).ToList();
            return Page();
        }
    }
}
