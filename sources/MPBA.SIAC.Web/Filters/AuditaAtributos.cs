using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MPBA.SIAC.Web.Models;
using System.Web.Helpers;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace MPBA.SIAC.Web.Filters
{  public class AuditaAttribute : ActionFilterAttribute
        {
    public int AuditingLevel { get; set; }
    //This will serialize the Request object based on the level that you determine
    private string SerializeRequest(HttpRequestBase request)
    {
        switch (AuditingLevel)
        {
            //No Request Data will be serialized
            case 0:
            default:
                return "";
            //Basic Request Serialization - just stores Data
            case 1:
                return Json.Encode(new { request.Cookies, request.Headers, request.Files });
            //Middle Level - Customize to your Preferences
            case 2:
                return Json.Encode(new { request.UserAgent, request.QueryString });
            //Highest Level - Serialize the entire Request object (As mentioned earlier, this will blow up)
            case 3:
                //We can't simply just Encode the entire request string due to circular references as well
                //as objects that cannot "simply" be serialized such as Streams, References etc.
                return Json.Encode(request);
        }
    }
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        //Stores the Request in an Accessible object
        var request = filterContext.HttpContext.Request;

          //Stores the Audit in the Database
         SIACEntities db = new SIACEntities();
        //Generate an audit
         Audita audit = new Audita()
         {
             //Your Audit Identifier     

             //Our Username (if available)
             usuario = (request.IsAuthenticated) ? filterContext.HttpContext.User.Identity.Name : "Anonymous",
             //The IP Address of the Request
             IPAddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress,
             //The URL that was accessed
             AreaAccedida = request.RawUrl,
             //Creates our Timestamp
             fecha = DateTime.UtcNow,
             nivel = AuditingLevel,
            Data = Convert.ToString(SerializeRequest(request))
         };



         try
         {
             db.Auditorias.Add(audit);
             db.SaveChanges();
         }
         catch (DbEntityValidationException dbEx)
         {
             foreach (var validationErrors in dbEx.EntityValidationErrors)
             {
                 foreach (var validationError in validationErrors.ValidationErrors)
                 {
                     Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                 }
             }
         }

        //Finishes executing the Action as normal 
        base.OnActionExecuting(filterContext);
    }
        }
    
}