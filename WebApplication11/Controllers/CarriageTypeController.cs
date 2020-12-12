using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    public class CarriageTypeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
             select TypeId,TypeNumber, TypeDescription from
             dbo.CarriageType
              ";
            DataTable table = new DataTable();
            using(var con= new SqlConnection(ConfigurationManager.
                ConnectionStrings["CarriageAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string Post(CarriageType cartype)
        {
            try
            {
                string query = @"
                  insert into dbo.CarriageType values
                   ('"+cartype.TypeDescription+ @"'
                      ,'" + cartype.TypeNumber + @"'
                     )

                  ";
                 DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["CarriageAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Type added successfully!";
            }
            catch (Exception)
            {
                return "Failed to Add!";
            }
        }

        public string Put(CarriageType cartype)
        {
            try
            {
                string query = @"
                  update dbo.CarriageType set TypeDescription=
                   ('" + cartype.TypeDescription + @"')
                     ,TypeNumber=('" + cartype.TypeNumber + @"'
                     )
                   where TypeId=" + cartype.TypeId+@"

                  ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["CarriageAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Type updated successfully!";
            }
            catch (Exception)
            {
                return "Failed to update!";
            }
        }
        public string Delete(int id)
        {
            try
            {
                string query = @"
                  delete from dbo.CarriageType 
                  where TypeId=" + id + @"

                  ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["CarriageAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Deleted successfully!";
            }
            catch (Exception)
            {
                return "Failed to delete!";
            }
        }
    }
}
