using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementDemo.Models;
using TaskManagementDemo.Repositories;

namespace TaskManagementDemo.Services
{
    public class TaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<UserTask>> GetAllTasks() => _repository.GetAllTasksAsync();

        public Task<UserTask> GetTaskById(int id) => _repository.GetTaskByIdAsync(id);

        public Task AddTask(UserTask task) => _repository.AddTaskAsync(task);

        public Task UpdateTask(UserTask task) => _repository.UpdateTaskAsync(task);

        public Task DeleteTask(int id) => _repository.DeleteTaskAsync(id);
    }
}