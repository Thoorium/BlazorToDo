using BlazorToDo.WebApp.Data;
using static BlazorToDo.WebApp.Services.ToDoUpdateService;

namespace BlazorToDo.WebApp.Services
{
    public interface IToDoUpdateService
    {
        void Enqueue(ToDoItem item);

        void ProcessQueue();

        event ToDoUpdateEventHandler OnUpdate;
    }
}