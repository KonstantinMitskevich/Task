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
    public class ServiceModule : NinjectModule // module to provide dependency between IUnitOfWork and UnitOfWork
    {
        private SqlConnection con;
        public ServiceModule(string connection) 
        {
            string constr = ConfigurationManager.ConnectionStrings["TaskConnection"].ToString();
            con = new SqlConnection(constr);
        }
        public override void Load() // binding IUnitOfWork interface to UnitOfWork class via Ninject
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(con);
        }
    }
}
