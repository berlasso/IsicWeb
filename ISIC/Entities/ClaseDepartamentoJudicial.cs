﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPBA.Entities;

namespace ISIC.Entities
{
    public class ClaseDepartamentoJudicial : Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string sigDto { get; set; }
        public int? idSIMP { get; set; }
        public string descripcion { get; set; }
    }
}