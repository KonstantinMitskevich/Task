using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.DTO;
using BusinessLayer.Interfaces;
using BusinessLayer.Infrastructure;
using Task.Models;
using AutoMapper;

namespace Task.Controllers
{
    public class HomeController : Controller
    {
        IOperationInterface operationInterface;

        public HomeController(IOperationInterface operation)
        {
            operationInterface = operation;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateExecutor(int id = 0) 
        {
            ExecutorViewModel executorNewModel = new ExecutorViewModel();
            if (id != 0)
            {
                ExecutorDTO exec = operationInterface.GetExecutor(id);
                executorNewModel.ExecutorId = exec.ExecutorId;
                executorNewModel.Name = exec.Name;
                executorNewModel.SurName = exec.SurName;
                executorNewModel.LastName = exec.LastName;
                
            }
            return View(executorNewModel);
        }

        [HttpPost]
        public ActionResult CreateExecutor(ExecutorViewModel model)  // create an executor
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("Name", "Incorrect name input");
            }
            if (string.IsNullOrEmpty(model.SurName))
            {
                ModelState.AddModelError("SurName", "Incorrect surName input");
            }
            if (string.IsNullOrEmpty(model.LastName))
            {
                ModelState.AddModelError("LastName", "Incorrect lastName input");
            }
            if (ModelState.IsValid)
            {
                Mapper.Initialize(t => t.CreateMap<ExecutorViewModel, ExecutorDTO>());
                var executor = Mapper.Map<ExecutorViewModel, ExecutorDTO>(model);
                if (model.ExecutorId != 0)
                {
                    operationInterface.EditExecutor(executor);
                }
                else
                {
                    operationInterface.EditExecutor(executor);
                }
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Please, try again";
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateTask(int id = 0) 
        {
            TaskViewModel taskModel = new TaskViewModel();
            if (id != 0)
            {
                TaskDTO task = operationInterface.GetTask(id);
                taskModel.TaskId = task.TaskId;
                taskModel.ExecutorId = task.ExecutorId;
                taskModel.EndDate = task.EndDate;
                taskModel.StartDate = task.StartDate;
                taskModel.Status = task.Status;
                taskModel.Value = task.Value;
                taskModel.Name = task.Name;
            }
            return View(taskModel);
        }

        [HttpPost]
        public ActionResult CreateTask(TaskViewModel model) // create a task
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("Name", "Incorrect name input");
            }
            if (model.StartDate > model.EndDate)
            {
                ModelState.AddModelError("StartDate", "Start date can't be later than end date");
            }
            if (model.Status <= 0)
            {
                ModelState.AddModelError("Status", "Incorrect status input");
            }
            if (model.Value <= 0)
            {
                ModelState.AddModelError("Value", "Incorrect value input");
            }
            if (ModelState.IsValid)
            {
                Mapper.Initialize(t => t.CreateMap<TaskViewModel, TaskDTO>());
                var task = Mapper.Map<TaskViewModel, TaskDTO>(model);
                if (model.TaskId != 0)
                {
                    operationInterface.EditTask(task);
                }
                else
                {
                    operationInterface.CreateTask(task);
                }
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Please, try again";
            return View(model);
        }

        public PartialViewResult GetAllTasks()
        {
            List<TaskViewModel> taskViewModel = new List<TaskViewModel>();
            foreach (TaskDTO task in operationInterface.GetAllTasks())
            {
                TaskViewModel tVM = new TaskViewModel();
                tVM.TaskId = task.TaskId;
                tVM.ExecutorId = task.ExecutorId;
                tVM.EndDate = task.EndDate;
                tVM.StartDate = task.StartDate;
                tVM.Status = task.Status;
                tVM.Value = task.Value;
                tVM.Name = task.Name;
                taskViewModel.Add(tVM);
            }
            return PartialView("GetAllTasks", taskViewModel);
        }

        public PartialViewResult GetAllExecutors()
        {
            List<ExecutorViewModel> execViewModel = new List<ExecutorViewModel>();
            foreach (ExecutorDTO exec in operationInterface.GetAllExecutors())
            {
                ExecutorViewModel eVM = new ExecutorViewModel();
                eVM.ExecutorId = exec.ExecutorId;
                eVM.Name = exec.Name;
                eVM.SurName = exec.SurName;
                eVM.LastName = exec.LastName;
                execViewModel.Add(eVM);
            }
            return PartialView("GetAllExecutors", execViewModel);
        }

        [HttpPost]
        public ActionResult DeleteTask(int id)
        {
            if (id != 0)
            {
                operationInterface.DeleteTask(id);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult DeleteExecutor(int id)
        {
            if (id != 0)
            {
                operationInterface.DeleteExecutor(id);
            }
            return RedirectToAction("Index");
        }
    }
}