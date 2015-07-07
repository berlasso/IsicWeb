using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The VehiculosDB class is responsible for interacting with the database to retrieve and store information
/// about Vehiculos objects.
/// </summary>
public partial class VehiculosDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of Vehiculos from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the Vehiculos in the database.</param>
/// <returns>An Vehiculos when the id was found in the database, or null otherwise.</returns>
public static Vehiculos GetItem(int id)
{
Vehiculos myVehiculos = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("VehiculosSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myVehiculos = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myVehiculos;
}
}

/// <summary>
/// Gets an instance of Vehiculos from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the Vehiculos in the database.</param>
/// <returns>An Vehiculos when the id was found in the database, or null otherwise.</returns>
public static Vehiculos GetItemByBienSustraido(int idBienSustraido)
{
    Vehiculos myVehiculos = null;
    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    {
        using (SqlCommand myCommand = new SqlCommand("VehiculosSelectSingleItemByBienSustraido", myConnection))
        {
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.Parameters.AddWithValue("@idBienSustraido", idBienSustraido);

            myConnection.Open();
            using (SqlDataReader myReader = myCommand.ExecuteReader())
            {
                if (myReader.Read())
                {
                    myVehiculos = FillDataRecord(myReader);
                }
                myReader.Close();
            }
            myConnection.Close();
        }
        return myVehiculos;
    }
}


