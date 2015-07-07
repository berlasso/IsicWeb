using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The BusquedaRoboDelitosSexualesTipoCabelloDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaRoboDelitosSexualesTipoCabello objects.
/// </summary>
public partial class BusquedaRoboDelitosSexualesTipoCabelloDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaRoboDelitosSexualesTipoCabello from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaRoboDelitosSexualesTipoCabello in the database.</param>
/// <returns>An BusquedaRoboDelitosSexualesTipoCabello when the id was found in the database, or null otherwise.</returns>
public static BusquedaRoboDelitosSexualesTipoCabello GetItem(int id)
{
BusquedaRoboDelitosSexualesTipoCabello myBusquedaRoboDelitosSexualesTipoCabello = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesTipoCabelloSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaRoboDelitosSexualesTipoCabello = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaRoboDelitosSexualesTipoCabello;
}
}

/// <summary>
/// Returns a list with BusquedaRoboDelitosSexualesTipoCabello objects.
/// </summary>
/// <returns>A generics List with the BusquedaRoboDelitosSexualesTipoCabello objects.</returns>
public static BusquedaRoboDelitosSexualesTipoCabelloList GetList()
{
BusquedaRoboDelitosSexualesTipoCabelloList tempList = new BusquedaRoboDelitosSexualesTipoCabelloList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesTipoCabelloSelectList", myConnection))
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
/// Returns a list with BusquedaRoboDelitosSexualesTipoCabello objects.
/// </summary>
/// <returns>A generics List with the BusquedaRoboDelitosSexualesTipoCabello objects.</returns>
public static BusquedaRoboDelitosSexualesTipoCabelloList GetListByidBusquedaRoboDS(int idBusquedaRoboDS)
{
BusquedaRoboDelitosSexualesTipoCabelloList tempList = new BusquedaRoboDelitosSexualesTipoCabelloList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesTipoCabelloSelectListByidBusquedaRoboDS", myConnection))
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
/// Saves a BusquedaRoboDelitosSexualesTipoCabello in the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesTipoCabello">The BusquedaRoboDelitosSexualesTipoCabello instance to save.</param>
/// <returns>The new id if the BusquedaRoboDelitosSexualesTipoCabello is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaRoboDelitosSexualesTipoCabello myBusquedaRoboDelitosSexualesTipoCabello)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesTipoCabelloInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myBusquedaRoboDelitosSexualesTipoCabello.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myBusquedaRoboDelitosSexualesTipoCabello.id);
}
if (myBusquedaRoboDelitosSexualesTipoCabello.idBusquedaRoboDS == null){
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", myBusquedaRoboDelitosSexualesTipoCabello.idBusquedaRoboDS);
}
if (myBusquedaRoboDelitosSexualesTipoCabello.idTipoCabello == null){
myCommand.Parameters.AddWithValue("@idTipoCabello", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idTipoCabello", myBusquedaRoboDelitosSexualesTipoCabello.idTipoCabello);
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
/// Deletes a BusquedaRoboDelitosSexualesTipoCabello from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesTipoCabello to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesTipoCabelloDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the BusquedaRoboDelitosSexualesTipoCabello class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaRoboDelitosSexualesTipoCabello FillDataRecord(IDataRecord myDataRecord )
{
BusquedaRoboDelitosSexualesTipoCabello myBusquedaRoboDelitosSexualesTipoCabello = new BusquedaRoboDelitosSexualesTipoCabello();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaRoboDelitosSexualesTipoCabello.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusquedaRoboDS")))
{
myBusquedaRoboDelitosSexualesTipoCabello.idBusquedaRoboDS = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusquedaRoboDS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idTipoCabello")))
{
myBusquedaRoboDelitosSexualesTipoCabello.idTipoCabello = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idTipoCabello"));
}
return myBusquedaRoboDelitosSexualesTipoCabello;
}
}

 } 
