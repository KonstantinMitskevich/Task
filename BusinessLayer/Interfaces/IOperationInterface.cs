using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTO;
using DataLayer.Entities;


namespace BusinessLayer.Interfaces
{
    public interface IOperationInterface
    {
        void CreateTask(TaskDTO item);
        void DeleteTask(int id);
        IEnumerable<TaskDTO> GetAllTasks();
        void EditTask(TaskDTO item);
        TaskDTO GetTask(int id);

        void CreateExecutor(ExecutorDTO item);
        void DeleteExecutor(int id);
        IEnumerable<ExecutorDTO> GetAllExecutors();
        void EditExecutor(ExecutorDTO item);
        ExecutorDTO GetExecutor(int id);
    }
}
