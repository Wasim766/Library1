using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Book
{
    public int BookID { get; set; }

    [Required]
    public string Title { get; set; }

    public int AuthorID { get; set; }
    public int AvailableCopies { get; set; }
    public virtual Author Author { get; set; }
}

