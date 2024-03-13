using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetBiblio.Models;

namespace ProjetBiblio.Pages.Comments
{
    public class BookModel : PageModel
    {
        public List<Comment> comments = new List<Comment>();
        public Book? book;
        public List<Book> books = new List<Book>();

        private readonly ProjetBiblio.Models.OnlineLibraryDbContext _context;

        public BookModel(ProjetBiblio.Models.OnlineLibraryDbContext context)
        {
            _context = context;
        }
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                // Redirect to Index page if id is null
                return RedirectToPage("./Index");
            }

            books = _context.Books.Where(b => b.BookId.Equals(id)).ToList();

            book = books.Count() != 0 ? books[0] : null;

            if (book != null)
            {
                comments = _context.Comments.Where(c => c.BookId.Equals(book.BookId)).ToList();
            }
            
            return Page();
        }
    }
}
