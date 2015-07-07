using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal
{
    /// <summary>
    /// The BusquedasFavoritasDB class is responsible for interacting with the database to retrieve and store information
    /// about BusquedasFavoritas objects.
    /// </summary>
    public partial class BusquedasFavoritasDB
    {
        #region "Public Methods"

        /// <summary>
        /// Gets an instance of BusquedasFavoritas from the underlying datasource.
        /// </summary>
        /// <param name="id">The unique id of the BusquedasFavoritas in the database.</param>
        /// <returns>An BusquedasFavoritas when the id was found in the database, or null otherwise.</returns>
        public static BusquedasFavoritas GetItem(int id)
        {
            BusquedasFavoritas myBusquedasFavoritas = null;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("BusquedasFavoritasSelectSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@id", id);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            myBusquedasFavoritas = FillDataRecord(myReader);
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
                return myBusquedasFavoritas;
            }
        }

        /// <summary>
        /// Gets an instance of BusquedasFavoritas from the underlying datasource.
        /// </summary>
        /// <param name="idPersona">The unique idPersona of the BusquedasFavoritas in the database.</param>
        /// <param name="idTablaDestino">The unique idTablaDestino of the BusquedasFavoritas in the database.</param>
        /// <returns>An BusquedasFavoritas when the id was found in the database, or null otherwise.</returns>
        public static BusquedasFavoritas GetItem(int idPersona, int idTablaDestino)
        {
            BusquedasFavoritas myBusquedasFavoritas = null;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("[BusquedasFavoritasSelectSingleItemByIdPersonaAndIdTablaDestino]", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idPersona", idPersona);
                    myCommand.Parameters.AddWithValue("@idTablaDestino", idTablaDestino);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            myBusquedasFavoritas = FillDataRecord(myReader);
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
                return myBusquedasFavoritas;
            }
        }


        /// <summary>
        /// Returns a list with BusquedasFavoritas objects.
        /// </summary>
        /// <returns>A generics List with the BusquedasFavoritas objects.</returns>
        public static BusquedasFavoritasList GetList()
        {
            BusquedasFavoritasList tempList = new BusquedasFavoritasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("BusquedasFavoritasSelectList", myConnection))
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
        /// Gets a list of BusquedasFavoritas from the underlying datasource.
        /// </summary>
        /// <param name="id">The idTablaDestino of the BusquedasFavoritas in the database.</param>
        /// <returns>An BusquedasFavoritas when the idTablaDestino was found in the database, or null otherwise.</returns>
        public static PersonasDesaparecidasList GetListJoinedDesaparecidas(string Usuario)
        {
            PersonasDesaparecidasList tempList = new PersonasDesaparecidasList();
            //System.Collections.Generic.List<PersonasDesaparecidas> tempList = new System.Collections.Generic.List<PersonasDesaparecidas>();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("[BusquedasFavoritasDesapJoinedSelectListByUsuario]", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@Usuario", Usuario);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {

                                tempList.Add(FillDataRecordD(myReader));
                            }
                        }
                        myReader.Close();
                    }
                    return tempList;
                }
            }
        }

        /// <summary>
        /// Gets a list of BusquedasFavoritas from the underlying datasource.
        /// </summary>
        /// <param name="id">The idTablaDestino of the BusquedasFavoritas in the database.</param>
        /// <returns>An BusquedasFavoritas when the idTablaDestino was found in the database, or null otherwise.</returns>
        public static PersonasHalladasList GetListJoinedHalladas(string Usuario)
        {
            PersonasHalladasList tempList = new PersonasHalladasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("[BusquedasFavoritasHalladasJoinedSelectListByUsuario]", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@Usuario", Usuario);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {

                                tempList.Add(FillDataRecordH(myReader));
                            }
                        }
                        myReader.Close();
                    }
                    return tempList;
                }
            }
        }

        /// <summary>
        /// Saves a BusquedasFavoritas in the database.
        /// </summary>
        /// <param name="myBusquedasFavoritas">The BusquedasFavoritas instance to save.</param>
        /// <returns>The new id if the BusquedasFavoritas is new in the database or the existing id when an item was updated.</returns>
        public static int Save(BusquedasFavoritas myBusquedasFavoritas, SqlCommand myCommand)
        {
            int result = 0;
            try
            {
            //using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            //{
            //    using (SqlCommand myCommand = new SqlCommand("BusquedasFavoritasInsertUpdateSingleItem", myConnection))
            //    {
            myCommand.CommandText="BusquedasFavoritasInsertUpdateSingleItem";
                    myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.Clear();
                    if (myBusquedasFavoritas.id == -1)
                    {
                        myCommand.Parameters.AddWithValue("@id", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@id", myBusquedasFavoritas.id);
                    }
                    if (myBusquedasFavoritas.idPersona == null)
                    {
                        myCommand.Parameters.AddWithValue("@idPersona", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idPersona", myBusquedasFavoritas.idPersona);
                    }
                    if (myBusquedasFavoritas.idTablaDestino == null)
                    {
                        myCommand.Parameters.AddWithValue("@idTablaDestino", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idTablaDestino", myBusquedasFavoritas.idTablaDestino);
                    }
                    if (string.IsNullOrEmpty(myBusquedasFavoritas.Usuario))
                    {
                        myCommand.Parameters.AddWithValue("@usuario", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@usuario", myBusquedasFavoritas.Usuario);
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
                throw e;
            }
            return result;
        }

        /// <summary>
        /// Saves a BusquedasFavoritas in the database.
        /// </summary>
        /// <param name="myBusquedasFavoritas">The BusquedasFavoritas instance to save.</param>
        /// <returns>The new id if the BusquedasFavoritas is new in the database or the existing id when an item was updated.</returns>
        public static int Save(BusquedasFavoritas myBusquedasFavoritas)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("BusquedasFavoritasInsertUpdateSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    if (myBusquedasFavoritas.id == -1)
                    {
                        myCommand.Parameters.AddWithValue("@id", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@id", myBusquedasFavoritas.id);
                    }
                    if (myBusquedasFavoritas.idPersona == null)
                    {
                        myCommand.Parameters.AddWithValue("@idPersona", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idPersona", myBusquedasFavoritas.idPersona);
                    }
                    if (myBusquedasFavoritas.idTablaDestino == null)
                    {
                        myCommand.Parameters.AddWithValue("@idTablaDestino", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idTablaDestino", myBusquedasFavoritas.idTablaDestino);
                    }
                    if (string.IsNullOrEmpty(myBusquedasFavoritas.Usuario))
                    {
                        myCommand.Parameters.AddWithValue("@usuario", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@usuario", myBusquedasFavoritas.Usuario);
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
        /// Initializes a new instance of the PersonasDesaparecidas class and fills it with the data fom the IDataRecord.
        /// </summary>
        private static PersonasDesaparecidas FillDataRecordD(IDataRecord myDataRecord)
        {
            PersonasDesaparecidas myPersonasDesaparecidas = new PersonasDesaparecidas();
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
            {
                myPersonasDesaparecidas.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Ipp")))
            {
                myPersonasDesaparecidas.Ipp = myDataRecord.GetString(myDataRecord.GetOrdinal("Ipp"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("UFI")))
            {
                myPersonasDesaparecidas.UFI = myDataRecord.GetString(myDataRecord.GetOrdinal("UFI"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idOrganismoInterviniente")))
            {
                myPersonasDesaparecidas.idOrganismoInterviniente = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idOrganismoInterviniente"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idComisaria")))
            {
                myPersonasDesaparecidas.idComisaria = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idComisaria"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DNI")))
            {
                myPersonasDesaparecidas.DNI = myDataRecord.GetString(myDataRecord.GetOrdinal("DNI"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Apellido")))
            {
                myPersonasDesaparecidas.Apellido = myDataRecord.GetString(myDataRecord.GetOrdinal("Apellido"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Nombre")))
            {
                myPersonasDesaparecidas.Nombre = myDataRecord.GetString(myDataRecord.GetOrdinal("Nombre"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idLugarDesaparicion")))
            {
                myPersonasDesaparecidas.idLugarDesaparicion = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idLugarDesaparicion"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaDesaparicion")))
            {
                myPersonasDesaparecidas.FechaDesaparicion = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaDesaparicion"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idSexo")))
            {
                myPersonasDesaparecidas.idSexo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idSexo"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaNacimiento")))
            {
                myPersonasDesaparecidas.FechaNacimiento = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaNacimiento"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("EdadMomentoDesaparicion")))
            {
                myPersonasDesaparecidas.EdadMomentoDesaparicion = myDataRecord.GetInt32(myDataRecord.GetOrdinal("EdadMomentoDesaparicion"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Talla")))
            {
                myPersonasDesaparecidas.Talla = myDataRecord.GetFloat(myDataRecord.GetOrdinal("Talla"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Peso")))
            {
                myPersonasDesaparecidas.Peso = myDataRecord.GetFloat(myDataRecord.GetOrdinal("Peso"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idColorPiel")))
            {
                myPersonasDesaparecidas.idColorPiel = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idColorPiel"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idColorCabello")))
            {
                myPersonasDesaparecidas.idColorCabello = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idColorCabello"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idColorTenido")))
            {
                myPersonasDesaparecidas.idColorTenido = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idColorTenido"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idLongitudCabello")))
            {
                myPersonasDesaparecidas.idLongitudCabello = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idLongitudCabello"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idAspectoCabello")))
            {
                myPersonasDesaparecidas.idAspectoCabello = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idAspectoCabello"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idCalvicie")))
            {
                myPersonasDesaparecidas.idCalvicie = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idCalvicie"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idColorOjos")))
            {
                myPersonasDesaparecidas.idColorOjos = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idColorOjos"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idRostro")))
            {
                myPersonasDesaparecidas.idRostro = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idRostro"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CantidadDiasNoAfeitado")))
            {
                myPersonasDesaparecidas.CantidadDiasNoAfeitado = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CantidadDiasNoAfeitado"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FaltanPiezasDentales")))
            {
                myPersonasDesaparecidas.FaltanPiezasDentales = myDataRecord.GetInt32(myDataRecord.GetOrdinal("FaltanPiezasDentales"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idDentadura")))
            {
                myPersonasDesaparecidas.idDentadura = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idDentadura"));
            }
         
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("tieneADN")))
            {
                myPersonasDesaparecidas.tieneADN = myDataRecord.GetInt32(myDataRecord.GetOrdinal("tieneADN"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("ADN")))
            {
                myPersonasDesaparecidas.ADN = myDataRecord.GetString(myDataRecord.GetOrdinal("ADN"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idGrupoSanguineo")))
            {
                myPersonasDesaparecidas.idGrupoSanguineo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idGrupoSanguineo"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Foto")))
            {
                myPersonasDesaparecidas.Foto = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Foto"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FichasDactilares")))
            {
                myPersonasDesaparecidas.FichasDactilares = myDataRecord.GetInt32(myDataRecord.GetOrdinal("FichasDactilares"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Ropa")))
            {
                myPersonasDesaparecidas.Ropa = myDataRecord.GetString(myDataRecord.GetOrdinal("Ropa"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("ArticulosPersonales")))
            {
                myPersonasDesaparecidas.ArticulosPersonales = myDataRecord.GetString(myDataRecord.GetOrdinal("ArticulosPersonales"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("ExistenRadiografia")))
            {
                myPersonasDesaparecidas.ExistenRadiografia = myDataRecord.GetInt32(myDataRecord.GetOrdinal("ExistenRadiografia"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaUltimaModificacion")))
            {
                myPersonasDesaparecidas.FechaUltimaModificacion = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaUltimaModificacion"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("UsuarioUltimaModificacion")))
            {
                myPersonasDesaparecidas.UsuarioUltimaModificacion = myDataRecord.GetString(myDataRecord.GetOrdinal("UsuarioUltimaModificacion"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Baja")))
            {
                myPersonasDesaparecidas.Baja = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("Baja"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusqueda")))
            {
                myPersonasDesaparecidas.idBusqueda = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusqueda"));
            }
            return myPersonasDesaparecidas;
        }


        /// <summary>
        /// Deletes a BusquedasFavoritas from the database.
        /// </summary>
        /// <param name="id">The id of the BusquedasFavoritas to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        public static bool Delete(int id)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("BusquedasFavoritasDeleteSingleItem", myConnection))
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
        /// Initializes a new instance of the PersonasHalladas class and fills it with the data fom the IDataRecord.
        /// </summary>
        private static PersonasHalladas FillDataRecordH(IDataRecord myDataRecord)
        {
            PersonasHalladas myPersonasHalladas = new PersonasHalladas();
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
            {
                myPersonasHalladas.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Ipp")))
            {
                myPersonasHalladas.Ipp = myDataRecord.GetString(myDataRecord.GetOrdinal("Ipp"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("UFI")))
            {
                myPersonasHalladas.UFI = myDataRecord.GetString(myDataRecord.GetOrdinal("UFI"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idOrganismoInterviniente")))
            {
                myPersonasHalladas.idOrganismoInterviniente = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idOrganismoInterviniente"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idComisaria")))
            {
                myPersonasHalladas.idComisaria = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idComisaria"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DNI")))
            {
                myPersonasHalladas.DNI = myDataRecord.GetString(myDataRecord.GetOrdinal("DNI"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Apellido")))
            {
                myPersonasHalladas.Apellido = myDataRecord.GetString(myDataRecord.GetOrdinal("Apellido"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Nombre")))
            {
                myPersonasHalladas.Nombre = myDataRecord.GetString(myDataRecord.GetOrdinal("Nombre"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idLugarHallazgo")))
            {
                myPersonasHalladas.idLugarHallazgo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idLugarHallazgo"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaHallazgo")))
            {
                myPersonasHalladas.FechaHallazgo = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaHallazgo"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idSexo")))
            {
                myPersonasHalladas.idSexo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idSexo"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("EdadAparente")))
            {
                myPersonasHalladas.EdadAparente = myDataRecord.GetInt32(myDataRecord.GetOrdinal("EdadAparente"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("EdadCientifica")))
            {
                myPersonasHalladas.EdadCientifica = myDataRecord.GetInt32(myDataRecord.GetOrdinal("EdadCientifica"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Talla")))
            {
                myPersonasHalladas.Talla = myDataRecord.GetFloat(myDataRecord.GetOrdinal("Talla"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Peso")))
            {
                myPersonasHalladas.Peso = myDataRecord.GetFloat(myDataRecord.GetOrdinal("Peso"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idColorPiel")))
            {
                myPersonasHalladas.idColorPiel = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idColorPiel"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idColorCabello")))
            {
                myPersonasHalladas.idColorCabello = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idColorCabello"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idColorTenido")))
            {
                myPersonasHalladas.idColorTenido = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idColorTenido"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idLongitudCabello")))
            {
                myPersonasHalladas.idLongitudCabello = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idLongitudCabello"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idAspectoCabello")))
            {
                myPersonasHalladas.idAspectoCabello = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idAspectoCabello"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idCalvicie")))
            {
                myPersonasHalladas.idCalvicie = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idCalvicie"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idColorOjos")))
            {
                myPersonasHalladas.idColorOjos = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idColorOjos"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idRostro")))
            {
                myPersonasHalladas.idRostro = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idRostro"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CantidadDiasNoAfeitado")))
            {
                myPersonasHalladas.CantidadDiasNoAfeitado = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CantidadDiasNoAfeitado"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FaltanPiezasDentales")))
            {
                myPersonasHalladas.FaltanPiezasDentales = myDataRecord.GetInt32(myDataRecord.GetOrdinal("FaltanPiezasDentales"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idDentadura")))
            {
                myPersonasHalladas.idDentadura = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idDentadura"));
            }

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("tieneADN")))
            {
                myPersonasHalladas.tieneADN = myDataRecord.GetInt32(myDataRecord.GetOrdinal("tieneADN"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("ADN")))
            {
                myPersonasHalladas.ADN = myDataRecord.GetString(myDataRecord.GetOrdinal("ADN"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idGrupoSanguineo")))
            {
                myPersonasHalladas.idGrupoSanguineo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idGrupoSanguineo"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Foto")))
            {
                myPersonasHalladas.Foto = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Foto"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FichasDactilares")))
            {
                myPersonasHalladas.FichasDactilares = myDataRecord.GetInt32(myDataRecord.GetOrdinal("FichasDactilares"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Ropa")))
            {
                myPersonasHalladas.Ropa = myDataRecord.GetString(myDataRecord.GetOrdinal("Ropa"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("ArticulosPersonales")))
            {
                myPersonasHalladas.ArticulosPersonales = myDataRecord.GetString(myDataRecord.GetOrdinal("ArticulosPersonales"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("ExistenRadiografia")))
            {
                myPersonasHalladas.ExistenRadiografia = myDataRecord.GetInt32(myDataRecord.GetOrdinal("ExistenRadiografia"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Vive")))
            {
                myPersonasHalladas.Vive = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Vive"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusqueda")))
            {
                myPersonasHalladas.idBusqueda = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusqueda"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaUltimaModificacion")))
            {
                myPersonasHalladas.FechaUltimaModificacion = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaUltimaModificacion"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("UsuarioUltimaModificacion")))
            {
                myPersonasHalladas.UsuarioUltimaModificacion = myDataRecord.GetString(myDataRecord.GetOrdinal("UsuarioUltimaModificacion"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Baja")))
            {
                myPersonasHalladas.Baja = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("Baja"));
            }
            return myPersonasHalladas;
        }

        /// <summary>
        /// Initializes a new instance of the BusquedasFavoritas class and fills it with the data fom the IDataRecord.
        /// </summary>
        private static BusquedasFavoritas FillDataRecord(IDataRecord myDataRecord)
        {
            BusquedasFavoritas myBusquedasFavoritas = new BusquedasFavoritas();
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
            {
                myBusquedasFavoritas.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idPersona")))
            {
                myBusquedasFavoritas.idPersona = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idPersona"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idTablaDestino")))
            {
                myBusquedasFavoritas.idTablaDestino = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idTablaDestino"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Usuario")))
            {
                myBusquedasFavoritas.Usuario = myDataRecord.GetString(myDataRecord.GetOrdinal("Usuario"));
            }
            return myBusquedasFavoritas;
        }
    }

} 
