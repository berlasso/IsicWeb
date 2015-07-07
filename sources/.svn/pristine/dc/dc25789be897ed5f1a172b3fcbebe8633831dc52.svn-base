using System;
using System.ComponentModel;
using System.Transactions;
using System.Data;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll
{

    /// <summary>
    /// The BusquedaRostroManager class is responsible for managing Business Object.BusquedaRostro objects in the system.
    /// </summary>
    [DataObjectAttribute()]
    public partial class BusquedaRostroManager
    {

        #region "Public Methods"

        /// <summary>
        /// Gets a list with all BusquedaRostro objects in the database.
        /// </summary>
        /// <returns>A list with all BusquedaRostro from the database when the database contains any, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static BusquedaRostroList GetList()
        {
            return BusquedaRostroDB.GetList();
        }

        /// <summary>
        /// Gets a single BusquedaRostro from the database without its data.
        /// </summary>
        /// <param name="id">The id of the BusquedaRostro in the database.</param>
        /// <returns>A BusquedaRostro object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static BusquedaRostro GetItem(decimal id)
        {
            return GetItem(id, false);
        }

        /// <summary>
        /// Gets a single BusquedaRostro from the database.
        /// </summary>
        /// <param name="id">The id of the BusquedaRostro in the database.</param>
        /// <param name="getBusquedaRostroRecords">Determines whether to load all associated BusquedaRostro records as well.</param>
        /// <returns>
        /// A BusquedaRostro object when the id exists in the database, or <see langword="null"/> otherwise.
        /// </returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static BusquedaRostro GetItem(decimal id, bool getBusquedaRostroRecords)
        {
            BusquedaRostro myBusquedaRostro = BusquedaRostroDB.GetItem(id);
            return myBusquedaRostro;
        }

        /// <summary>
        /// Saves a BusquedaRostro in the database.
        /// </summary>
        /// <param name="myBusquedaRostro">The BusquedaRostro instance to save.</param>
        /// <returns>The new id if the BusquedaRostro is new in the database or the existing id when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static decimal Save(BusquedaRostro myBusquedaRostro, SqlCommand myCommand)
        {
            //using (TransactionScope myTransactionScope = new TransactionScope()){
            decimal BusquedaRostroid = BusquedaRostroDB.Save(myBusquedaRostro, myCommand);

            //  Assign the BusquedaRostro its new (or existing id).
            myBusquedaRostro.id = BusquedaRostroid;

            //myTransactionScope.Complete();

            return BusquedaRostroid;
            //}
        }

        /// <summary>
        /// Deletes a BusquedaRostro from the database.
        /// </summary>
        /// <param name="myBusquedaRostro">The BusquedaRostro instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(BusquedaRostro myBusquedaRostro)
        {
            return BusquedaRostroDB.Delete(myBusquedaRostro.id);
        }

        /// <summary>
        /// Deletes las BusquedaRostro de una Busqueda from the database.
        /// </summary>
        /// <param name="myBusquedaRostro">The Busqueda to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool DeleteByIdBusqueda(decimal idBusqueda)
        {
            return BusquedaRostroDB.DeleteByIdBusqueda(idBusqueda);
        }



        #endregion

    }

}
