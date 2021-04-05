
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebAPI.Models;
namespace WebAPI.Controllers
{
    public class HomeController : ApiController
    {
       
        public DataSet GetRecord(int id)
        {
            DataSet ds = new DataSet();
                return ds;
        }
       

    }
}
