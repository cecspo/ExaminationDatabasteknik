﻿namespace Business.Models;

public class EmployeeRegistrationForm
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
    
    public string FullName => $"{FirstName} {LastName}";
}
