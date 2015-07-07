using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal
{
    /// <summary>
    /// The RastrosDB class is responsible for interacting with the database to retrieve and store information
    /// about Rastros objects.
    /// </summary>
    public partial class RastrosDB
    {
        #region "Public Methods"

        /// <summary>
        /// Gets an instance of Rastros from the underlying datasource.
        /// </summary>
        /// <param name="id">The unique id of the Rastros in the database.</param>
        /// <returns>An Rastros when the id was found in the database, or null otherwise.</returns>
        public static Rastros GetItem(int id)
        {
            Rastros myRastros = null;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("RastrosSelectSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@id", id);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            myRastros = FillDataRecord(myReader);
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
                return myRastros;
            }
        }

        /// <summary>
        /// Returns a list with Rastros objects.
        /// </summary>
        /// <returns>A generics List with the Rastros objects.</returns>
        public static RastrosList GetList()
        {
            RastrosList tempList = new RastrosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("RastrosSelectList", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
            }
            return tempList;
        }

        /// <summary>
        /// Returns a list with Rastros objects.
        /// </summary>
        /// <returns>A generics List with the Rastros objects.</returns>
        public static RastrosList GetList(CriteriosBusquedaCompleta Criterio)
        {
            RastrosList tempList = new RastrosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("RastrosSelectListByFiltroGeneral", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    if (Criterio.FechaDesde == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@FechaDesde", Criterio.FechaDesde);
                    }

                    if (Criterio.FechaHasta == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@FechaHasta", Criterio.FechaHasta);
                    }
                    if (Criterio.IdPartido == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdPartido", Criterio.IdPartido);
                    }

                    if (Criterio.IdLocalidad == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdLocalidad", Criterio.IdLocalidad);
                    }
                    if (Criterio.IdCausa == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@IdCausa", Criterio.IdCausa);
                    }
                    if (Criterio.idClaseRastro == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idClaseRastro", Criterio.idClaseRastro);
                    }
                    if (Criterio.SusceptibleCotejoRastro == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@SusceptibleCotejoRastro", Criterio.SusceptibleCotejoRastro);
                    }
                    if (Criterio.idClaseEstadoInformeRastro == null)
                    {

                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("idClaseEstadoInformeRastro", Criterio.idClaseEstadoInformeRastro);
                    }
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
            }
            return tempList;
        }

        /// <summary>
        /// Returns a list with Rastros objects.
        /// </summary>
        /// <param name="idDelito">id de delito a buscar en rastros</param>
        /// <returns>A generics List with the Rastros objects.</returns>
        public static RastrosList GetListByidDelito(int idDelito)
        {
            RastrosList tempList = new RastrosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("RastrosSelectListByidDelito", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idDelito", idDelito);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with Rastros objects.
        /// </summary>
        /// <param name="idDelito">id de delito a buscar en rastros</param>
        /// <returns>A generics List with the Rastros objects.</returns>
        public static RastrosList GetListByidDelitoGroupedByIdClaseRastro(int idDelito)
        {
            RastrosList tempList = new RastrosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("RastrosSelectListByidDelitoGroupedByIdClaseRastro", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idDelito", idDelito);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecordGroupByClaseRastro(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        
        /// <summary>
        /// Returns a list with Rastros objects grouped by claserastro
        /// </summary>
        /// <param name="idDelito">id del delito</param>
        /// <param name="grouped">si trae agrupado por claserastro</param>
        /// <returns>A generics List with the Rastros objects grouped by claserastro.</returns>
        public static RastrosList GetListByidDelito(int idDelito,bool grouped)
        {
            RastrosList tempList = new RastrosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                string sp = "";
                if (grouped)
                    sp = "RastrosSelectListByidDelito";
                else
                    sp = "RastrosSelectListByidDelitoGroupedByIdClaseRastro";
                using (SqlCommand myCommand = new SqlCommand(sp, myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idDelito", idDelito);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }



        ///// <summary>
        ///// Returns a list with Rastros objects agrupados por clase de rastro
        ///// </summary>
        ///// <returns>A generics List with the Rastros objects.</returns>
        //public static RastrosList GetListByidDelitoGroupedByIdClaseRastro(int idDelito)
        //{
        //    RastrosList tempList = new RastrosList();
        //    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
        //    {
        //        using (SqlCommand myCommand = new SqlCommand("RastrosSelectListByidDelitoGroupedByIdClaseRastro", myConnection))
        //        {
        //            myCommand.CommandType = CommandType.StoredProcedure;
        //            myCommand.Parameters.AddWithValue("@idDelito", idDelito);
        //            myConnection.Open();
        //            using (SqlDataReader myReader = myCommand.ExecuteReader())
        //            {
        //                if (myReader.HasRows)
        //                {
        //                    while (myReader.Read())
        //                    {
        //                        tempList.Add(FillDataRecord(myReader));
        //                    }
        //                }
        //                myReader.Close();
        //            }
        //        }
        //        return tempList;
        //    }
        //}




        /// <summary>
        /// Returns a list with Rastros objects.
        /// </summary>
        /// <returns>A generics List with the Rastros objects.</returns>
        public static RastrosList GetListByidClaseEstadoInformeRastro(int idClaseEstadoInformeRastro, int idClaseDelito)
        {
            RastrosList tempList = new RastrosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("RastrosSelectListByidClaseEstadoInformeRastro", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idClaseEstadoInformeRastro", idClaseEstadoInformeRastro);
                    myCommand.Parameters.AddWithValue("@idClaseDelito", idClaseDelito);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }


        /// <summary>
        /// Returns a list with Rastros objects.
        /// </summary>
        /// <returns>A generics List with the Rastros objects.</returns>
        public static RastrosList GetListByidClaseEstadoInformeRastro(int idClaseEstadoInformeRastro)
        {
            RastrosList tempList = new RastrosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("RastrosSelectListByidClaseEstadoInformeRastro", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idClaseEstadoInformeRastro", idClaseEstadoInformeRastro);
        
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with Rastros objects.
        /// </summary>
        /// <returns>A generics List with the Rastros objects.</returns>
        public static RastrosList GetListByidClaseRastro(int idClaseRastro)
        {
            RastrosList tempList = new RastrosList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("RastrosSelectListByidClaseRastro", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idClaseRastro", idClaseRastro);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Saves a Rastros in the database.
        /// </summary>
        /// <param name="myRastros">The Rastros instance to save.</param>
        /// <returns>The new id if the Rastros is new in the database or the existing id when an item was updated.</returns>
public static int Save(Rastros myRastros)
{
    int result = 0;
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("RastrosInsertUpdateSingleItem", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;

            if (myRastros.id == -1)
            {
                myCommand.Parameters.AddWithValue("@id", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@id", myRastros.id);
            }
            
                myCommand.Parameters.AddWithValue("@idDelito", myRastros.idDelito);
            
            if (string.IsNullOrEmpty(myRastros.idCausa))
            {
                myCommand.Parameters.AddWithValue("@idCausa", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idCausa", myRastros.idCausa);
            }
            
                myCommand.Parameters.AddWithValue("@idClaseRastro", myRastros.idClaseRastro);
            
            
                myCommand.Parameters.AddWithValue("@idClaseEstadoInformeRastro", myRastros.idClaseEstadoInformeRastro);
            
            
                myCommand.Parameters.AddWithValue("@susceptibleCotejoRastro", myRastros.SusceptibleCotejoRastro);
             if (string.IsNullOrEmpty(myRastros.Descripcion))
             {
                    myCommand.Parameters.AddWithValue("@Descripcion", DBNull.Value);
             }
             else
             {
                 myCommand.Parameters.AddWithValue("@Descripcion", myRastros.Descripcion);
             }
            
                myCommand.Parameters.AddWithValue("@baja", myRastros.Baja);
            
            if (string.IsNullOrEmpty(myRastros.idUsuarioUltimaModificacion))
            {
                myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", myRastros.idUsuarioUltimaModificacion);
            }
            if (myRastros.FechaUltimaModificacion == null)
            {
                myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
            }
            else
            {
                myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myRastros.FechaUltimaModificacion);
            }

            DbParameter returnValue;
            returnValue = myCommand.CreateParameter();
            returnValue.Direction = ParameterDirection.ReturnValue;
            myCommand.Parameters.Add(returnValue);

            myConnection.Open();
            myCommand.ExecuteNonQuery();
            result = Convert.ToInt32(returnValue.Value);
            myConnection.Close();
        }
    }
    return result;
}

public static int Save(Rastros myRastros, SqlCommand myCommand)
{
    int result = 0;
    //using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    //{
    //    using (SqlCommand myCommand = new SqlCommand("RastrosInsertUpdateSingleItem", myConnection))
    //    {
    //        myCommand.CommandType = CommandType.StoredProcedure;
    try
    {
        myCommand.CommandText = "RastrosInsertUpdateSingleItem";
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.Parameters.Clear();


        if (myRastros.id == -1)
        {
            myCommand.Parameters.AddWithValue("@id", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@id", myRastros.id);
        }

        myCommand.Parameters.AddWithValue("@idDelito", myRastros.idDelito);

        if (string.IsNullOrEmpty(myRastros.idCausa))
        {
            myCommand.Parameters.AddWithValue("@idCausa", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idCausa", myRastros.idCausa);
        }

        myCommand.Parameters.AddWithValue("@idClaseRastro", myRastros.idClaseRastro);


        myCommand.Parameters.AddWithValue("@idClaseEstadoInformeRastro", myRastros.idClaseEstadoInformeRastro);


        myCommand.Parameters.AddWithValue("@susceptibleCotejoRastro", myRastros.SusceptibleCotejoRastro);

        if (string.IsNullOrEmpty(myRastros.Descripcion))
        {
            myCommand.Parameters.AddWithValue("@Descripcion", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@Descripcion", myRastros.Descripcion);
        }

        myCommand.Parameters.AddWithValue("@baja", myRastros.Baja);

        if (string.IsNullOrEmpty(myRastros.idUsuarioUltimaModificacion))
        {
            myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", myRastros.idUsuarioUltimaModificacion);
        }
        if (myRastros.FechaUltimaModificacion == null)
        {
            myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myRastros.FechaUltimaModificacion);
        }

        DbParameter returnValue;
        returnValue = myCommand.CreateParameter();
        returnValue.Direction = ParameterDirection.ReturnValue;
        myCommand.Parameters.Add(returnValue);

        //myConnection.Open();
        myCommand.ExecuteNonQuery();
        result = Convert.ToInt32(returnValue.Value);
        //        myConnection.Close();
        //    }
        //}
    } // try
    catch (Exception e)
    {
        //tr.Rollback();
        throw e;
    }

    return result;
}


        /// <summary>
        /// Deletes a Rastros from the database.
        /// </summary>
        /// <param name="id">The id of the Rastros to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        public static bool Delete(int id)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("RastrosDeleteSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@id", id);
                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                    myConnection.Close();
                }
            }
            return result > 0;
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the Rastros class and fills it with the data fom the IDataRecord.
        /// </summary>
        private static Rastros FillDataRecord(IDataRecord myDataRecord)
        {
            Rastros myRastros = new Rastros();
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
            {
                myRastros.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idDelito")))
            {
                myRastros.idDelito = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idDelito"));
            }

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idCausa")))
            {
                myRastros.idCausa = myDataRecord.GetString(myDataRecord.GetOrdinal("idCausa"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseRastro")))
            {
                myRastros.idClaseRastro = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseRastro"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseEstadoInformeRastro")))
            {
                myRastros.idClaseEstadoInformeRastro = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseEstadoInformeRastro"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("SusceptibleCotejoRastro")))
            {
                myRastros.SusceptibleCotejoRastro = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("SusceptibleCotejoRastro"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
            {
                myRastros.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Baja")))
            {
                myRastros.Baja = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("Baja"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idUsuarioUltimaModificacion")))
            {
                myRastros.idUsuarioUltimaModificacion = myDataRecord.GetString(myDataRecord.GetOrdinal("idUsuarioUltimaModificacion"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaUltimaModificacion")))
            {
                myRastros.FechaUltimaModificacion = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaUltimaModificacion"));
            }
            
            return myRastros;
        }
        private static Rastros FillDataRecordGroupByClaseRastro(IDataRecord myDataRecord)
        {
            Rastros myRastros = new Rastros();
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
            {
                myRastros.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idDelito")))
            {
                myRastros.idDelito = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idDelito"));
            }

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idCausa")))
            {
                myRastros.idCausa = myDataRecord.GetString(myDataRecord.GetOrdinal("idCausa"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseRastro")))
            {
                myRastros.idClaseRastro = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseRastro"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseEstadoInformeRastro")))
            {
                myRastros.idClaseEstadoInformeRastro = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseEstadoInformeRastro"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("SusceptibleCotejoRastro")))
            {
                myRastros.SusceptibleCotejoRastro = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("SusceptibleCotejoRastro"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
            {
                myRastros.idCausa = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Baja")))
            {
                myRastros.Baja = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("Baja"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idUsuarioUltimaModificacion")))
            {
                myRastros.idUsuarioUltimaModificacion = myDataRecord.GetString(myDataRecord.GetOrdinal("idUsuarioUltimaModificacion"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaUltimaModificacion")))
            {
                myRastros.FechaUltimaModificacion = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaUltimaModificacion"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CantidadPruebas")))
            {
                myRastros.CantidadPruebas = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CantidadPruebas"));
            }
            return myRastros;
        }
    }

} 
