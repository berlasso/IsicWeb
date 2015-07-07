using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll
{

    /// <summary>
    /// The NNClaseEstadoInformeRastroManager class is responsible for managing Business Object.NNClaseEstadoInformeRastro objects in the system.
    /// </summary>
    [DataObjectAttribute()]
    public partial class NNClaseEstadoInformeRastroManager
    {

        #region "Public Methods"

        /// <summary>
        /// Gets a list with all NNClaseEstadoInformeRastro objects in the database.
        /// </summary>
        /// <returns>A list with all NNClaseEstadoInformeRastro from the database when the database contains any, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static NNClaseEstadoInformeRastroList GetList()
        {
            return NNClaseEstadoInformeRastroDB.GetList();
        }

        /// <summary>
        /// Gets a single NNClaseEstadoInformeRastro from the database without its data.
        /// </summary>
        /// <param name="id">The id of the NNClaseEstadoInformeRastro in the database.</param>
        /// <returns>A NNClaseEstadoInformeRastro object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static NNClaseEstadoInformeRastro GetItem(int id, int idDelito)
        {
            return GetItem(id, false, idDelito);
        }

        /// <summary>
        /// Gets a single NNClaseEstadoInformeRastro from the database without its data.
        /// </summary>
        /// <param name="id">The id of the NNClaseEstadoInformeRastro in the database.</param>
        /// <returns>A NNClaseEstadoInformeRastro object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static NNClaseEstadoInformeRastro GetItem(int id)
        {
            return GetItem(id, false);
        }

        ///// <summary>
        ///// Gets a single NNClaseEstadoInformeRastro from the database without its data.
        ///// </summary>
        ///// <param name="id">The id of the NNClaseEstadoInformeRastro in the database.</param>
        ///// <returns>A NNClaseEstadoInformeRastro object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
        //[DataObjectMethod(DataObjectMethodType.Select, false)]
        //public static NNClaseEstadoInformeRastro GetItem(int id,iddelito)
        //{
        //    return GetItem(id, false,iddelito);
        //}

      

        /// <summary>
        /// Gets a single NNClaseEstadoInformeRastro from the database.
        /// </summary>
        /// <param name="id">The id of the NNClaseEstadoInformeRastro in the database.</param>
        /// <param name="getNNClaseEstadoInformeRastroRecords">Determines whether to load all associated NNClaseEstadoInformeRastro records as well.</param>
        /// <returns>
        /// A NNClaseEstadoInformeRastro object when the id exists in the database, or <see langword="null"/> otherwise.
        /// </returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static NNClaseEstadoInformeRastro GetItem(int id, bool getNNClaseEstadoInformeRastroRecords, int idTipoDelito)
        {
            NNClaseEstadoInformeRastro myNNClaseEstadoInformeRastro = NNClaseEstadoInformeRastroDB.GetItem(id);
            if (myNNClaseEstadoInformeRastro != null && getNNClaseEstadoInformeRastroRecords)
            {
                myNNClaseEstadoInformeRastro.rastross = RastrosDB.GetListByidClaseEstadoInformeRastro(id, idTipoDelito);
            }
            return myNNClaseEstadoInformeRastro;
        }

        /// <summary>
        /// Gets a single NNClaseEstadoInformeRastro from the database.
        /// </summary>
        /// <param name="id">The id of the NNClaseEstadoInformeRastro in the database.</param>
        /// <param name="getNNClaseEstadoInformeRastroRecords">Determines whether to load all associated NNClaseEstadoInformeRastro records as well.</param>
        /// <returns>
        /// A NNClaseEstadoInformeRastro object when the id exists in the database, or <see langword="null"/> otherwise.
        /// </returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static NNClaseEstadoInformeRastro GetItem(int id, bool getNNClaseEstadoInformeRastroRecords)
        {
            NNClaseEstadoInformeRastro myNNClaseEstadoInformeRastro = NNClaseEstadoInformeRastroDB.GetItem(id);
            if (myNNClaseEstadoInformeRastro != null && getNNClaseEstadoInformeRastroRecords)
            {
                myNNClaseEstadoInformeRastro.rastross = RastrosDB.GetListByidClaseEstadoInformeRastro(id);
            }
            return myNNClaseEstadoInformeRastro;
        }
       

        /// <summary>
        /// Saves a NNClaseEstadoInformeRastro in the database.
        /// </summary>
        /// <param name="myNNClaseEstadoInformeRastro">The NNClaseEstadoInformeRastro instance to save.</param>
        /// <returns>The new id if the NNClaseEstadoInformeRastro is new in the database or the existing id when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static int Save(NNClaseEstadoInformeRastro myNNClaseEstadoInformeRastro)
        {
            using (TransactionScope myTransactionScope = new TransactionScope())
            {
                int nNClaseEstadoInformeRastroid = NNClaseEstadoInformeRastroDB.Save(myNNClaseEstadoInformeRastro);
                foreach (Rastros myRastros in myNNClaseEstadoInformeRastro.rastross)
                {
                    myRastros.id = nNClaseEstadoInformeRastroid;
                    RastrosDB.Save(myRastros);
                }

                //  Assign the NNClaseEstadoInformeRastro its new (or existing id).
                myNNClaseEstadoInformeRastro.id = nNClaseEstadoInformeRastroid;

                myTransactionScope.Complete();

                return nNClaseEstadoInformeRastroid;
            }
        }

        /// <summary>
        /// Deletes a NNClaseEstadoInformeRastro from the database.
        /// </summary>
        /// <param name="myNNClaseEstadoInformeRastro">The NNClaseEstadoInformeRastro instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(NNClaseEstadoInformeRastro myNNClaseEstadoInformeRastro)
        {
            return NNClaseEstadoInformeRastroDB.Delete(myNNClaseEstadoInformeRastro.id);
        }

        #endregion

    }

}
