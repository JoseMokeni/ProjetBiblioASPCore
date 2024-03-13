using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ProjetBiblio.Models;

namespace ProjetBiblio.Pages.Users
{
    public class IndexModel : PageModel
    {
        public string searchVal = string.Empty;
        private readonly ProjetBiblio.Models.OnlineLibraryDbContext _context;

        public IndexModel(ProjetBiblio.Models.OnlineLibraryDbContext context)
        {
            _context = context;
        }

        public List<User> users = new List<User>();
        public List<Borrowing> borrowings = new List<Borrowing>();

        public void OnGet(string? keyword)
        {
            if (keyword == null)
            {
                users = _context.Users.ToList();

            }
            else
            {
                users = _context.Users.Where(u => u.Name.Contains(keyword) || u.Email.Contains(keyword) || u.Phone.Contains(keyword)).ToList();
                searchVal = keyword;
            }
            if (users.Count > 0)
            {
                borrowings = _context.Borrowings.ToList();
            }
        }
    }
}
