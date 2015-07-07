using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The BusquedaRoboDelitosSexualesFormaMentonDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaRoboDelitosSexualesFormaMenton objects.
/// </summary>
public partial class BusquedaRoboDelitosSexualesFormaMentonDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaRoboDelitosSexualesFormaMenton from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaRoboDelitosSexualesFormaMenton in the database.</param>
/// <returns>An BusquedaRoboDelitosSexualesFormaMenton when the id was found in the database, or null otherwise.</returns>
public static BusquedaRoboDelitosSexualesFormaMenton GetItem(int id)
{
BusquedaRoboDelitosSexualesFormaMenton myBusquedaRoboDelitosSexualesFormaMenton = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaMentonSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaRoboDelitosSexualesFormaMenton = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaRoboDelitosSexualesFormaMenton;
}
}

/// <summary>
/// Returns a list with BusquedaRoboDelitosSexualesFormaMenton objects.
/// </summary>
/// <returns>A generics List with the BusquedaRoboDelitosSexualesFormaMenton objects.</returns>
public static BusquedaRoboDelitosSexualesFormaMentonList GetList()
{
BusquedaRoboDelitosSexualesFormaMentonList tempList = new BusquedaRoboDelitosSexualesFormaMentonList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaMentonSelectList", myConnection))
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
/// Returns a list with BusquedaRoboDelitosSexualesFormaMenton objects.
/// </summary>
/// <returns>A generics List with the BusquedaRoboDelitosSexualesFormaMenton objects.</returns>
public static BusquedaRoboDelitosSexualesFormaMentonList GetListByidBusquedaRoboDS(int idBusquedaRoboDS)
{
BusquedaRoboDelitosSexualesFormaMentonList tempList = new BusquedaRoboDelitosSexualesFormaMentonList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaMentonSelectListByidBusquedaRoboDS", myConnection))
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
/// Saves a BusquedaRoboDelitosSexualesFormaMenton in the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesFormaMenton">The BusquedaRoboDelitosSexualesFormaMenton instance to save.</param>
/// <returns>The new id if the BusquedaRoboDelitosSexualesFormaMenton is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaRoboDelitosSexualesFormaMenton myBusquedaRoboDelitosSexualesFormaMenton)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaMentonInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myBusquedaRoboDelitosSexualesFormaMenton.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myBusquedaRoboDelitosSexualesFormaMenton.id);
}
if (myBusquedaRoboDelitosSexualesFormaMenton.idBusquedaRoboDS == null){
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", myBusquedaRoboDelitosSexualesFormaMenton.idBusquedaRoboDS);
}
if (myBusquedaRoboDelitosSexualesFormaMenton.idFormaMenton == null){
myCommand.Parameters.AddWithValue("@idFormaMenton", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idFormaMenton", myBusquedaRoboDelitosSexualesFormaMenton.idFormaMenton);
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
/// Deletes a BusquedaRoboDelitosSexualesFormaMenton from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesFormaMenton to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaMentonDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the BusquedaRoboDelitosSexualesFormaMenton class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaRoboDelitosSexualesFormaMenton FillDataRecord(IDataRecord myDataRecord )
{
BusquedaRoboDelitosSexualesFormaMenton myBusquedaRoboDelitosSexualesFormaMenton = new BusquedaRoboDelitosSexualesFormaMenton();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaRoboDelitosSexualesFormaMenton.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusquedaRoboDS")))
{
myBusquedaRoboDelitosSexualesFormaMenton.idBusquedaRoboDS = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusquedaRoboDS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idFormaMenton")))
{
myBusquedaRoboDelitosSexualesFormaMenton.idFormaMenton = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idFormaMenton"));
}
return myBusquedaRoboDelitosSexualesFormaMenton;
}
}

 } 
