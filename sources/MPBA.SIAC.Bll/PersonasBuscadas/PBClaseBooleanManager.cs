using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll
{

    /// <summary>
    /// The PBClaseBooleanManager class is responsible for managing Business Object.PBClaseBoolean objects in the system.
    /// </summary>
    [DataObjectAttribute()]
    public partial class PBClaseBooleanManager
    {

        #region "Public Methods"

        /// <summary>
        /// Gets a list with all PBClaseBoolean objects in the database.
        /// </summary>
        /// <returns>A list with all PBClaseBoolean from the database when the database contains any, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static PBClaseBooleanList GetList()
        {
            return PBClaseBooleanDB.GetList();
        }

        /// <summary>
        /// Gets a single PBClaseBoolean from the database without its data.
        /// </summary>
        /// <param name="id">The Id of the PBClaseBoolean in the database.</param>
        /// <returns>A PBClaseBoolean object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static PBClaseBoolean GetItem(int id)
        {
            return GetItem(id, false);
        }

        /// <summary>
        /// Gets a single PBClaseBoolean from the database.
        /// </summary>
        /// <param name="id">The Id of the PBClaseBoolean in the database.</param>
        /// <param name="getPBClaseBooleanRecords">Determines whether to load all associated PBClaseBoolean records as well.</param>
        /// <returns>
        /// A PBClaseBoolean object when the Id exists in the database, or <see langword="null"/> otherwise.
        /// </returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static PBClaseBoolean GetItem(int id, bool getPBClaseBooleanRecords)
        {
            PBClaseBoolean myPBClaseBoolean = PBClaseBooleanDB.GetItem(id);
            return myPBClaseBoolean;
        }

        #endregion

    }

}
