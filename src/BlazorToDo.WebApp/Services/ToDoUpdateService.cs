using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorToDo.WebApp.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BlazorToDo.WebApp.Services
{
    public class ToDoUpdateService : IToDoUpdateService
    {
        Queue<ToDoItem> queue;

        private readonly ILogger _logger;

        public IServiceProvider Services { get; }

        public ToDoUpdateService(IServiceProvider services, ILogger<ToDoUpdateService> logger)
        {
            Services = services;
            _logger = logger;
            queue = new Queue<ToDoItem>();
        }

        public void Enqueue(ToDoItem item)
        {
            queue.Enqueue(item);
        }

        public void ProcessQueue()
        {
            Dictionary<Guid, ToDoItem> items = new Dictionary<Guid, ToDoItem>();
            ToDoItem toDoItem;
            while(queue.TryDequeue(out toDoItem))
            {
                items[toDoItem.EditId] = toDoItem;
            }

            foreach (var item in items)
            {
                // TODO: Database Update Here
                // TEMP
                if(item.Value.Id == 0)
                    item.Value.Id = 1;
                    
                OnUpdate?.Invoke(this, new ToDoItemUpdateEventArgs
                {
                    EditId = item.Key,
                    Id = item.Value.Id
                });
            }
        }

        public event ToDoUpdateEventHandler OnUpdate;
        public delegate void ToDoUpdateEventHandler(object sender, ToDoItemUpdateEventArgs e); 
    }
}