using System;
using System.ComponentModel;
using System.Transactions;

using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;


namespace MPBA.PersonasBuscadas.Bll
{

    /// <summary>
    /// The PBClaseTipoJurisdiccionCausaManager class is responsible for managing Business Object.PBClaseTipoJurisdiccionCausa objects in the system.
    /// </summary>
    [DataObjectAttribute()]
    public partial class PBClaseTipoJurisdiccionCausaManager
    {

        #region "Public Methods"

        /// <summary>
        /// Gets a list with all PBClaseTipoJurisdiccionCausa objects in the database.
        /// </summary>
        /// <returns>A list with all PBClaseTipoJurisdiccionCausa from the database when the database contains any, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static PBClaseTipoJurisdiccionCausaList GetList()
        {
            return PBClaseTipoJurisdiccionCausaDB.GetList();
        }

        /// <summary>
        /// Gets a single PBClaseTipoJurisdiccionCausa from the database without its data.
        /// </summary>
        /// <param name="id">The id of the PBClaseTipoJurisdiccionCausa in the database.</param>
        /// <returns>A PBClaseTipoJurisdiccionCausa object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static PBClaseTipoJurisdiccionCausa GetItem(int id)
        {
            PBClaseTipoJurisdiccionCausa myPBClaseTipoJurisdiccionCausa = PBClaseTipoJurisdiccionCausaDB.GetItem(id);
            return myPBClaseTipoJurisdiccionCausa;
        }

       

        /// <summary>
        /// Saves a PBClaseTipoJurisdiccionCausa in the database.
        /// </summary>
        /// <param name="myPBClaseTipoJurisdiccionCausa">The PBClaseTipoJurisdiccionCausa instance to save.</param>
        /// <returns>The new id if the PBClaseTipoJurisdiccionCausa is new in the database or the existing id when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static int Save(PBClaseTipoJurisdiccionCausa myPBClaseTipoJurisdiccionCausa)
        {
            using (TransactionScope myTransactionScope = new TransactionScope())
            {
                int pBClaseTipoJurisdiccionCausaid = PBClaseTipoJurisdiccionCausaDB.Save(myPBClaseTipoJurisdiccionCausa);
                foreach (PersonasDesaparecidas myPersonasDesaparecidas in myPBClaseTipoJurisdiccionCausa.personasDesaparecidass)
                {
                    myPersonasDesaparecidas.Id = pBClaseTipoJurisdiccionCausaid;
                    PersonasDesaparecidasDB.Save(myPersonasDesaparecidas);
                }
                foreach (PersonasHalladas myPersonasHalladas in myPBClaseTipoJurisdiccionCausa.personasHalladass)
                {
                    myPersonasHalladas.Id = pBClaseTipoJurisdiccionCausaid;
                    PersonasHalladasDB.Save(myPersonasHalladas);
                }

                //  Assign the PBClaseTipoJurisdiccionCausa its new (or existing id).
                myPBClaseTipoJurisdiccionCausa.id = pBClaseTipoJurisdiccionCausaid;

                myTransactionScope.Complete();

                return pBClaseTipoJurisdiccionCausaid;
            }
        }

        /// <summary>
        /// Deletes a PBClaseTipoJurisdiccionCausa from the database.
        /// </summary>
        /// <param name="myPBClaseTipoJurisdiccionCausa">The PBClaseTipoJurisdiccionCausa instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(PBClaseTipoJurisdiccionCausa myPBClaseTipoJurisdiccionCausa)
        {
            return PBClaseTipoJurisdiccionCausaDB.Delete(myPBClaseTipoJurisdiccionCausa.id);
        }

        #endregion

    }

}
