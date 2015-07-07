using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal
{
    /// <summary>
    /// The BusquedaRostroDB class is responsible for interacting with the database to retrieve and store information
    /// about BusquedaRostro objects.
    /// </summary>
    public partial class BusquedaRostroDB
    {
        #region "Public Methods"

        /// <summary>
        /// Gets an instance of BusquedaRostro from the underlying datasource.
        /// </summary>
        /// <param name="id">The unique id of the BusquedaRostro in the database.</param>
        /// <returns>An BusquedaRostro when the id was found in the database, or null otherwise.</returns>
        public static BusquedaRostro GetItem(decimal id)
        {
            BusquedaRostro myBusquedaRostro = null;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("BusquedaRostroSelectSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@id", id);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            myBusquedaRostro = FillDataRecord(myReader);
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
                return myBusquedaRostro;
            }
        }

        /// <summary>
        /// Returns a list with BusquedaRostro objects.
        /// </summary>
        /// <returns>A generics List with the BusquedaRostro objects.</returns>
        public static BusquedaRostroList GetList()
        {
            BusquedaRostroList tempList = new BusquedaRostroList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("BusquedaRostroSelectList", myConnection))
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
        /// Returns a list with BusquedaRostro objects.
        /// </summary>
        /// <returns>A generics List with the BusquedaRostro objects.</returns>
        public static BusquedaRostroList GetListByidBusqueda(decimal idBusqueda)
        {
            BusquedaRostroList tempList = new BusquedaRostroList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("BusquedaRostroSelectListByidBusqueda", myConnection))
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
        /// Returns a list with BusquedaRostro objects.
        /// </summary>
        /// <returns>A generics List with the BusquedaRostro objects.</returns>
        public static BusquedaRostroList GetListByidClaseRostro(int idClaseRostro)
        {
            BusquedaRostroList tempList = new BusquedaRostroList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("BusquedaRostroSelectListByidClaseRostro", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idClaseRostro", idClaseRostro);
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
        /// Saves a BusquedaRostro in the database.
        /// </summary>
        /// <param name="myBusquedaRostro">The BusquedaRostro instance to save.</param>
        /// <returns>The new id if the BusquedaRostro is new in the database or the existing id when an item was updated.</returns>
        public static int Save(BusquedaRostro myBusquedaRostro, SqlCommand myCommand)
        {
            int result = 0;
            //using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            //{
            //using (SqlCommand myCommand = new SqlCommand("BusquedaRostroInsertUpdateSingleItem", myConnection))
            //{
            //myCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                myCommand.CommandText = "BusquedaRostroInsertUpdateSingleItem";
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Clear();

                if (myBusquedaRostro.id == -1)
                {
                    myCommand.Parameters.AddWithValue("@id", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@id", myBusquedaRostro.id);
                }
                if (myBusquedaRostro.idBusqueda == null)
                {
                    myCommand.Parameters.AddWithValue("@idBusqueda", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idBusqueda", myBusquedaRostro.idBusqueda);
                }
                if (myBusquedaRostro.idClaseRostro == null)
                {
                    myCommand.Parameters.AddWithValue("@idClaseRostro", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idClaseRostro", myBusquedaRostro.idClaseRostro);
                }

                DbParameter returnValue;
                returnValue = myCommand.CreateParameter();
                returnValue.Direction = ParameterDirection.ReturnValue;
                myCommand.Parameters.Add(returnValue);

                //myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = Convert.ToInt32(returnValue.Value);
                //myConnection.Close();
                //}
                //}
            }
            catch (Exception e)
            {
                //tr.Rollback();
                throw e;
            }
            return result;
        }


        /// <summary>
        /// Deletes a BusquedaRostro from the database.
        /// </summary>
        /// <param name="id">The id of the BusquedaRostro to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        public static bool Delete(decimal id)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("BusquedaRostroDeleteSingleItem", myConnection))
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
        /// Deletes a BusquedaRostro from the database.
        /// </summary>
        /// <param name="id">The id of the BusquedaRostro to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        public static bool DeleteByIdBusqueda(decimal idBusqueda)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("BusquedaRostroDeleteItemByIdBusqueda", myConnection))
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
        /// Initializes a new instance of the BusquedaRostro class and fills it with the data fom the IDataRecord.
        /// </summary>
        private static BusquedaRostro FillDataRecord(IDataRecord myDataRecord)
        {
            BusquedaRostro myBusquedaRostro = new BusquedaRostro();
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
            {
                myBusquedaRostro.id = myDataRecord.GetDecimal(myDataRecord.GetOrdinal("id"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusqueda")))
            {
                myBusquedaRostro.idBusqueda = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusqueda"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseRostro")))
            {
                myBusquedaRostro.idClaseRostro = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseRostro"));
            }
            return myBusquedaRostro;
        }
    }

}
