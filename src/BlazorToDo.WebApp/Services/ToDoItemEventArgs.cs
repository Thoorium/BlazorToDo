using System;

namespace BlazorToDo.WebApp.Services
{
    public class ToDoItemEventArgs : EventArgs
    {
        public Guid EditId { get; set; }
        public int Id { get; set; }
    }
}