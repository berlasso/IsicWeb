using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MPBA.SIAC.Web.Models;
using System.Web.Helpers;
using System.ComponentModel.DataAnnotations;

namespace MPBA.SIAC.Web.Models
{
    [MetadataType(typeof(AuditaMetadata))]
    public partial class Audita
    {

        internal sealed class AuditaMetadata
        {
            private AuditaMetadata()
            { }
            //Audit Properties

        
            public int Id { get; set; }
            public string usuario { get; set; }
            public string IPAddress { get; set; }
            public string AreaAccedida { get; set; }
            public DateTime fecha { get; set; }
            public  Nullable<int> nivel { get; set; }
            public string Data { get; set; }


            //This will serialize the Request object based on the level that you determine
            private string SerializeRequest(HttpRequestBase request)
            {
                switch (nivel)
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
                        return Json.Encode(new { request.Cookies, request.Headers, request.Files, request.Form, request.QueryString, request.Params });
                    //Highest Level - Serialize the entire Request object (As mentioned earlier, this will blow up)
                    case 3:
                        //We can't simply just Encode the entire request string due to circular references as well
                        //as objects that cannot "simply" be serialized such as Streams, References etc.
                        return Json.Encode(request);
                }
            }
        }
        /*Example AuditingContext 
         public class AuditingContext : DbContext
         {
              public DbSet<Audita> AuditRecords { get; set; }
         }
         */

    }
}