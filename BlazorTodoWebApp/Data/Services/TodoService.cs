using BlazorTodoWebApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorTodoWebApp.Data.Services
{
    public class TodoService
    {
        readonly TodoDbContext _dbContext = new();

        public TodoService(TodoDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        /// <summary>
        /// To Get all TodoRecords
        /// </summary>
        /// <returns></returns>
        public List<TodoRecord> GetTodoRecords()
        {
            try
            {
                return _dbContext.TodoRecords.ToList();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// To Add new TodoRecord record
        /// </summary>
        /// <param name="TodoRecord"></param>
        public void AddTodoRecord(TodoRecord TodoRecord)
        {
            try
            {
                _dbContext.TodoRecords.Add(TodoRecord);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// To Update the records of a particluar TodoRecord
        /// </summary>
        /// <param name="TodoRecord"></param>
        public void UpdateTodoRecordDetails(TodoRecord TodoRecord)
        {
            try
            {
                _dbContext.Entry(TodoRecord).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Get the details of a particular TodoRecord
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TodoRecord GetTodoRecordData(int id)
        {
            try
            {
                TodoRecord? TodoRecord = _dbContext.TodoRecords.Find(id);
                if (TodoRecord != null)
                {
                    return TodoRecord;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// To Delete the record of a particular TodoRecord
        /// </summary>
        /// <param name="id"></param>
        public void DeleteTodoRecord(int id)
        {
            try
            {
                TodoRecord? TodoRecord = _dbContext.TodoRecords.Find(id);
                if (TodoRecord != null)
                {
                    _dbContext.TodoRecords.Remove(TodoRecord);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// To Get all TodoWeeks
        /// </summary>
        /// <returns></returns>
        public List<TodoWeek> GetTodoWeeks()
        {
            try
            {
                return _dbContext.TodoWeeks.ToList();
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// To Get all Employees
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetEmployees()
        {
            try
            {
                return _dbContext.Employees.ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
