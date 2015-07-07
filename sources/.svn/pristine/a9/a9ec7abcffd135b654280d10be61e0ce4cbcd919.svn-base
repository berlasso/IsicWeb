using System;
using System.ComponentModel;
using System.Transactions;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.SIAC.Bll;
using MPBA.SIAC.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;
using MPBA.SIAC.Dal;

namespace MPBA.PersonasBuscadas.Bll
{

    /// <summary>
    /// The PersonasHalladasManager class is responsible for managing Business Object.PersonasHalladas objects in the system.
    /// </summary>
    [DataObjectAttribute()]
    public partial class PersonasHalladasManager
    {

        #region "Public Methods"

        /// <summary>
        /// Gets a list with all PersonasHalladas objects in the database.
        /// </summary>
        /// <returns>A list with all PersonasHalladas from the database when the database contains any, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static PersonasHalladasList GetList()
        {
            return PersonasHalladasDB.GetList();
        }

        /// <summary>
        /// Gets a list with all PersonasHalladas objects in the database that match the filters
        /// </summary>
        /// <returns>A list with all PersonasHalladas from the database when the database contains any, or null otherwise.</returns>
        /// <param name="parametrosBusqueda">Los parametros de busqueda a utilizar.</param>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static PersonasHalladasList GetList(Busqueda parametrosBusqueda)
        {
            if (parametrosBusqueda.IPP != null && parametrosBusqueda.IPP.Length > 0)
                return PersonasHalladasDB.GetListByIPP(parametrosBusqueda.IPP.Trim());
            else
                return PersonasHalladasDB.GetListByParametrosBusqueda(parametrosBusqueda);
        }

        /// <summary>
        /// Gets a single PersonasHalladas from the database without its data.
        /// </summary>
        /// <param name="id">The id of the Busqueda in the database.</param>
        /// <returns>A IPP when the id from Busqueda exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static PersonasHalladas GetItemByIdBusqueda(int id)
        {
            return PersonasHalladasDB.GetItemByIdBusqueda(id);
        }

        ///// <summary>
        ///// Gets a list with all PersonasHalladas objects in the database that match the fechaultimamodificacion en adelante
        ///// </summary>
        ///// <returns>A list with all PersonasHalladas from the database when the database contains any, or null otherwise.</returns>
        ///// <param name="fechaUltimaModificacion">A partir de que fechaultimamodificacion quiero el listado.</param>
        //[DataObjectMethod(DataObjectMethodType.Select, true)]
        //public static PersonasHalladasList GetList(DateTime fechaUltimaModificacion)
        //{
            
        //        return PersonasHalladasDB.GetListByFechaUltimaModificacion(fechaUltimaModificacion);
        //}

        /// <summary>
        /// Gets a single PersonasHalladas from the database without its data.
        /// </summary>
        /// <param name="id">The id of the PersonasHalladas in the database.</param>
        /// <returns>A PersonasHalladas object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static PersonasHalladas GetItem(int id)
        {
            return GetItem(id, false);
        }

        /// <summary>
        /// Gets a single PersonasHalladas from the database.
        /// </summary>
        /// <param name="id">The id of the PersonasHalladas in the database.</param>
        /// <param name="getPersonasHalladasRecords">Determines whether to load all associated PersonasHalladas records as well.</param>
        /// <returns>
        /// A PersonasHalladas object when the id exists in the database, or <see langword="null"/> otherwise.
        /// </returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static PersonasHalladas GetItem(int id, bool getPersonasHalladasRecords)
        {
            PersonasHalladas myPersonasHalladas = PersonasHalladasDB.GetItem(id);
            if (myPersonasHalladas != null && getPersonasHalladasRecords)
            {
                int idBusqueda = Convert.ToInt32(myPersonasHalladas.idBusqueda);
                if (myPersonasHalladas.esExtJurisdiccion == true)//ext jur
                    myPersonasHalladas.PBCausaExtranaJurisdiccion = PBCausaExtranaJurisdiccionManager.GetItem(myPersonasHalladas.Ipp.Trim(), 2);
                myPersonasHalladas.busqueda = BusquedaManager.GetItem(idBusqueda,true);
                myPersonasHalladas.seniasParticularess = SeniasParticularesDB.GetListByidPersona(id, 2);
                myPersonasHalladas.fotoss = PBFotosDB.GetListByidPersonaYTablaDestino(id, 2);
                myPersonasHalladas.tatuajesPersonas = TatuajesPersonaDB.GetListByidPersonaHallada(id);
            }
            return myPersonasHalladas;
        }

