using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPBA.SIAC.Web.Models.MetaDataClass
{
    public class CustomByteArrayModelBinder : System.Web.Mvc.ByteArrayModelBinder
    {
        public override object BindModel(System.Web.Mvc.ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext)
        {
            var file = controllerContext.HttpContext.Request.Files[bindingContext.ModelName];

            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    var fileBytes = new byte[file.ContentLength];
                    file.InputStream.Read(fileBytes, 0, fileBytes.Length);
                    return fileBytes;
                }

                return null;
            }

            return base.BindModel(controllerContext, bindingContext);
        }
    }
}
