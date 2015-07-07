using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The BusquedaRoboDelitosSexualesFormaOrejaDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaRoboDelitosSexualesFormaOreja objects.
/// </summary>
public partial class BusquedaRoboDelitosSexualesFormaOrejaDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaRoboDelitosSexualesFormaOreja from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaRoboDelitosSexualesFormaOreja in the database.</param>
/// <returns>An BusquedaRoboDelitosSexualesFormaOreja when the id was found in the database, or null otherwise.</returns>
public static BusquedaRoboDelitosSexualesFormaOreja GetItem(int id)
{
BusquedaRoboDelitosSexualesFormaOreja myBusquedaRoboDelitosSexualesFormaOreja = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaOrejaSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaRoboDelitosSexualesFormaOreja = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaRoboDelitosSexualesFormaOreja;
}
}

/// <summary>
/// Returns a list with BusquedaRoboDelitosSexualesFormaOreja objects.
/// </summary>
/// <returns>A generics List with the BusquedaRoboDelitosSexualesFormaOreja objects.</returns>
public static BusquedaRoboDelitosSexualesFormaOrejaList GetList()
{
BusquedaRoboDelitosSexualesFormaOrejaList tempList = new BusquedaRoboDelitosSexualesFormaOrejaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaOrejaSelectList", myConnection))
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
/// Returns a list with BusquedaRoboDelitosSexualesFormaOreja objects.
/// </summary>
/// <returns>A generics List with the BusquedaRoboDelitosSexualesFormaOreja objects.</returns>
public static BusquedaRoboDelitosSexualesFormaOrejaList GetListByidBusquedaRoboDS(int idBusquedaRoboDS)
{
BusquedaRoboDelitosSexualesFormaOrejaList tempList = new BusquedaRoboDelitosSexualesFormaOrejaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaOrejaSelectListByidBusquedaRoboDS", myConnection))
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
/// Saves a BusquedaRoboDelitosSexualesFormaOreja in the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesFormaOreja">The BusquedaRoboDelitosSexualesFormaOreja instance to save.</param>
/// <returns>The new id if the BusquedaRoboDelitosSexualesFormaOreja is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaRoboDelitosSexualesFormaOreja myBusquedaRoboDelitosSexualesFormaOreja)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaOrejaInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myBusquedaRoboDelitosSexualesFormaOreja.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myBusquedaRoboDelitosSexualesFormaOreja.id);
}
if (myBusquedaRoboDelitosSexualesFormaOreja.idBusquedaRoboDS == null){
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", myBusquedaRoboDelitosSexualesFormaOreja.idBusquedaRoboDS);
}
if (myBusquedaRoboDelitosSexualesFormaOreja.idFormaOreja == null){
myCommand.Parameters.AddWithValue("@idFormaOreja", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idFormaOreja", myBusquedaRoboDelitosSexualesFormaOreja.idFormaOreja);
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
/// Deletes a BusquedaRoboDelitosSexualesFormaOreja from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesFormaOreja to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaOrejaDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the BusquedaRoboDelitosSexualesFormaOreja class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaRoboDelitosSexualesFormaOreja FillDataRecord(IDataRecord myDataRecord )
{
BusquedaRoboDelitosSexualesFormaOreja myBusquedaRoboDelitosSexualesFormaOreja = new BusquedaRoboDelitosSexualesFormaOreja();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaRoboDelitosSexualesFormaOreja.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusquedaRoboDS")))
{
myBusquedaRoboDelitosSexualesFormaOreja.idBusquedaRoboDS = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusquedaRoboDS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idFormaOreja")))
{
myBusquedaRoboDelitosSexualesFormaOreja.idFormaOreja = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idFormaOreja"));
}
return myBusquedaRoboDelitosSexualesFormaOreja;
}
}

 } 
