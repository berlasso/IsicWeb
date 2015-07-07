using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The BusquedaRoboDelitosSexualesFormaNarizDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaRoboDelitosSexualesFormaNariz objects.
/// </summary>
public partial class BusquedaRoboDelitosSexualesFormaNarizDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaRoboDelitosSexualesFormaNariz from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaRoboDelitosSexualesFormaNariz in the database.</param>
/// <returns>An BusquedaRoboDelitosSexualesFormaNariz when the id was found in the database, or null otherwise.</returns>
public static BusquedaRoboDelitosSexualesFormaNariz GetItem(int id)
{
BusquedaRoboDelitosSexualesFormaNariz myBusquedaRoboDelitosSexualesFormaNariz = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaNarizSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaRoboDelitosSexualesFormaNariz = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaRoboDelitosSexualesFormaNariz;
}
}

/// <summary>
/// Returns a list with BusquedaRoboDelitosSexualesFormaNariz objects.
/// </summary>
/// <returns>A generics List with the BusquedaRoboDelitosSexualesFormaNariz objects.</returns>
public static BusquedaRoboDelitosSexualesFormaNarizList GetList()
{
BusquedaRoboDelitosSexualesFormaNarizList tempList = new BusquedaRoboDelitosSexualesFormaNarizList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaNarizSelectList", myConnection))
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
/// Returns a list with BusquedaRoboDelitosSexualesFormaNariz objects.
/// </summary>
/// <returns>A generics List with the BusquedaRoboDelitosSexualesFormaNariz objects.</returns>
public static BusquedaRoboDelitosSexualesFormaNarizList GetListByidBusquedaRoboDS(int idBusquedaRoboDS)
{
BusquedaRoboDelitosSexualesFormaNarizList tempList = new BusquedaRoboDelitosSexualesFormaNarizList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaNarizSelectListByidBusquedaRoboDS", myConnection))
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
/// Saves a BusquedaRoboDelitosSexualesFormaNariz in the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesFormaNariz">The BusquedaRoboDelitosSexualesFormaNariz instance to save.</param>
/// <returns>The new id if the BusquedaRoboDelitosSexualesFormaNariz is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaRoboDelitosSexualesFormaNariz myBusquedaRoboDelitosSexualesFormaNariz)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaNarizInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myBusquedaRoboDelitosSexualesFormaNariz.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myBusquedaRoboDelitosSexualesFormaNariz.id);
}
if (myBusquedaRoboDelitosSexualesFormaNariz.idBusquedaRoboDS == null){
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", myBusquedaRoboDelitosSexualesFormaNariz.idBusquedaRoboDS);
}
if (myBusquedaRoboDelitosSexualesFormaNariz.idFormaNariz == null){
myCommand.Parameters.AddWithValue("@idFormaNariz", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idFormaNariz", myBusquedaRoboDelitosSexualesFormaNariz.idFormaNariz);
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
/// Deletes a BusquedaRoboDelitosSexualesFormaNariz from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesFormaNariz to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaNarizDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the BusquedaRoboDelitosSexualesFormaNariz class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaRoboDelitosSexualesFormaNariz FillDataRecord(IDataRecord myDataRecord )
{
BusquedaRoboDelitosSexualesFormaNariz myBusquedaRoboDelitosSexualesFormaNariz = new BusquedaRoboDelitosSexualesFormaNariz();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaRoboDelitosSexualesFormaNariz.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusquedaRoboDS")))
{
myBusquedaRoboDelitosSexualesFormaNariz.idBusquedaRoboDS = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusquedaRoboDS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idFormaNariz")))
{
myBusquedaRoboDelitosSexualesFormaNariz.idFormaNariz = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idFormaNariz"));
}
return myBusquedaRoboDelitosSexualesFormaNariz;
}
}

 } 
