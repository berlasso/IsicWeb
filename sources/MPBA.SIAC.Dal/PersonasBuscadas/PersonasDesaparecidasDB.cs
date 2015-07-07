using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal
{
    /// <summary>
    /// The PersonasDesaparecidasDB class is responsible for interacting with the database to retrieve and store information
    /// about PersonasDesaparecidas objects.
    /// </summary>
    public partial class PersonasDesaparecidasDB
    {
        
        #region "Public Methods"

        /// <summary>
        /// Gets an instance of PersonasDesaparecidas from the underlying datasource.
        /// </summary>
        /// <param name="id">The unique id of the PersonasDesaparecidas in the database.</param>
        /// <returns>An PersonasDesaparecidas when the id was found in the database, or null otherwise.</returns>
        public static PersonasDesaparecidas GetItem(int id)
        {
            PersonasDesaparecidas myPersonasDesaparecidas = null;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasSelectSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@id", id);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            myPersonasDesaparecidas = FillDataRecord(myReader, false);
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
                return myPersonasDesaparecidas;
            }
        }


        /// <summary>
        /// Gets an instance of PersonasDesaparecidas from the underlying datasource.
        /// </summary>
        /// <param name="id">The unique id of the PersonasDesaparecidas in the database by this IPP.</param>
        /// <returns>An PersonasDesaparecidas when the id was found in the database, or null otherwise.</returns>
        public static PersonasDesaparecidas GetItemByidCausa(string idCausa)
        {
            PersonasDesaparecidas myPersonasDesaparecidas = null;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasSelectSingleItemByIdCausa", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@IdCausa", idCausa);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            myPersonasDesaparecidas = FillDataRecord(myReader, false);
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
                return myPersonasDesaparecidas;
            }
        }

        /// <summary>
        /// Returns a list with PersonasDesaparecidas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasDesaparecidas objects.</returns>
        public static PersonasDesaparecidasList GetList()
        {
            PersonasDesaparecidasList tempList = new PersonasDesaparecidasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasSelectList", myConnection))
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

        // <summary>
        /// Returns a list with PersonasDesaparecidas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasDesaparecidas objects.</returns>
        public static PersonasDesaparecidasList GetListByParametrosBusqueda(Busqueda criterios)
        {
            PersonasDesaparecidasList tempList = new PersonasDesaparecidasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("[PersonasDesaparecidasSelectCoincidencias]", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@apellido", criterios.Apellido);
                    myCommand.Parameters.AddWithValue("@nombre", criterios.Nombre);
                    myCommand.Parameters.AddWithValue("@DNI", criterios.DNI);
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
                    if (criterios.busquedaRostros.Count > 0)
                    {
                        string rostroIds = "";
                        for (int i = 0; i <= criterios.busquedaRostros.Count - 1; i++)
                        {
                            rostroIds += criterios.busquedaRostros[i].idClaseRostro.ToString();
                            if (i < criterios.busquedaRostros.Count - 1)
                                rostroIds += ",";
                        }
                        myCommand.Parameters.AddWithValue("@rostro", rostroIds);
                    }
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
                    //myCommand.Parameters.AddWithValue("@faltanPiezasDentales", criterios.FaltanPiezasDentales);
                    //if (criterios.busquedaSeniasParticularess.Count > 0)
                    //{
                    //    string seniasIds = "";
                    //    for (int i = 0; i <= criterios.busquedaSeniasParticularess.Count - 1; i++)
                    //    {
                    //        seniasIds += criterios.busquedaSeniasParticularess[i].idClaseSeniaParticular.ToString();
                    //        if (i < criterios.busquedaSeniasParticularess.Count - 1)
                    //            seniasIds += ",";
                    //    }
                        //myCommand.Parameters.AddWithValue("@colorOjos", colorOjosIds);
                    //}

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
                    if (criterios.FaltanPiezasDentales > 1)
                        myCommand.Parameters.AddWithValue("@faltanPiezasDentales", criterios.FaltanPiezasDentales);
                    else
                        myCommand.Parameters.AddWithValue("@faltanPiezasDentales", null);
                   // myCommand.Parameters.AddWithValue("@faltanPiezasDentales", criterios.FaltanPiezasDentales);
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
        /// Returns a list with PersonasDesaparecidas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasDesaparecidas objects.</returns>
        public static PersonasDesaparecidasList GetListByidComisaria(int idComisaria)
        {
            PersonasDesaparecidasList tempList = new PersonasDesaparecidasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasSelectListByidComisaria", myConnection))
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
        /// Returns an IPP from PersonasDesaparecidas objects.
        /// </summary>
        /// <returns>An IPP from PersonasDesaparecidas based on Id from Busqueda table.</returns>
        public static PersonasDesaparecidas GetItemByIdBusqueda(int idBusqueda)
        {
            
            PersonasDesaparecidas myPersonasDesaparecidas = null;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasSelectListByidBusqueda", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idBusqueda", idBusqueda);

                     myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            myPersonasDesaparecidas = FillDataRecord(myReader, false);
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
                return myPersonasDesaparecidas;

                    //myConnection.Open();
                    //Ipp = myCommand.ExecuteScalar().ToString();
                    //return Ipp;

                }
            }
      

        /// <summary>
        /// Returns a list with PersonasDesaparecidas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasDesaparecidas objects.</returns>
        public static PersonasDesaparecidasList GetListByIPP(string ipp)
        { 
            PersonasDesaparecidasList tempList = new PersonasDesaparecidasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasSelectListByIPP", myConnection))
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
        /// Returns a list with PersonasDesaparecidas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasDesaparecidas objects.</returns>
        public static PersonasDesaparecidasList GetListByidDentadura(int idDentadura)
        {
            PersonasDesaparecidasList tempList = new PersonasDesaparecidasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasSelectListByidDentadura", myConnection))
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
        /// Returns a list with PersonasDesaparecidas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasDesaparecidas objects.</returns>
        public static PersonasDesaparecidasList GetListByidLugarDesaparicion(int idLugarDesaparicion)
        {
            PersonasDesaparecidasList tempList = new PersonasDesaparecidasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasSelectListByidLugarDesaparicion", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idLugarDesaparicion", idLugarDesaparicion);
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
        public static PersonasDesaparecidasList GetListByidAspectoCabello(int idAspectoCabello)
        {
            PersonasDesaparecidasList tempList = new PersonasDesaparecidasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasSelectListByidAspectoCabello", myConnection))
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
        /// Returns a list with PersonasDesaparecidas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasDesaparecidas objects.</returns>
        public static PersonasDesaparecidasList GetListByidCalvicie(int idCalvicie)
        {
            PersonasDesaparecidasList tempList = new PersonasDesaparecidasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasSelectListByidCalvicie", myConnection))
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

        /// <summary>
        /// Returns a list with PersonasDesaparecidas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasDesaparecidas objects.</returns>
        public static PersonasDesaparecidasList GetListByidColorTenido(int idColorTenido)
        {
            PersonasDesaparecidasList tempList = new PersonasDesaparecidasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasSelectListByidColorTenido", myConnection))
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
        /// Returns a list with PersonasDesaparecidas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasDesaparecidas objects.</returns>
        public static PersonasDesaparecidasList GetListByidColorCabello(int idColorCabello)
        {
            PersonasDesaparecidasList tempList = new PersonasDesaparecidasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasSelectListByidColorCabello", myConnection))
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
        /// Returns a list with PersonasDesaparecidas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasDesaparecidas objects.</returns>
        public static PersonasDesaparecidasList GetListByTipoDNI(int idTipoDNI)
        {
            PersonasDesaparecidasList tempList = new PersonasDesaparecidasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasSelectListByidColorCabello", myConnection))
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
        /// Returns a list with PersonasDesaparecidas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasDesaparecidas objects.</returns>
        public static PersonasDesaparecidasList GetListByidColorPiel(int idColorPiel)
        {
            PersonasDesaparecidasList tempList = new PersonasDesaparecidasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasSelectListByidColorPiel", myConnection))
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
        /// Returns a list with PersonasDesaparecidas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasDesaparecidas objects.</returns>
        public static PersonasDesaparecidasList GetListByidColorOjos(int idColorOjos)
        {
            PersonasDesaparecidasList tempList = new PersonasDesaparecidasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasSelectListByidColorOjos", myConnection))
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
        /// Returns a list with PersonasDesaparecidas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasDesaparecidas objects.</returns>
        public static PersonasDesaparecidasList GetListByidLongitudCabello(int idLongitudCabello)
        {
            PersonasDesaparecidasList tempList = new PersonasDesaparecidasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasSelectListByidLongitudCabello", myConnection))
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
        /// Returns a list with PersonasDesaparecidas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasDesaparecidas objects.</returns>
        public static PersonasDesaparecidasList GetListByidOrganismoInterviniente(int idOrganismoInterviniente)
        {
            PersonasDesaparecidasList tempList = new PersonasDesaparecidasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasSelectListByidOrganismoInterviniente", myConnection))
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
        /// Returns a list with PersonasDesaparecidas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasDesaparecidas objects.</returns>
        public static PersonasDesaparecidasList GetListByidRostro(int idRostro)
        {
            PersonasDesaparecidasList tempList = new PersonasDesaparecidasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasSelectListByidRostro", myConnection))
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
        /// Returns a list with PersonasDesaparecidas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasDesaparecidas objects.</returns>
        public static PersonasDesaparecidasList GetListByidSeniaParticular(int idSeniaParticular)
        {
            PersonasDesaparecidasList tempList = new PersonasDesaparecidasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasSelectListByidSeniaParticular", myConnection))
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
        /// Returns a list with PersonasDesaparecidas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasDesaparecidas objects.</returns>
        public static PersonasDesaparecidasList GetListByidUbicacionSeniaParticular(int idUbicacionSeniaParticular)
        {
            PersonasDesaparecidasList tempList = new PersonasDesaparecidasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasSelectListByidUbicacionSeniaParticular", myConnection))
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
        /// Returns a list with PersonasDesaparecidas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasDesaparecidas objects.</returns>
        public static PersonasDesaparecidasList GetListByidSexo(int idSexo)
        {
            PersonasDesaparecidasList tempList = new PersonasDesaparecidasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasSelectListByidSexo", myConnection))
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
        /// Returns a list with PersonasDesaparecidas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasDesaparecidas objects.</returns>
        public static PersonasDesaparecidasList GetListByidGrupoSanguineo(int idGrupoSanguineo)
        {
            PersonasDesaparecidasList tempList = new PersonasDesaparecidasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasSelectListByidGrupoSanguineo", myConnection))
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

        /// <summary>
        /// Returns a list with PersonasDesaparecidas objects.
        /// </summary>
        /// <returns>A generics List with the PersonasDesaparecidas objects.</returns>
        public static PersonasDesaparecidasList GetListByidBusqueda(decimal idBusqueda)
        {
            PersonasDesaparecidasList tempList = new PersonasDesaparecidasList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasSelectListByidBusqueda", myConnection))
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

        ///// <summary>
        ///// Returns a list with PersonasDesaparecidas objects.
        ///// </summary>
        ///// <returns>A generics List with the PersonasDesaparecidas objects.</returns>
        //public static PersonasDesaparecidasList GetListByidUbicacionSeniaParticular(int idUbicacionSeniaParticular)
        //{
        //PersonasDesaparecidasList tempList = new PersonasDesaparecidasList();
        //using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
        //{
        //using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasSelectListByidUbicacionSeniaParticular", myConnection))
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
        /// Saves a PersonasDesaparecidas in the database.
        /// </summary>
        /// <param name="myPersonasDesaparecidas">The PersonasDesaparecidas instance to save.</param>
        /// <returns>The new id if the PersonasDesaparecidas is new in the database or the existing id when an item was updated.</returns>
        public static int Save(PersonasDesaparecidas myPersonasDesaparecidas)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasInsertUpdateSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    if (myPersonasDesaparecidas.Id == -1)
                    {
                        myCommand.Parameters.AddWithValue("@id", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@id", myPersonasDesaparecidas.Id);
                    }
                    if (string.IsNullOrEmpty(myPersonasDesaparecidas.Ipp))
                    {
                        myCommand.Parameters.AddWithValue("@ipp", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@ipp", myPersonasDesaparecidas.Ipp);
                    }
                    if (string.IsNullOrEmpty(myPersonasDesaparecidas.UFI))
                    {
                        myCommand.Parameters.AddWithValue("@uFI", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@uFI", myPersonasDesaparecidas.UFI);
                    }
                    if (myPersonasDesaparecidas.esExtJurisdiccion == null)
                    {
                        myCommand.Parameters.AddWithValue("@esExtJurisdiccion", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@esExtJurisdiccion", myPersonasDesaparecidas.esExtJurisdiccion);
                    }
                    if (myPersonasDesaparecidas.idOrganismoInterviniente == null)
                    {
                        myCommand.Parameters.AddWithValue("@idOrganismoInterviniente", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idOrganismoInterviniente", myPersonasDesaparecidas.idOrganismoInterviniente);
                    }
                    if (myPersonasDesaparecidas.idComisaria == null)
                    {
                        myCommand.Parameters.AddWithValue("@idComisaria", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idComisaria", myPersonasDesaparecidas.idComisaria);
                    }
                    if (myPersonasDesaparecidas.idTipoDNI == null)
                    {
                        myCommand.Parameters.AddWithValue("@idTipoDNI", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idTipoDNI", myPersonasDesaparecidas.idTipoDNI);
                    }
                    if (string.IsNullOrEmpty(myPersonasDesaparecidas.DNI))
                    {
                        myCommand.Parameters.AddWithValue("@DNI", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@DNI", myPersonasDesaparecidas.DNI);
                    }
                    if (string.IsNullOrEmpty(myPersonasDesaparecidas.Apellido))
                    {
                        myCommand.Parameters.AddWithValue("@apellido", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@apellido", myPersonasDesaparecidas.Apellido);
                    }
                    if (string.IsNullOrEmpty(myPersonasDesaparecidas.Nombre))
                    {
                        myCommand.Parameters.AddWithValue("@nombre", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@nombre", myPersonasDesaparecidas.Nombre);
                    }
                    if (myPersonasDesaparecidas.idLugarDesaparicion == null)
                    {
                        myCommand.Parameters.AddWithValue("@idLugarDesaparicion", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idLugarDesaparicion", myPersonasDesaparecidas.idLugarDesaparicion);
                    }
                    if (myPersonasDesaparecidas.FechaDesaparicion == null)
                    {
                        myCommand.Parameters.AddWithValue("@fechaDesaparicion", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@fechaDesaparicion", myPersonasDesaparecidas.FechaDesaparicion);
                    }
                    if (myPersonasDesaparecidas.idSexo == null)
                    {
                        myCommand.Parameters.AddWithValue("@idSexo", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idSexo", myPersonasDesaparecidas.idSexo);
                    }
                    if (myPersonasDesaparecidas.FechaNacimiento == null)
                    {
                        myCommand.Parameters.AddWithValue("@fechaNacimiento", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@fechaNacimiento", myPersonasDesaparecidas.FechaNacimiento);
                    }
                    if (myPersonasDesaparecidas.EdadMomentoDesaparicion == null)
                    {
                        myCommand.Parameters.AddWithValue("@edadMomentoDesaparicion", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@edadMomentoDesaparicion", myPersonasDesaparecidas.EdadMomentoDesaparicion);
                    }
                    if (myPersonasDesaparecidas.Talla == null)
                    {
                        myCommand.Parameters.AddWithValue("@talla", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@talla", myPersonasDesaparecidas.Talla);
                    }
                    if (myPersonasDesaparecidas.Peso == null)
                    {
                        myCommand.Parameters.AddWithValue("@peso", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@peso", myPersonasDesaparecidas.Peso);
                    }
                    if (myPersonasDesaparecidas.idColorPiel == null)
                    {
                        myCommand.Parameters.AddWithValue("@idColorPiel", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idColorPiel", myPersonasDesaparecidas.idColorPiel);
                    }
                    if (myPersonasDesaparecidas.idColorCabello == null)
                    {
                        myCommand.Parameters.AddWithValue("@idColorCabello", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idColorCabello", myPersonasDesaparecidas.idColorCabello);
                    }
                    if (myPersonasDesaparecidas.idColorTenido == null)
                    {
                        myCommand.Parameters.AddWithValue("@idColorTenido", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idColorTenido", myPersonasDesaparecidas.idColorTenido);
                    }
                    if (myPersonasDesaparecidas.idLongitudCabello == null)
                    {
                        myCommand.Parameters.AddWithValue("@idLongitudCabello", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idLongitudCabello", myPersonasDesaparecidas.idLongitudCabello);
                    }
                    if (myPersonasDesaparecidas.idAspectoCabello == null)
                    {
                        myCommand.Parameters.AddWithValue("@idAspectoCabello", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idAspectoCabello", myPersonasDesaparecidas.idAspectoCabello);
                    }
                    if (myPersonasDesaparecidas.idCalvicie == null)
                    {
                        myCommand.Parameters.AddWithValue("@idCalvicie", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idCalvicie", myPersonasDesaparecidas.idCalvicie);
                    }
                    if (myPersonasDesaparecidas.idColorOjos == null)
                    {
                        myCommand.Parameters.AddWithValue("@idColorOjos", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idColorOjos", myPersonasDesaparecidas.idColorOjos);
                    }
                    if (myPersonasDesaparecidas.idRostro == null)
                    {
                        myCommand.Parameters.AddWithValue("@idRostro", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idRostro", myPersonasDesaparecidas.idRostro);
                    }
                    if (myPersonasDesaparecidas.CantidadDiasNoAfeitado == null)
                    {
                        myCommand.Parameters.AddWithValue("@cantidadDiasNoAfeitado", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@cantidadDiasNoAfeitado", myPersonasDesaparecidas.CantidadDiasNoAfeitado);
                    }
                    if (myPersonasDesaparecidas.FaltanPiezasDentales == null)
                    {
                        myCommand.Parameters.AddWithValue("@faltanPiezasDentales", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@faltanPiezasDentales", myPersonasDesaparecidas.FaltanPiezasDentales);
                    }
                    if (myPersonasDesaparecidas.idDentadura == null)
                    {
                        myCommand.Parameters.AddWithValue("@idDentadura", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idDentadura", myPersonasDesaparecidas.idDentadura);
                    }
                    //if (myPersonasDesaparecidas.idSeniaParticular == null){
                    //myCommand.Parameters.AddWithValue("@idSeniaParticular", DBNull.Value);
                    //}
                    //else
                    //{
                    //myCommand.Parameters.AddWithValue("@idSeniaParticular", myPersonasDesaparecidas.idSeniaParticular);
                    //}
                    //if (myPersonasDesaparecidas.idUbicacionSeniaParticular == null){
                    //myCommand.Parameters.AddWithValue("@idUbicacionSeniaParticular", DBNull.Value);
                    //}
                    //else
                    //{
                    //myCommand.Parameters.AddWithValue("@idUbicacionSeniaParticular", myPersonasDesaparecidas.idUbicacionSeniaParticular);
                    //}
                    if (myPersonasDesaparecidas.tieneADN == null)
                    {
                        myCommand.Parameters.AddWithValue("@tieneADN", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@tieneADN", myPersonasDesaparecidas.tieneADN);
                    }
                    if (string.IsNullOrEmpty(myPersonasDesaparecidas.ADN))
                    {
                        myCommand.Parameters.AddWithValue("@aDN", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@aDN", myPersonasDesaparecidas.ADN);
                    }
                    if (myPersonasDesaparecidas.idGrupoSanguineo == null)
                    {
                        myCommand.Parameters.AddWithValue("@idGrupoSanguineo", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idGrupoSanguineo", myPersonasDesaparecidas.idGrupoSanguineo);
                    }
                    if (myPersonasDesaparecidas.Foto == null)
                    {
                        myCommand.Parameters.AddWithValue("@foto", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@foto", myPersonasDesaparecidas.Foto);
                    }
                    if (myPersonasDesaparecidas.FichasDactilares == null)
                    {
                        myCommand.Parameters.AddWithValue("@fichasDactilares", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@fichasDactilares", myPersonasDesaparecidas.FichasDactilares);
                    }
                    if (string.IsNullOrEmpty(myPersonasDesaparecidas.Ropa))
                    {
                        myCommand.Parameters.AddWithValue("@ropa", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@ropa", myPersonasDesaparecidas.Ropa);
                    }
                    if (string.IsNullOrEmpty(myPersonasDesaparecidas.ArticulosPersonales))
                    {
                        myCommand.Parameters.AddWithValue("@articulosPersonales", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@articulosPersonales", myPersonasDesaparecidas.ArticulosPersonales);
                    }
                    if (myPersonasDesaparecidas.ExistenRadiografia == null)
                    {
                        myCommand.Parameters.AddWithValue("@existenRadiografia", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@existenRadiografia", myPersonasDesaparecidas.ExistenRadiografia);
                    }
                    if (myPersonasDesaparecidas.idBusqueda == null)
                    {
                        myCommand.Parameters.AddWithValue("@idBusqueda", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idBusqueda", myPersonasDesaparecidas.idBusqueda);
                    }
                    if (myPersonasDesaparecidas.FechaUltimaModificacion == null)
                    {
                        myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myPersonasDesaparecidas.FechaUltimaModificacion);
                    }

                    myCommand.Parameters.AddWithValue("@fechaAlta", myPersonasDesaparecidas.FechaAlta);

                    myCommand.Parameters.AddWithValue("@usuarioAlta", myPersonasDesaparecidas.UsuarioAlta);

                    if (string.IsNullOrEmpty(myPersonasDesaparecidas.UsuarioUltimaModificacion))
                    {
                        myCommand.Parameters.AddWithValue("@usuarioUltimaModificacion", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@usuarioUltimaModificacion", myPersonasDesaparecidas.UsuarioUltimaModificacion);
                    }
                    if (myPersonasDesaparecidas.Baja == null)
                    {
                        myCommand.Parameters.AddWithValue("@baja", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@baja", myPersonasDesaparecidas.Baja);
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
        /// Saves a PersonasDesaparecidas in the database.
        /// </summary>
        /// <param name="myPersonasDesaparecidas">The PersonasDesaparecidas instance to save.</param>
        /// <returns>The new id if the PersonasDesaparecidas is new in the database or the existing id when an item was updated.</returns>
        public static int Save(PersonasDesaparecidas myPersonasDesaparecidas, SqlCommand myCommand)
        {
            int result = 0;
            //using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            //{
            //    using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasInsertUpdateSingleItem", myConnection))
            //    {
            try
            {
                myCommand.CommandText = "PersonasDesaparecidasInsertUpdateSingleItem";
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Clear();

                if (myPersonasDesaparecidas.Id == -1)
                {
                    myCommand.Parameters.AddWithValue("@id", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@id", myPersonasDesaparecidas.Id);
                }
                if (string.IsNullOrEmpty(myPersonasDesaparecidas.Ipp))
                {
                    myCommand.Parameters.AddWithValue("@ipp", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@ipp", myPersonasDesaparecidas.Ipp);
                }
                if (string.IsNullOrEmpty(myPersonasDesaparecidas.UFI))
                {
                    myCommand.Parameters.AddWithValue("@uFI", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@uFI", myPersonasDesaparecidas.UFI);
                }
                if (myPersonasDesaparecidas.esExtJurisdiccion == null)
                {
                    myCommand.Parameters.AddWithValue("@esExtJurisdiccion", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@esExtJurisdiccion", myPersonasDesaparecidas.esExtJurisdiccion);
                }
                if (myPersonasDesaparecidas.idOrganismoInterviniente == null)
                {
                    myCommand.Parameters.AddWithValue("@idOrganismoInterviniente", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idOrganismoInterviniente", myPersonasDesaparecidas.idOrganismoInterviniente);
                }
                if (myPersonasDesaparecidas.idComisaria == null)
                {
                    myCommand.Parameters.AddWithValue("@idComisaria", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idComisaria", myPersonasDesaparecidas.idComisaria);
                }
                if (myPersonasDesaparecidas.idTipoDNI == null)
                {
                    myCommand.Parameters.AddWithValue("@idTipoDNI", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idTipoDNI", myPersonasDesaparecidas.idTipoDNI);
                }
                if (string.IsNullOrEmpty(myPersonasDesaparecidas.DNI))
                {
                    myCommand.Parameters.AddWithValue("@DNI", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@DNI", myPersonasDesaparecidas.DNI);
                }
                if (string.IsNullOrEmpty(myPersonasDesaparecidas.Apellido))
                {
                    myCommand.Parameters.AddWithValue("@apellido", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@apellido", myPersonasDesaparecidas.Apellido);
                }
                if (string.IsNullOrEmpty(myPersonasDesaparecidas.Nombre))
                {
                    myCommand.Parameters.AddWithValue("@nombre", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@nombre", myPersonasDesaparecidas.Nombre);
                }
                if (myPersonasDesaparecidas.idLugarDesaparicion == null)
                {
                    myCommand.Parameters.AddWithValue("@idLugarDesaparicion", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idLugarDesaparicion", myPersonasDesaparecidas.idLugarDesaparicion);
                }
                if (myPersonasDesaparecidas.FechaDesaparicion == null)
                {
                    myCommand.Parameters.AddWithValue("@fechaDesaparicion", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@fechaDesaparicion", myPersonasDesaparecidas.FechaDesaparicion);
                }
                if (myPersonasDesaparecidas.idSexo == null)
                {
                    myCommand.Parameters.AddWithValue("@idSexo", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idSexo", myPersonasDesaparecidas.idSexo);
                }
                if (myPersonasDesaparecidas.FechaNacimiento == null)
                {
                    myCommand.Parameters.AddWithValue("@fechaNacimiento", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@fechaNacimiento", myPersonasDesaparecidas.FechaNacimiento);
                }
                if (myPersonasDesaparecidas.EdadMomentoDesaparicion == null)
                {
                    myCommand.Parameters.AddWithValue("@edadMomentoDesaparicion", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@edadMomentoDesaparicion", myPersonasDesaparecidas.EdadMomentoDesaparicion);
                }
                if (myPersonasDesaparecidas.Talla == null)
                {
                    myCommand.Parameters.AddWithValue("@talla", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@talla", myPersonasDesaparecidas.Talla);
                }
                if (myPersonasDesaparecidas.Peso == null)
                {
                    myCommand.Parameters.AddWithValue("@peso", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@peso", myPersonasDesaparecidas.Peso);
                }
                if (myPersonasDesaparecidas.idColorPiel == null)
                {
                    myCommand.Parameters.AddWithValue("@idColorPiel", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idColorPiel", myPersonasDesaparecidas.idColorPiel);
                }
                if (myPersonasDesaparecidas.idColorCabello == null)
                {
                    myCommand.Parameters.AddWithValue("@idColorCabello", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idColorCabello", myPersonasDesaparecidas.idColorCabello);
                }
                if (myPersonasDesaparecidas.idColorTenido == null)
                {
                    myCommand.Parameters.AddWithValue("@idColorTenido", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idColorTenido", myPersonasDesaparecidas.idColorTenido);
                }
                if (myPersonasDesaparecidas.idLongitudCabello == null)
                {
                    myCommand.Parameters.AddWithValue("@idLongitudCabello", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idLongitudCabello", myPersonasDesaparecidas.idLongitudCabello);
                }
                if (myPersonasDesaparecidas.idAspectoCabello == null)
                {
                    myCommand.Parameters.AddWithValue("@idAspectoCabello", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idAspectoCabello", myPersonasDesaparecidas.idAspectoCabello);
                }
                if (myPersonasDesaparecidas.idCalvicie == null)
                {
                    myCommand.Parameters.AddWithValue("@idCalvicie", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idCalvicie", myPersonasDesaparecidas.idCalvicie);
                }
                if (myPersonasDesaparecidas.idColorOjos == null)
                {
                    myCommand.Parameters.AddWithValue("@idColorOjos", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idColorOjos", myPersonasDesaparecidas.idColorOjos);
                }
                if (myPersonasDesaparecidas.idRostro == null)
                {
                    myCommand.Parameters.AddWithValue("@idRostro", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idRostro", myPersonasDesaparecidas.idRostro);
                }
                if (myPersonasDesaparecidas.CantidadDiasNoAfeitado == null)
                {
                    myCommand.Parameters.AddWithValue("@cantidadDiasNoAfeitado", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@cantidadDiasNoAfeitado", myPersonasDesaparecidas.CantidadDiasNoAfeitado);
                }
                if (myPersonasDesaparecidas.FaltanPiezasDentales == null)
                {
                    myCommand.Parameters.AddWithValue("@faltanPiezasDentales", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@faltanPiezasDentales", myPersonasDesaparecidas.FaltanPiezasDentales);
                }
                if (myPersonasDesaparecidas.idDentadura == null)
                {
                    myCommand.Parameters.AddWithValue("@idDentadura", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idDentadura", myPersonasDesaparecidas.idDentadura);
                }
                //if (myPersonasDesaparecidas.idSeniaParticular == null){
                //myCommand.Parameters.AddWithValue("@idSeniaParticular", DBNull.Value);
                //}
                //else
                //{
                //myCommand.Parameters.AddWithValue("@idSeniaParticular", myPersonasDesaparecidas.idSeniaParticular);
                //}
                //if (myPersonasDesaparecidas.idUbicacionSeniaParticular == null){
                //myCommand.Parameters.AddWithValue("@idUbicacionSeniaParticular", DBNull.Value);
                //}
                //else
                //{
                //myCommand.Parameters.AddWithValue("@idUbicacionSeniaParticular", myPersonasDesaparecidas.idUbicacionSeniaParticular);
                //}
                if (myPersonasDesaparecidas.tieneADN == null)
                {
                    myCommand.Parameters.AddWithValue("@tieneADN", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@tieneADN", myPersonasDesaparecidas.tieneADN);
                }
                if (string.IsNullOrEmpty(myPersonasDesaparecidas.ADN))
                {
                    myCommand.Parameters.AddWithValue("@aDN", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@aDN", myPersonasDesaparecidas.ADN);
                }
                if (myPersonasDesaparecidas.idGrupoSanguineo == null)
                {
                    myCommand.Parameters.AddWithValue("@idGrupoSanguineo", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idGrupoSanguineo", myPersonasDesaparecidas.idGrupoSanguineo);
                }
                if (myPersonasDesaparecidas.Foto == null)
                {
                    myCommand.Parameters.AddWithValue("@foto", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@foto", myPersonasDesaparecidas.Foto);
                }
                if (myPersonasDesaparecidas.FichasDactilares == null)
                {
                    myCommand.Parameters.AddWithValue("@fichasDactilares", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@fichasDactilares", myPersonasDesaparecidas.FichasDactilares);
                }
                if (string.IsNullOrEmpty(myPersonasDesaparecidas.Ropa))
                {
                    myCommand.Parameters.AddWithValue("@ropa", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@ropa", myPersonasDesaparecidas.Ropa);
                }
                if (string.IsNullOrEmpty(myPersonasDesaparecidas.ArticulosPersonales))
                {
                    myCommand.Parameters.AddWithValue("@articulosPersonales", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@articulosPersonales", myPersonasDesaparecidas.ArticulosPersonales);
                }
                if (myPersonasDesaparecidas.ExistenRadiografia == null)
                {
                    myCommand.Parameters.AddWithValue("@existenRadiografia", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@existenRadiografia", myPersonasDesaparecidas.ExistenRadiografia);
                }
                if (myPersonasDesaparecidas.idBusqueda == null)
                {
                    myCommand.Parameters.AddWithValue("@idBusqueda", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idBusqueda", myPersonasDesaparecidas.idBusqueda);
                }
                if (myPersonasDesaparecidas.FechaUltimaModificacion == null)
                {
                    myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myPersonasDesaparecidas.FechaUltimaModificacion);
                }

              
                if (string.IsNullOrEmpty(myPersonasDesaparecidas.UsuarioUltimaModificacion))
                {
                    myCommand.Parameters.AddWithValue("@usuarioUltimaModificacion", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@usuarioUltimaModificacion", myPersonasDesaparecidas.UsuarioUltimaModificacion);
                }

                myCommand.Parameters.AddWithValue("@FechaAlta", myPersonasDesaparecidas.FechaAlta);

                myCommand.Parameters.AddWithValue("@UsuarioAlta", myPersonasDesaparecidas.UsuarioAlta);

                if (myPersonasDesaparecidas.Baja == null)
                {
                    myCommand.Parameters.AddWithValue("@baja", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@baja", myPersonasDesaparecidas.Baja);
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
                //}  }
            }
            catch (Exception e)
            {
                //tr.Rollback();
                throw e;
            }
            return result;
        }




        /// <summary>
        /// Deletes a PersonasDesaparecidas from the database.
        /// </summary>
        /// <param name="id">The id of the PersonasDesaparecidas to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        public static bool Delete(int id)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("PersonasDesaparecidasDeleteSingleItem", myConnection))
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
        /// Initializes a new instance of the PersonasDesaparecidas class and fills it with the data fom the IDataRecord.
        /// </summary>
        private static PersonasDesaparecidas FillDataRecord(IDataRecord myDataRecord, bool traeCoincidencias)
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
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("esExtJurisdiccion")))
            {
                myPersonasDesaparecidas.esExtJurisdiccion = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("esExtJurisdiccion"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idOrganismoInterviniente")))
            {
                myPersonasDesaparecidas.idOrganismoInterviniente = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idOrganismoInterviniente"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idComisaria")))
            {
                myPersonasDesaparecidas.idComisaria = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idComisaria"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idTipoDNI")))
            {
                myPersonasDesaparecidas.idTipoDNI = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idTipoDNI"));
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
            /*if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idSeniaParticular")))
            {
            myPersonasDesaparecidas.idSeniaParticular = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idSeniaParticular"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idUbicacionSeniaParticular")))
            {
            myPersonasDesaparecidas.idUbicacionSeniaParticular = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idUbicacionSeniaParticular"));
            }*/


            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("MotivoDeBaja")))
            {
                myPersonasDesaparecidas.MotivoDeBaja = myDataRecord.GetInt32(myDataRecord.GetOrdinal("MotivoDeBaja"));
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
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaAlta")))
            {
                myPersonasDesaparecidas.FechaAlta = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaAlta"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("UsuarioUltimaModificacion")))
            {
                myPersonasDesaparecidas.UsuarioUltimaModificacion = myDataRecord.GetString(myDataRecord.GetOrdinal("UsuarioUltimaModificacion"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("UsuarioAlta")))
            {
                myPersonasDesaparecidas.UsuarioAlta = myDataRecord.GetString(myDataRecord.GetOrdinal("UsuarioAlta"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Baja")))
            {
                myPersonasDesaparecidas.Baja = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("Baja"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusqueda")))
            {
                myPersonasDesaparecidas.idBusqueda = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusqueda"));
            }
            if (traeCoincidencias)
            {
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaEdad")))
                {
                    myPersonasDesaparecidas.CoincidenciaEdad = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaEdad"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaFecha")))
                {
                    myPersonasDesaparecidas.CoincidenciaFecha = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaFecha"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaTalla")))
                {
                    myPersonasDesaparecidas.CoincidenciaTalla = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaTalla"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaPeso")))
                {
                    myPersonasDesaparecidas.CoincidenciaPeso = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaPeso"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaSexo")))
                {
                    myPersonasDesaparecidas.CoincidenciaSexo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaSexo"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaColorPiel")))
                {
                    myPersonasDesaparecidas.CoincidenciaColorPiel = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaColorPiel"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaColorCabello")))
                {
                    myPersonasDesaparecidas.CoincidenciaColorCabello = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaColorCabello"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaColorTenido")))
                {
                    myPersonasDesaparecidas.CoincidenciaColorTenido = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaColorTenido"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaLongCabello")))
                {
                    myPersonasDesaparecidas.CoincidenciaLongitudCabello = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaLongCabello"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaAspectoCabello")))
                {
                    myPersonasDesaparecidas.CoincidenciaAspectoCabello = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaAspectoCabello"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaCalvicie")))
                {
                    myPersonasDesaparecidas.CoincidenciaCalvicie = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaCalvicie"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaColorOjos")))
                {
                    myPersonasDesaparecidas.CoincidenciaColorOjos = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaColorOjos"));
                }
                //if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaFaltanDientes")))
                //{
                //    myPersonasDesaparecidas.CoincidenciaFaltanDientes = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaFaltanDientes"));
                //}
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaSeniasParticulares")))
                {
                    myPersonasDesaparecidas.CoincidenciaSeniasParticulares = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaSeniasParticulares"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaTatuajes")))
                {
                    myPersonasDesaparecidas.CoincidenciaTatuajes = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaTatuajes"));
                }
                /*if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaSeniaPart")))
                {
                    myPersonasDesaparecidas.CoincidenciaSeniasParticulares = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaSeniaPart"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaUbicacionSeniaPart")))
                {
                    myPersonasDesaparecidas.CoincidenciaUbicacionSeniasParticulares = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaUbicacionSeniaPart"));
                }*/
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaAdn")))
                {
                    myPersonasDesaparecidas.CoincidenciaAdn = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaAdn"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaNombreyApellido")))
                {
                    myPersonasDesaparecidas.CoincidenciaNombreyApellido = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaNombreyApellido"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CoincidenciaDNI")))
                {
                    myPersonasDesaparecidas.CoincidenciaDNI = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CoincidenciaDNI"));
                }
                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CantidadCoincidencias")))
                {
                    myPersonasDesaparecidas.CoincidenciaCantidad = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CantidadCoincidencias"));
                }
            }
            return myPersonasDesaparecidas;
        }
    }

} 
