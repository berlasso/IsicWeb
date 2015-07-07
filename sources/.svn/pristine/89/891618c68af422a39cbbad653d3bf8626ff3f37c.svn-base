using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;


namespace MPBA.SIAC.Bll
{

    /// <summary>
    /// The DepartamentoManager class is responsible for managing Business Object.Departamento objects in the system.
    /// </summary>
    [DataObjectAttribute()]
    public partial class DepartamentoManager
    {

        #region "Public Methods"

        /// <summary>
        /// Gets a list with all Departamento objects in the database.
        /// </summary>
        /// <returns>A list with all Departamento from the database when the database contains any, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static DepartamentoList GetList()
        {
            return DepartamentoDB.GetList();
        }


        /// <summary>
        /// Gets a single Departamento from the database without its data.
        /// </summary>
        /// <param name="id">The Id of the Departamento in the database.</param>
        /// <returns>A Departamento object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Departamento GetItem(int id)
        {
            return GetItem(id, false);
        }

        /// <summary>
        /// Gets a single Departamento from the database.
        /// </summary>
        /// <param name="id">The Id of the Departamento in the database.</param>
        /// <param name="getDepartamentoRecords">Determines whether to load all associated Departamento records as well.</param>
        /// <returns>
        /// A Departamento object when the Id exists in the database, or <see langword="null"/> otherwise.
        /// </returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Departamento GetItem(int id, bool getDepartamentoRecords)
        {
            Departamento myDepartamento = DepartamentoDB.GetItem(id);
            if (myDepartamento != null && getDepartamentoRecords)
            {
                myDepartamento.comisarias = ComisariaDB.GetListByidDepartamento(id);
            }
            return myDepartamento;
        }

        /// <summary>
        /// Saves a Departamento in the database.
        /// </summary>
        /// <param name="myDepartamento">The Departamento instance to save.</param>
        /// <returns>The new Id if the Departamento is new in the database or the existing Id when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static int Save(Departamento myDepartamento)
        {
            using (TransactionScope myTransactionScope = new TransactionScope())
            {
                int departamentoId = DepartamentoDB.Save(myDepartamento);
                foreach (Comisaria myComisaria in myDepartamento.comisarias)
                {
                    myComisaria.idDepartamento = departamentoId;
                    ComisariaDB.Save(myComisaria);
                }

                //  Assign the Departamento its new (or existing Id).
                myDepartamento.Id = departamentoId;

                myTransactionScope.Complete();

                return departamentoId;
            }
        }

        /// <summary>
        /// Deletes a Departamento from the database.
        /// </summary>
        /// <param name="myDepartamento">The Departamento instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(Departamento myDepartamento)
        {
            return DepartamentoDB.Delete(myDepartamento.Id);
        }

        #endregion

    }

}
