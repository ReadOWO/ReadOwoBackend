﻿namespace ReadOwoBackend.ReadOwo.Domain.Models;

public class User
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string email { get; set; }
    
    public string password { get; set; }
}