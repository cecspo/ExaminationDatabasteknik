﻿using Data.Entities;

namespace Business.Models;

public class ProjectManager
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string FullName => $"{FirstName} {LastName}";
}
