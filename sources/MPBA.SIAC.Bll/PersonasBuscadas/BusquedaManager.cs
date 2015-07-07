using System;
using System.ComponentModel;
using System.Transactions;
using System.Data;
using System.Data.Common;
using MPBA.PersonasBuscadas.BusinessEntities;
using MPBA.PersonasBuscadas.Dal;

using System.Configuration;
using System.Data.SqlClient;
namespace MPBA.PersonasBuscadas.Bll
{

    /// <summary>
    /// The BusquedaManager class is responsible for managing Business Object.Busqueda objects in the system.
    /// </summary>
    [DataObjectAttribute()]
    public partial class BusquedaManager
    {

        #region "Public Methods"

        /// <summary>
        /// Gets a list with all Busqueda objects in the database.
        /// </summary>
        /// <returns>A list with all Busqueda from the database when the database contains any, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static BusquedaList GetList()
        {
            return BusquedaDB.GetList();
        }

        /// <summary>
        /// Gets a list with all Busqueda objects in the database.
        /// </summary>
        /// <returns>A list with all Busqueda from the database when the database contains any, or null otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static BusquedaList GetListActivas()
        {
            return BusquedaDB.GetListActivas();
        }

        

        /// <summary>
        /// Gets a single Busqueda from the database without its data.
        /// </summary>
        /// <param name="id">The Id of the Busqueda in the database.</param>
        /// <returns>A Busqueda object when the Id exists in the database, or <see langword="null"/> otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Busqueda GetItem(decimal id)
        {
            return GetItem(id, false);
        }

        /// <summary>
        /// Gets a single Busqueda from the database.
        /// </summary>
        /// <param name="id">The Id of the Busqueda in the database.</param>
        /// <param name="getBusquedaRecords">Determines whether to load all associated Busqueda records as well.</param>
        /// <returns>
        /// A Busqueda object when the Id exists in the database, or <see langword="null"/> otherwise.
        /// </returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static Busqueda GetItem(decimal id, bool getBusquedaRecords)
        {
            Busqueda myBusqueda = BusquedaDB.GetItem(id);
            if (myBusqueda != null && getBusquedaRecords)
            {
                myBusqueda.busquedaAspectoCabellos = BusquedaAspectoCabelloDB.GetListByidBusqueda(id);
           
                myBusqueda.busquedaCalvicies = BusquedaCalvicieDB.GetListByidBusqueda(id);
           
                myBusqueda.busquedaColorCabellos = BusquedaColorCabelloDB.GetListByidBusqueda(id);
           
                myBusqueda.busquedaColorOjoss = BusquedaColorOjosDB.GetListByidBusqueda(id);
           
                myBusqueda.busquedaColorPiels = BusquedaColorPielDB.GetListByidBusqueda(id);
           
                myBusqueda.busquedaColorTenidos = BusquedaColorTenidoDB.GetListByidBusqueda(id);
           
                myBusqueda.busquedaGrupoSanguineos = BusquedaGrupoSanguineoDB.GetListByidBusqueda(id);
           
                myBusqueda.busquedaLongitudCabellos = BusquedaLongitudCabelloDB.GetListByidBusqueda(id);
           
                myBusqueda.busquedaSeniasParticularess = BusquedaSeniasParticularesDB.GetListByidBusqueda(id);
           
                myBusqueda.personasDesaparecidass = PersonasDesaparecidasDB.GetListByidBusqueda(id);
           
                myBusqueda.personasHalladass = PersonasHalladasDB.GetListByidBusqueda(id);

                myBusqueda.busquedaTatuajess = BusquedaTatuajesDB.GetListByidBusqueda(id);
            }
            return myBusqueda;
        }

