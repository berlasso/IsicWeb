using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal
{
    /// <summary>
    /// The PartidoDB class is responsible for interacting with the database to retrieve and store information
    /// about Partido objects.
    /// </summary>
    public partial class PartidoDB
    {
        #region "Public Methods"

        /// <summary>
        /// Gets an instance of Partido from the underlying datasource.
        /// </summary>
        /// <param name="id">The unique id of the Partido in the database.</param>
        /// <returns>An Partido when the id was found in the database, or null otherwise.</returns>
        public static Partido GetItem(int id)
        {
            Partido myPartido = null;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PartidoSelectSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@id", id);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            myPartido = FillDataRecord(myReader);
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
                return myPartido;
            }
        }

        /// <summary>
        /// Returns a list with Partido objects.
        /// </summary>
        /// <returns>A generics List with the Partido objects.</returns>
        public static PartidoList GetList()
        {
            PartidoList tempList = new PartidoList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PartidoSelectList", myConnection))
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
        /// Returns a list with partido objects matching partido
        /// </summary>
        /// <param name="partido">partido being searched</param>
        /// <returns>A generics List with the partido objects that match partido.</returns>
        public static PartidoList GetList(string partido)
        {
            PartidoList tempList = new PartidoList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PartidoSelectListByPartido", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@partido", partido);
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
        /// Returns a list with Partido objects.
        /// </summary>
        /// <returns>A generics List with the Partido objects.</returns>
        public static PartidoList GetListByidProvincia(int idProvincia)
        {
            PartidoList tempList = new PartidoList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PartidoSelectListByidProvincia", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idProvincia", idProvincia);
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
        /// Saves a Partido in the database.
        /// </summary>
        /// <param name="myPartido">The Partido instance to save.</param>
        /// <returns>The new id if the Partido is new in the database or the existing id when an item was updated.</returns>
        public static int Save(Partido myPartido)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PartidoInsertUpdateSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    if (myPartido.id == -1)
                    {
                        myCommand.Parameters.AddWithValue("@id", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@id", myPartido.id);
                    }
                    if (string.IsNullOrEmpty(myPartido.partido))
                    {
                        myCommand.Parameters.AddWithValue("@partido", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@partido", myPartido.partido);
                    }

                    myCommand.Parameters.AddWithValue("@idDepartamento", myPartido.idDepartamento);

                    myCommand.Parameters.AddWithValue("@idProvincia", myPartido.idProvincia);


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
        /// Deletes a Partido from the database.
        /// </summary>
        /// <param name="id">The id of the Partido to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        public static bool Delete(int id)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PartidoDeleteSingleItem", myConnection))
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
        /// Initializes a new instance of the Partido class and fills it with the data fom the IDataRecord.
        /// </summary>
        private static Partido FillDataRecord(IDataRecord myDataRecord)
        {
            Partido myPartido = new Partido();
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
            {
                myPartido.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Partido")))
            {
                myPartido.partido = myDataRecord.GetString(myDataRecord.GetOrdinal("Partido"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idDepartamento")))
            {
                myPartido.idDepartamento = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idDepartamento"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idProvincia")))
            {
                myPartido.idProvincia = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idProvincia"));
            }
            return myPartido;
        }
    }

} 
