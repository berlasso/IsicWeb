using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The BusquedaRoboDelitosSexualesRobustezDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaRoboDelitosSexualesRobustez objects.
/// </summary>
public partial class BusquedaRoboDelitosSexualesRobustezDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaRoboDelitosSexualesRobustez from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaRoboDelitosSexualesRobustez in the database.</param>
/// <returns>An BusquedaRoboDelitosSexualesRobustez when the id was found in the database, or null otherwise.</returns>
public static BusquedaRoboDelitosSexualesRobustez GetItem(int id)
{
BusquedaRoboDelitosSexualesRobustez myBusquedaRoboDelitosSexualesRobustez = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesRobustezSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaRoboDelitosSexualesRobustez = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaRoboDelitosSexualesRobustez;
}
}

/// <summary>
/// Returns a list with BusquedaRoboDelitosSexualesRobustez objects.
/// </summary>
/// <returns>A generics List with the BusquedaRoboDelitosSexualesRobustez objects.</returns>
public static BusquedaRoboDelitosSexualesRobustezList GetList()
{
BusquedaRoboDelitosSexualesRobustezList tempList = new BusquedaRoboDelitosSexualesRobustezList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesRobustezSelectList", myConnection))
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
/// Returns a list with BusquedaRoboDelitosSexualesRobustez objects.
/// </summary>
/// <returns>A generics List with the BusquedaRoboDelitosSexualesRobustez objects.</returns>
public static BusquedaRoboDelitosSexualesRobustezList GetListByidBusquedaRoboDS(int idBusquedaRoboDS)
{
BusquedaRoboDelitosSexualesRobustezList tempList = new BusquedaRoboDelitosSexualesRobustezList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesRobustezSelectListByidBusquedaRoboDS", myConnection))
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
/// Saves a BusquedaRoboDelitosSexualesRobustez in the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesRobustez">The BusquedaRoboDelitosSexualesRobustez instance to save.</param>
/// <returns>The new id if the BusquedaRoboDelitosSexualesRobustez is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaRoboDelitosSexualesRobustez myBusquedaRoboDelitosSexualesRobustez)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesRobustezInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myBusquedaRoboDelitosSexualesRobustez.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myBusquedaRoboDelitosSexualesRobustez.id);
}
if (myBusquedaRoboDelitosSexualesRobustez.idBusquedaRoboDS == null){
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", myBusquedaRoboDelitosSexualesRobustez.idBusquedaRoboDS);
}
if (myBusquedaRoboDelitosSexualesRobustez.idRobustez == null){
myCommand.Parameters.AddWithValue("@idRobustez", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idRobustez", myBusquedaRoboDelitosSexualesRobustez.idRobustez);
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
/// Deletes a BusquedaRoboDelitosSexualesRobustez from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesRobustez to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesRobustezDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the BusquedaRoboDelitosSexualesRobustez class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaRoboDelitosSexualesRobustez FillDataRecord(IDataRecord myDataRecord )
{
BusquedaRoboDelitosSexualesRobustez myBusquedaRoboDelitosSexualesRobustez = new BusquedaRoboDelitosSexualesRobustez();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaRoboDelitosSexualesRobustez.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusquedaRoboDS")))
{
myBusquedaRoboDelitosSexualesRobustez.idBusquedaRoboDS = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusquedaRoboDS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idRobustez")))
{
myBusquedaRoboDelitosSexualesRobustez.idRobustez = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idRobustez"));
}
return myBusquedaRoboDelitosSexualesRobustez;
}
}

 } 
