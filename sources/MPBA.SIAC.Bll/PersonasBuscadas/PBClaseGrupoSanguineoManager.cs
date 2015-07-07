using System;
using System.ComponentModel;
using System.Transactions;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll
{

    /// <summary>
    /// The PBClaseGrupoSanguineoManager class is responsible for managing Business Object.PBClaseGrupoSanguineo objects in the system.
    /// </summary>
    [DataObjectAttribute()]
    public partial class PBClaseGrupoSanguineoManager
    {

        #region "Public Methods"

        /// <summary>
        /// Gets a list with all PBClaseGrupoSanguineo objects in the database.
        /// </summary>
        /// <returns>A list with all PBClaseGrupoSanguineo from the database when the database contains any, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static PBClaseGrupoSanguineoList GetList()
        {
            return PBClaseGrupoSanguineoDB.GetList();
        }

        /// <summary>
        /// Gets a single PBClaseGrupoSanguineo from the database without its data.
        /// </summary>
        /// <param name="id">The Id of the PBClaseGrupoSanguineo in the database.</param>
        /// <returns>A PBClaseGrupoSanguineo object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static PBClaseGrupoSanguineo GetItem(int id)
        {
            return GetItem(id, false);
        }

        /// <summary>
        /// Gets a single PBClaseGrupoSanguineo from the database.
        /// </summary>
        /// <param name="id">The Id of the PBClaseGrupoSanguineo in the database.</param>
        /// <param name="getPBClaseGrupoSanguineoRecords">Determines whether to load all associated PBClaseGrupoSanguineo records as well.</param>
        /// <returns>
        /// A PBClaseGrupoSanguineo object when the Id exists in the database, or <see langword="null"/> otherwise.
        /// </returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static PBClaseGrupoSanguineo GetItem(int id, bool getPBClaseGrupoSanguineoRecords)
        {
            PBClaseGrupoSanguineo myPBClaseGrupoSanguineo = PBClaseGrupoSanguineoDB.GetItem(id);
            if (myPBClaseGrupoSanguineo != null && getPBClaseGrupoSanguineoRecords)
            {
                myPBClaseGrupoSanguineo.busquedaGrupoSanguineos = BusquedaGrupoSanguineoDB.GetListByidGrupoSanguineo(id);
            }
            //if (myPBClaseGrupoSanguineo != null && getPBClaseGrupoSanguineoRecords){
            //myPBClaseGrupoSanguineo.personasDesaparecidass = PersonasDesaparecidasDB.GetListByidGrupoSanguineo(id);
            //}
            if (myPBClaseGrupoSanguineo != null && getPBClaseGrupoSanguineoRecords)
            {
                myPBClaseGrupoSanguineo.personasHalladass = PersonasHalladasDB.GetListByidGrupoSanguineo(id);
            }
            return myPBClaseGrupoSanguineo;
        }

        /// <summary>
        /// Saves a PBClaseGrupoSanguineo in the database.
        /// </summary>
        /// <param name="myPBClaseGrupoSanguineo">The PBClaseGrupoSanguineo instance to save.</param>
        /// <returns>The new Id if the PBClaseGrupoSanguineo is new in the database or the existing Id when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static int Save(PBClaseGrupoSanguineo myPBClaseGrupoSanguineo, SqlCommand myCommand)
        {
            using (TransactionScope myTransactionScope = new TransactionScope())
            {
                int pBClaseGrupoSanguineoId = PBClaseGrupoSanguineoDB.Save(myPBClaseGrupoSanguineo);
                foreach (BusquedaGrupoSanguineo myBusquedaGrupoSanguineo in myPBClaseGrupoSanguineo.busquedaGrupoSanguineos)
                {
                    myBusquedaGrupoSanguineo.id = pBClaseGrupoSanguineoId;
                    BusquedaGrupoSanguineoDB.Save(myBusquedaGrupoSanguineo, myCommand);
                }
                foreach (PersonasDesaparecidas myPersonasDesaparecidas in myPBClaseGrupoSanguineo.personasDesaparecidass)
                {
                    myPersonasDesaparecidas.Id = pBClaseGrupoSanguineoId;
                    PersonasDesaparecidasDB.Save(myPersonasDesaparecidas, myCommand);
                }
                foreach (PersonasHalladas myPersonasHalladas in myPBClaseGrupoSanguineo.personasHalladass)
                {
                    myPersonasHalladas.Id = pBClaseGrupoSanguineoId;
                    PersonasHalladasDB.Save(myPersonasHalladas, myCommand);
                }

                //  Assign the PBClaseGrupoSanguineo its new (or existing Id).
                myPBClaseGrupoSanguineo.Id = pBClaseGrupoSanguineoId;

                myTransactionScope.Complete();

                return pBClaseGrupoSanguineoId;
            }
        }

        /// <summary>
        /// Deletes a PBClaseGrupoSanguineo from the database.
        /// </summary>
        /// <param name="myPBClaseGrupoSanguineo">The PBClaseGrupoSanguineo instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(PBClaseGrupoSanguineo myPBClaseGrupoSanguineo)
        {
            return PBClaseGrupoSanguineoDB.Delete(myPBClaseGrupoSanguineo.Id);
        }

        #endregion

    }

}
