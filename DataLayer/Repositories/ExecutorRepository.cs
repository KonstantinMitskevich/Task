using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using DataLayer.Entities;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace DataLayer.Repositories
{
    public class ExecutorRepository : IRepository<Executor>
    {

        private SqlConnection con;
        public void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["TaskConnection"].ToString();
            con = new SqlConnection(constr);
        }

        public async Task Create(Executor item)
        {
            Connection();
            SqlCommand com = new SqlCommand("AddNewExecutor", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", item.Name);
            com.Parameters.AddWithValue("@LastName", item.LastName);
            com.Parameters.AddWithValue("@SurName", item.SurName);
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

        public async Task Delete(int id)
        {
            Connection();
            SqlCommand com = new SqlCommand("DeleteExecutorById", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ExecutorId", id);

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

        public Executor Get(int id)
        {
            Connection();
            SqlCommand com = new SqlCommand("GetExecutorById", con);

            Executor executor = new Executor();
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ExecutorId", id);

            con.Open();
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    executor.ExecutorId = (int)reader.GetValue(0);
                    executor.Name = (string)reader.GetValue(1);
                    executor.SurName = (string)reader.GetValue(2);
                    executor.LastName = (string)reader.GetValue(3);
                }
            }

            con.Close();
            return executor;
        }

        public IEnumerable<Executor> GetAll()
        {
            Connection();
            List<Executor> ExecutorList = new List<Executor>();

            SqlCommand com = new SqlCommand("GetExecutors", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
        
            foreach (DataRow dr in dt.Rows)
            {
                ExecutorList.Add(
                    new Executor
                    {
                        ExecutorId = Convert.ToInt32(dr["ExecutorId"]),
                        Name = Convert.ToString(dr["Name"]),
                        LastName = Convert.ToString(dr["LastName"]),
                        SurName = Convert.ToString(dr["SurName"])}
                    );
            }
            return ExecutorList;
        }

        public async Task Edit(Executor item)
        {
            Connection();
            SqlCommand com = new SqlCommand("EditExecutor", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ExecutorId", item.ExecutorId);
            com.Parameters.AddWithValue("@Name", item.Name);
            com.Parameters.AddWithValue("@LastName", item.LastName);
            com.Parameters.AddWithValue("@SurName", item.SurName);
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
