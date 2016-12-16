using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTO;
using DataLayer.Entities;
using BusinessLayer.Interfaces;
using BusinessLayer.Infrastructure;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using AutoMapper;


namespace BusinessLayer.Operations
{
    public class Operations : IOperationInterface
    {
        IUnitOfWork db { get; set; }

        public Operations(IUnitOfWork uow)
        {
            db = uow;
        }

        public void CreateTask(TaskDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("Error!!! Incorret input data","");
            }
            Mapper.Initialize(t => t.CreateMap<TaskDTO, Taskk>());
            db.Tasks.Create(Mapper.Map<TaskDTO, Taskk>(item));
        }

        public void DeleteTask(int id)
        {
            db.Tasks.Delete(id);
        }

        public IEnumerable<TaskDTO> GetAllTasks()
        {
            Mapper.Initialize(t => t.CreateMap<Taskk,TaskDTO>());
            return Mapper.Map<IEnumerable<Taskk>,List<TaskDTO>>(db.Tasks.GetAll());
        }

        public void EditTask(TaskDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("Error!!! Incorret input data", "");
            }
            Mapper.Initialize(t => t.CreateMap<TaskDTO, Taskk>());
            db.Tasks.Edit(Mapper.Map<TaskDTO, Taskk>(item));
        }

        public void CreateExecutor(ExecutorDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("Error!!! Incorret input data", "");
            }
            Mapper.Initialize(t => t.CreateMap<ExecutorDTO, Executor>());
            db.Executors.Create(Mapper.Map<ExecutorDTO, Executor>(item));
        }

        public void DeleteExecutor(int id)
        {
            db.Executors.Delete(id);
        }

        public IEnumerable<ExecutorDTO> GetAllExecutors()
        {
            Mapper.Initialize(t => t.CreateMap<Executor, ExecutorDTO>());
            return Mapper.Map<IEnumerable<Executor>, List<ExecutorDTO>>(db.Executors.GetAll());
        }

        public ExecutorDTO GetExecutor(int id)
        {
            Mapper.Initialize(t => t.CreateMap<Executor, ExecutorDTO>());
            return Mapper.Map<Executor, ExecutorDTO>(db.Executors.Get(id));
        }

        public TaskDTO GetTask(int id)
        {
            Mapper.Initialize(t => t.CreateMap<Taskk, TaskDTO>());
            return Mapper.Map<Taskk, TaskDTO>(db.Tasks.Get(id));
        }

        public void EditExecutor(ExecutorDTO item)
        {
            if (item == null)
            {
                throw new ValidationException("Error!!! Incorret input data", "");
            }
            Mapper.Initialize(t => t.CreateMap<ExecutorDTO, Executor>());
            db.Executors.Edit(Mapper.Map<ExecutorDTO, Executor>(item));
        }
    }
}
