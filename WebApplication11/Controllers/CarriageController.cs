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
    public class CarriageController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
             select CarriageId,CarriageName,CarriageNumber,CarriageType from
             dbo.Carriages
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
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string Post(Carriage car)
        {
            try
            {
                string query = @"
                  insert into dbo.Carriages values
                  ( '" + car.CarriageName + @"'
                    ,'" + car.CarriageNumber + @"'
                   ,'" + car.CarriageType + @"')

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

        public string Put(Carriage car)
        {
            try
            {
                string query = @"
                  update dbo.Carriages set 
                   CarriageName = ('" + car.CarriageName + @"')
                   ,CarriageNumber = ('" + car.CarriageNumber + @"')
                   ,CarriageType = ('" + car.CarriageType + @"')
                   where CarriageId=" + car.CarriageId + @"

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
                return "Carriage updated successfully!";
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
                  delete from dbo.Carriages
                  where CarriageId=" + id + @"

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
            [Route("api/Carriage/GetAllTypes")]

            [HttpGet]
        public HttpResponseMessage GetAllTypes()
        {
            string query = @"
                  select TypeDescription from dbo.CarriageType
                 

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
            return Request.CreateResponse(HttpStatusCode.OK,table);
        }
    }
}
