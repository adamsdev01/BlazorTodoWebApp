using System;
using System.Collections.Generic;

namespace BlazorTodoWebApp.Data.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public int? EmployeeNumber { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? DepartmentName { get; set; }
}
