using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ISIC.Entities;
using ISICWeb.Models;
using ISIC.Enums;

namespace ISICWeb.Mappers
{
    public class BioDactilarMapper : Mapper<BioDactilar, BioDactilarViewModel>
    {
        public override BioDactilarViewModel MapFromModel(BioDactilar model)
        {
            int orden = 0;

            switch (model.Dedo)
            {
                case ClaseDedo.Pulgar:
                    orden = 0;
                    break;

                case ClaseDedo.Indice:
                    orden = 1;
                    break;

                case ClaseDedo.Medio:
                    orden = 2;
                    break;

                case ClaseDedo.Anular:
                    orden = 3;
                    break;

                case ClaseDedo.Meñique:
                    orden = 4;
                    break;
            }

            return new BioDactilarViewModel
            {
                Id = model.Id,
                CodigoDeBarra = model.CodigoDeBarra,
                imagen = model.imagen,
                Mano = model.Mano,
                Dedo = model.Dedo,
                EstadoDedo = model.EstadoDedo,
                DactilarVuc =
                    (model.DactilarVuc != null) ?
                    new VucClasificaViewModel
                    {
                        Id = model.DactilarVuc.Clasificacion.Id.ToString(),
                        Descripcion = model.DactilarVuc.Clasificacion.Descripcion,
                        Sigla = model.DactilarVuc.GetSiglaClasificacion()
                    } :
                    new VucClasificaViewModel() { Id = "0" },
                SubDactilarVuc =
                    (model.DactilarVuc != null) && (model.DactilarVuc.SubClasificacion != null) ?
                    new VucClasificaViewModel
                    {
                        Id = model.DactilarVuc.SubClasificacion.Id.ToString(),
                        Descripcion = model.DactilarVuc.SubClasificacion.Descripcion,
                        Sigla = model.DactilarVuc.SubClasificacion.Sigla
                    } :
                    new VucClasificaViewModel() { Id = "0" },
                Orden = orden
            };
        }

    }
}