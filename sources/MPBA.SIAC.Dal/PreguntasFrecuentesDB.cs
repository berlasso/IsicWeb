using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;
using MPBA.SIAC.BusinessEntities; 


namespace MPBA.SIAC.Dal
{
    /// <summary>
    /// The PreguntasFrecuentesDB class is responsible for interacting with the database to retrieve and store information
    /// about PreguntasFrecuentes objects.
    /// </summary>
   public partial class PreguntasFrecuentesDB
    {
        #region "Public Methods"

        /// <summary>
        /// Gets an instance of PreguntasFrecuentes from the underlying datasource.
        /// </summary>
        /// <param name="id">The unique id of the PreguntasFrecuentes in the database.</param>
        /// <returns>An PreguntasFrecuentes when the id was found in the database, or null otherwise.</returns>
        public static PreguntasFrecuentes GetItem(int id)
        {
            PreguntasFrecuentes myPreguntasFrecuentes = null;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PreguntasFrecuentesSelectSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@id", id);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            myPreguntasFrecuentes = FillDataRecord(myReader);
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
                return myPreguntasFrecuentes;
            }
        }   


        // Recupera la respuesta dada una pregunta
        public static PreguntasFrecuentes GetRespuesta(int id)
        {
            PreguntasFrecuentes myPreguntasFrecuentes = null;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PreguntasFrecuentesSelectListRespPreg", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@pregunta", id);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            myPreguntasFrecuentes = FillDataRecord(myReader);
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
                return myPreguntasFrecuentes;
            }
        }







        /// <summary>
        /// Returns a list with PreguntasFrecuentes objects.
        /// </summary>
        /// <returns>A generics List with the PreguntasFrecuentes objects.</returns>
        public static PreguntasFrecuentesList GetList()
        {
            PreguntasFrecuentesList tempList = new PreguntasFrecuentesList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PreguntasFrecuentesSelectListPreg", myConnection))
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
        /// Saves a PreguntasFrecuentes in the database.
        /// </summary>
        /// <param name="myPreguntasFrecuentes">The PreguntasFrecuentes instance to save.</param>
        /// <returns>The new id if the PreguntasFrecuentes is new in the database or the existing id when an item was updated.</returns>
        public static int Save(PreguntasFrecuentes myPreguntasFrecuentes)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PreguntasFrecuentesInsertUpdateSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    if (myPreguntasFrecuentes.id == -1)
                    {
                        myCommand.Parameters.AddWithValue("@id", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@id", myPreguntasFrecuentes.id);
                    }
                    if (myPreguntasFrecuentes.pregunta == null)
                    {
                        myCommand.Parameters.AddWithValue("@pregunta", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@pregunta", myPreguntasFrecuentes.pregunta);
                    }
                    if (string.IsNullOrEmpty(myPreguntasFrecuentes.texto))
                    {
                        myCommand.Parameters.AddWithValue("@texto", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@texto", myPreguntasFrecuentes.texto);
                    }
                    if (myPreguntasFrecuentes.grupo == null)
                    {
                        myCommand.Parameters.AddWithValue("@grupo", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@grupo", myPreguntasFrecuentes.grupo);
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
        /// Deletes a PreguntasFrecuentes from the database.
        /// </summary>
        /// <param name="id">The id of the PreguntasFrecuentes to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        public static bool Delete(int id)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PreguntasFrecuentesDeleteSingleItem", myConnection))
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
        /// Initializes a new instance of the PreguntasFrecuentes class and fills it with the data fom the IDataRecord.
        /// </summary>
        private static PreguntasFrecuentes FillDataRecord(IDataRecord myDataRecord)
        {
            PreguntasFrecuentes myPreguntasFrecuentes = new PreguntasFrecuentes();
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
            {
                myPreguntasFrecuentes.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("pregunta")))
            {
                myPreguntasFrecuentes.pregunta = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("pregunta"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("texto")))
            {
                myPreguntasFrecuentes.texto = myDataRecord.GetString(myDataRecord.GetOrdinal("texto"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("grupo")))
            {
                myPreguntasFrecuentes.grupo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("grupo"));
            }
            return myPreguntasFrecuentes;
        }
    }
}