using System;
using System.Collections.Generic;

namespace BlazorTodoWebApp.Data.Models;

public partial class TodoWeek
{
    public int TodoWeekId { get; set; }

    public DateTime? TodoWeekStartDate { get; set; }

    public DateTime? TodoWeekEndDate { get; set; }

    public virtual ICollection<TodoRecord> TodoRecords { get; set; } = new List<TodoRecord>();
}
