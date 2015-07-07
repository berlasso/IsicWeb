using System;
using System.ComponentModel;
using System.Transactions;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;
using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Bll;
using MPBA.SIAC.Dal;
namespace MPBA.PersonasBuscadas.Bll
{

    /// <summary>
    /// The PersonasDesaparecidasManager class is responsible for managing Business Object.PersonasDesaparecidas objects in the system.
    /// </summary>
    [DataObjectAttribute()]
    public partial class PersonasDesaparecidasManager
    {

        #region "Public Methods"

        /// <summary>
        /// Gets a list with all PersonasDesaparecidas objects in the database.
        /// </summary>
        /// <returns>A list with all PersonasDesaparecidas from the database when the database contains any, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static PersonasDesaparecidasList GetList()
        {
            return PersonasDesaparecidasDB.GetList();
        }

        /// <summary>
        /// Gets a list with all PersonasDesaparecidas objects in the database that match the filters.
        /// </summary>
        /// <returns>A list with all PersonasDesaparecidas from the database when the database contains any, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static PersonasDesaparecidasList GetListByIPP(string Ipp)
        {
                return PersonasDesaparecidasDB.GetListByIPP(Ipp.Trim());
            
        }

        /// <summary>
        /// Gets a list with all PersonasDesaparecidas objects in the database that match the filters.
        /// </summary>
        /// <returns>A list with all PersonasDesaparecidas from the database when the database contains any, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static PersonasDesaparecidasList GetList(Busqueda parametrosBusqueda)
        {
            if (parametrosBusqueda.IPP!=null && parametrosBusqueda.IPP.Length>0)
                return PersonasDesaparecidasDB.GetListByIPP(parametrosBusqueda.IPP.Trim());
            else
                return PersonasDesaparecidasDB.GetListByParametrosBusqueda(parametrosBusqueda);
        }

        /// <summary>
        /// Gets a single PersonasDesaparecidas from the database without its data.
        /// </summary>
        /// <param name="id">The id of the PersonasDesaparecidas in the database.</param>
        /// <returns>A PersonasDesaparecidas object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static PersonasDesaparecidas GetItem(int id)
        {
            return GetItem(id, false);
        }

        /// <summary>
        /// Gets a single PersonasDesaparecidas from the database without its data.
        /// </summary>
        /// <param name="id">The id of the Busqueda in the database.</param>
        /// <returns>A IPP when the id from Busqueda exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static PersonasDesaparecidas GetItemByIdBusqueda(int id)
        {
            return PersonasDesaparecidasDB.GetItemByIdBusqueda(id);
        }

        /// <summary>
        /// Gets a single PersonasDesaparecidas from the database.
        /// </summary>
        /// <param name="id">The id of the PersonasDesaparecidas in the database.</param>
        /// <param name="getPersonasDesaparecidasRecords">Determines whether to load all associated PersonasDesaparecidas records as well.</param>
        /// <returns>
        /// A PersonasDesaparecidas object when the id exists in the database, or <see langword="null"/> otherwise.
        /// </returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static PersonasDesaparecidas GetItem(int id, bool getPersonasDesaparecidasRecords)
        {
            PersonasDesaparecidas myPersonasDesaparecidas = PersonasDesaparecidasDB.GetItem(id);
            if (myPersonasDesaparecidas != null && getPersonasDesaparecidasRecords)
            {
                int idBusqueda = Convert.ToInt32(myPersonasDesaparecidas.idBusqueda);
                if (myPersonasDesaparecidas.esExtJurisdiccion == true)//ext jur
                    myPersonasDesaparecidas.PBCausaExtranaJurisdiccion = PBCausaExtranaJurisdiccionManager.GetItem(myPersonasDesaparecidas.Ipp, 1);
                myPersonasDesaparecidas.busqueda = BusquedaManager.GetItem(idBusqueda, true);
                myPersonasDesaparecidas.seniasParticularess = SeniasParticularesDB.GetListByidPersona(id, 1);
                myPersonasDesaparecidas.fotoss = PBFotosDB.GetListByidPersonaYTablaDestino(id, 1);
                myPersonasDesaparecidas.tatuajesPersonas = TatuajesPersonaDB.GetListByidPersonaDesaparecida(id);
            }
            return myPersonasDesaparecidas;
        }

