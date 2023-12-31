﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Author
{
    public int AuthorID { get; set; }

    [Required]
    public string Name { get; set; }
    public virtual ICollection<Book> Books { get; set; }
}
