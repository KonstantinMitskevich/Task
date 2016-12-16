using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using DataLayer.Repositories;

namespace DataLayer.Interfaces
{
    public class UnitOfWork : IUnitOfWork
    {
        private SqlConnection con;
        private TaskRepository taskRepository;
        private ExecutorRepository executorRepository;

        public void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["TaskConnection"].ToString();
            con = new SqlConnection(constr);
        }
        public IRepository<Executor> Executors
        {
            get
            {
                if (executorRepository == null)
                    executorRepository = new ExecutorRepository();
                return executorRepository;
            }
        }

        public IRepository<Taskk> Tasks
        {
            get
            {
                if (taskRepository == null)
                    taskRepository = new TaskRepository();
                return taskRepository;
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    con.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