        /// <summary>
        /// Gets a single PersonasDesaparecidas from the database using the IPP.
        /// </summary>
        /// <param name="id">The id of the PersonasDesaparecidas in the database.</param>
        /// <param name="getPersonasHalladasRecords">Determines whether to load all associated PersonasHalladas records as well.</param>
        /// <returns>
        /// A PersonasDesaparecidas object when the id exists in the database, or <see langword="null"/> otherwise.
        /// </returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static PersonasDesaparecidas GetItemByidCausa(string idCausa, bool getPersonasDesaparecidasRecords)
        {
            PersonasDesaparecidas myPersonaDesaparecida = PersonasDesaparecidasDB.GetItemByidCausa(idCausa);
            if (myPersonaDesaparecida != null && getPersonasDesaparecidasRecords)
            {
                int idBusqueda = Convert.ToInt32(myPersonaDesaparecida.idBusqueda);
                myPersonaDesaparecida.busqueda = BusquedaManager.GetItem(idBusqueda, true);
                myPersonaDesaparecida.seniasParticularess = SeniasParticularesDB.GetListByidPersona(Convert.ToInt32(myPersonaDesaparecida.Id), 1);
                myPersonaDesaparecida.fotoss = PBFotosDB.GetListByidPersonaYTablaDestino(Convert.ToInt32(myPersonaDesaparecida.Id), 1);
                myPersonaDesaparecida.tatuajesPersonas = TatuajesPersonaDB.GetListByidPersonaDesaparecida(Convert.ToInt32(myPersonaDesaparecida.Id));
            }
            return myPersonaDesaparecida;
        }


        /// <summary>
        /// Saves a PersonasDesaparecidas in the database.
        /// </summary>
        /// <param name="myPersonasDesaparecidas">The PersonasDesaparecidas instance to save.</param>
        /// <returns>The new id if the PersonasDesaparecidas is new in the database or the existing id when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static int Save(PersonasDesaparecidas myPersonasDesaparecidas)
        {

            int personasDesaparecidasid;
            int busquedaid;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasInsertUpdateSingleItem", myConnection);

                myCommand.CommandType = CommandType.StoredProcedure;
                myConnection.Open();
                SqlTransaction tr = myConnection.BeginTransaction();
                myCommand.Transaction = tr;

                try
                {
                    busquedaid = Convert.ToInt32(BusquedaManager.Save(myPersonasDesaparecidas.busqueda, myCommand));
                    myPersonasDesaparecidas.idBusqueda = busquedaid;
                    if (busquedaid < 1)
                        throw new Exception("no pudo guardar la busqueda");

                    personasDesaparecidasid = PersonasDesaparecidasDB.Save(myPersonasDesaparecidas, myCommand);
                    myPersonasDesaparecidas.Id = personasDesaparecidasid;
                    if (myPersonasDesaparecidas.PBCausaExtranaJurisdiccion != null)
                    {
                        myPersonasDesaparecidas.PBCausaExtranaJurisdiccion.NroCausa = myPersonasDesaparecidas.Ipp;
                        PBCausaExtranaJurisdiccionManager.Save(myPersonasDesaparecidas.PBCausaExtranaJurisdiccion);
                    }
                    if (myPersonasDesaparecidas.seniasParticularess != null)
                    {
                        foreach (SeniasParticulares mySeniasParticulares in myPersonasDesaparecidas.seniasParticularess)
                        {
                            mySeniasParticulares.idPersona = personasDesaparecidasid;
                            mySeniasParticulares.idTablaDestino = 1;
                            SeniasParticularesManager.Save(mySeniasParticulares, myCommand);
                        }
                    }

                    if (myPersonasDesaparecidas.tatuajesPersonas != null)
                    {
                        foreach (TatuajesPersona myTatuajePersona in myPersonasDesaparecidas.tatuajesPersonas)
                        {
                            myTatuajePersona.idPersona = personasDesaparecidasid;
                            myTatuajePersona.idTablaDestino = 1;
                            TatuajesPersonaManager.Save(myTatuajePersona, myCommand);
                        }
                    }

                    if (myPersonasDesaparecidas.fotoss != null)
                    {
                        foreach (PBFotos myFoto in myPersonasDesaparecidas.fotoss)
                        {
                            myFoto.idPersona = personasDesaparecidasid;
                            myFoto.idTablaDestino = 1;
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

                return personasDesaparecidasid;
            }

        }

        /// <summary>
        /// Saves a PersonasDesaparecidas in the database.
        /// </summary>
        /// <param name="myPersonasDesaparecidas">The PersonasDesaparecidas instance to save.</param>
        /// <returns>The new id if the PersonasDesaparecidas is new in the database or the existing id when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static int Save(PersonasDesaparecidas myPersonasDesaparecidas, SqlCommand myCommand)
        {
            int personasDesaparecidasid = PersonasDesaparecidasDB.Save(myPersonasDesaparecidas, myCommand);
            myPersonasDesaparecidas.Id = personasDesaparecidasid;
            return personasDesaparecidasid;


        }
        /// <summary>
        /// Deletes a PersonasDesaparecidas from the database.
        /// </summary>
        /// <param name="myPersonasDesaparecidas">The PersonasDesaparecidas instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(PersonasDesaparecidas myPersonasDesaparecidas)
        {
            return PersonasDesaparecidasDB.Delete(myPersonasDesaparecidas.Id);
        }

        #endregion

    }

}
