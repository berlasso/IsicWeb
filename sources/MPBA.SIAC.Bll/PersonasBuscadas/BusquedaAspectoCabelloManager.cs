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
    /// The BusquedaAspectoCabelloManager class is responsible for managing Business Object.BusquedaAspectoCabello objects in the system.
    /// </summary>
    [DataObjectAttribute()]
    public partial class BusquedaAspectoCabelloManager
    {

        #region "Public Methods"

        /// <summary>
        /// Gets a list with all BusquedaAspectoCabello objects in the database.
        /// </summary>
        /// <returns>A list with all BusquedaAspectoCabello from the database when the database contains any, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static BusquedaAspectoCabelloList GetList()
        {
            return BusquedaAspectoCabelloDB.GetList();
        }

        /// <summary>
        /// Gets a single BusquedaAspectoCabello from the database without its data.
        /// </summary>
        /// <param name="id">The id of the BusquedaAspectoCabello in the database.</param>
        /// <returns>A BusquedaAspectoCabello object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static BusquedaAspectoCabello GetItem(decimal id)
        {
            return GetItem(id, false);
        }

        /// <summary>
        /// Gets a single BusquedaAspectoCabello from the database.
        /// </summary>
        /// <param name="id">The id of the BusquedaAspectoCabello in the database.</param>
        /// <param name="getBusquedaAspectoCabelloRecords">Determines whether to load all associated BusquedaAspectoCabello records as well.</param>
        /// <returns>
        /// A BusquedaAspectoCabello object when the id exists in the database, or <see langword="null"/> otherwise.
        /// </returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static BusquedaAspectoCabello GetItem(decimal id, bool getBusquedaAspectoCabelloRecords)
        {
            BusquedaAspectoCabello myBusquedaAspectoCabello = BusquedaAspectoCabelloDB.GetItem(id);
            return myBusquedaAspectoCabello;
        }

        /// <summary>
        /// Saves a BusquedaAspectoCabello in the database.
        /// </summary>
        /// <param name="myBusquedaAspectoCabello">The BusquedaAspectoCabello instance to save.</param>
        /// <returns>The new id if the BusquedaAspectoCabello is new in the database or the existing id when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static decimal Save(BusquedaAspectoCabello myBusquedaAspectoCabello, SqlCommand myCommand)
        {
            //using (TransactionScope myTransactionScope = new TransactionScope())
            //{
                decimal busquedaAspectoCabelloid = BusquedaAspectoCabelloDB.Save(myBusquedaAspectoCabello, myCommand);

                //  Assign the BusquedaAspectoCabello its new (or existing id).
                myBusquedaAspectoCabello.id = busquedaAspectoCabelloid;

                //myTransactionScope.Complete();

                return busquedaAspectoCabelloid;
           // }
        }

        /// <summary>
        /// Deletes a BusquedaAspectoCabello from the database.
        /// </summary>
        /// <param name="myBusquedaAspectoCabello">The BusquedaAspectoCabello instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(BusquedaAspectoCabello myBusquedaAspectoCabello)
        {
            return BusquedaAspectoCabelloDB.Delete(myBusquedaAspectoCabello.id);
        }
        /// <summary>
        /// Deletes las BusquedaAspectoCabello de una Busqueda from the database.
        /// </summary>
        /// <param name="myBusquedaAspectoCabello">The Busqueda to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool DeleteByIdBusqueda(decimal idBusqueda)
        {
            return BusquedaAspectoCabelloDB.DeleteByIdBusqueda(idBusqueda);
        }

        #endregion

    }

}
