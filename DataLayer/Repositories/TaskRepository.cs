using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using DataLayer.Entities;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DataLayer.Repositories
{
    class TaskRepository : IRepository<Taskk>
    {
        private SqlConnection con;
        public void Connection() // constructor, creates connction string 
        {
            string constr = ConfigurationManager.ConnectionStrings["TaskConnection"].ToString();
            con = new SqlConnection(constr);
        }
        public async Task Create(Taskk item) // creat a new Task item
        {
            Connection();
            SqlCommand com = new SqlCommand("AddNewTask", con);
            com.CommandType = CommandType.StoredProcedure;
          //  com.Parameters.AddWithValue("@TaskId", item.TaskId);
            com.Parameters.AddWithValue("@Name", item.Name);
            com.Parameters.AddWithValue("@StartDate", item.StartDate);
            com.Parameters.AddWithValue("@EndDate", item.EndDate);
            com.Parameters.AddWithValue("@Status", item.Status);
            com.Parameters.AddWithValue("@Value", item.Value);
            com.Parameters.AddWithValue("@ExecutorId", item.ExecutorId);
            await con.OpenAsync();
            
            int i =  com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                //  return true;
            }
            else
            {
                //  return false;
            }
        }

        public Taskk Get(int id) // get a Task item
        {
            Connection();
            SqlCommand com = new SqlCommand("GetTaskById", con);

            Taskk task = new Taskk();
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@TaskId", id);

            con.Open();
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    task.TaskId = (int)reader.GetValue(0);
                    task.Name = (string)reader.GetValue(1);
                    task.Value = (double)reader.GetValue(2);
                    task.StartDate = (DateTime)reader.GetValue(3);
                    task.EndDate = (DateTime)reader.GetValue(4);
                    task.Status = (int)reader.GetValue(5);
                    task.ExecutorId = (int)reader.GetValue(6);
                }
            }

            con.Close();
            return task;
        }

        public async Task Delete(int id) // delete a Task item
        {
            Connection();
            SqlCommand com = new SqlCommand("DeleteTaskById", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@TaskId", id);

            await con.OpenAsync();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                //  return true;
            }
            else
            {
                //  return false;
            }
        }

        public IEnumerable<Taskk> GetAll() // get all Task items
        {
            Connection();
            List<Taskk> TaskList = new List<Taskk>();

            SqlCommand com = new SqlCommand("GetTasks", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                TaskList.Add(
                    new Taskk
                    {
                        TaskId = Convert.ToInt32(dr["TaskId"]),
                        ExecutorId = Convert.ToInt32(dr["ExecutorId"]),
                        Name = Convert.ToString(dr["Name"]),
                        EndDate = Convert.ToDateTime(dr["EndDate"]),
                        StartDate = Convert.ToDateTime(dr["StartDate"]),
                        Value = Convert.ToDouble(dr["Value"]),
                        Status = Convert.ToInt32(dr["Status"])
                    });
            }
            return TaskList;
        }

        public async Task Edit(Taskk item) // edit a Task item
        {
            Connection();
            SqlCommand com = new SqlCommand("EditTask", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@TaskId", item.TaskId);
            com.Parameters.AddWithValue("@Name", item.Name);
            com.Parameters.AddWithValue("@StartDate", item.StartDate);
            com.Parameters.AddWithValue("@EndDate", item.EndDate);
            com.Parameters.AddWithValue("@Status", item.Status);
            com.Parameters.AddWithValue("@Value", item.Value);
            com.Parameters.AddWithValue("@ExecutorId", item.ExecutorId);

            await con.OpenAsync();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                //  return true;
            }
            else
            {
                //   return false;
            }
        }
    }
}
