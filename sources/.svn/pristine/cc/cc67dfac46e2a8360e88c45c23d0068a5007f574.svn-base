using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal
{
    /// <summary>
    /// The BusquedaAspectoCabelloDB class is responsible for interacting with the database to retrieve and store information
    /// about BusquedaAspectoCabello objects.
    /// </summary>
    public partial class BusquedaAspectoCabelloDB
    {
        #region "Public Methods"

        /// <summary>
        /// Gets an instance of BusquedaAspectoCabello from the underlying datasource.
        /// </summary>
        /// <param name="id">The unique id of the BusquedaAspectoCabello in the database.</param>
        /// <returns>An BusquedaAspectoCabello when the id was found in the database, or null otherwise.</returns>
        public static BusquedaAspectoCabello GetItem(decimal id)
        {
            BusquedaAspectoCabello myBusquedaAspectoCabello = null;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("BusquedaAspectoCabelloSelectSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@id", id);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            myBusquedaAspectoCabello = FillDataRecord(myReader);
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
                return myBusquedaAspectoCabello;
            }
        }

        /// <summary>
        /// Returns a list with BusquedaAspectoCabello objects.
        /// </summary>
        /// <returns>A generics List with the BusquedaAspectoCabello objects.</returns>
        public static BusquedaAspectoCabelloList GetList()
        {
            BusquedaAspectoCabelloList tempList = new BusquedaAspectoCabelloList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("BusquedaAspectoCabelloSelectList", myConnection))
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
        /// Returns a list with BusquedaAspectoCabello objects.
        /// </summary>
        /// <returns>A generics List with the BusquedaAspectoCabello objects.</returns>
        public static BusquedaAspectoCabelloList GetListByidBusqueda(decimal idBusqueda)
        {
            BusquedaAspectoCabelloList tempList = new BusquedaAspectoCabelloList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("BusquedaAspectoCabelloSelectListByidBusqueda", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idBusqueda", idBusqueda);
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
        /// Returns a list with BusquedaAspectoCabello objects.
        /// </summary>
        /// <returns>A generics List with the BusquedaAspectoCabello objects.</returns>
        public static BusquedaAspectoCabelloList GetListByidAspectoCabello(int idAspectoCabello)
        {
            BusquedaAspectoCabelloList tempList = new BusquedaAspectoCabelloList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("BusquedaAspectoCabelloSelectListByidAspectoCabello", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idAspectoCabello", idAspectoCabello);
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
        /// Saves a BusquedaAspectoCabello in the database.
        /// </summary>
        /// <param name="myBusquedaAspectoCabello">The BusquedaAspectoCabello instance to save.</param>
        /// <returns>The new id if the BusquedaAspectoCabello is new in the database or the existing id when an item was updated.</returns>
        public static int Save(BusquedaAspectoCabello myBusquedaAspectoCabello)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("BusquedaAspectoCabelloInsertUpdateSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    if (myBusquedaAspectoCabello.id == -1)
                    {
                        myCommand.Parameters.AddWithValue("@id", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@id", myBusquedaAspectoCabello.id);
                    }
                    if (myBusquedaAspectoCabello.idBusqueda == null)
                    {
                        myCommand.Parameters.AddWithValue("@idBusqueda", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idBusqueda", myBusquedaAspectoCabello.idBusqueda);
                    }
                    if (myBusquedaAspectoCabello.idAspectoCabello == null)
                    {
                        myCommand.Parameters.AddWithValue("@idAspectoCabello", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idAspectoCabello", myBusquedaAspectoCabello.idAspectoCabello);
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

        /// <summary>
        /// Saves a BusquedaAspectoCabello in the database.
        /// </summary>
        /// <param name="myBusquedaAspectoCabello">The BusquedaAspectoCabello instance to save.</param>
        /// <returns>The new id if the BusquedaAspectoCabello is new in the database or the existing id when an item was updated.</returns>
        public static int Save(BusquedaAspectoCabello myBusquedaAspectoCabello, SqlCommand myCommand)
        {
            int result = 0;
            //using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            //{
            //    using (SqlCommand myCommand = new SqlCommand("BusquedaAspectoCabelloInsertUpdateSingleItem", myConnection))
            //    {
            //        myCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                myCommand.CommandText = "BusquedaAspectoCabelloInsertUpdateSingleItem";
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Clear();
                if (myBusquedaAspectoCabello.id == -1)
                {
                    myCommand.Parameters.AddWithValue("@id", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@id", myBusquedaAspectoCabello.id);
                }
                if (myBusquedaAspectoCabello.idBusqueda == null)
                {
                    myCommand.Parameters.AddWithValue("@idBusqueda", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idBusqueda", myBusquedaAspectoCabello.idBusqueda);
                }
                if (myBusquedaAspectoCabello.idAspectoCabello == null)
                {
                    myCommand.Parameters.AddWithValue("@idAspectoCabello", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idAspectoCabello", myBusquedaAspectoCabello.idAspectoCabello);
                }

                DbParameter returnValue;
                returnValue = myCommand.CreateParameter();
                returnValue.Direction = ParameterDirection.ReturnValue;
                myCommand.Parameters.Add(returnValue);

                //myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = Convert.ToInt32(returnValue.Value);
                //myConnection.Close();
            }
            catch (Exception e)
            {
                //tr.Rollback();
                throw e;
            }
            return result;
        }

        /// <summary>
        /// Deletes a BusquedaAspectoCabello from the database.
        /// </summary>
        /// <param name="id">The id of the BusquedaAspectoCabello to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        public static bool Delete(decimal id)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("BusquedaAspectoCabelloDeleteSingleItem", myConnection))
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
        /// <summary>
        /// Deletes a BusquedaAspectoCabello from the database.
        /// </summary>
        /// <param name="id">The id of the BusquedaAspectoCabello to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        public static bool DeleteByIdBusqueda(decimal idBusqueda)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("BusquedaAspectoCabelloDeleteItemByIdBusqueda", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@idBusqueda", idBusqueda);
                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                    myConnection.Close();
                }
            }
            return result > 0;
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the BusquedaAspectoCabello class and fills it with the data fom the IDataRecord.
        /// </summary>
        private static BusquedaAspectoCabello FillDataRecord(IDataRecord myDataRecord)
        {
            BusquedaAspectoCabello myBusquedaAspectoCabello = new BusquedaAspectoCabello();
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
            {
                myBusquedaAspectoCabello.id = myDataRecord.GetDecimal(myDataRecord.GetOrdinal("id"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusqueda")))
            {
                myBusquedaAspectoCabello.idBusqueda = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusqueda"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idAspectoCabello")))
            {
                myBusquedaAspectoCabello.idAspectoCabello = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idAspectoCabello"));
            }
            return myBusquedaAspectoCabello;
        }
    }

} 
