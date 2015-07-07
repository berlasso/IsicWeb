using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal
{
    /// <summary>
    /// The PersonasHalladasDB class is responsible for interacting with the database to retrieve and store information
    /// about PersonasHalladas objects.
    /// </summary>
    public partial class PersonasHalladasDB
    {
        #region "Public Methods"

        /// <summary>
        /// Gets an instance of PersonasHalladas from the underlying datasource.
        /// </summary>
        /// <param name="id">The unique id of the PersonasHalladas in the database.</param>
        /// <returns>An PersonasHalladas when the id was found in the database, or null otherwise.</returns>
        public static PersonasHalladas GetItem(int id)
        {
            PersonasHalladas myPersonasHalladas = null;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasHalladasSelectSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@id", id);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            myPersonasHalladas = FillDataRecord(myReader, false);
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
                return myPersonasHalladas;
            }
        }

        /// <summary>
        /// Returns an IPP from PersonasHalladas objects.
        /// </summary>
        /// <returns>An IPP from PersonasHalladas based on Id from Busqueda table.</returns>
        public static PersonasHalladas GetItemByIdBusqueda(int idBusqueda)
        {
           
            PersonasHalladas myPersonasHalladas = null;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasHalladasSelectListByidBusqueda", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idBusqueda", idBusqueda);
                    myConnection.Open();

                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            myPersonasHalladas = FillDataRecord(myReader, false);
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
                return myPersonasHalladas;
                    //Ipp = myCommand.ExecuteScalar().ToString();
                    //return Ipp;

                }
            }
        

        /// <summary>
        /// Gets an instance of PersonasHalladas from the underlying datasource.
        /// </summary>
        /// <param name="id">The unique id of the PersonasHalladas in the database by this IPP.</param>
        /// <returns>An PersonasHalladas when the id was found in the database, or null otherwise.</returns>
        public static PersonasHalladas GetItemByidCausa(string idCausa)
        {
            PersonasHalladas myPersonasHalladas = null;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasHalladasSelectSingleItemByIdCausa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@IdCausa", idCausa);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            myPersonasHalladas = FillDataRecord(myReader, false);
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
                return myPersonasHalladas;
            }
        }

        /// <summary>
        /// Returns a list with PersonasHalladas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasHalladas objects.</returns>
        public static PersonasHalladasList GetList()
        {
            PersonasHalladasList tempList = new PersonasHalladasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasHalladasSelectList", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader, false));
                            }
                        }
                        myReader.Close();
                    }
                }
            }
            return tempList;
        }


        /// <summary>
        /// Returns a list with PersonasHalladas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasHalladas objects.</returns>
        public static PersonasHalladasList GetListByParametrosBusqueda(Busqueda criterios)
        {
            PersonasHalladasList tempList = new PersonasHalladasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasHalladasSelectCoincidencias", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@apellido", criterios.Apellido);
                    myCommand.Parameters.AddWithValue("@DNI", criterios.DNI);
                    myCommand.Parameters.AddWithValue("@nombre", criterios.Nombre);
                    myCommand.Parameters.AddWithValue("@fechaDesde", criterios.FechaDesde);
                    myCommand.Parameters.AddWithValue("@fechaHasta", criterios.FechaHasta);
                    myCommand.Parameters.AddWithValue("@edadDesde", criterios.EdadDesde);
                    myCommand.Parameters.AddWithValue("@edadHasta", criterios.EdadHasta);
                    myCommand.Parameters.AddWithValue("@tallaDesde", criterios.TallaDesde);
                    myCommand.Parameters.AddWithValue("@tallaHasta", criterios.TallaHasta);
                    myCommand.Parameters.AddWithValue("@pesoDesde", criterios.PesoDesde);
                    myCommand.Parameters.AddWithValue("@pesoHasta", criterios.PesoHasta);
                    myCommand.Parameters.AddWithValue("@sexo", criterios.idsexo);
                    myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", criterios.FechaUltimaModificacion);
                    myCommand.Parameters.AddWithValue("@fechaAlta", criterios.FechaAlta);
                    if (criterios.busquedaColorPiels.Count > 0)
                    {
                        string colorPielIds = "";
                        for (int i = 0; i <= criterios.busquedaColorPiels.Count - 1; i++)
                        {
                            colorPielIds += criterios.busquedaColorPiels[i].idClaseColorPiel.ToString();
                            if (i < criterios.busquedaColorPiels.Count - 1)
                                colorPielIds += ",";
                        }
                        myCommand.Parameters.AddWithValue("@colorPiel", colorPielIds);
                    }
                    //if (criterios.busquedaRostros.Count > 0)
                    //{
                    //    string rostroIds = "";
                    //    for (int i = 0; i <= criterios.busquedaRostros.Count - 1; i++)
                    //    {
                    //        rostroIds += criterios.busquedaRostros[i].idClaseRostro.ToString();
                    //        if (i < criterios.busquedaRostros.Count - 1)
                    //            rostroIds += ",";
                    //    }
                    //    myCommand.Parameters.AddWithValue("@rostro", rostroIds);
                    //}
                    if (criterios.busquedaColorCabellos.Count > 0)
                    {
                        string colorCabelloIds = "";
                        for (int i = 0; i <= criterios.busquedaColorCabellos.Count - 1; i++)
                        {
                            colorCabelloIds += criterios.busquedaColorCabellos[i].idClaseColorCabello.ToString();
                            if (i < criterios.busquedaColorCabellos.Count - 1)
                                colorCabelloIds += ",";
                        }
                        myCommand.Parameters.AddWithValue("@colorCabello", colorCabelloIds);
                    }
                    if (criterios.busquedaColorTenidos.Count > 0)
                    {
                        string colorTenidoIds = "";
                        for (int i = 0; i <= criterios.busquedaColorTenidos.Count - 1; i++)
                        {
                            colorTenidoIds += criterios.busquedaColorTenidos[i].idClaseColorTenido.ToString();
                            if (i < criterios.busquedaColorTenidos.Count - 1)
                                colorTenidoIds += ",";
                        }
                        myCommand.Parameters.AddWithValue("@colorTenido", colorTenidoIds);
                    }
                    if (criterios.busquedaLongitudCabellos.Count > 0)
                    {
                        string longitudCabelloIds = "";
                        for (int i = 0; i <= criterios.busquedaLongitudCabellos.Count - 1; i++)
                        {
                            longitudCabelloIds += criterios.busquedaLongitudCabellos[i].idClaseLongitudCabello.ToString();
                            if (i < criterios.busquedaLongitudCabellos.Count - 1)
                                longitudCabelloIds += ",";
                        }
                        myCommand.Parameters.AddWithValue("@longitudCabello", longitudCabelloIds);
                    }
                    if (criterios.busquedaAspectoCabellos.Count > 0)
                    {
                        string aspectoCabelloIds = "";
                        for (int i = 0; i <= criterios.busquedaAspectoCabellos.Count - 1; i++)
                        {
                            aspectoCabelloIds += criterios.busquedaAspectoCabellos[i].idAspectoCabello.ToString();
                            if (i < criterios.busquedaAspectoCabellos.Count - 1)
                                aspectoCabelloIds += ",";
                        }
                        myCommand.Parameters.AddWithValue("@aspectoCabello", aspectoCabelloIds);
                    }
                    if (criterios.busquedaCalvicies.Count > 0)
                    {
                        string calviciesIds = "";
                        for (int i = 0; i <= criterios.busquedaCalvicies.Count - 1; i++)
                        {
                            calviciesIds += criterios.busquedaCalvicies[i].idClaseCalvicie.ToString();
                            if (i < criterios.busquedaCalvicies.Count - 1)
                                calviciesIds += ",";
                        }
                        myCommand.Parameters.AddWithValue("@calvicie", calviciesIds);
                    }
                    if (criterios.busquedaColorOjoss.Count > 0)
                    {
                        string colorOjosIds = "";
                        for (int i = 0; i <= criterios.busquedaColorOjoss.Count - 1; i++)
                        {
                            colorOjosIds += criterios.busquedaColorOjoss[i].idClaseColorOjos.ToString();
                            if (i < criterios.busquedaColorOjoss.Count - 1)
                                colorOjosIds += ",";
                        }
                        myCommand.Parameters.AddWithValue("@colorOjos", colorOjosIds);
                    }

                    if (criterios.busquedaSeniasParticularess.Count > 0)
                    {
                        string senias = ""; //= criterios.busquedaSeniasParticularess[0].idClaseSeniaParticular.ToString();
                        string ubicacion = ""; //= criterios.busquedaSeniasParticularess[0].idUbicacionSeniaParticular.ToString();
                        for (int i = 0; i <= criterios.busquedaSeniasParticularess.Count - 1; i++)
                        {
                            senias += criterios.busquedaSeniasParticularess[i].idClaseSeniaParticular.ToString();
                            ubicacion += criterios.busquedaSeniasParticularess[i].idUbicacionSeniaParticular.ToString();
                            if (i < criterios.busquedaSeniasParticularess.Count - 1)
                            {
                                senias += ",";
                                ubicacion += ",";
                            }
                        }
                        myCommand.Parameters.AddWithValue("@seniaParticular", senias);
                        myCommand.Parameters.AddWithValue("@ubicacionSeniaParticular", ubicacion);
                    }
                    if (criterios.busquedaTatuajess.Count > 0)
                    {
                        string tatuaje = ""; //= criterios.busquedaSeniasParticularess[0].idClaseSeniaParticular.ToString();
                        string ubicacion = ""; //= criterios.busquedaSeniasParticularess[0].idUbicacionSeniaParticular.ToString();
                        for (int i = 0; i <= criterios.busquedaTatuajess.Count - 1; i++)
                        {
                            tatuaje += criterios.busquedaTatuajess[i].IdClaseTatuaje.ToString();
                            ubicacion += criterios.busquedaTatuajess[i].IdUbicacionTatuaje.ToString();
                            if (i < criterios.busquedaTatuajess.Count - 1)
                            {
                                tatuaje += ",";
                                ubicacion += ",";
                            }
                        }
                        myCommand.Parameters.AddWithValue("@tatuaje", tatuaje);
                        myCommand.Parameters.AddWithValue("@ubicacionTatuaje", ubicacion);
                    }

                    //if (criterios.busquedaSeniasParticularess.Count > 0)
                    //{
                    //    string seniasIds = "";
                    //    for (int i = 0; i <= criterios.busquedaSeniasParticularess.Count - 1; i++)
                    //    {
                    //        seniasIds += criterios.busquedaSeniasParticularess[i].idClaseSeniaParticular.ToString();
                    //        if (i < criterios.busquedaSeniasParticularess.Count - 1)
                    //            seniasIds += ",";
                    //    }
                    //    myCommand.Parameters.AddWithValue("@seniasParticulares", seniasIds);
                    //}
                    //myCommand.Parameters.AddWithValue("@colorPiel", criterios.idColorPiel);
                    //myCommand.Parameters.AddWithValue("@colorCabello", criterios.idColorCabello);
                    //myCommand.Parameters.AddWithValue("@colorTenido", criterios.idColorTenido);
                    //myCommand.Parameters.AddWithValue("@longitudCabello", criterios.idLongitudCabellos);
                    //myCommand.Parameters.AddWithValue("@aspectoCabello", criterios.idAspectoCabello);
                    //myCommand.Parameters.AddWithValue("@calvicie", criterios.idCalvicie);
                    //myCommand.Parameters.AddWithValue("@colorOjos", criterios.idColorOjos);
                    if (criterios.FaltanPiezasDentales > 1) 
                            myCommand.Parameters.AddWithValue("@faltanPiezasDentales", criterios.FaltanPiezasDentales);
                    else
                            myCommand.Parameters.AddWithValue("@faltanPiezasDentales", null);
                    //myCommand.Parameters.AddWithValue("@seniaParticular", criterios.idSeniaParticular);
                    //myCommand.Parameters.AddWithValue("@ubicacionSeniaParticular", criterios.idUbicacionSeniaParticular);
                    myCommand.Parameters.AddWithValue("@ADN", criterios.tieneADN);
                    myCommand.Parameters.AddWithValue("@cantidadCoincidencias", criterios.CantidadCoincidencias);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader, true));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with PersonasHalladas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasHalladas objects.</returns>
        public static PersonasHalladasList GetListByIPP(string ipp)
        {
            PersonasHalladasList tempList = new PersonasHalladasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasHalladasSelectListByIPP", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@IPP", ipp);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader, false));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with PersonasHalladas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasHalladas objects.</returns>
        public static PersonasHalladasList GetListByidComisaria(int idComisaria)
        {
            PersonasHalladasList tempList = new PersonasHalladasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasHalladasSelectListByidComisaria", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idComisaria", idComisaria);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader, false));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with PersonasHalladas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasHalladas objects.</returns>
        public static PersonasHalladasList GetListByidDentadura(int idDentadura)
        {
            PersonasHalladasList tempList = new PersonasHalladasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasHalladasSelectListByidDentadura", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idDentadura", idDentadura);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader, false));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with PersonasHalladas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasHalladas objects.</returns>
        public static PersonasHalladasList GetListByidLugarHallazgo(int idLugarHallazgo)
        {
            PersonasHalladasList tempList = new PersonasHalladasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasHalladasSelectListByidLugarHallazgo", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idLugarHallazgo", idLugarHallazgo);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader, false));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with PersonasHalladas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasHalladas objects.</returns>
        public static PersonasHalladasList GetListByidAspectoCabello(int idAspectoCabello)
        {
            PersonasHalladasList tempList = new PersonasHalladasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasHalladasSelectListByidAspectoCabello", myConnection))
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
                                tempList.Add(FillDataRecord(myReader, false));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with PersonasHalladas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasHalladas objects.</returns>
        public static PersonasHalladasList GetListByidCalvicie(int idCalvicie)
        {
            PersonasHalladasList tempList = new PersonasHalladasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasHalladasSelectListByidCalvicie", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idCalvicie", idCalvicie);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader, false));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        ///// <summary>
        ///// Returns a list with PersonasHalladas objects.
        ///// </summary>
        ///// <returns>A generics List with the PersonasHalladas objects.</returns>
        //public static PersonasHalladasList GetListByFechaUltimaModificacion(DateTime fechaUltimaModificacion)
        //{
        //    PersonasHalladasList tempList = new PersonasHalladasList();
        //    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
        //    {
        //        using (SqlCommand myCommand = new SqlCommand("PersonasHalladasSelectListByFechaUltimaModificacion", myConnection))
        //        {
        //            myCommand.CommandType = CommandType.StoredProcedure;
        //            myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", fechaUltimaModificacion);
        //            myConnection.Open();
        //            using (SqlDataReader myReader = myCommand.ExecuteReader())
        //            {
        //                if (myReader.HasRows)
        //                {
        //                    while (myReader.Read())
        //                    {
        //                        tempList.Add(FillDataRecord(myReader, false));
        //                    }
        //                }
        //                myReader.Close();
        //            }
        //        }
        //        return tempList;
        //    }
        //}

        /// <summary>
        /// Returns a list with PersonasHalladas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasHalladas objects.</returns>
        public static PersonasHalladasList GetListByidColorTenido(int idColorTenido)
        {
            PersonasHalladasList tempList = new PersonasHalladasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasHalladasSelectListByidColorTenido", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idColorTenido", idColorTenido);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader, false));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with PersonasHalladas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasHalladas objects.</returns>
        public static PersonasHalladasList GetListByidColorCabello(int idColorCabello)
        {
            PersonasHalladasList tempList = new PersonasHalladasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasHalladasSelectListByidColorCabello", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idColorCabello", idColorCabello);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader, false));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with PersonasHalladas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasDesaparecidas objects.</returns>
        public static PersonasHalladasList GetListByTipoDNI(int idTipoDNI)
        {
            PersonasHalladasList tempList = new PersonasHalladasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasHalladasSelectListByidTipoDNI", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idTipoDNI", idTipoDNI);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader, false));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }


        /// <summary>
        /// Returns a list with PersonasHalladas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasHalladas objects.</returns>
        public static PersonasHalladasList GetListByidColorPiel(int idColorPiel)
        {
            PersonasHalladasList tempList = new PersonasHalladasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasHalladasSelectListByidColorPiel", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idColorPiel", idColorPiel);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader, false));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with PersonasHalladas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasHalladas objects.</returns>
        public static PersonasHalladasList GetListByidColorOjos(int idColorOjos)
        {
            PersonasHalladasList tempList = new PersonasHalladasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasHalladasSelectListByidColorOjos", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idColorOjos", idColorOjos);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader, false));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with PersonasHalladas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasHalladas objects.</returns>
        public static PersonasHalladasList GetListByidLongitudCabello(int idLongitudCabello)
        {
            PersonasHalladasList tempList = new PersonasHalladasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasHalladasSelectListByidLongitudCabello", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idLongitudCabello", idLongitudCabello);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader, false));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with PersonasHalladas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasHalladas objects.</returns>
        public static PersonasHalladasList GetListByidOrganismoInterviniente(int idOrganismoInterviniente)
        {
            PersonasHalladasList tempList = new PersonasHalladasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasHalladasSelectListByidOrganismoInterviniente", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idOrganismoInterviniente", idOrganismoInterviniente);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader, false));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with PersonasHalladas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasHalladas objects.</returns>
        public static PersonasHalladasList GetListByidRostro(int idRostro)
        {
            PersonasHalladasList tempList = new PersonasHalladasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasHalladasSelectListByidRostro", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idRostro", idRostro);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader, false));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with PersonasHalladas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasHalladas objects.</returns>
        public static PersonasHalladasList GetListByidSeniaParticular(int idSeniaParticular)
        {
            PersonasHalladasList tempList = new PersonasHalladasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasHalladasSelectListByidSeniaParticular", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idSeniaParticular", idSeniaParticular);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader, false));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with PersonasHalladas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasHalladas objects.</returns>
        public static PersonasHalladasList GetListByidUbicacionSeniaParticular(int idUbicacionSeniaParticular)
        {
            PersonasHalladasList tempList = new PersonasHalladasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasHalladasSelectListByidUbicacionSeniaParticular", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idUbicacionSeniaParticular", idUbicacionSeniaParticular);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader, false));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }
        /// <summary>
        /// Returns a list with PersonasHalladas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasHalladas objects.</returns>
        public static PersonasHalladasList GetListByidSexo(int idSexo)
        {
            PersonasHalladasList tempList = new PersonasHalladasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasHalladasSelectListByidSexo", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idSexo", idSexo);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader, false));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with PersonasHalladas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasHalladas objects.</returns>
        public static PersonasHalladasList GetListByidBusqueda(decimal idBusqueda)
        {
            PersonasHalladasList tempList = new PersonasHalladasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasHalladasSelectListByidBusqueda", myConnection))
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
                                tempList.Add(FillDataRecord(myReader, false));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Returns a list with PersonasDesaparecidas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasDesaparecidas objects.</returns>
        public static PersonasHalladasList GetListByidGrupoSanguineo(int idGrupoSanguineo)
        {
            PersonasHalladasList tempList = new PersonasHalladasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasHalladasSelectListByidGrupoSanguineo", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idGrupoSanguineo", idGrupoSanguineo);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader, false));
                            }
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        ///// <summary>
        ///// Returns a list with PersonasHalladas objects.
        ///// </summary>
        ///// <returns>A generics List with the PersonasHalladas objects.</returns>
        //public static PersonasHalladasList GetListByidUbicacionSeniaParticular(int idUbicacionSeniaParticular)
        //{
        //PersonasHalladasList tempList = new PersonasHalladasList();
        //using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
        //{
        //using (SqlCommand myCommand = new SqlCommand("PersonasHalladasSelectListByidUbicacionSeniaParticular", myConnection))
        //{
        //myCommand.CommandType = CommandType.StoredProcedure;
        //myCommand.Parameters.AddWithValue("@idUbicacionSeniaParticular", idUbicacionSeniaParticular);
        //myConnection.Open();
        //using (SqlDataReader myReader = myCommand.ExecuteReader())
        //{
        //if (myReader.HasRows)
        //{
        //while (myReader.Read())
        //{
        //tempList.Add(FillDataRecord(myReader,false));
        //}
        //}
        //myReader.Close();
        //}
        //}
        //return tempList;
        //}
        //}

        /// <summary>
        /// Saves a PersonasHalladas in the database.
        /// </summary>
        /// <param name="myPersonasHalladas">The PersonasHalladas instance to save.</param>
        /// <returns>The new id if the PersonasHalladas is new in the database or the existing id when an item was updated.</returns>
        public static int Save(PersonasHalladas myPersonasHalladas)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasHalladasInsertUpdateSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    if (myPersonasHalladas.Id == -1)
                    {
                        myCommand.Parameters.AddWithValue("@id", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@id", myPersonasHalladas.Id);
                    }
                    if (string.IsNullOrEmpty(myPersonasHalladas.Ipp))
                    {
                        myCommand.Parameters.AddWithValue("@ipp", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@ipp", myPersonasHalladas.Ipp);
                    }
                    if (string.IsNullOrEmpty(myPersonasHalladas.UFI))
                    {
                        myCommand.Parameters.AddWithValue("@uFI", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@uFI", myPersonasHalladas.UFI);
                    }
                    if (myPersonasHalladas.idOrganismoInterviniente == null)
                    {
                        myCommand.Parameters.AddWithValue("@idOrganismoInterviniente", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idOrganismoInterviniente", myPersonasHalladas.idOrganismoInterviniente);
                    }
                    if (myPersonasHalladas.idComisaria == null)
                    {
                        myCommand.Parameters.AddWithValue("@idComisaria", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idComisaria", myPersonasHalladas.idComisaria);
                    }
                    if (myPersonasHalladas.idTipoDNI == null)
                    {
                        myCommand.Parameters.AddWithValue("@idTipoDNI", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idTipoDNI", myPersonasHalladas.idTipoDNI);
                    }
                    if (myPersonasHalladas.esExtJurisdiccion == null)
                    {
                        myCommand.Parameters.AddWithValue("@esExtJurisdiccion", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@esExtJurisdiccion", myPersonasHalladas.esExtJurisdiccion);
                    }
                    if (string.IsNullOrEmpty(myPersonasHalladas.DNI))
                    {
                        myCommand.Parameters.AddWithValue("@DNI", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@DNI", myPersonasHalladas.DNI);
                    }
                    if (string.IsNullOrEmpty(myPersonasHalladas.Apellido))
                    {
                        myCommand.Parameters.AddWithValue("@apellido", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@apellido", myPersonasHalladas.Apellido);
                    }
                    if (string.IsNullOrEmpty(myPersonasHalladas.Nombre))
                    {
                        myCommand.Parameters.AddWithValue("@nombre", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@nombre", myPersonasHalladas.Nombre);
                    }
                    if (myPersonasHalladas.idLugarHallazgo == null)
                    {
                        myCommand.Parameters.AddWithValue("@idLugarHallazgo", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idLugarHallazgo", myPersonasHalladas.idLugarHallazgo);
                    }
                    if (myPersonasHalladas.FechaHallazgo == null)
                    {
                        myCommand.Parameters.AddWithValue("@fechaHallazgo", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@fechaHallazgo", myPersonasHalladas.FechaHallazgo);
                    }
                    if (myPersonasHalladas.idSexo == null)
                    {
                        myCommand.Parameters.AddWithValue("@idSexo", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSexo", myPersonasHalladas.idSexo);
                    }
                    if (myPersonasHalladas.EdadAparente == null)
                    {
                        myCommand.Parameters.AddWithValue("@edadAparente", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@edadAparente", myPersonasHalladas.EdadAparente);
                    }
                    if (myPersonasHalladas.EdadCientifica == null)
                    {
                        myCommand.Parameters.AddWithValue("@edadCientifica", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@edadCientifica", myPersonasHalladas.EdadCientifica);
                    }
                    if (myPersonasHalladas.Talla == null)
                    {
                        myCommand.Parameters.AddWithValue("@talla", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@talla", myPersonasHalladas.Talla);
                    }
                    if (myPersonasHalladas.Peso == null)
                    {
                        myCommand.Parameters.AddWithValue("@peso", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@peso", myPersonasHalladas.Peso);
                    }
                    if (myPersonasHalladas.idColorPiel == null)
                    {
                        myCommand.Parameters.AddWithValue("@idColorPiel", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idColorPiel", myPersonasHalladas.idColorPiel);
                    }
                    if (myPersonasHalladas.idColorCabello == null)
                    {
                        myCommand.Parameters.AddWithValue("@idColorCabello", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idColorCabello", myPersonasHalladas.idColorCabello);
                    }
                    if (myPersonasHalladas.idColorTenido == null)
                    {
                        myCommand.Parameters.AddWithValue("@idColorTenido", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idColorTenido", myPersonasHalladas.idColorTenido);
                    }
                    if (myPersonasHalladas.idLongitudCabello == null)
                    {
                        myCommand.Parameters.AddWithValue("@idLongitudCabello", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idLongitudCabello", myPersonasHalladas.idLongitudCabello);
                    }
                    if (myPersonasHalladas.idAspectoCabello == null)
                    {
                        myCommand.Parameters.AddWithValue("@idAspectoCabello", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idAspectoCabello", myPersonasHalladas.idAspectoCabello);
                    }
                    if (myPersonasHalladas.idCalvicie == null)
                    {
                        myCommand.Parameters.AddWithValue("@idCalvicie", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idCalvicie", myPersonasHalladas.idCalvicie);
                    }
                    if (myPersonasHalladas.idColorOjos == null)
                    {
                        myCommand.Parameters.AddWithValue("@idColorOjos", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idColorOjos", myPersonasHalladas.idColorOjos);
                    }
                    if (myPersonasHalladas.idRostro == null)
                    {
                        myCommand.Parameters.AddWithValue("@idRostro", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idRostro", myPersonasHalladas.idRostro);
                    }
                    if (myPersonasHalladas.CantidadDiasNoAfeitado == null)
                    {
                        myCommand.Parameters.AddWithValue("@cantidadDiasNoAfeitado", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@cantidadDiasNoAfeitado", myPersonasHalladas.CantidadDiasNoAfeitado);
                    }
                    if (myPersonasHalladas.FaltanPiezasDentales == null)
                    {
                        myCommand.Parameters.AddWithValue("@faltanPiezasDentales", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@faltanPiezasDentales", myPersonasHalladas.FaltanPiezasDentales);
                    }
                    if (myPersonasHalladas.idDentadura == null)
                    {
                        myCommand.Parameters.AddWithValue("@idDentadura", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idDentadura", myPersonasHalladas.idDentadura);
                    }
                    //if (myPersonasHalladas.idSeniaParticular == null){
                    //myCommand.Parameters.AddWithValue("@idSeniaParticular", DBNull.Value);
                    //}
                    //else
                    //{
                    //myCommand.Parameters.AddWithValue("@idSeniaParticular", myPersonasHalladas.idSeniaParticular);
                    //}
                    //if (myPersonasHalladas.idUbicacionSeniaParticular == null){
                    //myCommand.Parameters.AddWithValue("@idUbicacionSeniaParticular", DBNull.Value);
                    //}
                    //else
                    //{
                    //myCommand.Parameters.AddWithValue("@idUbicacionSeniaParticular", myPersonasHalladas.idUbicacionSeniaParticular);
                    //}
                    if (myPersonasHalladas.tieneADN == null)
                    {
                        myCommand.Parameters.AddWithValue("@tieneADN", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@tieneADN", myPersonasHalladas.tieneADN);
                    }
                    if (string.IsNullOrEmpty(myPersonasHalladas.ADN))
                    {
                        myCommand.Parameters.AddWithValue("@aDN", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@aDN", myPersonasHalladas.ADN);
                    }
                    if (myPersonasHalladas.idGrupoSanguineo == null)
                    {
                        myCommand.Parameters.AddWithValue("@idGrupoSanguineo", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idGrupoSanguineo", myPersonasHalladas.idGrupoSanguineo);
                    }
                    if (myPersonasHalladas.Foto == null)
                    {
                        myCommand.Parameters.AddWithValue("@foto", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@foto", myPersonasHalladas.Foto);
                    }
                    if (myPersonasHalladas.FichasDactilares == null)
                    {
                        myCommand.Parameters.AddWithValue("@fichasDactilares", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@fichasDactilares", myPersonasHalladas.FichasDactilares);
                    }
                    if (string.IsNullOrEmpty(myPersonasHalladas.Ropa))
                    {
                        myCommand.Parameters.AddWithValue("@ropa", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@ropa", myPersonasHalladas.Ropa);
                    }
                    if (string.IsNullOrEmpty(myPersonasHalladas.ArticulosPersonales))
                    {
                        myCommand.Parameters.AddWithValue("@articulosPersonales", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@articulosPersonales", myPersonasHalladas.ArticulosPersonales);
                    }
                    if (myPersonasHalladas.ExistenRadiografia == null)
                    {
                        myCommand.Parameters.AddWithValue("@existenRadiografia", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@existenRadiografia", myPersonasHalladas.ExistenRadiografia);
                    }
                    if (myPersonasHalladas.Vive == null)
                    {
                        myCommand.Parameters.AddWithValue("@vive", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@vive", myPersonasHalladas.Vive);
                    }
                    if (myPersonasHalladas.idBusqueda == null)
                    {
                        myCommand.Parameters.AddWithValue("@idBusqueda", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idBusqueda", myPersonasHalladas.idBusqueda);
                    }
                    if (myPersonasHalladas.FechaUltimaModificacion == null)
                    {
                        myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myPersonasHalladas.FechaUltimaModificacion);
                    }
                    if (string.IsNullOrEmpty(myPersonasHalladas.UsuarioUltimaModificacion))
                    {
                        myCommand.Parameters.AddWithValue("@usuarioUltimaModificacion", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@usuarioUltimaModificacion", myPersonasHalladas.UsuarioUltimaModificacion);
                    }
                    myCommand.Parameters.AddWithValue("@fechaAlta", myPersonasHalladas.FechaAlta);
                    myCommand.Parameters.AddWithValue("@usuarioAlta", myPersonasHalladas.UsuarioAlta);

                    if (myPersonasHalladas.Baja == null)
                    {
                        myCommand.Parameters.AddWithValue("@baja", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@baja", myPersonasHalladas.Baja);
                    }

                    if (myPersonasHalladas.RestosOseos == null)
                    {
                        // restos osos es not null, por defecto no es resto oseo, valor cero
                        myCommand.Parameters.AddWithValue("@restosOseos", 0);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@restosOseos", myPersonasHalladas.RestosOseos);
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
        /// Saves a PersonasHalladas in the database.
        /// </summary>
        /// <param name="myPersonasHalladas">The PersonasHalladas instance to save.</param>
        /// <returns>The new id if the PersonasHalladas is new in the database or the existing id when an item was updated.</returns>
        public static int Save(PersonasHalladas myPersonasHalladas, SqlCommand myCommand)
        {
            int result = 0;
            //using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            //{
            //    using (SqlCommand myCommand = new SqlCommand("PersonasHalladasInsertUpdateSingleItem", myConnection))
            //    {
            try
            {
                myCommand.CommandText = "PersonasHalladasInsertUpdateSingleItem";
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Clear();

                if (myPersonasHalladas.Id == -1)
                {
                    myCommand.Parameters.AddWithValue("@id", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@id", myPersonasHalladas.Id);
                }
                if (string.IsNullOrEmpty(myPersonasHalladas.Ipp))
                {
                    myCommand.Parameters.AddWithValue("@ipp", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@ipp", myPersonasHalladas.Ipp);
                }
                if (string.IsNullOrEmpty(myPersonasHalladas.UFI))
                {
                    myCommand.Parameters.AddWithValue("@uFI", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@uFI", myPersonasHalladas.UFI);
                }
                if (myPersonasHalladas.idOrganismoInterviniente == null)
                {
                    myCommand.Parameters.AddWithValue("@idOrganismoInterviniente", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idOrganismoInterviniente", myPersonasHalladas.idOrganismoInterviniente);
                }
                if (myPersonasHalladas.idComisaria == null)
                {
                    myCommand.Parameters.AddWithValue("@idComisaria", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idComisaria", myPersonasHalladas.idComisaria);
                }
                if (myPersonasHalladas.idTipoDNI == null)
                {
                    myCommand.Parameters.AddWithValue("@idTipoDNI", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idTipoDNI", myPersonasHalladas.idTipoDNI);
                }
                if (string.IsNullOrEmpty(myPersonasHalladas.DNI))
                {
                    myCommand.Parameters.AddWithValue("@DNI", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@DNI", myPersonasHalladas.DNI);
                }
                if (string.IsNullOrEmpty(myPersonasHalladas.Apellido))
                {
                    myCommand.Parameters.AddWithValue("@apellido", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@apellido", myPersonasHalladas.Apellido);
                }
                if (string.IsNullOrEmpty(myPersonasHalladas.Nombre))
                {
                    myCommand.Parameters.AddWithValue("@nombre", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@nombre", myPersonasHalladas.Nombre);
                }
                if (myPersonasHalladas.idLugarHallazgo == null)
                {
                    myCommand.Parameters.AddWithValue("@idLugarHallazgo", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idLugarHallazgo", myPersonasHalladas.idLugarHallazgo);
                }
                if (myPersonasHalladas.FechaHallazgo == null)
                {
                    myCommand.Parameters.AddWithValue("@fechaHallazgo", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@fechaHallazgo", myPersonasHalladas.FechaHallazgo);
                }
                if (myPersonasHalladas.idSexo == null)
                {
                    myCommand.Parameters.AddWithValue("@idSexo", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idSexo", myPersonasHalladas.idSexo);
                }
                if (myPersonasHalladas.esExtJurisdiccion == null)
                {
                    myCommand.Parameters.AddWithValue("@esExtJurisdiccion", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@esExtJurisdiccion", myPersonasHalladas.esExtJurisdiccion);
                }
                if (myPersonasHalladas.EdadAparente == null)
                {
                    myCommand.Parameters.AddWithValue("@edadAparente", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@edadAparente", myPersonasHalladas.EdadAparente);
                }
                if (myPersonasHalladas.EdadCientifica == null)
                {
                    myCommand.Parameters.AddWithValue("@edadCientifica", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@edadCientifica", myPersonasHalladas.EdadCientifica);
                }
                if (myPersonasHalladas.Talla == null)
                {
                    myCommand.Parameters.AddWithValue("@talla", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@talla", myPersonasHalladas.Talla);
                }
                if (myPersonasHalladas.Peso == null)
                {
                    myCommand.Parameters.AddWithValue("@peso", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@peso", myPersonasHalladas.Peso);
                }
                if (myPersonasHalladas.idColorPiel == null)
                {
                    myCommand.Parameters.AddWithValue("@idColorPiel", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idColorPiel", myPersonasHalladas.idColorPiel);
                }
                if (myPersonasHalladas.idColorCabello == null)
                {
                    myCommand.Parameters.AddWithValue("@idColorCabello", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idColorCabello", myPersonasHalladas.idColorCabello);
                }
                if (myPersonasHalladas.idColorTenido == null)
                {
                    myCommand.Parameters.AddWithValue("@idColorTenido", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idColorTenido", myPersonasHalladas.idColorTenido);
                }
                if (myPersonasHalladas.idLongitudCabello == null)
                {
                    myCommand.Parameters.AddWithValue("@idLongitudCabello", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idLongitudCabello", myPersonasHalladas.idLongitudCabello);
                }
                if (myPersonasHalladas.idAspectoCabello == null)
                {
                    myCommand.Parameters.AddWithValue("@idAspectoCabello", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idAspectoCabello", myPersonasHalladas.idAspectoCabello);
                }
                if (myPersonasHalladas.idCalvicie == null)
                {
                    myCommand.Parameters.AddWithValue("@idCalvicie", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idCalvicie", myPersonasHalladas.idCalvicie);
                }
                if (myPersonasHalladas.idColorOjos == null)
                {
                    myCommand.Parameters.AddWithValue("@idColorOjos", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idColorOjos", myPersonasHalladas.idColorOjos);
                }
                if (myPersonasHalladas.idRostro == null)
                {
                    myCommand.Parameters.AddWithValue("@idRostro", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idRostro", myPersonasHalladas.idRostro);
                }
                if (myPersonasHalladas.CantidadDiasNoAfeitado == null)
                {
                    myCommand.Parameters.AddWithValue("@cantidadDiasNoAfeitado", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@cantidadDiasNoAfeitado", myPersonasHalladas.CantidadDiasNoAfeitado);
                }
                if (myPersonasHalladas.FaltanPiezasDentales == null)
                {
                    myCommand.Parameters.AddWithValue("@faltanPiezasDentales", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@faltanPiezasDentales", myPersonasHalladas.FaltanPiezasDentales);
                }
                if (myPersonasHalladas.idDentadura == null)
                {
                    myCommand.Parameters.AddWithValue("@idDentadura", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idDentadura", myPersonasHalladas.idDentadura);
                }
                //if (myPersonasHalladas.idSeniaParticular == null){
                //myCommand.Parameters.AddWithValue("@idSeniaParticular", DBNull.Value);
                //}
                //else
                //{
                //myCommand.Parameters.AddWithValue("@idSeniaParticular", myPersonasHalladas.idSeniaParticular);
                //}
                //if (myPersonasHalladas.idUbicacionSeniaParticular == null){
                //myCommand.Parameters.AddWithValue("@idUbicacionSeniaParticular", DBNull.Value);
                //}
                //else
                //{
                //myCommand.Parameters.AddWithValue("@idUbicacionSeniaParticular", myPersonasHalladas.idUbicacionSeniaParticular);
                //}
                if (myPersonasHalladas.tieneADN == null)
                {
                    myCommand.Parameters.AddWithValue("@tieneADN", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@tieneADN", myPersonasHalladas.tieneADN);
                }
                if (string.IsNullOrEmpty(myPersonasHalladas.ADN))
                {
                    myCommand.Parameters.AddWithValue("@aDN", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@aDN", myPersonasHalladas.ADN);
                }
                if (myPersonasHalladas.idGrupoSanguineo == null)
                {
                    myCommand.Parameters.AddWithValue("@idGrupoSanguineo", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idGrupoSanguineo", myPersonasHalladas.idGrupoSanguineo);
                }
                if (myPersonasHalladas.Foto == null)
                {
                    myCommand.Parameters.AddWithValue("@foto", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@foto", myPersonasHalladas.Foto);
                }
                if (myPersonasHalladas.FichasDactilares == null)
                {
                    myCommand.Parameters.AddWithValue("@fichasDactilares", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@fichasDactilares", myPersonasHalladas.FichasDactilares);
                }
                if (string.IsNullOrEmpty(myPersonasHalladas.Ropa))
                {
                    myCommand.Parameters.AddWithValue("@ropa", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@ropa", myPersonasHalladas.Ropa);
                }
                if (string.IsNullOrEmpty(myPersonasHalladas.ArticulosPersonales))
                {
                    myCommand.Parameters.AddWithValue("@articulosPersonales", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@articulosPersonales", myPersonasHalladas.ArticulosPersonales);
                }
                if (myPersonasHalladas.ExistenRadiografia == null)
                {
                    myCommand.Parameters.AddWithValue("@existenRadiografia", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@existenRadiografia", myPersonasHalladas.ExistenRadiografia);
                }
                if (myPersonasHalladas.Vive == null)
                {
                    myCommand.Parameters.AddWithValue("@vive", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@vive", myPersonasHalladas.Vive);
                }
                if (myPersonasHalladas.idBusqueda == null)
                {
                    myCommand.Parameters.AddWithValue("@idBusqueda", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idBusqueda", myPersonasHalladas.idBusqueda);
                }
                if (myPersonasHalladas.FechaUltimaModificacion == null)
                {
                    myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myPersonasHalladas.FechaUltimaModificacion);
                }
                if (string.IsNullOrEmpty(myPersonasHalladas.UsuarioUltimaModificacion))
                {
                    myCommand.Parameters.AddWithValue("@usuarioUltimaModificacion", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@usuarioUltimaModificacion", myPersonasHalladas.UsuarioUltimaModificacion);
                }
                if (myPersonasHalladas.RestosOseos == null)
                {
                    myCommand.Parameters.AddWithValue("@restosOseos", 0);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@restosOseos", myPersonasHalladas.RestosOseos);
                }
                myCommand.Parameters.AddWithValue("@fechaAlta", myPersonasHalladas.FechaAlta);
                myCommand.Parameters.AddWithValue("@usuarioAlta", myPersonasHalladas.UsuarioAlta);
                if (myPersonasHalladas.Baja == null)
                {
                    myCommand.Parameters.AddWithValue("@baja", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@baja", myPersonasHalladas.Baja);
                }

                DbParameter returnValue;
                returnValue = myCommand.CreateParameter();
                returnValue.Direction = ParameterDirection.ReturnValue;
                myCommand.Parameters.Add(returnValue);

                //myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = Convert.ToInt32(returnValue.Value);
                //myConnection.Close();
                // }
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
        /// Deletes a PersonasHalladas from the database.
        /// </summary>
        /// <param name="id">The id of the PersonasHalladas to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        public static bool Delete(int id)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasHalladasDeleteSingleItem", myConnection))
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
        private static PersonasHalladas FillDataRecord(IDataRecord myDataRecord, bool traeCoincidencias)
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
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idTipoDNI")))
            {
                myPersonasHalladas.idTipoDNI = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idTipoDNI"));
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
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("esExtJurisdiccion")))
            {
                myPersonasHalladas.esExtJurisdiccion = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("esExtJurisdiccion"));
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
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("esExtJurisdiccion")))
            {
                myPersonasHalladas.esExtJurisdiccion = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("esExtJurisdiccion"));
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
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("MotivoDeBaja")))
            {
                myPersonasHalladas.MotivoDeBaja = myDataRecord.GetInt32(myDataRecord.GetOrdinal("MotivoDeBaja"));
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
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaAlta")))
            {
                myPersonasHalladas.FechaAlta = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaAlta"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("UsuarioAlta")))
            {
                myPersonasHalladas.UsuarioAlta = myDataRecord.GetString(myDataRecord.GetOrdinal("UsuarioAlta"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Baja")))
            {
                myPersonasHalladas.Baja = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("Baja"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("RestosOseos")))
            {
                myPersonasHalladas.RestosOseos = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("RestosOseos"));
            }

            if (traeCoincidencias)
            {
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaEdadAparente")))
                {
                    myPersonasHalladas.CoincidenciaEdadAparente = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaEdadAparente"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaFecha")))
                {
                    myPersonasHalladas.CoincidenciaFecha = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaFecha"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaTalla")))
                {
                    myPersonasHalladas.CoincidenciaTalla = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaTalla"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaPeso")))
                {
                    myPersonasHalladas.CoincidenciaPeso = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaPeso"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaSexo")))
                {
                    myPersonasHalladas.CoincidenciaSexo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaSexo"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaColorPiel")))
                {
                    myPersonasHalladas.CoincidenciaColorPiel = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaColorPiel"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaColorCabello")))
                {
                    myPersonasHalladas.CoincidenciaColorCabello = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaColorCabello"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaColorTenido")))
                {
                    myPersonasHalladas.CoincidenciaColorTenido = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaColorTenido"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaLongCabello")))
                {
                    myPersonasHalladas.CoincidenciaLongitudCabello = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaLongCabello"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaAspectoCabello")))
                {
                    myPersonasHalladas.CoincidenciaAspectoCabello = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaAspectoCabello"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaCalvicie")))
                {
                    myPersonasHalladas.CoincidenciaCalvicie = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaCalvicie"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaColorOjos")))
                {
                    myPersonasHalladas.CoincidenciaColorOjos = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaColorOjos"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaFaltanDientes")))
                {
                    myPersonasHalladas.CoincidenciaFaltanDientes = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaFaltanDientes"));
                }
                /*if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaSeniaPart")))
                {
                    myPersonasHalladas.CoincidenciaSeniasParticulares = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaSeniaPart"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaUbicacionSeniaPart")))
                {
                    myPersonasHalladas.CoincidenciaUbicacionSeniasParticulares = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaUbicacionSeniaPart"));
                }*/
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaSeniasParticulares")))
                {
                    myPersonasHalladas.CoincidenciaSeniasParticulares = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaSeniasParticulares"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaTatuajes")))
                {
                    myPersonasHalladas.Coincidenciastatuajes = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaTatuajes"));
                }

                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaAdn")))
                {
                    myPersonasHalladas.CoincidenciaAdn = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaAdn"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaNombreyApellido")))
                {
                    myPersonasHalladas.CoincidenciaNombreyApellido = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaNombreyApellido"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaDNI")))
                {
                    myPersonasHalladas.CoincidenciaDNI = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaDNI"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CantidadCoincidencias")))
                {
                    myPersonasHalladas.CoincidenciaCantidad = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CantidadCoincidencias"));
                }
            }
            return myPersonasHalladas;
        }
    }

} 
