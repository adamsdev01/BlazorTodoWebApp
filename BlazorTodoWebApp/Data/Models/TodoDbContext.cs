using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorTodoWebApp.Data.Models;

public partial class TodoDbContext : DbContext
{
    public TodoDbContext()
    {
    }

    public TodoDbContext(DbContextOptions<TodoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<TodoItem> TodoItems { get; set; }

    public virtual DbSet<TodoRecord> TodoRecords { get; set; }

    public virtual DbSet<TodoWeek> TodoWeeks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK_EmployeeId");

            entity.Property(e => e.DepartmentName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeNumber).HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.HasKey(e => e.TodoItemId).HasName("PK_TodoItemId");

            entity.Property(e => e.CompletedTask)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DateTaskWorkedOn).HasColumnType("datetime");
            entity.Property(e => e.Notes).IsUnicode(false);
            entity.Property(e => e.Task).IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TodoRecord>(entity =>
        {
            entity.HasKey(e => e.TodoRecordId).HasName("PK_TodoRecordId");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ManagerDepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ManagerEmployeeNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ManagerName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.TodoWeek).WithMany(p => p.TodoRecords)
                .HasForeignKey(d => d.TodoWeekId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TodoWeekId");
        });

        modelBuilder.Entity<TodoWeek>(entity =>
        {
            entity.HasKey(e => e.TodoWeekId).HasName("PK_TodoWeekId");

            entity.Property(e => e.TodoWeekEndDate).HasColumnType("datetime");
            entity.Property(e => e.TodoWeekStartDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
