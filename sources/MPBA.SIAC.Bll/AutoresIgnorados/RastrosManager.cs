using System;
using System.ComponentModel;
using System.Transactions;
using System.Data;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;
using MPBA.AutoresIgnorados.Dal;


namespace MPBA.AutoresIgnorados.Bll
{

    /// <summary>
    /// The RastrosManager class is responsible for managing Business Object.Rastros objects in the system.
    /// </summary>
    [DataObjectAttribute()]
    public partial class RastrosManager
    {

        #region "Public Methods"

        /// <summary>
        /// Gets a list with all Rastros objects in the database.
        /// </summary>
        /// <returns>A list with all Rastros from the database when the database contains any, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static RastrosList GetList()
        {
            return RastrosDB.GetList();
        }

        
        /// <summary>
        /// Gets a list with all Rastros objects in the database with IdClaseEstadoInformeRastro specified.
        /// </summary>
        /// <param name="idClaseEstadoInformeRastro">IdClaseEstadoInformeRastro correspondiente a los rastors</param>
        /// <returns>A list with all Rastros from the database when the database contains idClaseEstadoInformeRastro given.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static RastrosList GetListByIdClaseEstadoInformeRastro(int idClaseEstadoInformeRastro, int idClaseDelito)
        {
            return RastrosDB.GetListByidClaseEstadoInformeRastro(idClaseEstadoInformeRastro,idClaseDelito);
        }

        
        /// <summary>
        /// Gets a list with all Rastros objects in the database with IdDelito specified.
        /// </summary>
        /// <param name="idDelito">IdDelito correspondiente a los rastors</param>
        /// <returns>A list with all Rastros from the database when the database contains idDelito given.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static RastrosList GetList(int idDelito)
        {
            return RastrosDB.GetListByidDelito(idDelito);
        }

        /// <summary>
        /// Gets a list with all Rastros objects in the database with Criterio specified.
        /// </summary>
        /// <param name="idDelito">IdDelito correspondiente a los rastors</param>
        /// <returns>A list with all Rastros from the database when the database contains idDelito given.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static RastrosList GetList(CriteriosBusquedaCompleta criterio)
        {
            return RastrosDB.GetList(criterio);
        }
        ///// <summary>
        ///// Gets a list with all Rastros objects in the database with IdDelito specified grouped by ClaseRastros
        ///// </summary>
        ///// <param name="idDelito">IdDelito correspondiente a los rastros</param>
        ///// <returns>A list with all Rastros from the database when the database contains idDelito given groped by idClaseRastros.</returns>
        //[DataObjectMethod(DataObjectMethodType.Select, true)]
        //public static RastrosList GetListGroupedByClaseRastro(int idDelito)
        //{
        //    return RastrosDB.GetListByidDelitoGroupedByIdClaseRastro(idDelito);
        //}

        /// <summary>
        /// Gets a single Rastros from the database without its data.
        /// </summary>
        /// <param name="id">The id of the Rastros in the database.</param>
        /// <returns>A Rastros object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Rastros GetItem(int id)
        {
            return GetItem(id, false);
        }


        /// <summary>
        /// Gets a single Rastros from the database.
        /// </summary>
        /// <param name="id">The id of the Rastros in the database.</param>
        /// <param name="getRastrosRecords">Determines whether to load all associated Rastros records as well.</param>
        /// <returns>
        /// A Rastros object when the id exists in the database, or <see langword="null"/> otherwise.
        /// </returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Rastros GetItem(int id, bool getRastrosRecords)
        {
            Rastros myRastros = RastrosDB.GetItem(id);
            return myRastros;
        }

        /// <summary>
        /// Saves a Rastros in the database.
        /// </summary>
        /// <param name="myRastros">The Rastros instance to save.</param>
        /// <returns>The new id if the Rastros is new in the database or the existing id when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static int Save(Rastros myRastros)
        {
            using (TransactionScope myTransactionScope = new TransactionScope())
            {
                int rastrosid = RastrosDB.Save(myRastros);

                //  Assign the Rastros its new (or existing id).
                myRastros.id = rastrosid;

                myTransactionScope.Complete();

                return rastrosid;
            }
        }

public static int Save(Rastros myRastros, SqlCommand myCommand)
{
    //using (TransactionScope myTransactionScope = new TransactionScope())
    //{
        int rastrosid = RastrosDB.Save(myRastros, myCommand);

        //  Assign the Rastros its new (or existing id).
        myRastros.id = rastrosid;

        //myTransactionScope.Complete();

        return rastrosid;
    //}
}

        /// <summary>
        /// Deletes a Rastros from the database.
        /// </summary>
        /// <param name="myRastros">The Rastros instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(Rastros myRastros)
        {
            return RastrosDB.Delete(myRastros.id);
        }

        #endregion

    }

}
