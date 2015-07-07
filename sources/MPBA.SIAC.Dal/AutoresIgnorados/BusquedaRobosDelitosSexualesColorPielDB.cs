using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The BusquedaRobosDelitosSexualesColorPielDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaRobosDelitosSexualesColorPiel objects.
/// </summary>
public partial class BusquedaRobosDelitosSexualesColorPielDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaRobosDelitosSexualesColorPiel from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaRobosDelitosSexualesColorPiel in the database.</param>
/// <returns>An BusquedaRobosDelitosSexualesColorPiel when the id was found in the database, or null otherwise.</returns>
public static BusquedaRobosDelitosSexualesColorPiel GetItem(int id)
{
BusquedaRobosDelitosSexualesColorPiel myBusquedaRobosDelitosSexualesColorPiel = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesColorPielSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaRobosDelitosSexualesColorPiel = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaRobosDelitosSexualesColorPiel;
}
}

/// <summary>
/// Returns a list with BusquedaRobosDelitosSexualesColorPiel objects.
/// </summary>
/// <returns>A generics List with the BusquedaRobosDelitosSexualesColorPiel objects.</returns>
public static BusquedaRobosDelitosSexualesColorPielList GetList()
{
BusquedaRobosDelitosSexualesColorPielList tempList = new BusquedaRobosDelitosSexualesColorPielList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesColorPielSelectList", myConnection))
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
/// Returns a list with BusquedaRobosDelitosSexualesColorPiel objects.
/// </summary>
/// <returns>A generics List with the BusquedaRobosDelitosSexualesColorPiel objects.</returns>
public static BusquedaRobosDelitosSexualesColorPielList GetListByidBusquedaRoboDS(int idBusquedaRoboDS)
{
BusquedaRobosDelitosSexualesColorPielList tempList = new BusquedaRobosDelitosSexualesColorPielList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesColorPielSelectListByidBusquedaRoboDS", myConnection))
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
/// Saves a BusquedaRobosDelitosSexualesColorPiel in the database.
/// </summary>
/// <param name="myBusquedaRobosDelitosSexualesColorPiel">The BusquedaRobosDelitosSexualesColorPiel instance to save.</param>
/// <returns>The new id if the BusquedaRobosDelitosSexualesColorPiel is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaRobosDelitosSexualesColorPiel myBusquedaRobosDelitosSexualesColorPiel)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesColorPielInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myBusquedaRobosDelitosSexualesColorPiel.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myBusquedaRobosDelitosSexualesColorPiel.id);
}
if (myBusquedaRobosDelitosSexualesColorPiel.idBusquedaRoboDS == null){
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", myBusquedaRobosDelitosSexualesColorPiel.idBusquedaRoboDS);
}
if (myBusquedaRobosDelitosSexualesColorPiel.idColorPiel == null){
myCommand.Parameters.AddWithValue("@idColorPiel", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idColorPiel", myBusquedaRobosDelitosSexualesColorPiel.idColorPiel);
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
/// Deletes a BusquedaRobosDelitosSexualesColorPiel from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRobosDelitosSexualesColorPiel to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesColorPielDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the BusquedaRobosDelitosSexualesColorPiel class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaRobosDelitosSexualesColorPiel FillDataRecord(IDataRecord myDataRecord )
{
BusquedaRobosDelitosSexualesColorPiel myBusquedaRobosDelitosSexualesColorPiel = new BusquedaRobosDelitosSexualesColorPiel();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaRobosDelitosSexualesColorPiel.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusquedaRoboDS")))
{
myBusquedaRobosDelitosSexualesColorPiel.idBusquedaRoboDS = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusquedaRoboDS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idColorPiel")))
{
myBusquedaRobosDelitosSexualesColorPiel.idColorPiel = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idColorPiel"));
}
return myBusquedaRobosDelitosSexualesColorPiel;
}
}

 } 
