using System;
using System.Collections.Generic;

namespace ProjetBiblio.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public int BookId { get; set; }

    public string? CommentText { get; set; }

    public DateTime CommentDate { get; set; }

    public int Rate { get; set; }

    public virtual Book Book { get; set; } = null!;
}
