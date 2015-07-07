using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal
{
/// <summary>
/// The TatuajesPersonaDB class is responsible for interacting with the database to retrieve and store information
/// about TatuajesPersona objects.
/// </summary>
    public partial class TatuajesPersonaDB
    {
        #region "Public Methods"

        /// <summary>
        /// Gets an instance of TatuajesPersona from the underlying datasource.
        /// </summary>
        /// <param name="id">The unique id of the TatuajesPersona in the database.</param>
        /// <returns>An TatuajesPersona when the id was found in the database, or null otherwise.</returns>
        public static TatuajesPersona GetItem(int id)
        {
            TatuajesPersona myTatuajesPersona = null;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("TatuajesPersonaSelectSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@id", id);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            myTatuajesPersona = FillDataRecord(myReader);
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
                return myTatuajesPersona;
            }
        }


        /// <summary>
        /// Gets an instance of TatuajesPersona from the underlying datasource.
        /// </summary>
        /// <param name="idPersona">The unique idPersona of the TatuajesPersona in the database.</param>
        /// /// <param name="idTablaDestino">The unique idTablaDestino of the TatuajesPersona in the database.</param>
        /// <returns>An TatuajesPersona when the id was found in the database, or null otherwise.</returns>
        public static TatuajesPersonaList GetList(int idPersona, int idTablaDestino)
        {
            TatuajesPersonaList tempList = new TatuajesPersonaList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("TatuajesPersonaSelectListByIdPersona", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idPersona", idPersona);
                    myCommand.Parameters.AddWithValue("@idTablaDestino", idTablaDestino);

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
        /// Returns a list with TatuajesPersona objects.
        /// </summary>
        /// <returns>A generics List with the TatuajesPersona objects.</returns>
        public static TatuajesPersonaList GetList()
        {
            TatuajesPersonaList tempList = new TatuajesPersonaList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("TatuajesPersonaSelectList", myConnection))
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
        /// Returns a list with TatuajesPersona objects.
        /// </summary>
        /// <returns>A generics List with the TatuajesPersona objects.</returns>
        public static TatuajesPersonaList GetListByidTablaDestino(int idTablaDestino)
        {
            TatuajesPersonaList tempList = new TatuajesPersonaList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("TatuajesPersonaSelectListByidTablaDestino", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idTablaDestino", idTablaDestino);
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
        /// Returns a list with TatuajesPersona objects.
        /// </summary>
        /// <returns>A generics List with the TatuajesPersona objects.</returns>
        public static TatuajesPersonaList GetListByidTatuaje(int idTatuaje)
        {
            TatuajesPersonaList tempList = new TatuajesPersonaList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("TatuajesPersonaSelectListByidTatuaje", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idTatuaje", idTatuaje);
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
        /// Returns a list with TatuajesPersona objects.
        /// </summary>
        /// <returns>A generics List with the TatuajesPersona objects.</returns>
        public static TatuajesPersonaList GetListByidUbicacionTatuaje(int idUbicacionTatuaje)
        {
            TatuajesPersonaList tempList = new TatuajesPersonaList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("TatuajesPersonaSelectListByidUbicacionTatuaje", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idUbicacionTatuaje", idUbicacionTatuaje);
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
        /// Returns a list with TatuajesPersona objects.
        /// </summary>
        /// <returns>A generics List with the TatuajesPersona objects.</returns>
        public static TatuajesPersonaList GetListByidPersona(int idPersona)
        {
            TatuajesPersonaList tempList = new TatuajesPersonaList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("TatuajesPersonaSelectListByidPersona", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idPersona", idPersona);
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
        /// Returns a list with TatuajesPersona objects.
        /// </summary>
        /// <returns>A generics List with the TatuajesPersona objects of a PersonaDesaparecida.</returns>
        public static TatuajesPersonaList GetListByidPersonaDesaparecida(int idPersona)
        {
            TatuajesPersonaList tempList = new TatuajesPersonaList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("TatuajesPersonaSelectListByidPersonaDesaparecida", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idPersona", idPersona);
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
        /// Returns a list with TatuajesPersona objects.
        /// </summary>
        /// <returns>A generics List with the TatuajesPersona objects of a PersonaDesaparecida.</returns>
        public static TatuajesPersonaList GetListByidPersonaHallada(int idPersona)
        {
            TatuajesPersonaList tempList = new TatuajesPersonaList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("TatuajesPersonaSelectListByidPersonaHallada", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idPersona", idPersona);
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
        /// Returns a list with TatuajesPersona objects.
        /// </summary>
        /// <returns>A generics List with the TatuajesPersona objects.</returns>
        public static TatuajesPersonaList GetListByidAutor(int idAutor)
        {
            TatuajesPersonaList tempList = new TatuajesPersonaList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("TatuajesPersonaSelectListByidAutor", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idAutor", idAutor);
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
        /// Saves a TatuajesPersona in the database.
        /// </summary>
        /// <param name="myTatuajesPersona">The TatuajesPersona instance to save.</param>
        /// <param name="myCommand"></param>
        /// <returns>The new id if the TatuajesPersona is new in the database or the existing id when an item was updated.</returns>
        public static int Save(TatuajesPersona myTatuajesPersona, SqlCommand myCommand)
        {
            int result = 0;
            try
            {
                myCommand.CommandText = "TatuajesPersonaInsertUpdateSingleItem";
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Clear();
                if (myTatuajesPersona.id == -1)
                {
                    myCommand.Parameters.AddWithValue("@id", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@id", myTatuajesPersona.id);
                }
                if (myTatuajesPersona.idPersona == null)
                {
                    myCommand.Parameters.AddWithValue("@idPersona", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idPersona", myTatuajesPersona.idPersona);
                }
                if (myTatuajesPersona.idTablaDestino == null)
                {
                    myCommand.Parameters.AddWithValue("@idTablaDestino", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idTablaDestino", myTatuajesPersona.idTablaDestino);
                }
                if (myTatuajesPersona.idTatuaje == null)
                {
                    myCommand.Parameters.AddWithValue("@idTatuaje", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idTatuaje", myTatuajesPersona.idTatuaje);
                }
                if (myTatuajesPersona.idUbicacionTatuaje == null)
                {
                    myCommand.Parameters.AddWithValue("@idUbicacionTatuaje", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idUbicacionTatuaje", myTatuajesPersona.idUbicacionTatuaje);
                }

                if (myTatuajesPersona.descripcion == null)
                {
                    myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@descripcion", myTatuajesPersona.descripcion);
                }

                if (myTatuajesPersona.idAutor == 0 )
                {
                    myCommand.Parameters.AddWithValue("@idAutor", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idAutor", myTatuajesPersona.idAutor);
                }

                DbParameter returnValue;
                returnValue = myCommand.CreateParameter();
                returnValue.Direction = ParameterDirection.ReturnValue;
                myCommand.Parameters.Add(returnValue);

                //myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = Convert.ToInt32(returnValue.Value);
                //myConnection.Close();
            } // try
            catch (Exception e)
            {
                //tr.Rollback();
                throw e;
            }

            return result;
        }

        /// <summary>
        /// Saves a TatuajesPersona in the database.
        /// </summary>
        /// <param name="myTatuajesPersona">The TatuajesPersona instance to save.</param>
        /// <returns>The new id if the TatuajesPersona is new in the database or the existing id when an item was updated.</returns>
        public static int Save(TatuajesPersona myTatuajesPersona)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("TatuajesPersonaInsertUpdateSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    if (myTatuajesPersona.id == -1)
                    {
                        myCommand.Parameters.AddWithValue("@id", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@id", myTatuajesPersona.id);
                    }
                    if (myTatuajesPersona.idPersona == null)
                    {
                        myCommand.Parameters.AddWithValue("@idPersona", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idPersona", myTatuajesPersona.idPersona);
                    }
                    if (myTatuajesPersona.idTablaDestino == null)
                    {
                        myCommand.Parameters.AddWithValue("@idTablaDestino", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idTablaDestino", myTatuajesPersona.idTablaDestino);
                    }
                    if (myTatuajesPersona.idTatuaje == null)
                    {
                        myCommand.Parameters.AddWithValue("@idTatuaje", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idTatuaje", myTatuajesPersona.idTatuaje);
                    }
                    if (myTatuajesPersona.idUbicacionTatuaje == null)
                    {
                        myCommand.Parameters.AddWithValue("@idUbicacionTatuaje", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idUbicacionTatuaje", myTatuajesPersona.idUbicacionTatuaje);
                    }
                    if (string.IsNullOrEmpty(myTatuajesPersona.descripcion))
                    {
                        myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@descripcion", myTatuajesPersona.descripcion);
                    }
                    if (myTatuajesPersona.idAutor == null)
                    {
                        myCommand.Parameters.AddWithValue("@idAutor", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idAutor", myTatuajesPersona.idAutor);
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
        /// Deletes a TatuajesPersona from the database.
        /// </summary>
        /// <param name="id">The id of the TatuajesPersona to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        public static bool Delete(int id)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("TatuajesPersonaDeleteSingleItem", myConnection))
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
        /// Initializes a new instance of the TatuajesPersona class and fills it with the data fom the IDataRecord.
        /// </summary>
        private static TatuajesPersona FillDataRecord(IDataRecord myDataRecord)
        {
            TatuajesPersona myTatuajesPersona = new TatuajesPersona();
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
            {
                myTatuajesPersona.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idPersona")))
            {
                myTatuajesPersona.idPersona = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idPersona"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idTablaDestino")))
            {
                myTatuajesPersona.idTablaDestino = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idTablaDestino"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idTatuaje")))
            {
                myTatuajesPersona.idTatuaje = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idTatuaje"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idUbicacionTatuaje")))
            {
                myTatuajesPersona.idUbicacionTatuaje = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idUbicacionTatuaje"));
            }

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
            {
                myTatuajesPersona.descripcion= myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idAutor")))
            {
                myTatuajesPersona.idAutor = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idAutor"));
            }
            return myTatuajesPersona;
        }

    }
 } 
