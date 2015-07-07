using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.PersonasBuscadas.BusinessEntities;


namespace MPBA.PersonasBuscadas.Dal
{
    /// <summary>
    /// The BusquedaDB class is responsible for interacting with the database to retrieve and store information
    /// about Busqueda objects.
    /// </summary>
    public partial class BusquedaDB
    {
        #region "Public Methods"

        /// <summary>
        /// Gets an instance of Busqueda from the underlying datasource.
        /// </summary>
        /// <param name="id">The unique Id of the Busqueda in the database.</param>
        /// <returns>An Busqueda when the Id was found in the database, or null otherwise.</returns>
        public static Busqueda GetItem(decimal id)
        {
            Busqueda myBusqueda = null;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("BusquedaSelectSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@id", id);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            myBusqueda = FillDataRecord(myReader);
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
                return myBusqueda;
            }
        }

        /// <summary>
        /// Returns a list with Busqueda objects.
        /// </summary>
        /// <returns>A generics List with the Busqueda objects.</returns>
        public static BusquedaList GetList()
        {
            BusquedaList tempList = new BusquedaList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("BusquedaSelectList", myConnection))
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
        /// Returns a list with Busqueda objects.
        /// </summary>
        /// <returns>A generics List with the Busqueda objects.</returns>
        public static BusquedaList GetListActivas()
        {
            BusquedaList tempList = new BusquedaList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("BusquedaSelectListActiva", myConnection))
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
        /// Returns a list with Busqueda objects.
        /// </summary>
        /// <returns>A generics List with the Busqueda objects.</returns>
        public static BusquedaList GetListByidComisariaIntervinoAparcicion(int idComisariaIntervinoAparcicion)
        {
            BusquedaList tempList = new BusquedaList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("BusquedaSelectListByidComisariaIntervinoAparcicion", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idComisariaIntervinoAparcicion", idComisariaIntervinoAparcicion);
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
        /// Returns a list with Busqueda objects.
        /// </summary>
        /// <returns>A generics List with the Busqueda objects.</returns>
        public static BusquedaList GetListByFaltanPiezasDentales(int FaltanPiezasDentales)
        {
            BusquedaList tempList = new BusquedaList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("BusquedaSelectListByFaltanPiezasDentales", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@faltanPiezasDentales", FaltanPiezasDentales);
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
        /// Returns a list with Busqueda objects.
        /// </summary>
        /// <returns>A generics List with the Busqueda objects.</returns>
        public static BusquedaList GetListByidMotivoHallazgo(int idMotivoHallazgo)
        {
            BusquedaList tempList = new BusquedaList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("BusquedaSelectListByidMotivoHallazgo", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idMotivoHallazgo", idMotivoHallazgo);
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
        /// Returns a list with Busqueda objects.
        /// </summary>
        /// <returns>A generics List with the Busqueda objects.</returns>
        public static BusquedaList GetListByidsexo(int idsexo)
        {
            BusquedaList tempList = new BusquedaList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("BusquedaSelectListByidsexo", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idsexo", idsexo);
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
        /// Returns a list with Busqueda objects.
        /// </summary>
        /// <returns>A generics List with the Busqueda objects.</returns>
        public static BusquedaList GetListByidOrigen(int idOrigen)
        {
            BusquedaList tempList = new BusquedaList();
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("BusquedaSelectListByidOrigen", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idOrigen", idOrigen);
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
        /// Saves a Busqueda in the database.
        /// </summary>
        /// <param name="myBusqueda">The Busqueda instance to save.</param>
        /// <returns>The new Id if the Busqueda is new in the database or the existing Id when an item was updated.</returns>
        public static int Save(Busqueda myBusqueda)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("BusquedaInsertUpdateSingleItem", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    if (myBusqueda.Id == -1)
                    {
                        myCommand.Parameters.AddWithValue("@id", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@id", myBusqueda.Id);
                    }
                    if (string.IsNullOrEmpty(myBusqueda.UFI))
                    {
                        myCommand.Parameters.AddWithValue("@uFI", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@uFI", myBusqueda.UFI);
                    }
                    if (myBusqueda.idOrigen == null)
                    {
                        myCommand.Parameters.AddWithValue("@idOrigen", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idOrigen", myBusqueda.idOrigen);
                    }
                    if (string.IsNullOrEmpty(myBusqueda.Usuario))
                    {
                        myCommand.Parameters.AddWithValue("@usuario", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@usuario", myBusqueda.Usuario);
                    }
                    if (string.IsNullOrEmpty(myBusqueda.TablaDestino))
                    {
                        myCommand.Parameters.AddWithValue("@tablaDestino", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@tablaDestino", myBusqueda.TablaDestino);
                    }
                    if (string.IsNullOrEmpty(myBusqueda.DNI))
                    {
                        myCommand.Parameters.AddWithValue("@dNI", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@dNI", myBusqueda.DNI);
                    }
                    if (string.IsNullOrEmpty(myBusqueda.Apellido))
                    {
                        myCommand.Parameters.AddWithValue("@apellido" , DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@apellido", '%' + myBusqueda.Apellido + '%');
                    }
                    if (string.IsNullOrEmpty(myBusqueda.Nombre))
                    {
                        myCommand.Parameters.AddWithValue("@nombre", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@nombre", myBusqueda.Nombre);
                    }
                    if (myBusqueda.FechaDesde == null)
                    {
                        myCommand.Parameters.AddWithValue("@fechaDesde", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@fechaDesde", myBusqueda.FechaDesde);
                    }
                    if (myBusqueda.FechaHasta == null)
                    {
                        myCommand.Parameters.AddWithValue("@fechaHasta", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@fechaHasta", myBusqueda.FechaHasta);
                    }
                    if (myBusqueda.EdadDesde == null)
                    {
                        myCommand.Parameters.AddWithValue("@edadDesde", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@edadDesde", myBusqueda.EdadDesde);
                    }
                    if (myBusqueda.EdadHasta == null)
                    {
                        myCommand.Parameters.AddWithValue("@edadHasta", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@edadHasta", myBusqueda.EdadHasta);
                    }
                    if (myBusqueda.idsexo == null)
                    {
                        myCommand.Parameters.AddWithValue("@idsexo", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idsexo", myBusqueda.idsexo);
                    }
                    if (myBusqueda.tieneADN == null)
                    {
                        myCommand.Parameters.AddWithValue("@tieneADN", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@tieneADN", myBusqueda.tieneADN);
                    }
                    if (myBusqueda.TallaDesde == null)
                    {
                        myCommand.Parameters.AddWithValue("@tallaDesde", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@tallaDesde", myBusqueda.TallaDesde);
                    }
                    if (myBusqueda.TallaHasta == null)
                    {
                        myCommand.Parameters.AddWithValue("@tallaHasta", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@tallaHasta", myBusqueda.TallaHasta);
                    }
                    if (myBusqueda.PesoDesde == null)
                    {
                        myCommand.Parameters.AddWithValue("@pesoDesde", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@pesoDesde", myBusqueda.PesoDesde);
                    }
                    if (myBusqueda.PesoHasta == null)
                    {
                        myCommand.Parameters.AddWithValue("@pesoHasta", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@pesoHasta", myBusqueda.PesoHasta);
                    }
                    if (myBusqueda.FaltanPiezasDentales == null)
                    {
                        myCommand.Parameters.AddWithValue("@faltanPiezasDentales", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@faltanPiezasDentales", myBusqueda.FaltanPiezasDentales);
                    }
                    if (string.IsNullOrEmpty(myBusqueda.CodigoADN))
                    {
                        myCommand.Parameters.AddWithValue("@codigoADN", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@codigoADN", myBusqueda.CodigoADN);
                    }
                    if (myBusqueda.CantidadCoincidencias == null)
                    {
                        myCommand.Parameters.AddWithValue("@cantidadCoincidencias", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@cantidadCoincidencias", myBusqueda.CantidadCoincidencias);
                    }
                    if (myBusqueda.FechaUltimaCoincidencia == null)
                    {
                        myCommand.Parameters.AddWithValue("@fechaUltimaCoincidencia", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@fechaUltimaCoincidencia", myBusqueda.FechaUltimaCoincidencia);
                    }
                    if (myBusqueda.idComisariaIntervinoAparcicion == null)
                    {
                        myCommand.Parameters.AddWithValue("@idComisariaIntervinoAparcicion", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idComisariaIntervinoAparcicion", myBusqueda.idComisariaIntervinoAparcicion);
                    }
                    if (myBusqueda.fechaActuaciones == null)
                    {
                        myCommand.Parameters.AddWithValue("@fechaActuaciones", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@fechaActuaciones", myBusqueda.fechaActuaciones);
                    }
                    if (myBusqueda.idMotivoHallazgo == null)
                    {
                        myCommand.Parameters.AddWithValue("@idMotivoHallazgo", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@idMotivoHallazgo", myBusqueda.idMotivoHallazgo);
                    }
                    if (string.IsNullOrEmpty(myBusqueda.MotivoHallazgoDescripcion))
                    {
                        myCommand.Parameters.AddWithValue("@motivoHallazgoDescripcion", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@motivoHallazgoDescripcion", myBusqueda.MotivoHallazgoDescripcion);
                    }
                    if (myBusqueda.FechaUltimaModificacion == null)
                    {
                        myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myBusqueda.FechaUltimaModificacion);
                    }
                    if (string.IsNullOrEmpty(myBusqueda.UsuarioUltimaModificacion))
                    {
                        myCommand.Parameters.AddWithValue("@usuarioUltimaModificacion", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@usuarioUltimaModificacion", myBusqueda.UsuarioUltimaModificacion);
                    }
                    if (myBusqueda.Baja == null)
                    {
                        myCommand.Parameters.AddWithValue("@baja", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@baja", myBusqueda.Baja);
                    }
                    if (string.IsNullOrEmpty(myBusqueda.IPP))
                    {
                        myCommand.Parameters.AddWithValue("@iPP", DBNull.Value);
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@iPP", myBusqueda.IPP);
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
        /// Saves a Busqueda in the database.
        /// </summary>
        /// <param name="myBusqueda">The Busqueda instance to save.</param>
        /// <returns>The new Id if the Busqueda is new in the database or the existing Id when an item was updated.</returns>
        public static int Save(Busqueda myBusqueda, SqlCommand myCommand)
        {
            int result = 0;
            try
            {
                myCommand.CommandText = "BusquedaInsertUpdateSingleItem";
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Clear();

                if (myBusqueda.Id == -1)
                {
                    myCommand.Parameters.AddWithValue("@id", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@id", myBusqueda.Id);
                }
                if (string.IsNullOrEmpty(myBusqueda.UFI))
                {
                    myCommand.Parameters.AddWithValue("@uFI", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@uFI", myBusqueda.UFI);
                }
                if (myBusqueda.idOrigen == null)
                {
                    myCommand.Parameters.AddWithValue("@idOrigen", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idOrigen", myBusqueda.idOrigen);
                }
                if (string.IsNullOrEmpty(myBusqueda.Usuario))
                {
                    myCommand.Parameters.AddWithValue("@usuario", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@usuario", myBusqueda.Usuario);
                }
                if (string.IsNullOrEmpty(myBusqueda.TablaDestino))
                {
                    myCommand.Parameters.AddWithValue("@tablaDestino", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@tablaDestino", myBusqueda.TablaDestino);
                }
                if (string.IsNullOrEmpty(myBusqueda.DNI))
                {
                    myCommand.Parameters.AddWithValue("@dNI", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@dNI", myBusqueda.DNI);
                }
                if (string.IsNullOrEmpty(myBusqueda.Apellido))
                {
                    myCommand.Parameters.AddWithValue("@apellido", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@apellido", myBusqueda.Apellido);
                }
                if (string.IsNullOrEmpty(myBusqueda.Nombre))
                {
                    myCommand.Parameters.AddWithValue("@nombre", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@nombre", myBusqueda.Nombre);
                }
                if (myBusqueda.FechaDesde == null)
                {
                    myCommand.Parameters.AddWithValue("@fechaDesde", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@fechaDesde", myBusqueda.FechaDesde);
                }
                if (myBusqueda.FechaHasta == null)
                {
                    myCommand.Parameters.AddWithValue("@fechaHasta", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@fechaHasta", myBusqueda.FechaHasta);
                }
                if (myBusqueda.EdadDesde == null)
                {
                    myCommand.Parameters.AddWithValue("@edadDesde", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@edadDesde", myBusqueda.EdadDesde);
                }
                if (myBusqueda.tieneADN == null)
                {
                    myCommand.Parameters.AddWithValue("@tieneADN", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@tieneADN", myBusqueda.tieneADN);
                }
                if (myBusqueda.EdadHasta == null)
                {
                    myCommand.Parameters.AddWithValue("@edadHasta", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@edadHasta", myBusqueda.EdadHasta);
                }
                if (myBusqueda.idsexo == null)
                {
                    myCommand.Parameters.AddWithValue("@idsexo", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idsexo", myBusqueda.idsexo);
                }
                if (myBusqueda.TallaDesde == null)
                {
                    myCommand.Parameters.AddWithValue("@tallaDesde", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@tallaDesde", myBusqueda.TallaDesde);
                }
                if (myBusqueda.TallaHasta == null)
                {
                    myCommand.Parameters.AddWithValue("@tallaHasta", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@tallaHasta", myBusqueda.TallaHasta);
                }
                if (myBusqueda.PesoDesde == null)
                {
                    myCommand.Parameters.AddWithValue("@pesoDesde", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@pesoDesde", myBusqueda.PesoDesde);
                }
                if (myBusqueda.PesoHasta == null)
                {
                    myCommand.Parameters.AddWithValue("@pesoHasta", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@pesoHasta", myBusqueda.PesoHasta);
                }
                if (myBusqueda.FaltanPiezasDentales == null)
                {
                    myCommand.Parameters.AddWithValue("@faltanPiezasDentales", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@faltanPiezasDentales", myBusqueda.FaltanPiezasDentales);
                }
                if (string.IsNullOrEmpty(myBusqueda.CodigoADN))
                {
                    myCommand.Parameters.AddWithValue("@codigoADN", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@codigoADN", myBusqueda.CodigoADN);
                }
                if (myBusqueda.CantidadCoincidencias == null)
                {
                    myCommand.Parameters.AddWithValue("@cantidadCoincidencias", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@cantidadCoincidencias", myBusqueda.CantidadCoincidencias);
                }
                if (myBusqueda.FechaUltimaCoincidencia == null)
                {
                    myCommand.Parameters.AddWithValue("@fechaUltimaCoincidencia", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@fechaUltimaCoincidencia", myBusqueda.FechaUltimaCoincidencia);
                }
                if (myBusqueda.idComisariaIntervinoAparcicion == null)
                {
                    myCommand.Parameters.AddWithValue("@idComisariaIntervinoAparcicion", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idComisariaIntervinoAparcicion", myBusqueda.idComisariaIntervinoAparcicion);
                }
                if (myBusqueda.fechaActuaciones == null)
                {
                    myCommand.Parameters.AddWithValue("@fechaActuaciones", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@fechaActuaciones", myBusqueda.fechaActuaciones);
                }
                if (myBusqueda.idMotivoHallazgo == null)
                {
                    myCommand.Parameters.AddWithValue("@idMotivoHallazgo", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@idMotivoHallazgo", myBusqueda.idMotivoHallazgo);
                }
                if (string.IsNullOrEmpty(myBusqueda.MotivoHallazgoDescripcion))
                {
                    myCommand.Parameters.AddWithValue("@motivoHallazgoDescripcion", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@motivoHallazgoDescripcion", myBusqueda.MotivoHallazgoDescripcion);
                }
                if (myBusqueda.FechaUltimaModificacion == null)
                {
                    myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myBusqueda.FechaUltimaModificacion);
                }
               
                if (string.IsNullOrEmpty(myBusqueda.UsuarioUltimaModificacion))
                {
                    myCommand.Parameters.AddWithValue("@usuarioUltimaModificacion", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@usuarioUltimaModificacion", myBusqueda.UsuarioUltimaModificacion);
                }
              
                if (myBusqueda.Baja == null)
                {
                    myCommand.Parameters.AddWithValue("@baja", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@baja", myBusqueda.Baja);
                }
                if (string.IsNullOrEmpty(myBusqueda.IPP))
                {
                    myCommand.Parameters.AddWithValue("@iPP", DBNull.Value);
                }
                else
                {
                    myCommand.Parameters.AddWithValue("@iPP", myBusqueda.IPP);
                }
               
                DbParameter returnValue;
                returnValue = myCommand.CreateParameter();
                returnValue.Direction = ParameterDirection.ReturnValue;
                myCommand.Parameters.Add(returnValue);

                //myConnection.Open();
                myCommand.ExecuteNonQuery();
                result = Convert.ToInt32(returnValue.Value);
                //myConnection.Close();
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
        /// Deletes a Busqueda from the database.
        /// </summary>
        /// <param name="id">The Id of the Busqueda to delete.</param>
        /// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
        public static bool Delete(decimal id)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("BusquedaDeleteSingleItem", myConnection))
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
        /// Initializes a new instance of the Busqueda class and fills it with the data fom the IDataRecord.
        /// </summary>
        private static Busqueda FillDataRecord(IDataRecord myDataRecord)
        {
            Busqueda myBusqueda = new Busqueda();
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Id")))
            {
                myBusqueda.Id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Id"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("UFI")))
            {
                myBusqueda.UFI = myDataRecord.GetString(myDataRecord.GetOrdinal("UFI"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idOrigen")))
            {
                myBusqueda.idOrigen = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idOrigen"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("tieneADN")))
            {
                myBusqueda.tieneADN = myDataRecord.GetInt32(myDataRecord.GetOrdinal("tieneADN"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Usuario")))
            {
                myBusqueda.Usuario = myDataRecord.GetString(myDataRecord.GetOrdinal("Usuario"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("TablaDestino")))
            {
                myBusqueda.TablaDestino = myDataRecord.GetString(myDataRecord.GetOrdinal("TablaDestino"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DNI")))
            {
                myBusqueda.DNI = myDataRecord.GetString(myDataRecord.GetOrdinal("DNI"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Apellido")))
            {
                myBusqueda.Apellido = myDataRecord.GetString(myDataRecord.GetOrdinal("Apellido"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Nombre")))
            {
                myBusqueda.Nombre = myDataRecord.GetString(myDataRecord.GetOrdinal("Nombre"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaDesde")))
            {
                myBusqueda.FechaDesde = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaDesde"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaHasta")))
            {
                myBusqueda.FechaHasta = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaHasta"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("EdadDesde")))
            {
                myBusqueda.EdadDesde = myDataRecord.GetInt32(myDataRecord.GetOrdinal("EdadDesde"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("EdadHasta")))
            {
                myBusqueda.EdadHasta = myDataRecord.GetInt32(myDataRecord.GetOrdinal("EdadHasta"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idsexo")))
            {
                myBusqueda.idsexo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idsexo"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("TallaDesde")))
            {
                myBusqueda.TallaDesde = myDataRecord.GetFloat(myDataRecord.GetOrdinal("TallaDesde"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("TallaHasta")))
            {
                myBusqueda.TallaHasta = myDataRecord.GetFloat(myDataRecord.GetOrdinal("TallaHasta"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("PesoDesde")))
            {
                myBusqueda.PesoDesde = myDataRecord.GetFloat(myDataRecord.GetOrdinal("PesoDesde"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("PesoHasta")))
            {
                myBusqueda.PesoHasta = myDataRecord.GetFloat(myDataRecord.GetOrdinal("PesoHasta"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FaltanPiezasDentales")))
            {
                myBusqueda.FaltanPiezasDentales = myDataRecord.GetInt32(myDataRecord.GetOrdinal("FaltanPiezasDentales"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CodigoADN")))
            {
                myBusqueda.CodigoADN = myDataRecord.GetString(myDataRecord.GetOrdinal("CodigoADN"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CantidadCoincidencias")))
            {
                myBusqueda.CantidadCoincidencias = myDataRecord.GetInt32(myDataRecord.GetOrdinal("CantidadCoincidencias"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaUltimaCoincidencia")))
            {
                myBusqueda.FechaUltimaCoincidencia = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaUltimaCoincidencia"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idComisariaIntervinoAparcicion")))
            {
                myBusqueda.idComisariaIntervinoAparcicion = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idComisariaIntervinoAparcicion"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("fechaActuaciones")))
            {
                myBusqueda.fechaActuaciones = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("fechaActuaciones"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idMotivoHallazgo")))
            {
                myBusqueda.idMotivoHallazgo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idMotivoHallazgo"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("MotivoHallazgoDescripcion")))
            {
                myBusqueda.MotivoHallazgoDescripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("MotivoHallazgoDescripcion"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaUltimaModificacion")))
            {
                myBusqueda.FechaUltimaModificacion = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaUltimaModificacion"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("UsuarioUltimaModificacion")))
            {
                myBusqueda.UsuarioUltimaModificacion = myDataRecord.GetString(myDataRecord.GetOrdinal("UsuarioUltimaModificacion"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Baja")))
            {
                myBusqueda.Baja = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("Baja"));
            }
            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IPP")))
            {
                myBusqueda.IPP = myDataRecord.GetString(myDataRecord.GetOrdinal("IPP"));
            }
            
            return myBusqueda;
        }
    }

} 
