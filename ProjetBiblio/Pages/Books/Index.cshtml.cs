using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetBiblio.Models;

namespace ProjetBiblio.Pages.Books
{
    public class IndexModel : PageModel
    {
        public string searchVal = string.Empty;
        private readonly ProjetBiblio.Models.OnlineLibraryDbContext _context;

        public IndexModel(ProjetBiblio.Models.OnlineLibraryDbContext context)
        {
            _context = context;
        }

        public List<Book> books = new List<Book>();
        public List<Borrowing> borrowings = new List<Borrowing>();

        public void OnGet(string? keyword)
        {
            if (keyword == null)
            {
                books = _context.Books.Include(b => b.Genre).ToList();

            }
            else
            {
                books = _context.Books.Include(b => b.Genre).Where(b => b.Title.Contains(keyword) || b.Author.Contains(keyword) || b.Genre.Name.Contains(keyword)).ToList();
                searchVal = keyword;
            }
            //borrowings = _context.Borrowings.Where(b => b.Status.Equals("lent") || b.IsReturned.Equals(false)).ToList();
            borrowings = _context.Borrowings.ToList();
        }
    }
}
