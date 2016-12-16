using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using DataLayer.Repositories;
using DataLayer.Interfaces;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace BusinessLayer.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private SqlConnection con;
        public ServiceModule(string connection)
        {
            string constr = ConfigurationManager.ConnectionStrings["TaskConnection"].ToString();
            con = new SqlConnection(constr);
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(con);
        }
    }
}