        /// <summary>
        /// Gets a single PersonasHalladas from the database using the IPP.
        /// </summary>
        /// <param name="id">The id of the PersonasHalladas in the database.</param>
        /// <param name="getPersonasHalladasRecords">Determines whether to load all associated PersonasHalladas records as well.</param>
        /// <returns>
        /// A PersonasHalladas object when the id exists in the database, or <see langword="null"/> otherwise.
        /// </returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static PersonasHalladas GetItemByidCausa(string idCausa, bool getPersonasHalladasRecords)
        {
            PersonasHalladas myPersonasHalladas = PersonasHalladasDB.GetItemByidCausa(idCausa);
            if (myPersonasHalladas != null && getPersonasHalladasRecords)
            {
                int idBusqueda = Convert.ToInt32(myPersonasHalladas.idBusqueda);
                myPersonasHalladas.busqueda = BusquedaManager.GetItem(idBusqueda, true);
                myPersonasHalladas.seniasParticularess = SeniasParticularesDB.GetListByidPersona(Convert.ToInt32(myPersonasHalladas.Id), 2);
                myPersonasHalladas.fotoss = PBFotosDB.GetListByidPersonaYTablaDestino(Convert.ToInt32(myPersonasHalladas.Id), 2);
                myPersonasHalladas.tatuajesPersonas = TatuajesPersonaDB.GetListByidPersonaHallada(Convert.ToInt32(myPersonasHalladas.Id));
            }
            return myPersonasHalladas;
        }

        /// <summary>
        /// Gets a list with all PersonasHalladas objects in the database that match the filters.
        /// </summary>
        /// <returns>A list with all PersonasHalladas from the database when the database contains any, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static PersonasHalladasList GetListByIPP(string Ipp)
        {
            return PersonasHalladasDB.GetListByIPP(Ipp.Trim());

        }


        /// <summary>
        /// Saves a PersonasHalladas in the database.
        /// </summary>
        /// <param name="myPersonasHalladas">The PersonasHalladas instance to save.</param>
        /// <returns>The new id if the PersonasHalladas is new in the database or the existing id when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static int Save(PersonasHalladas myPersonasHalladas)
        {
            int personasHalladasid;
            int busquedaid;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                SqlCommand myCommand = new SqlCommand("PersonasHalladasInsertUpdateSingleItem", myConnection);

                myCommand.CommandType = CommandType.StoredProcedure;
                myConnection.Open();
                SqlTransaction tr = myConnection.BeginTransaction();
                myCommand.Transaction = tr;

                try
                {
                    

                    
                        busquedaid=Convert.ToInt32(BusquedaManager.Save(myPersonasHalladas.busqueda, myCommand));
                        myPersonasHalladas.idBusqueda = busquedaid;
                        if (busquedaid < 1)
                            throw new Exception("no pudo guardar la busqueda");
                    
                    personasHalladasid = PersonasHalladasDB.Save(myPersonasHalladas, myCommand);
                    myPersonasHalladas.Id = personasHalladasid;
                    if (myPersonasHalladas.PBCausaExtranaJurisdiccion != null)
                    {
                        myPersonasHalladas.PBCausaExtranaJurisdiccion.NroCausa = myPersonasHalladas.Ipp;
                        PBCausaExtranaJurisdiccionManager.Save(myPersonasHalladas.PBCausaExtranaJurisdiccion);
                    }

                    if (myPersonasHalladas.seniasParticularess != null)
                    {
                        foreach (SeniasParticulares mySeniasParticulares in myPersonasHalladas.seniasParticularess)
                        {
                            mySeniasParticulares.idPersona = personasHalladasid;
                            mySeniasParticulares.idTablaDestino = 2;
                            SeniasParticularesManager.Save(mySeniasParticulares, myCommand);

                        }
                    }

                    if (myPersonasHalladas.tatuajesPersonas != null)
                    {
                        foreach (TatuajesPersona myTatuajePersona in myPersonasHalladas.tatuajesPersonas)
                        {
                            myTatuajePersona.idPersona = personasHalladasid;
                            myTatuajePersona.idTablaDestino = 2;
                            TatuajesPersonaManager.Save(myTatuajePersona, myCommand);
                        }
                    }

                    if (myPersonasHalladas.fotoss != null)
                    {
                        foreach (PBFotos myFoto in myPersonasHalladas.fotoss)
                        {
                            myFoto.idPersona = personasHalladasid;
                            myFoto.idTablaDestino = 2;
                            PBFotosManager.Save(myFoto, myCommand);
                        }
                    }

                    tr.Commit();
                }

                catch (Exception e)
                {
                    tr.Rollback();
                    throw (e);
                }
                finally { myConnection.Close(); }

                return personasHalladasid;
            }
        }

        /// <summary>
        /// Saves a PersonasHalladas in the database.
        /// </summary>
        /// <param name="myPersonasHalladas">The PersonasHalladas instance to save.</param>
        /// <returns>The new id if the PersonasHalladas is new in the database or the existing id when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static int Save(PersonasHalladas myPersonasHalladas, SqlCommand myCommand)
        {
            int personasHalladasid = PersonasHalladasDB.Save(myPersonasHalladas, myCommand);
            myPersonasHalladas.Id = personasHalladasid;
            return personasHalladasid;
        }



        /// <summary>
        /// Deletes a PersonasHalladas from the database.
        /// </summary>
        /// <param name="myPersonasHalladas">The PersonasHalladas instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(PersonasHalladas myPersonasHalladas)
        {
            return PersonasHalladasDB.Delete(myPersonasHalladas.Id);
        }

        #endregion

    }

}
