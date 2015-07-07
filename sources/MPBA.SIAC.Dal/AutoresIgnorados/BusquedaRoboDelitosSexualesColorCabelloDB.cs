using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The BusquedaRoboDelitosSexualesColorCabelloDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaRoboDelitosSexualesColorCabello objects.
/// </summary>
public partial class BusquedaRoboDelitosSexualesColorCabelloDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaRoboDelitosSexualesColorCabello from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaRoboDelitosSexualesColorCabello in the database.</param>
/// <returns>An BusquedaRoboDelitosSexualesColorCabello when the id was found in the database, or null otherwise.</returns>
public static BusquedaRoboDelitosSexualesColorCabello GetItem(int id)
{
BusquedaRoboDelitosSexualesColorCabello myBusquedaRoboDelitosSexualesColorCabello = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesColorCabelloSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaRoboDelitosSexualesColorCabello = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaRoboDelitosSexualesColorCabello;
}
}

/// <summary>
/// Returns a list with BusquedaRoboDelitosSexualesColorCabello objects.
/// </summary>
/// <returns>A generics List with the BusquedaRoboDelitosSexualesColorCabello objects.</returns>
public static BusquedaRoboDelitosSexualesColorCabelloList GetList()
{
BusquedaRoboDelitosSexualesColorCabelloList tempList = new BusquedaRoboDelitosSexualesColorCabelloList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesColorCabelloSelectList", myConnection))
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
/// Returns a list with BusquedaRoboDelitosSexualesColorCabello objects.
/// </summary>
/// <returns>A generics List with the BusquedaRoboDelitosSexualesColorCabello objects.</returns>
public static BusquedaRoboDelitosSexualesColorCabelloList GetListByidBusquedaRoboDS(int idBusquedaRoboDS)
{
BusquedaRoboDelitosSexualesColorCabelloList tempList = new BusquedaRoboDelitosSexualesColorCabelloList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesColorCabelloSelectListByidBusquedaRoboDS", myConnection))
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
/// Saves a BusquedaRoboDelitosSexualesColorCabello in the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesColorCabello">The BusquedaRoboDelitosSexualesColorCabello instance to save.</param>
/// <returns>The new id if the BusquedaRoboDelitosSexualesColorCabello is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaRoboDelitosSexualesColorCabello myBusquedaRoboDelitosSexualesColorCabello)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesColorCabelloInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myBusquedaRoboDelitosSexualesColorCabello.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myBusquedaRoboDelitosSexualesColorCabello.id);
}
if (myBusquedaRoboDelitosSexualesColorCabello.idBusquedaRoboDS == null){
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", myBusquedaRoboDelitosSexualesColorCabello.idBusquedaRoboDS);
}
if (myBusquedaRoboDelitosSexualesColorCabello.idColorCabello == null){
myCommand.Parameters.AddWithValue("@idColorCabello", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idColorCabello", myBusquedaRoboDelitosSexualesColorCabello.idColorCabello);
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
/// Deletes a BusquedaRoboDelitosSexualesColorCabello from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesColorCabello to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesColorCabelloDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the BusquedaRoboDelitosSexualesColorCabello class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaRoboDelitosSexualesColorCabello FillDataRecord(IDataRecord myDataRecord )
{
BusquedaRoboDelitosSexualesColorCabello myBusquedaRoboDelitosSexualesColorCabello = new BusquedaRoboDelitosSexualesColorCabello();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaRoboDelitosSexualesColorCabello.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusquedaRoboDS")))
{
myBusquedaRoboDelitosSexualesColorCabello.idBusquedaRoboDS = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusquedaRoboDS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idColorCabello")))
{
myBusquedaRoboDelitosSexualesColorCabello.idColorCabello = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idColorCabello"));
}
return myBusquedaRoboDelitosSexualesColorCabello;
}
}

 } 