        /// <summary>
        /// Saves a Busqueda in the database.
        /// </summary>
        /// <param name="myBusqueda">The Busqueda instance to save.</param>
        /// <returns>The new Id if the Busqueda is new in the database or the existing Id when an item was updated.</returns>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static decimal Save(Busqueda myBusqueda, SqlCommand myCommand)
        {
            decimal busquedaId;
            //using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            //{
            //SqlCommand myCommand = new SqlCommand("BusquedaInsertUpdateSingleItem", myConnection);

            //myCommand.CommandType = CommandType.StoredProcedure;
            //myConnection.Open();
            //SqlTransaction tr = myConnection.BeginTransaction();
            //myCommand.Transaction = tr;

            //try
            //{

            busquedaId = BusquedaDB.Save(myBusqueda, myCommand);
            myBusqueda.Id = busquedaId;
            BusquedaAspectoCabelloManager.DeleteByIdBusqueda(busquedaId);
            foreach (BusquedaAspectoCabello myBusquedaAspectoCabello in myBusqueda.busquedaAspectoCabellos)
            {
                myBusquedaAspectoCabello.idBusqueda = busquedaId;
                BusquedaAspectoCabelloManager.Save(myBusquedaAspectoCabello, myCommand);
            }
            BusquedaRostroManager.DeleteByIdBusqueda(busquedaId);
            foreach (BusquedaRostro myBusquedaRostro in myBusqueda.busquedaRostros)
            {
                myBusquedaRostro.idBusqueda = busquedaId;
                BusquedaRostroManager.Save(myBusquedaRostro, myCommand);
            }
            BusquedaCalvicieManager.DeletebyIdBusqueda(busquedaId);
            foreach (BusquedaCalvicie myBusquedaCalvicie in myBusqueda.busquedaCalvicies)
            {
                myBusquedaCalvicie.idBusqueda = busquedaId;
                BusquedaCalvicieManager.Save(myBusquedaCalvicie, myCommand);
            }
            BusquedaColorCabelloManager.DeletebyIdBusqueda(busquedaId);
            foreach (BusquedaColorCabello myBusquedaColorCabello in myBusqueda.busquedaColorCabellos)
            {
                myBusquedaColorCabello.idBusqueda = busquedaId;
                BusquedaColorCabelloManager.Save(myBusquedaColorCabello, myCommand);
            }
            BusquedaColorOjosManager.DeleteByIdBusqueda(busquedaId);
            foreach (BusquedaColorOjos myBusquedaColorOjos in myBusqueda.busquedaColorOjoss)
            {
                myBusquedaColorOjos.idBusqueda = busquedaId;
                BusquedaColorOjosManager.Save(myBusquedaColorOjos, myCommand);
            }
            BusquedaColorPielManager.DeleteByIdBusqueda(busquedaId);
            foreach (BusquedaColorPiel myBusquedaColorPiel in myBusqueda.busquedaColorPiels)
            {
                myBusquedaColorPiel.idBusqueda = busquedaId;
                BusquedaColorPielManager.Save(myBusquedaColorPiel, myCommand);
            }
            BusquedaColorTenidoManager.DeleteByIdBusqueda(busquedaId);
            foreach (BusquedaColorTenido myBusquedaColorTenido in myBusqueda.busquedaColorTenidos)
            {
                myBusquedaColorTenido.idBusqueda = busquedaId;
                BusquedaColorTenidoManager.Save(myBusquedaColorTenido, myCommand);
            }
            BusquedaGrupoSanguineoManager.DeleteByIdBusqueda(busquedaId);
            foreach (BusquedaGrupoSanguineo myBusquedaGrupoSanguineo in myBusqueda.busquedaGrupoSanguineos)
            {
                myBusquedaGrupoSanguineo.idBusqueda = busquedaId;
                BusquedaGrupoSanguineoManager.Save(myBusquedaGrupoSanguineo, myCommand);
            }
            BusquedaLongitudCabelloManager.DeleteByIdBusqueda(busquedaId);
            foreach (BusquedaLongitudCabello myBusquedaLongitudCabello in myBusqueda.busquedaLongitudCabellos)
            {
                myBusquedaLongitudCabello.idBusqueda = busquedaId;
                BusquedaLongitudCabelloManager.Save(myBusquedaLongitudCabello, myCommand);
            }
            BusquedaSeniasParticularesManager.DeleteByIdBusqueda(busquedaId);
            foreach (BusquedaSeniasParticulares myBusquedaSeniasParticulares in myBusqueda.busquedaSeniasParticularess)
            {
                myBusquedaSeniasParticulares.idBusqueda = busquedaId;
                BusquedaSeniasParticularesManager.Save(myBusquedaSeniasParticulares, myCommand);
            }
            BusquedaTatuajesManager.DeleteByIdBusqueda(busquedaId);
            foreach (BusquedaTatuajes myBusquedaTatuajes in myBusqueda.busquedaTatuajess)
            {
                myBusquedaTatuajes.idBusqueda = busquedaId;
                BusquedaTatuajesManager.Save(myBusquedaTatuajes, myCommand);
            }
            foreach (PersonasDesaparecidas myPersonasDesaparecidas in myBusqueda.personasDesaparecidass)
            {
                myPersonasDesaparecidas.idBusqueda = busquedaId;
                PersonasDesaparecidasManager.Save(myPersonasDesaparecidas, myCommand);
            }
            foreach (PersonasHalladas myPersonasHalladas in myBusqueda.personasHalladass)
            {
                myPersonasHalladas.idBusqueda = busquedaId;
                PersonasHalladasManager.Save(myPersonasHalladas, myCommand);
            }
            // tr.Commit();
            //}
            //catch (Exception e)
            //{
            //    tr.Rollback();
            //    throw (e);
            //}
            //finally { myConnection.Close(); }

            return busquedaId;
        }




        /// <summary>
        /// Deletes a Busqueda from the database.
        /// </summary>
        /// <param name="myBusqueda">The Busqueda instance to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static bool Delete(Busqueda myBusqueda)
        {
            return BusquedaDB.Delete(myBusqueda.Id);
        }
    }
}
        #endregion




