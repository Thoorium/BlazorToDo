using System;

namespace BlazorToDo.WebApp.Services
{
    public class ToDoItemUpdateEventArgs : EventArgs
    {
        public Guid EditId { get; set; }
        public int Id { get; set; }
    }
}