using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;

namespace MPBA.SIAC.Bll
{
    /// <summary>
    /// The UsuariosAutorizadoManager class is responsible for managing Business Entities.UsuarioAutorizado objects in the system.
    /// </summary>
    [DataObjectAttribute()]
    public partial class UsuariosAutorizadoManager
    {

        #region "Public Methods"

        /// <summary>
        /// Gets a list with all UsuariosAutorizados objects in the database.
        /// </summary>
        /// <returns>A list with all Usuarios from the database when the database contains any, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static UsuarioAutorizadoList GetList()
        {
            return UsuarioAutorizadoDB.GetList();
        }

        /// <summary>
        /// Gets a single UsuarioAutorizado from the database without its data.
        /// </summary>
        /// <param name="id">The id of the UsuarioAutorizado in the database.</param>
        /// <returns>A UsuarioAutorizado object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static UsuarioAutorizado GetItem(string id)
        {
            return UsuarioAutorizadoDB.GetItem(id);
        }

        /// <summary>
        /// Saves a UsuarioAutorizado in the database.
        /// </summary>
        /// <param name="myUsuarios">The Usuarios instance to save.</param>
        /// <returns>The new id if the Usuarios is new in the database or the existing id when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static bool Save(UsuarioAutorizado myUsuarios)
        {
            using (TransactionScope myTransactionScope = new TransactionScope())
            {
                bool usuariosid = UsuarioAutorizadoDB.Save(myUsuarios);
                
                myTransactionScope.Complete();

                return usuariosid;
            }


        }
        #endregion
    }
}
