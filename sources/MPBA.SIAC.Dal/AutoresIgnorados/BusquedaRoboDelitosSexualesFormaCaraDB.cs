using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The BusquedaRoboDelitosSexualesFormaCaraDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaRoboDelitosSexualesFormaCara objects.
/// </summary>
public partial class BusquedaRoboDelitosSexualesFormaCaraDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaRoboDelitosSexualesFormaCara from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaRoboDelitosSexualesFormaCara in the database.</param>
/// <returns>An BusquedaRoboDelitosSexualesFormaCara when the id was found in the database, or null otherwise.</returns>
public static BusquedaRoboDelitosSexualesFormaCara GetItem(int id)
{
BusquedaRoboDelitosSexualesFormaCara myBusquedaRoboDelitosSexualesFormaCara = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaCaraSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaRoboDelitosSexualesFormaCara = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaRoboDelitosSexualesFormaCara;
}
}

/// <summary>
/// Returns a list with BusquedaRoboDelitosSexualesFormaCara objects.
/// </summary>
/// <returns>A generics List with the BusquedaRoboDelitosSexualesFormaCara objects.</returns>
public static BusquedaRoboDelitosSexualesFormaCaraList GetList()
{
BusquedaRoboDelitosSexualesFormaCaraList tempList = new BusquedaRoboDelitosSexualesFormaCaraList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaCaraSelectList", myConnection))
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
/// Returns a list with BusquedaRoboDelitosSexualesFormaCara objects.
/// </summary>
/// <returns>A generics List with the BusquedaRoboDelitosSexualesFormaCara objects.</returns>
public static BusquedaRoboDelitosSexualesFormaCaraList GetListByidBusquedaRoboDS(int idBusquedaRoboDS)
{
BusquedaRoboDelitosSexualesFormaCaraList tempList = new BusquedaRoboDelitosSexualesFormaCaraList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaCaraSelectListByidBusquedaRoboDS", myConnection))
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
/// Saves a BusquedaRoboDelitosSexualesFormaCara in the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesFormaCara">The BusquedaRoboDelitosSexualesFormaCara instance to save.</param>
/// <returns>The new id if the BusquedaRoboDelitosSexualesFormaCara is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaRoboDelitosSexualesFormaCara myBusquedaRoboDelitosSexualesFormaCara)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaCaraInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myBusquedaRoboDelitosSexualesFormaCara.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myBusquedaRoboDelitosSexualesFormaCara.id);
}
if (myBusquedaRoboDelitosSexualesFormaCara.idBusquedaRoboDS == null){
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", myBusquedaRoboDelitosSexualesFormaCara.idBusquedaRoboDS);
}
if (myBusquedaRoboDelitosSexualesFormaCara.idFormaCara == null){
myCommand.Parameters.AddWithValue("@idFormaCara", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idFormaCara", myBusquedaRoboDelitosSexualesFormaCara.idFormaCara);
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
/// Deletes a BusquedaRoboDelitosSexualesFormaCara from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesFormaCara to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaCaraDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the BusquedaRoboDelitosSexualesFormaCara class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaRoboDelitosSexualesFormaCara FillDataRecord(IDataRecord myDataRecord )
{
BusquedaRoboDelitosSexualesFormaCara myBusquedaRoboDelitosSexualesFormaCara = new BusquedaRoboDelitosSexualesFormaCara();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaRoboDelitosSexualesFormaCara.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusquedaRoboDS")))
{
myBusquedaRoboDelitosSexualesFormaCara.idBusquedaRoboDS = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusquedaRoboDS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idFormaCara")))
{
myBusquedaRoboDelitosSexualesFormaCara.idFormaCara = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idFormaCara"));
}
return myBusquedaRoboDelitosSexualesFormaCara;
}
}

 } 
