using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The BusquedaRobosDelitosSexualesColorOjosDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaRobosDelitosSexualesColorOjos objects.
/// </summary>
public partial class BusquedaRobosDelitosSexualesColorOjosDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaRobosDelitosSexualesColorOjos from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaRobosDelitosSexualesColorOjos in the database.</param>
/// <returns>An BusquedaRobosDelitosSexualesColorOjos when the id was found in the database, or null otherwise.</returns>
public static BusquedaRobosDelitosSexualesColorOjos GetItem(int id)
{
BusquedaRobosDelitosSexualesColorOjos myBusquedaRobosDelitosSexualesColorOjos = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesColorOjosSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaRobosDelitosSexualesColorOjos = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaRobosDelitosSexualesColorOjos;
}
}

/// <summary>
/// Returns a list with BusquedaRobosDelitosSexualesColorOjos objects.
/// </summary>
/// <returns>A generics List with the BusquedaRobosDelitosSexualesColorOjos objects.</returns>
public static BusquedaRobosDelitosSexualesColorOjosList GetList()
{
BusquedaRobosDelitosSexualesColorOjosList tempList = new BusquedaRobosDelitosSexualesColorOjosList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesColorOjosSelectList", myConnection))
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
/// Returns a list with BusquedaRobosDelitosSexualesColorOjos objects.
/// </summary>
/// <returns>A generics List with the BusquedaRobosDelitosSexualesColorOjos objects.</returns>
public static BusquedaRobosDelitosSexualesColorOjosList GetListByidBusquedaRoboDS(int idBusquedaRoboDS)
{
BusquedaRobosDelitosSexualesColorOjosList tempList = new BusquedaRobosDelitosSexualesColorOjosList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesColorOjosSelectListByidBusquedaRoboDS", myConnection))
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
/// Saves a BusquedaRobosDelitosSexualesColorOjos in the database.
/// </summary>
/// <param name="myBusquedaRobosDelitosSexualesColorOjos">The BusquedaRobosDelitosSexualesColorOjos instance to save.</param>
/// <returns>The new id if the BusquedaRobosDelitosSexualesColorOjos is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaRobosDelitosSexualesColorOjos myBusquedaRobosDelitosSexualesColorOjos)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesColorOjosInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myBusquedaRobosDelitosSexualesColorOjos.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myBusquedaRobosDelitosSexualesColorOjos.id);
}
if (myBusquedaRobosDelitosSexualesColorOjos.idBusquedaRoboDS == null){
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", myBusquedaRobosDelitosSexualesColorOjos.idBusquedaRoboDS);
}
if (myBusquedaRobosDelitosSexualesColorOjos.idColorOjos == null){
myCommand.Parameters.AddWithValue("@idColorOjos", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idColorOjos", myBusquedaRobosDelitosSexualesColorOjos.idColorOjos);
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
/// Deletes a BusquedaRobosDelitosSexualesColorOjos from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRobosDelitosSexualesColorOjos to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesColorOjosDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the BusquedaRobosDelitosSexualesColorOjos class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaRobosDelitosSexualesColorOjos FillDataRecord(IDataRecord myDataRecord )
{
BusquedaRobosDelitosSexualesColorOjos myBusquedaRobosDelitosSexualesColorOjos = new BusquedaRobosDelitosSexualesColorOjos();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaRobosDelitosSexualesColorOjos.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusquedaRoboDS")))
{
myBusquedaRobosDelitosSexualesColorOjos.idBusquedaRoboDS = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusquedaRoboDS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idColorOjos")))
{
myBusquedaRobosDelitosSexualesColorOjos.idColorOjos = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idColorOjos"));
}
return myBusquedaRobosDelitosSexualesColorOjos;
}
}

 } 
