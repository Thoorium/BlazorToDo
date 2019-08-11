using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorToDo.WebApp.Data
{
    public class ToDoItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool Done { get; set; }

        public string AddedBy { get; set; }

        [NotMapped]
        public Guid EditId { get; set; } = Guid.NewGuid();
    }
}