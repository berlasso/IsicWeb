using System;
using System.ComponentModel;
using System.Transactions;
using System.Data.SqlClient;
using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll
{

    /// <summary>
    /// The TatuajesPersonaManager class is responsible for managing Business Entities.TatuajesPersona objects in the system.
    /// </summary>
    [DataObjectAttribute()]
    public partial class TatuajesPersonaManager
    {

        #region "Public Methods"

        /// <summary>
        /// Gets a list with all TatuajesPersona objects in the database.
        /// </summary>
        /// <returns>A list with all TatuajesPersona from the database when the database contains any, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static TatuajesPersonaList GetList()
        {
            return TatuajesPersonaDB.GetList();
        }

        /// <summary>
        /// Gets a single TatuajesPersona from the database without its data.
        /// </summary>
        /// <param name="id">The id of the TatuajesPersona in the database.</param>
        /// <returns>A TatuajesPersona object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static TatuajesPersona GetItem(int id)
        {
            return GetItem(id, false);
        }

        /// <summary>
        /// Gets a list of TatuajesPersona from the database without its data.
        /// </summary>
        /// <param name="idPersona">The id of the Persona in the database.</param>
        /// <returns>A TatuajesPersona object when the persona exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static TatuajesPersonaList GetList(int idPersona, int idTablaDestino)
        {
            return TatuajesPersonaDB.GetList(idPersona, idTablaDestino);
        }

        /// <summary>
        /// Gets a single TatuajesPersona from the database.
        /// </summary>
        /// <param name="id">The id of the TatuajesPersona in the database.</param>
        /// <param name="getTatuajesPersonaRecords">Determines whether to load all associated TatuajesPersona records as well.</param>
        /// <returns>
        /// A TatuajesPersona object when the id exists in the database, or <see langword="null"/> otherwise.
        /// </returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static TatuajesPersona GetItem(int id, bool getTatuajesPersonaRecords)
        {
            TatuajesPersona myTatuajesPersona = TatuajesPersonaDB.GetItem(id);
            return myTatuajesPersona;
        }

        /// <summary>
        /// Saves a TatuajesPersona in the database.
        /// </summary>
        /// <param name="myTatuajesPersona">The TatuajesPersona instance to save.</param>
        /// <returns>The new id if the TatuajesPersona is new in the database or the existing id when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static int Save(TatuajesPersona myTatuajesPersona)
        {
            using (TransactionScope myTransactionScope = new TransactionScope())
            {
                int tatuajesPersonaid = TatuajesPersonaDB.Save(myTatuajesPersona);

                //  Assign the TatuajesPersona its new (or existing id).
                myTatuajesPersona.id = tatuajesPersonaid;

                myTransactionScope.Complete();

                return tatuajesPersonaid;
            }
        }

        /// <summary>
        /// Saves a TatuajePersona in the database.
        /// </summary>
        /// <param name="mySeniasParticulares">The TatuajePersona instance to save.</param>
        /// <returns>The new id if the TatuajePersona is new in the database or the existing id when an item was updated.</returns>
        public static int Save(TatuajesPersona myTatuajePersona, SqlCommand myCommand)
        {
            //using (TransactionScope myTransactionScope = new TransactionScope())
            //{
            int tatuajePersonaid = TatuajesPersonaDB.Save(myTatuajePersona, myCommand);

            //  Assign the TatuajePersona its new (or existing id).
            myTatuajePersona.id = tatuajePersonaid;

            //myTransactionScope.Complete();

            return tatuajePersonaid;
        }


        /// <summary>
        /// Deletes a TatuajesPersona from the database.
        /// </summary>
        /// <param name="myTatuajesPersona">The TatuajesPersona instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(TatuajesPersona myTatuajesPersona)
        {
            return TatuajesPersonaDB.Delete(myTatuajesPersona.id);
        }

        #endregion


    }

}
