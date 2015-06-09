using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using ISIC.Entities;

namespace ISICWeb.Areas.Otip.Models
{
    public class ImagenesViewModel
    {
        public int? idImputado { get; set; }
        public string codBarras { get; set; }
        public List<Archivo> archivos { get; set; }

    }
}