/// <summary>
/// Returns a list with Vehiculos objects.
/// </summary>
/// <returns>A generics List with the Vehiculos objects.</returns>
public static VehiculosList GetList()
{
VehiculosList tempList = new VehiculosList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("VehiculosSelectList", myConnection))
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
/// Returns a list with Vehiculos objects.
/// </summary>
/// <returns>A generics List with the Vehiculos objects.</returns>
public static VehiculosList GetListByidBienSustraido(int idBienSustraido)
{
VehiculosList tempList = new VehiculosList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("VehiculosSelectListByidBienSustraido", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idBienSustraido", idBienSustraido);
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
/// Returns a list with Vehiculos objects.
/// </summary>
/// <returns>A generics List with the Vehiculos objects.</returns>
public static VehiculosList GetListByidColorVehiculo(int idColorVehiculo)
{
VehiculosList tempList = new VehiculosList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("VehiculosSelectListByidColorVehiculo", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idColorVehiculo", idColorVehiculo);
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
/// Returns a list with Vehiculos objects.
/// </summary>
/// <returns>A generics List with the Vehiculos objects.</returns>
public static VehiculosList GetListByidDelito(int idDelito)
{
VehiculosList tempList = new VehiculosList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("VehiculosSelectListByidDelito", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idDelito", idDelito);
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

///// <summary>
///// Returns a list with Vehiculos objects.
///// </summary>
///// <param name="vinculo">el tipo de vinculo del vehiculo</param>
///// <returns>A generics List with the Vehiculos objects.</returns>
//public static VehiculosList GetListByVinculoANDidDelito(VinculoVehiculo vinculo, int idDelito)
//{
//    VehiculosList tempList = new VehiculosList();
//    using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
//    {
//        using (SqlCommand myCommand = new SqlCommand("VehiculosSelectListByVinculoVehiculoANDidDelito", myConnection))
//        {
//            myCommand.CommandType = CommandType.StoredProcedure;
//            myCommand.Parameters.AddWithValue("@idDelito", idDelito);
//            myCommand.Parameters.AddWithValue("@idClaseVinculoVehiculo", vinculo);
//            myConnection.Open();
//            using (SqlDataReader myReader = myCommand.ExecuteReader())
//            {
//                if (myReader.HasRows)
//                {
//                    while (myReader.Read())
//                    {
//                        tempList.Add(FillDataRecord(myReader));
//                    }
//                }
//                myReader.Close();
//            }
//        }
//        return tempList;
//    }
//}

/// <summary>
/// Returns a list with Vehiculos objects.
/// </summary>
/// <returns>A generics List with the Vehiculos objects.</returns>
public static VehiculosList GetListByidMarcaVehiculo(int idMarcaVehiculo)
{
VehiculosList tempList = new VehiculosList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("VehiculosSelectListByidMarcaVehiculo", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idMarcaVehiculo", idMarcaVehiculo);
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
/// Returns a list with Vehiculos objects.
/// </summary>
/// <returns>A generics List with the Vehiculos objects.</returns>
public static VehiculosList GetListByidModeloVehiculo(int idModeloVehiculo)
{
VehiculosList tempList = new VehiculosList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("VehiculosSelectListByidModeloVehiculo", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idModeloVehiculo", idModeloVehiculo);
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
/// Returns a list with Vehiculos objects.
/// </summary>
/// <returns>A generics List with the Vehiculos objects.</returns>
public static VehiculosList GetListByGNC(int GNC)
{
VehiculosList tempList = new VehiculosList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("VehiculosSelectListByGNC", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@gNC", GNC);
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
/// Returns a list with Vehiculos objects.
/// </summary>
/// <returns>A generics List with the Vehiculos objects.</returns>
public static VehiculosList GetListByidClaseVidrioVehiculo(int idClaseVidrioVehiculo)
{
VehiculosList tempList = new VehiculosList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("VehiculosSelectListByidClaseVidrioVehiculo", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idClaseVidrioVehiculo", idClaseVidrioVehiculo);
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
/// Returns a list with Vehiculos objects.
/// </summary>
/// <returns>A generics List with the Vehiculos objects.</returns>
public static VehiculosList GetListByidClaseVinculoVehiculo(int idClaseVinculoVehiculo)
{
VehiculosList tempList = new VehiculosList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("VehiculosSelectListByidClaseVinculoVehiculo", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idClaseVinculoVehiculo", idClaseVinculoVehiculo);
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
/// Saves a Vehiculos in the database.
/// </summary>
/// <param name="myVehiculos">The Vehiculos instance to save.</param>
/// <returns>The new id if the Vehiculos is new in the database or the existing id when an item was updated.</returns>
public static int Save(Vehiculos myVehiculos)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("VehiculosInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myVehiculos.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myVehiculos.id);
}

myCommand.Parameters.AddWithValue("@idBienSustraido", myVehiculos.idBienSustraido);


myCommand.Parameters.AddWithValue("@idDelito", myVehiculos.idDelito);

if (string.IsNullOrEmpty(myVehiculos.idCausa))
{
myCommand.Parameters.AddWithValue("@idCausa", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idCausa", myVehiculos.idCausa);
}

myCommand.Parameters.AddWithValue("@idClaseVinculoVehiculo", myVehiculos.idClaseVinculoVehiculo);



myCommand.Parameters.AddWithValue("@idMarcaVehiculo", myVehiculos.idMarcaVehiculo);


myCommand.Parameters.AddWithValue("@idModeloVehiculo", myVehiculos.idModeloVehiculo);

if (string.IsNullOrEmpty(myVehiculos.Dominio))
{
myCommand.Parameters.AddWithValue("@dominio", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@dominio", myVehiculos.Dominio);
}
if (string.IsNullOrEmpty(myVehiculos.NumeroChasis))
{
myCommand.Parameters.AddWithValue("@numeroChasis", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@numeroChasis", myVehiculos.NumeroChasis);
}
if (string.IsNullOrEmpty(myVehiculos.NumeroMotor))
{
myCommand.Parameters.AddWithValue("@numeroMotor", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@numeroMotor", myVehiculos.NumeroMotor);
}

myCommand.Parameters.AddWithValue("@idColorVehiculo", myVehiculos.idColorVehiculo);

if (string.IsNullOrEmpty(myVehiculos.anio))
{
myCommand.Parameters.AddWithValue("@anio", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@anio", myVehiculos.anio);
}
myCommand.Parameters.AddWithValue("@gNC", myVehiculos.GNC);

if (string.IsNullOrEmpty(myVehiculos.IdentificacionGNC))
{
myCommand.Parameters.AddWithValue("@identificacionGNC", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@identificacionGNC", myVehiculos.IdentificacionGNC);
}

myCommand.Parameters.AddWithValue("@idClaseVidrioVehiculo", myVehiculos.idClaseVidrioVehiculo);

myCommand.Parameters.AddWithValue("@baja", myVehiculos.Baja);

if (string.IsNullOrEmpty(myVehiculos.idUsuarioUltimaModificacion))
{
myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", myVehiculos.idUsuarioUltimaModificacion);
}
if (myVehiculos.FechaUltimaModificacion == null){
myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myVehiculos.FechaUltimaModificacion);
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
public static int Save(Vehiculos myVehiculos, SqlCommand myCommand)
{
    int result = 0;
    //using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
    //{
    //    using (SqlCommand myCommand = new SqlCommand("VehiculosInsertUpdateSingleItem", myConnection))
    //    {
    //        myCommand.CommandType = CommandType.StoredProcedure;
    try
    {
        myCommand.CommandText = "VehiculosInsertUpdateSingleItem";
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.Parameters.Clear();


        if (myVehiculos.id == -1)
        {
            myCommand.Parameters.AddWithValue("@id", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@id", myVehiculos.id);
        }
        if (myVehiculos.idBienSustraido == 0)
        {
            myCommand.Parameters.AddWithValue("@idBienSustraido", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idBienSustraido", myVehiculos.idBienSustraido);
        }
        if (myVehiculos.idDelito == 0 )
        {
            myCommand.Parameters.AddWithValue("@idDelito", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idDelito", myVehiculos.idDelito);
        }

        if (string.IsNullOrEmpty(myVehiculos.idCausa))
        {
            myCommand.Parameters.AddWithValue("@idCausa", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idCausa", myVehiculos.idCausa);
        }

        myCommand.Parameters.AddWithValue("@idClaseVinculoVehiculo", myVehiculos.idClaseVinculoVehiculo);

        
            myCommand.Parameters.AddWithValue("@idMarcaVehiculo", myVehiculos.idMarcaVehiculo);
        
        
            myCommand.Parameters.AddWithValue("@idModeloVehiculo", myVehiculos.idModeloVehiculo);
        
        if (string.IsNullOrEmpty(myVehiculos.Dominio))
        {
            myCommand.Parameters.AddWithValue("@dominio", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@dominio", myVehiculos.Dominio);
        }
        if (string.IsNullOrEmpty(myVehiculos.NumeroChasis))
        {
            myCommand.Parameters.AddWithValue("@numeroChasis", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@numeroChasis", myVehiculos.NumeroChasis);
        }
        if (string.IsNullOrEmpty(myVehiculos.NumeroMotor))
        {
            myCommand.Parameters.AddWithValue("@numeroMotor", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@numeroMotor", myVehiculos.NumeroMotor);
        }
        
            myCommand.Parameters.AddWithValue("@idColorVehiculo", myVehiculos.idColorVehiculo);
        
        if (string.IsNullOrEmpty(myVehiculos.anio))
        {
            myCommand.Parameters.AddWithValue("@anio", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@anio", myVehiculos.anio);
        }

        myCommand.Parameters.AddWithValue("@gNC", myVehiculos.GNC);

        if (string.IsNullOrEmpty(myVehiculos.IdentificacionGNC))
        {
            myCommand.Parameters.AddWithValue("@identificacionGNC", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@identificacionGNC", myVehiculos.IdentificacionGNC);
        }

        myCommand.Parameters.AddWithValue("@idClaseVidrioVehiculo", myVehiculos.idClaseVidrioVehiculo);

        myCommand.Parameters.AddWithValue("@baja", myVehiculos.Baja);

        if (string.IsNullOrEmpty(myVehiculos.idUsuarioUltimaModificacion))
        {
            myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@idUsuarioUltimaModificacion", myVehiculos.idUsuarioUltimaModificacion);
        }
        if (myVehiculos.FechaUltimaModificacion == null)
        {
            myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", DBNull.Value);
        }
        else
        {
            myCommand.Parameters.AddWithValue("@fechaUltimaModificacion", myVehiculos.FechaUltimaModificacion);
        }

        DbParameter returnValue;
        returnValue = myCommand.CreateParameter();
        returnValue.Direction = ParameterDirection.ReturnValue;
        myCommand.Parameters.Add(returnValue);

        //myConnection.Open();
        myCommand.ExecuteNonQuery();
        result = Convert.ToInt32(returnValue.Value);
        //        myConnection.Close();
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
/// Deletes a Vehiculos from the database.
/// </summary>
/// <param name="id">The id of the Vehiculos to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("VehiculosDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the Vehiculos class and fills it with the data fom the IDataRecord.
/// </summary>
private static Vehiculos FillDataRecord(IDataRecord myDataRecord )
{
Vehiculos myVehiculos = new Vehiculos();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myVehiculos.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBienSustraido")))
{
myVehiculos.idBienSustraido = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBienSustraido"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idDelito")))
{
myVehiculos.idDelito = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idDelito"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idCausa")))
{
myVehiculos.idCausa = myDataRecord.GetString(myDataRecord.GetOrdinal("idCausa"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseVinculoVehiculo")))
{
myVehiculos.idClaseVinculoVehiculo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseVinculoVehiculo"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idMarcaVehiculo")))
{
myVehiculos.idMarcaVehiculo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idMarcaVehiculo"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idModeloVehiculo")))
{
myVehiculos.idModeloVehiculo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idModeloVehiculo"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Dominio")))
{
myVehiculos.Dominio = myDataRecord.GetString(myDataRecord.GetOrdinal("Dominio"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("NumeroChasis")))
{
myVehiculos.NumeroChasis = myDataRecord.GetString(myDataRecord.GetOrdinal("NumeroChasis"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("NumeroMotor")))
{
myVehiculos.NumeroMotor = myDataRecord.GetString(myDataRecord.GetOrdinal("NumeroMotor"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idColorVehiculo")))
{
myVehiculos.idColorVehiculo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idColorVehiculo"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("anio")))
{
myVehiculos.anio = myDataRecord.GetString(myDataRecord.GetOrdinal("anio"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("GNC")))
{
myVehiculos.GNC = myDataRecord.GetInt32(myDataRecord.GetOrdinal("GNC"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("IdentificacionGNC")))
{
myVehiculos.IdentificacionGNC = myDataRecord.GetString(myDataRecord.GetOrdinal("IdentificacionGNC"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idClaseVidrioVehiculo")))
{
myVehiculos.idClaseVidrioVehiculo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idClaseVidrioVehiculo"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Baja")))
{
myVehiculos.Baja = myDataRecord.GetBoolean(myDataRecord.GetOrdinal("Baja"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idUsuarioUltimaModificacion")))
{
myVehiculos.idUsuarioUltimaModificacion = myDataRecord.GetString(myDataRecord.GetOrdinal("idUsuarioUltimaModificacion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FechaUltimaModificacion")))
{
myVehiculos.FechaUltimaModificacion = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("FechaUltimaModificacion"));
}
return myVehiculos;
}
}

 } 
