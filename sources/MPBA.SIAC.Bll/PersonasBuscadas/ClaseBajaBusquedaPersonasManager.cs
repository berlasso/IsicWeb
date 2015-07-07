using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;

namespace MPBA.SIAC.Bll
{/// <summary>
    /// The ClaseBajaBusquedaPersonasManager class is responsible for managing Business Entities.ClaseBajaBusquedaPersonas objects in the system.
    /// </summary>
    [DataObjectAttribute()]
    public partial class ClaseBajaBusquedaPersonasManager
    {

        #region "Public Methods"

        /// <summary>
        /// Gets a list with all ClaseBajaBusquedaPersonas objects in the database.
        /// </summary>
        /// <returns>A list with all ClaseBajaBusquedaPersonas from the database when the database contains any, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static ClaseBajaBusquedaPersonasList GetList()
        {
            return ClaseBajaBusquedaPersonasDB.GetList();
        }

        /// <summary>
        /// Gets a single ClaseBajaBusquedaPersonas from the database without its data.
        /// </summary>
        /// <param name="id">The id of the ClaseBajaBusquedaPersonas in the database.</param>
        /// <returns>A ClaseBajaBusquedaPersonas object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static ClaseBajaBusquedaPersonas GetItem(int id)
        {
            return GetItem(id, false);
        }

        /// <summary>
        /// Gets a single ClaseBajaBusquedaPersonas from the database.
        /// </summary>
        /// <param name="id">The id of the ClaseBajaBusquedaPersonas in the database.</param>
        /// <param name="getClaseBajaBusquedaPersonasRecords">Determines whether to load all associated ClaseBajaBusquedaPersonas records as well.</param>
        /// <returns>
        /// A ClaseBajaBusquedaPersonas object when the id exists in the database, or <see langword="null"/> otherwise.
        /// </returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static ClaseBajaBusquedaPersonas GetItem(int id, bool getClaseBajaBusquedaPersonasRecords)
        {
            ClaseBajaBusquedaPersonas myClaseBajaBusquedaPersonas = ClaseBajaBusquedaPersonasDB.GetItem(id);
            return myClaseBajaBusquedaPersonas;
        }

        /// <summary>
        /// Saves a ClaseBajaBusquedaPersonas in the database.
        /// </summary>
        /// <param name="myClaseBajaBusquedaPersonas">The ClaseBajaBusquedaPersonas instance to save.</param>
        /// <returns>The new id if the ClaseBajaBusquedaPersonas is new in the database or the existing id when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static int Save(ClaseBajaBusquedaPersonas myClaseBajaBusquedaPersonas)
        {
            using (TransactionScope myTransactionScope = new TransactionScope())
            {
                 int claseBajaBusquedaPersonasid = ClaseBajaBusquedaPersonasDB.Save(myClaseBajaBusquedaPersonas);

                //  Assign the ClaseBajaBusquedaPersonas its new (or existing id).
                myClaseBajaBusquedaPersonas.id = claseBajaBusquedaPersonasid;

                myTransactionScope.Complete();

                return claseBajaBusquedaPersonasid;
            }
        }

        /// <summary>
        /// Deletes a ClaseBajaBusquedaPersonas from the database.
        /// </summary>
        /// <param name="myClaseBajaBusquedaPersonas">The ClaseBajaBusquedaPersonas instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(ClaseBajaBusquedaPersonas myClaseBajaBusquedaPersonas)
        {
            return ClaseBajaBusquedaPersonasDB.Delete(myClaseBajaBusquedaPersonas.id);
        }

        #endregion

    }

}
