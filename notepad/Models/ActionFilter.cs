using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace notepad.Models
{
    public class ActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];
            Log(controllerName.ToString(), actionName.ToString(), DateTime.Now);
        }
        private void Log(string messageType, string messageText, DateTime messageDate)
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            try
            {
                connection.Open();
                var command = connection.CreateCommand();
                
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO Log (controller, action) VALUES (@controller, @action)";

                command.Parameters.AddWithValue("@controller", messageType);
                command.Parameters.AddWithValue("@action", messageText);

                command.ExecuteNonQuery();
            }
            catch (InvalidCastException e) { }
        }
    }
}