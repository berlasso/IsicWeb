using System;
using System.ComponentModel;
using System.Transactions;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll
{

    /// <summary>
    /// The DelitosManager class is responsible for managing Business Object.Delitos objects in the system.
    /// </summary>
    [DataObjectAttribute()]
    public partial class DelitosManager
    {

        #region "Public Methods"

        /// <summary>
        /// Gets a list with all Delitos objects in the database.
        /// </summary>
        /// <returns>A list with all Delitos from the database when the database contains any, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static DelitosList GetList()
        {
            return DelitosDB.GetList();
        }

       
          public  enum TipoAutores
        {
            Desconocidos = 1,
            Conocidos = 2,
              Todos = 3
        }

        /// <summary>
        /// Gets all Delitos from the database matching CriterioBusquedaCompleta.
        /// </summary>
        /// <param name="id">The id of the Delitos in the database.</param>
        /// <param name="traeDatosAsociados">Si trae los datos asociados al id del delito.</param>
        /// <param name="id">The id of the Delitos in the database.</param>
        /// <param name="traeDatosAsociados">Si trae los datos asociados agrupados por cantidad de clase(solo para rastros)</param>
        /// <returns>A list with all Delitos from the database matching criterios</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static DelitosList GetList(BusquedaRobosDelitosSexuales criterio, bool traeDatosAsociados, bool traeRastrosAgrupados, TipoAutores tipoAutor)
        {
            DelitosList myDelitosList=null;
            switch (tipoAutor)
            {
                case TipoAutores.Conocidos:
                    myDelitosList = DelitosDB.GetListSoloAutoresConocidos(criterio);
                    break;
                case TipoAutores.Desconocidos:
                    myDelitosList = DelitosDB.GetListSoloAutoresDesconocidos(criterio);
                    break;
                case TipoAutores.Todos:
                    myDelitosList = DelitosDB.GetList(criterio);
                    break;
            }
            
            if (myDelitosList != null && (traeDatosAsociados || traeRastrosAgrupados))
            {

                for (int i = 0; i <= myDelitosList.Count - 1; i++)
                {
                    Delitos myDelitos = myDelitosList[i];
                    int id = myDelitos.id;
                    if (myDelitos != null && traeDatosAsociados)
                    {
                        myDelitos.autoress = AutoresDB.GetListByidDelito(id);
                    }
                    if (myDelitos != null && traeDatosAsociados)
                    {
                        myDelitos.bienesSustraidoss = BienesSustraidosDB.GetListByidDelito(id);
                    }
                    if (myDelitos != null && traeDatosAsociados)
                    {
                        myDelitos.lugaresDeTrasladoDeVictimass = LugaresDeTrasladoDeVictimasDB.GetListByidDelito(id);
                    }
                    if (myDelitos != null && traeRastrosAgrupados)
                    {
                        myDelitos.rastross = RastrosDB.GetListByidDelitoGroupedByIdClaseRastro(id);
                    }
                    else if (myDelitos != null && traeRastrosAgrupados == false && traeDatosAsociados)
                    {
                        myDelitos.rastross = RastrosDB.GetListByidDelito(id);
                    }

                    //if (myDelitos != null && traeDatosAsociados)
                    //{
                    //    if (traeRastrosAgrupados)
                    //        myDelitos.rastross = RastrosDB.GetListByidDelitoGroupedByIdClaseRastro(id);
                    //    else                            
                    //        myDelitos.rastross = RastrosDB.GetListByidDelito(id);
                    //}
                    if (myDelitos != null && traeDatosAsociados)
                    {
                        myDelitos.vehiculoss = VehiculosDB.GetListByidDelito(id);
                    }
                }
            }
            return myDelitosList;

        }

        /// <summary>
        /// Gets a single Delitos from the database.
        /// </summary>
        /// <param name="id">The id of the Delitos in the database.</param>
        /// <param name="getDelitosRecords">Determines whether to load all associated Delitos records as well.</param>
        /// <returns>
        /// A Delitos object when the id exists in the database, or <see langword="null"/> otherwise.
        /// </returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Delitos GetItem(int id, bool getDelitosRecords)
        {
            Delitos myDelitos = DelitosDB.GetItem(id);
            if (myDelitos != null && getDelitosRecords)
            {
                myDelitos.autoress = AutoresDB.GetListByidDelito(id);
                
            }
            if (myDelitos != null && getDelitosRecords)
            {
                myDelitos.bienesSustraidoss = BienesSustraidosDB.GetListByidDelito(id);
            }
            if (myDelitos != null && getDelitosRecords)
            {
                myDelitos.lugaresDeTrasladoDeVictimass = LugaresDeTrasladoDeVictimasDB.GetListByidDelito(id);
            }
            if (myDelitos != null && getDelitosRecords)
            {
                myDelitos.rastross = RastrosDB.GetListByidDelito(id);
            }
            if (myDelitos != null && getDelitosRecords)
            {
                myDelitos.vehiculoss = VehiculosDB.GetListByidDelito(id);
                //myDelitos.vehiculoss.VehiculossSoloMO = VehiculosDB.GetListByVinculoANDidDelito(VinculoVehiculo.ModusOperandi, id);
                //myDelitos.vehiculoss.VehiculossSoloBS = VehiculosDB.GetListByVinculoANDidDelito(VinculoVehiculo.BienesSustraidos, id);
            }
            return myDelitos;
        }

        /// <summary>
        /// Gets a single Delitos from the database.
        /// </summary>
        /// <param name="id">The id of the Causa of the Delitos in the database.</param>
        /// <param name="getDelitosRecords">Determines whether to load all associated Delitos records as well.</param>
        /// <returns>
        /// A Delitos object when the id exists in the database, or <see langword="null"/> otherwise.
        /// </returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Delitos GetItemByIdCausa(string idCausa, bool getDelitosRecords)
        {
            Delitos myDelitos = DelitosDB.GetItemByIdCausa(idCausa);
            int id=0;
            if (myDelitos!=null)
                 id = myDelitos.id;
            if (myDelitos != null && getDelitosRecords)
            {
                myDelitos.autoress = AutoresDB.GetListByidDelito(id);
            }
            if (myDelitos != null && getDelitosRecords)
            {
                //trae los registros detalles de cada bien sustraido
                myDelitos.bienesSustraidoss = BienesSustraidosManager.GetListByIdDelito(id,true);
            }
            if (myDelitos != null && getDelitosRecords)
            {
                myDelitos.lugaresDeTrasladoDeVictimass = LugaresDeTrasladoDeVictimasDB.GetListByidDelito(id);
            }
            if (myDelitos != null && getDelitosRecords)
            {
                myDelitos.rastross = RastrosDB.GetListByidDelito(id);
            }
            if (myDelitos != null && getDelitosRecords)
            {
                myDelitos.vehiculoss = VehiculosDB.GetListByidDelito(id);
                //myDelitos.vehiculoss.VehiculossSoloMO = VehiculosDB.GetListByVinculoANDidDelito(VinculoVehiculo.ModusOperandi, id);
                //myDelitos.vehiculoss.VehiculossSoloBS = VehiculosDB.GetListByVinculoANDidDelito(VinculoVehiculo.BienesSustraidos, id);
            }
            return myDelitos;
        }

      

/// <summary>
/// Saves a Delitos in the database.
/// </summary>
/// <param name="myDelitos">The Delitos instance to save.</param>
/// <returns>The new id if the Delitos is new in the database or the existing id when an item was updated.</returns>
[DataObjectMethod(DataObjectMethodType.Update, true)]
public static int Save(Delitos myDelitos)
{
    int delitosid;

    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        SqlCommand myCommand = new SqlCommand("DelitosInsertUpdateSingleItem", myConnection);

        myCommand.CommandType = CommandType.StoredProcedure;
        myConnection.Open();
        SqlTransaction tr = myConnection.BeginTransaction();
        myCommand.Transaction = tr;

        try
        {
            delitosid = DelitosDB.Save(myDelitos, myCommand);
            myDelitos.id = delitosid;

            foreach (Autores myAutores in myDelitos.autoress)
            {
                myAutores.idDelito = delitosid;
                AutoresManager.Save(myAutores,myCommand);
            }
            foreach (LugaresDeTrasladoDeVictimas myLugaresDeTrasladoDeVictimas in myDelitos.lugaresDeTrasladoDeVictimass)
            {
                myLugaresDeTrasladoDeVictimas.idDelito = delitosid;
                LugaresDeTrasladoDeVictimasManager.Save(myLugaresDeTrasladoDeVictimas, myCommand);
            }
            foreach (Rastros myRastros in myDelitos.rastross)
            {
                myRastros.idDelito = delitosid;
                RastrosManager.Save(myRastros, myCommand);
            }
            foreach (Vehiculos myVehiculos in myDelitos.vehiculoss)
            {
                myVehiculos.idDelito = delitosid;
                VehiculosManager.Save(myVehiculos, myCommand);
            }
            //foreach (Vehiculos myVehiculos in myDelitos.vehiculoss.VehiculossSoloBS)
            //{
            //    myVehiculos.idDelito = delitosid;
            //    VehiculosManager.Save(myVehiculos, myCommand);
            //}
            //foreach (Vehiculos myVehiculos in myDelitos.vehiculoss.VehiculossSoloMO)
            //{
            //    myVehiculos.idDelito = delitosid;
            //    VehiculosManager.Save(myVehiculos, myCommand);
            //}
            //Debe ir después del foreach Vehiculos que también recorre los vehículos sustraídos
            foreach (BienesSustraidos myBienesSustraidos in myDelitos.bienesSustraidoss)
            {
                myBienesSustraidos.idDelito = delitosid;
                BienesSustraidosManager.Save(myBienesSustraidos, myCommand);
            }
            tr.Commit();

        }
        catch (Exception e)
        {
            tr.Rollback();
            throw (e);
        }
        finally { myConnection.Close(); }

        return delitosid;
    }
}

        /// <summary>
        /// Deletes a Delitos from the database.
        /// </summary>
        /// <param name="myDelitos">The Delitos instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(Delitos myDelitos)
        {
            return DelitosDB.Delete(myDelitos.id);
        }

        #endregion

    }

}
