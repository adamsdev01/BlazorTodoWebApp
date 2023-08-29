using System;
using System.Collections.Generic;

namespace BlazorTodoWebApp.Data.Models;

public partial class TodoRecord
{
    public int TodoRecordId { get; set; }

    public int TodoWeekId { get; set; }

    public int EmployeeNumber { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? DepartmentName { get; set; }

    public string? ManagerName { get; set; }

    public string? ManagerEmployeeNumber { get; set; }

    public string? ManagerDepartmentName { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual TodoWeek TodoWeek { get; set; } = null!;
}
