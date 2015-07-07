using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll
{

    /// <summary>
    /// The PersonasEncontradasManager class is responsible for managing Business Entities.PersonasEncontradas objects in the system.
    /// </summary>
    [DataObjectAttribute()]
    public partial class PersonasEncontradasManager
    {

        #region "Public Methods"

        /// <summary>
        /// Gets a list with all PersonasEncontradas objects in the database.
        /// </summary>
        /// <returns>A list with all PersonasEncontradas from the database when the database contains any, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static PersonasEncontradasList GetList()
        {
            return PersonasEncontradasDB.GetList();
        }

        /// <summary>
        /// Gets a single PersonasEncontradas from the database without its data.
        /// </summary>
        /// <param name="id">The id of the PersonasEncontradas in the database.</param>
        /// <returns>A PersonasEncontradas object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static PersonasEncontradas GetItem(int id)
        {
            return GetItem(id, false);
        }

        /// <summary>
        /// Gets a single PersonasEncontradas from the database.
        /// </summary>
        /// <param name="id">The id of the PersonasEncontradas in the database.</param>
        /// <param name="getPersonasEncontradasRecords">Determines whether to load all associated PersonasEncontradas records as well.</param>
        /// <returns>
        /// A PersonasEncontradas object when the id exists in the database, or <see langword="null"/> otherwise.
        /// </returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static PersonasEncontradas GetItem(int id, bool getPersonasEncontradasRecords)
        {
            PersonasEncontradas myPersonasEncontradas = PersonasEncontradasDB.GetItem(id);
            return myPersonasEncontradas;
        }

        /// <summary>
        /// Saves a PersonasEncontradas in the database.
        /// </summary>
        /// <param name="myPersonasEncontradas">The PersonasEncontradas instance to save.</param>
        /// <returns>The new id if the PersonasEncontradas is new in the database or the existing id when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static int Save(PersonasEncontradas myPersonasEncontradas)
        {
            using (TransactionScope myTransactionScope = new TransactionScope())
            {
                int personasEncontradasid = PersonasEncontradasDB.Save(myPersonasEncontradas);

                //  Assign the PersonasEncontradas its new (or existing id).
                myPersonasEncontradas.id = personasEncontradasid;

                myTransactionScope.Complete();

                return personasEncontradasid;
            }
        }

        /// <summary>
        /// Deletes a PersonasEncontradas from the database.
        /// </summary>
        /// <param name="myPersonasEncontradas">The PersonasEncontradas instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(PersonasEncontradas myPersonasEncontradas)
        {
            return PersonasEncontradasDB.Delete(myPersonasEncontradas.id);
        }

        #endregion

    }

}
