using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal
{
/// <summary>
/// The BusquedaRobosDelitosSexualesTatuajesDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaRobosDelitosSexualesTatuajes objects.
/// </summary>
public partial class BusquedaRobosDelitosSexualesTatuajesDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaRobosDelitosSexualesTatuajes from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaRobosDelitosSexualesTatuajes in the database.</param>
/// <returns>An BusquedaRobosDelitosSexualesTatuajes when the id was found in the database, or null otherwise.</returns>
public static BusquedaRobosDelitosSexualesTatuajes GetItem(int id)
{
BusquedaRobosDelitosSexualesTatuajes myBusquedaRobosDelitosSexualesTatuajes = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesTatuajesSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaRobosDelitosSexualesTatuajes = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaRobosDelitosSexualesTatuajes;
}
}

/// <summary>
/// Returns a list with BusquedaRobosDelitosSexualesTatuajes objects.
/// </summary>
/// <returns>A generics List with the BusquedaRobosDelitosSexualesTatuajes objects.</returns>
public static BusquedaRobosDelitosSexualesTatuajesList GetList()
{
BusquedaRobosDelitosSexualesTatuajesList tempList = new BusquedaRobosDelitosSexualesTatuajesList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesTatuajesSelectList", myConnection))
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
/// Returns a list with BusquedaRobosDelitosSexualesTatuajes objects.
/// </summary>
/// <returns>A generics List with the BusquedaRobosDelitosSexualesTatuajes objects.</returns>
public static BusquedaRobosDelitosSexualesTatuajesList GetListByidBusquedaRoboDS(int idBusquedaRoboDS)
{
BusquedaRobosDelitosSexualesTatuajesList tempList = new BusquedaRobosDelitosSexualesTatuajesList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesTatuajesSelectListByidBusquedaRoboDS", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", idBusquedaRoboDS);
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
/// Returns a list with BusquedaRobosDelitosSexualesTatuajes objects.
/// </summary>
/// <returns>A generics List with the BusquedaRobosDelitosSexualesTatuajes objects.</returns>
public static BusquedaRobosDelitosSexualesTatuajesList GetListByidLugarTatuaje(int idLugarTatuaje)
{
BusquedaRobosDelitosSexualesTatuajesList tempList = new BusquedaRobosDelitosSexualesTatuajesList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesTatuajesSelectListByidLugarTatuaje", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idLugarTatuaje", idLugarTatuaje);
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
/// Returns a list with BusquedaRobosDelitosSexualesTatuajes objects.
/// </summary>
/// <returns>A generics List with the BusquedaRobosDelitosSexualesTatuajes objects.</returns>
public static BusquedaRobosDelitosSexualesTatuajesList GetListByidTatuaje(int idTatuaje)
{
BusquedaRobosDelitosSexualesTatuajesList tempList = new BusquedaRobosDelitosSexualesTatuajesList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesTatuajesSelectListByidTatuaje", myConnection))
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
/// Saves a BusquedaRobosDelitosSexualesTatuajes in the database.
/// </summary>
/// <param name="myBusquedaRobosDelitosSexualesTatuajes">The BusquedaRobosDelitosSexualesTatuajes instance to save.</param>
/// <returns>The new id if the BusquedaRobosDelitosSexualesTatuajes is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaRobosDelitosSexualesTatuajes myBusquedaRobosDelitosSexualesTatuajes)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesTatuajesInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myBusquedaRobosDelitosSexualesTatuajes.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myBusquedaRobosDelitosSexualesTatuajes.id);
}
if (myBusquedaRobosDelitosSexualesTatuajes.idBusquedaRoboDS == null){
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", myBusquedaRobosDelitosSexualesTatuajes.idBusquedaRoboDS);
}
if (myBusquedaRobosDelitosSexualesTatuajes.idTatuaje == null){
myCommand.Parameters.AddWithValue("@idTatuaje", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idTatuaje", myBusquedaRobosDelitosSexualesTatuajes.idTatuaje);
}
if (myBusquedaRobosDelitosSexualesTatuajes.idLugarTatuaje == null){
myCommand.Parameters.AddWithValue("@idLugarTatuaje", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idLugarTatuaje", myBusquedaRobosDelitosSexualesTatuajes.idLugarTatuaje);
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
/// Deletes a BusquedaRobosDelitosSexualesTatuajes from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRobosDelitosSexualesTatuajes to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesTatuajesDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the BusquedaRobosDelitosSexualesTatuajes class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaRobosDelitosSexualesTatuajes FillDataRecord(IDataRecord myDataRecord )
{
BusquedaRobosDelitosSexualesTatuajes myBusquedaRobosDelitosSexualesTatuajes = new BusquedaRobosDelitosSexualesTatuajes();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaRobosDelitosSexualesTatuajes.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusquedaRoboDS")))
{
myBusquedaRobosDelitosSexualesTatuajes.idBusquedaRoboDS = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusquedaRoboDS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idTatuaje")))
{
myBusquedaRobosDelitosSexualesTatuajes.idTatuaje = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idTatuaje"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idLugarTatuaje")))
{
myBusquedaRobosDelitosSexualesTatuajes.idLugarTatuaje = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idLugarTatuaje"));
}
return myBusquedaRobosDelitosSexualesTatuajes;
}
}

 } 
