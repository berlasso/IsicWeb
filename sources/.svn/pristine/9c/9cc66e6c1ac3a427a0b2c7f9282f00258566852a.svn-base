using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal
{
    /// <summary>
    /// The PersonasEncontradasDB class is responsible for interacting with the database to retrieve and store information
    /// about PersonasEncontradas objects.
    /// </summary>
    public partial class PersonasEncontradasDB
    {
        #region "Public Methods"

        /// <summary>
        /// Gets an instance of PersonasEncontradas from the underlying datasource.
        /// </summary>
        /// <param name="id">The unique id of the PersonasEncontradas in the database.</param>
        /// <returns>An PersonasEncontradas when the id was found in the database, or null otherwise.</returns>
        public static PersonasEncontradas GetItem(int id)
        {
            PersonasEncontradas myPersonasEncontradas = null;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasEncontradasSelectSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@id", id);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            myPersonasEncontradas = FillDataRecord(myReader);
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
                return myPersonasEncontradas;
            }
        }

        /// <summary>
        /// Returns a list with PersonasEncontradas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasEncontradas objects.</returns>
        public static PersonasEncontradasList GetList()
        {
            PersonasEncontradasList tempList = new PersonasEncontradasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasEncontradasSelectList", myConnection))
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
        /// Saves a PersonasEncontradas in the database.
        /// </summary>
        /// <param name="myPersonasEncontradas">The PersonasEncontradas instance to save.</param>
        /// <returns>The new id if the PersonasEncontradas is new in the database or the existing id when an item was updated.</returns>
        public static int Save(PersonasEncontradas myPersonasEncontradas)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasEncontradasInsertUpdateSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    if (myPersonasEncontradas.id == -1)
                    {
                        myCommand.Parameters.AddWithValue("@id", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@id", myPersonasEncontradas.id);
                    }
                    if (string.IsNullOrEmpty(myPersonasEncontradas.IppHallada))
                    {
                        myCommand.Parameters.AddWithValue("@ippHallada ", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@ippHallada ", myPersonasEncontradas.IppHallada);
                    }
                    if (string.IsNullOrEmpty(myPersonasEncontradas.IppDesaparecida))
                    {
                        myCommand.Parameters.AddWithValue("@ippDesaparecida ", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@ippDesaparecida ", myPersonasEncontradas.IppDesaparecida);
                    }
                    if (myPersonasEncontradas.Fecha == null)
                    {
                        myCommand.Parameters.AddWithValue("@fecha", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@fecha", myPersonasEncontradas.Fecha);
                    }
                    if (string.IsNullOrEmpty(myPersonasEncontradas.Usuario))
                    {
                        myCommand.Parameters.AddWithValue("@usuario", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@usuario", myPersonasEncontradas.Usuario);
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
        /// Deletes a PersonasEncontradas from the database.
        /// </summary>
        /// <param name="id">The id of the PersonasEncontradas to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        public static bool Delete(int id)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasEncontradasDeleteSingleItem", myConnection))
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
        /// Initializes a new instance of the PersonasEncontradas class and fills it with the data fom the IDataRecord.
        /// </summary>
        private static PersonasEncontradas FillDataRecord(IDataRecord myDataRecord)
        {
            PersonasEncontradas myPersonasEncontradas = new PersonasEncontradas();
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
            {
                myPersonasEncontradas.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IppHallada ")))
            {
                myPersonasEncontradas.IppHallada = myDataRecord.GetString(myDataRecord.GetOrdinal("IppHallada "));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IppDesaparecida ")))
            {
                myPersonasEncontradas.IppDesaparecida = myDataRecord.GetString(myDataRecord.GetOrdinal("IppDesaparecida "));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Fecha")))
            {
                myPersonasEncontradas.Fecha = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("Fecha"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Usuario")))
            {
                myPersonasEncontradas.Usuario = myDataRecord.GetString(myDataRecord.GetOrdinal("Usuario"));
            }
            return myPersonasEncontradas;
        }
    }

}
