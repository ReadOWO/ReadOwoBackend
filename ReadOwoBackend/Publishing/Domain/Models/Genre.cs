﻿namespace ReadOwoBackend.Publishing.Domain.Models;

public class Genre
{
    public int Id { get; set; } 
    
    public string Name { get; set; }
    
    public IList<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
}