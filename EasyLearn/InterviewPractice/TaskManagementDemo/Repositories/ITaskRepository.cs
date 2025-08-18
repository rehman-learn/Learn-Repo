using TaskManagementDemo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManagementDemo.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<UserTask>> GetAllTasksAsync();
        Task<UserTask> GetTaskByIdAsync(int id);
        Task AddTaskAsync(UserTask task);
        Task UpdateTaskAsync(UserTask task);
        Task DeleteTaskAsync(int id);
    }
}
