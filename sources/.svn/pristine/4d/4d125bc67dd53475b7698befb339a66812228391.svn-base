using System;
using System.ComponentModel;
using System.Transactions;
using System.Data.SqlClient;
using MPBA.SIAC.BusinessEntities;
using MPBA.SIAC.Dal;
using System.Collections.Generic;


namespace MPBA.SIAC.Bll   
{

    /// <summary>
    /// The PersonaManager class is responsible for managing Business Entities.Persona objects in the system.
    /// </summary>
    [DataObjectAttribute()]
    public partial class PersonaManager
    {

        #region "Public Methods"

        /// <summary>
        /// Gets a list with all Persona objects in the database.
        /// </summary>
        /// <returns>A list with all Persona from the database when the database contains any, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static PersonaList GetList()
        {
            return PersonaDB.GetList();
        }

        /// <summary>
        /// Gets a list with all Persona objects in the database.
        /// </summary>
        /// <returns>A list with all Persona from the database when the database contains any, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static PersonaList Getreferentes()
        {
            return PersonaDB.Getreferentes();
        }



        /// <summary>
        /// Gets a list with all Persona objects in the database.
        /// </summary>
        /// <returns>A list with all Persona from the database when the database contains any, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static PersonaList GetListByApellido(string apellido)
        {
            return PersonaDB.GetListByidApellido(apellido);
        }


        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static string UpdateBaja(string ippHallada, string ippDesaparecida, int MotivoDeBaja,int IppOrigen, string Usuario,  IEnumerable<int> ids)
        {
            return PersonaDB.UpdateBaja(ippHallada, ippDesaparecida, MotivoDeBaja, IppOrigen, Usuario,  ids);
        }


        /// <summary>
        /// Gets a list with all Persona objects in the database.
        /// </summary>
        /// <returns>A list with all Persona from the database when the database contains any, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static PersonaList GetListByDocNroApellido(int? docNro,string apellido)
        {
            return PersonaDB.GetListByDocNroApellido(docNro,apellido);
        }

      

        /// <summary>
        /// Gets a single Persona from the database without its data.
        /// </summary>
        /// <param name="id">The id of the Persona in the database.</param>
        /// <returns>A Persona object when the id exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Persona GetItem(int id)
        {
            return GetItem(id, false);
        }

     

        /// <summary>
        /// Gets a single Persona from the database.
        /// </summary>
        /// <param name="id">The id of the Persona in the database.</param>
        /// <param name="getPersonaRecords">Determines whether to load all associated Persona records as well.</param>
        /// <returns>
        /// A Persona object when the id exists in the database, or <see langword="null"/> otherwise.
        /// </returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Persona GetItem(int id, bool getPersonaRecords)
        {
            Persona myPersona = PersonaDB.GetItem(id);
            return myPersona;
        }

        /// <summary>
        /// Saves a Persona in the database.
        /// </summary>
        /// <param name="myPersona">The Persona instance to save.</param>
        /// <returns>The new id if the Persona is new in the database or the existing id when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static int Save(Persona myPersona)
        {
            using (TransactionScope myTransactionScope = new TransactionScope())
            {
                int personaid = PersonaDB.Save(myPersona);

                //  Assign the Persona its new (or existing id).
                myPersona.id = personaid;

                myTransactionScope.Complete();

                return personaid;
            }
        }

        /// <summary>
        /// Saves a Persona in the database.
        /// </summary>
        /// <param name="myPersona">The Persona instance to save.</param>
        /// <returns>The new id if the Persona is new in the database or the existing id when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static int Save(Persona myPersona, SqlCommand myCommand)
        {
            //using (TransactionScope myTransactionScope = new TransactionScope())
            //{
                int personaid = PersonaDB.Save(myPersona);

                //  Assign the Persona its new (or existing id).
                myPersona.id = personaid;

               // myTransactionScope.Complete();

                return personaid;
           // }
        }

        /// <summary>
        /// Deletes a Persona from the database.
        /// </summary>
        /// <param name="myPersona">The Persona instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(Persona myPersona)
        {
            return PersonaDB.Delete(myPersona.id);
        }

        #endregion

    }

}
