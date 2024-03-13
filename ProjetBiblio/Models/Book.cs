using System;
using System.Collections.Generic;

namespace ProjetBiblio.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public int GenreId { get; set; }

    public string? Description { get; set; }

    public int? Quantity { get; set; }

    public virtual ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Genre Genre { get; set; } = null!;
}
