using System;
using System.Collections.Generic;

namespace BlazorTodoWebApp.Data.Models;

public partial class TodoItem
{
    public int TodoItemId { get; set; }

    public int TodoRecordId { get; set; }

    public DateTime? DateTaskWorkedOn { get; set; }

    public TimeSpan? StartTime { get; set; }

    public TimeSpan? StopTime { get; set; }

    public int? HoursTaskWorkedOn { get; set; }

    public int? MinutesTaskWorkedOn { get; set; }

    public string? Task { get; set; }

    public string? Notes { get; set; }

    public string? CompletedTask { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
