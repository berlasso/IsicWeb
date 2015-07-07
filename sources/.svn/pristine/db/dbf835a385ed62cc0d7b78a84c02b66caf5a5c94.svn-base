using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll
{
    /// <summary>
    /// The NNClaseModoArriboHuidaManager class is responsible for managing Business Object.NNClaseModoArriboHuida objects in the system.
    /// </summary>
    [DataObjectAttribute()]
    public partial class NNClaseModoArriboHuidaManager
    {

        #region "Public Methods"

        /// <summary>
        /// Gets a list with all NNClaseModoArriboHuida objects in the database.
        /// </summary>
        /// <returns>A list with all NNClaseModoArriboHuida from the database when the database contains any, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static NNClaseModoArriboHuidaList GetList()
        {
            return NNClaseModoArriboHuidaDB.GetList();
        }

        /// <summary>
        /// Gets a single NNClaseModoArriboHuida from the database without its data.
        /// </summary>
        /// <param name="id">The id of the NNClaseModoArriboHuida in the database.</param>
        /// <returns>A NNClaseModoArriboHuida object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static NNClaseModoArriboHuida GetItem(int id)
        {
            return GetItem(id, false);
        }

        /// <summary>
        /// Gets a single NNClaseModoArriboHuida from the database.
        /// </summary>
        /// <param name="id">The id of the NNClaseModoArriboHuida in the database.</param>
        /// <param name="getNNClaseModoArriboHuidaRecords">Determines whether to load all associated NNClaseModoArriboHuida records as well.</param>
        /// <returns>
        /// A NNClaseModoArriboHuida object when the id exists in the database, or <see langword="null"/> otherwise.
        /// </returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static NNClaseModoArriboHuida GetItem(int id, bool getNNClaseModoArriboHuidaRecords)
        {
            NNClaseModoArriboHuida myNNClaseModoArriboHuida = NNClaseModoArriboHuidaDB.GetItem(id);
            if (myNNClaseModoArriboHuida != null && getNNClaseModoArriboHuidaRecords)
            {
                myNNClaseModoArriboHuida.delitoss = DelitosDB.GetListByidClaseModoArriboHuida(id);
            }
            return myNNClaseModoArriboHuida;
        }

        /// <summary>
        /// Saves a NNClaseModoArriboHuida in the database.
        /// </summary>
        /// <param name="myNNClaseModoArriboHuida">The NNClaseModoArriboHuida instance to save.</param>
        /// <returns>The new id if the NNClaseModoArriboHuida is new in the database or the existing id when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static int Save(NNClaseModoArriboHuida myNNClaseModoArriboHuida)
        {
            using (TransactionScope myTransactionScope = new TransactionScope())
            {
                int nNClaseModoArriboHuidaid = NNClaseModoArriboHuidaDB.Save(myNNClaseModoArriboHuida);
                foreach (Delitos myDelitos in myNNClaseModoArriboHuida.delitoss)
                {
                    myDelitos.id = nNClaseModoArriboHuidaid;
                    DelitosDB.Save(myDelitos);
                }

                //  Assign the NNClaseModoArriboHuida its new (or existing id).
                myNNClaseModoArriboHuida.id = nNClaseModoArriboHuidaid;

                myTransactionScope.Complete();

                return nNClaseModoArriboHuidaid;
            }
        }

        /// <summary>
        /// Deletes a NNClaseModoArriboHuida from the database.
        /// </summary>
        /// <param name="myNNClaseModoArriboHuida">The NNClaseModoArriboHuida instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(NNClaseModoArriboHuida myNNClaseModoArriboHuida)
        {
            return NNClaseModoArriboHuidaDB.Delete(myNNClaseModoArriboHuida.id);
        }

        #endregion

    }
}