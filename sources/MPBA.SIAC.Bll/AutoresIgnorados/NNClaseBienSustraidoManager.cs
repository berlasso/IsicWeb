using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;

namespace MPBA.AutoresIgnorados.Bll
{
    /// <summary>
    /// The NNClaseBienSustraidoManager class is responsible for managing Business Object.NNClaseBienSustraido objects in the system.
    /// </summary>
    [DataObjectAttribute()]
    public partial class NNClaseBienSustraidoManager
    {

        #region "Public Methods"

        /// <summary>
        /// Gets a list with all NNClaseBienSustraido objects in the database.
        /// </summary>
        /// <returns>A list with all NNClaseBienSustraido from the database when the database contains any, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static NNClaseBienSustraidoList GetList()
        {
            return NNClaseBienSustraidoDB.GetList();
        }

        /// <summary>
        /// Gets a single NNClaseBienSustraido from the database without its data.
        /// </summary>
        /// <param name="id">The id of the NNClaseBienSustraido in the database.</param>
        /// <returns>A NNClaseBienSustraido object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static NNClaseBienSustraido GetItem(int id)
        {
            return GetItem(id, false);
        }

        /// <summary>
        /// Gets a single NNClaseBienSustraido from the database.
        /// </summary>
        /// <param name="id">The id of the NNClaseBienSustraido in the database.</param>
        /// <param name="getNNClaseBienSustraidoRecords">Determines whether to load all associated NNClaseBienSustraido records as well.</param>
        /// <returns>
        /// A NNClaseBienSustraido object when the id exists in the database, or <see langword="null"/> otherwise.
        /// </returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static NNClaseBienSustraido GetItem(int id, bool getNNClaseBienSustraidoRecords)
        {
            NNClaseBienSustraido myNNClaseBienSustraido = NNClaseBienSustraidoDB.GetItem(id);
            if (myNNClaseBienSustraido != null && getNNClaseBienSustraidoRecords)
            {
                myNNClaseBienSustraido.bienesSustraidoss = BienesSustraidosDB.GetListByidClaseBienSustraido(id);
            }
            return myNNClaseBienSustraido;
        }

        /// <summary>
        /// Saves a NNClaseBienSustraido in the database.
        /// </summary>
        /// <param name="myNNClaseBienSustraido">The NNClaseBienSustraido instance to save.</param>
        /// <returns>The new id if the NNClaseBienSustraido is new in the database or the existing id when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static int Save(NNClaseBienSustraido myNNClaseBienSustraido)
        {
            using (TransactionScope myTransactionScope = new TransactionScope())
            {
                int nNClaseBienSustraidoid = NNClaseBienSustraidoDB.Save(myNNClaseBienSustraido);
                foreach (BienesSustraidos myBienesSustraidos in myNNClaseBienSustraido.bienesSustraidoss)
                {
                    myBienesSustraidos.id = nNClaseBienSustraidoid;
                    BienesSustraidosDB.Save(myBienesSustraidos);
                }

                //  Assign the NNClaseBienSustraido its new (or existing id).
                myNNClaseBienSustraido.id = nNClaseBienSustraidoid;

                myTransactionScope.Complete();

                return nNClaseBienSustraidoid;
            }
        }

        /// <summary>
        /// Deletes a NNClaseBienSustraido from the database.
        /// </summary>
        /// <param name="myNNClaseBienSustraido">The NNClaseBienSustraido instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(NNClaseBienSustraido myNNClaseBienSustraido)
        {
            return NNClaseBienSustraidoDB.Delete(myNNClaseBienSustraido.id);
        }

        #endregion

    }
}
