﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Taskk> Tasks { get; }
        IRepository<Executor> Executors { get; }
    }
}
