using System;
using BlazorToDo.WebApp.Data;

namespace BlazorToDo.WebApp.Services
{
    public class ToDoItemEventArgs : EventArgs
    {
        public ToDoItem Item { get; set; }
    }
}