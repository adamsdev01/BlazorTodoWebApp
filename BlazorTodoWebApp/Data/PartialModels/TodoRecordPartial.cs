namespace BlazorTodoWebApp.Data.Models
{
    public partial class TodoRecord
    {
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
