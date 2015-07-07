using System;
using System.ComponentModel;
using System.Transactions;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll
{

    /// <summary>
    /// The BusquedasFavoritasManager class is responsible for managing Business Object.BusquedasFavoritas objects in the system.
    /// </summary>
    [DataObjectAttribute()]
    public partial class BusquedasFavoritasManager
    {

        #region "Public Methods"

        /// <summary>
        /// Gets a list with all BusquedasFavoritas objects in the database.
        /// </summary>
        /// <returns>A list with all BusquedasFavoritas from the database when the database contains any, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static BusquedasFavoritasList GetList()
        {
            return BusquedasFavoritasDB.GetList();
        }

        /// <summary>
        /// Gets a list joined  BusquedasFavoritas from the database without its data.
        /// </summary>
        /// <param name="id">The id of the tabladestino of the BusquedasFavoritas in the database.</param>
        /// <returns>A BusquedasFavoritas object when the idtabladestino exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static PersonasDesaparecidasList GetListJoinedDesaparecidas(string Usuario)
        {
            return BusquedasFavoritasDB.GetListJoinedDesaparecidas(Usuario);
        }

        /// <summary>
        /// Gets a list joined  BusquedasFavoritas from the database without its data.
        /// </summary>
        /// <param name="id">The id of the tabladestino of the BusquedasFavoritas in the database.</param>
        /// <returns>A BusquedasFavoritas object when the idtabladestino exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static PersonasHalladasList GetListJoinedHalladas(string Usuario)
        {
            return BusquedasFavoritasDB.GetListJoinedHalladas(Usuario);
        }

        /// <summary>
        /// Gets a single BusquedasFavoritas from the database without its data.
        /// </summary>
        /// <param name="id">The id of the BusquedasFavoritas in the database.</param>
        /// <returns>A BusquedasFavoritas object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static BusquedasFavoritas GetItem(int id)
        {
            return GetItem(id, false);
        }

        /// <summary>
        /// Gets a single BusquedasFavoritas from the database without its data.
        /// </summary>
        /// <param name="idPersona">The id of the Persona in the database.</param>
        /// /// <param name="idTablaDestino">The id of the TablaDestino in the database.</param>
        /// <returns>A BusquedasFavoritas object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static BusquedasFavoritas GetItem(int idPersona, int idTablaDestino)
        {
            return BusquedasFavoritasDB.GetItem(idPersona, idTablaDestino);
        }

        /// <summary>
        /// Gets a single BusquedasFavoritas from the database.
        /// </summary>
        /// <param name="id">The id of the BusquedasFavoritas in the database.</param>
        /// <param name="getBusquedasFavoritasRecords">Determines whether to load all associated BusquedasFavoritas records as well.</param>
        /// <returns>
        /// A BusquedasFavoritas object when the id exists in the database, or <see langword="null"/> otherwise.
        /// </returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static BusquedasFavoritas GetItem(int id, bool getBusquedasFavoritasRecords)
        {
            BusquedasFavoritas myBusquedasFavoritas = BusquedasFavoritasDB.GetItem(id);
            return myBusquedasFavoritas;
        }

        /// <summary>
        /// Saves a BusquedasFavoritas in the database.
        /// </summary>
        /// <param name="myBusquedasFavoritas">The BusquedasFavoritas instance to save.</param>
        /// <returns>The new id if the BusquedasFavoritas is new in the database or the existing id when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static int Save(BusquedasFavoritas myBusquedasFavoritas, SqlCommand myCommand)
        {
            //using (TransactionScope myTransactionScope = new TransactionScope())
            //{
                int busquedasFavoritasid = BusquedasFavoritasDB.Save(myBusquedasFavoritas);

                //  Assign the BusquedasFavoritas its new (or existing id).
                myBusquedasFavoritas.id = busquedasFavoritasid;

                //myTransactionScope.Complete();

                return busquedasFavoritasid;
          //  }
        }

        /// <summary>
        /// Saves a BusquedasFavoritas in the database.
        /// </summary>
        /// <param name="myBusquedasFavoritas">The BusquedasFavoritas instance to save.</param>
        /// <returns>The new id if the BusquedasFavoritas is new in the database or the existing id when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static int Save(BusquedasFavoritas myBusquedasFavoritas)
        {
            int busquedasFavoritasid;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                SqlCommand myCommand = new SqlCommand("BusquedasFavoritasInsertUpdateSingleItem", myConnection);

                myCommand.CommandType = CommandType.StoredProcedure;
                myConnection.Open();
                SqlTransaction tr = myConnection.BeginTransaction();
                myCommand.Transaction = tr;

                try
                {
                busquedasFavoritasid = BusquedasFavoritasDB.Save(myBusquedasFavoritas);

                //  Assign the BusquedasFavoritas its new (or existing id).
                myBusquedasFavoritas.id = busquedasFavoritasid;

                tr.Commit();
                }

                catch (Exception e)
                {
                    tr.Rollback();
                    throw (e);
                }
                finally { myConnection.Close(); }

            


                return busquedasFavoritasid;
            }
        }

        /// <summary>
        /// Deletes a BusquedasFavoritas from the database.
        /// </summary>
        /// <param name="myBusquedasFavoritas">The BusquedasFavoritas instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(BusquedasFavoritas myBusquedasFavoritas)
        {
            return BusquedasFavoritasDB.Delete(myBusquedasFavoritas.id);
        }

        #endregion

    }

}
