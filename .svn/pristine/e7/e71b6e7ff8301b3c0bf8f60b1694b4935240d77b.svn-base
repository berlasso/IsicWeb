using System;
using System.Web;
using System.Web.Mvc;
using ISIC.Entities;
using ISIC.Persistence.Context;

namespace ISICWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
    public class AuditAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Stores the Request in an Accessible object
            var request = filterContext.HttpContext.Request;
            // Generate an audit
            Audit audit = new Audit()
            {
                // Your Audit Identifier     
                id = Guid.NewGuid(),
                // Our Username (if available)
                UserName = (request.IsAuthenticated) ? filterContext.HttpContext.User.Identity.Name : "Anonymous",
                // The IP Address of the Request
                IPAddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress,
                // The URL that was accessed
                Direccion = request.RawUrl,
                // Creates our Timestamp
                FechaAcceso = DateTime.UtcNow
            };

            ISICContext context = new ISICContext();
            context.Audit.Add(audit);
            context.SaveChanges();

            // Finishes executing the Action as normal 
            base.OnActionExecuting(filterContext);
        }
    }


}
