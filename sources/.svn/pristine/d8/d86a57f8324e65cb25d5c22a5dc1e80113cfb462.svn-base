using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The BusquedaRoboDelitosSexualesFormaLabioSupDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaRoboDelitosSexualesFormaLabioSup objects.
/// </summary>
public partial class BusquedaRoboDelitosSexualesFormaLabioSupDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaRoboDelitosSexualesFormaLabioSup from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaRoboDelitosSexualesFormaLabioSup in the database.</param>
/// <returns>An BusquedaRoboDelitosSexualesFormaLabioSup when the id was found in the database, or null otherwise.</returns>
public static BusquedaRoboDelitosSexualesFormaLabioSup GetItem(int id)
{
BusquedaRoboDelitosSexualesFormaLabioSup myBusquedaRoboDelitosSexualesFormaLabioSup = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaLabioSupSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaRoboDelitosSexualesFormaLabioSup = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaRoboDelitosSexualesFormaLabioSup;
}
}

/// <summary>
/// Returns a list with BusquedaRoboDelitosSexualesFormaLabioSup objects.
/// </summary>
/// <returns>A generics List with the BusquedaRoboDelitosSexualesFormaLabioSup objects.</returns>
public static BusquedaRoboDelitosSexualesFormaLabioSupList GetList()
{
BusquedaRoboDelitosSexualesFormaLabioSupList tempList = new BusquedaRoboDelitosSexualesFormaLabioSupList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaLabioSupSelectList", myConnection))
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
/// Returns a list with BusquedaRoboDelitosSexualesFormaLabioSup objects.
/// </summary>
/// <returns>A generics List with the BusquedaRoboDelitosSexualesFormaLabioSup objects.</returns>
public static BusquedaRoboDelitosSexualesFormaLabioSupList GetListByidBusquedaRoboDS(int idBusquedaRoboDS)
{
BusquedaRoboDelitosSexualesFormaLabioSupList tempList = new BusquedaRoboDelitosSexualesFormaLabioSupList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaLabioSupSelectListByidBusquedaRoboDS", myConnection))
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
/// Saves a BusquedaRoboDelitosSexualesFormaLabioSup in the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesFormaLabioSup">The BusquedaRoboDelitosSexualesFormaLabioSup instance to save.</param>
/// <returns>The new id if the BusquedaRoboDelitosSexualesFormaLabioSup is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaRoboDelitosSexualesFormaLabioSup myBusquedaRoboDelitosSexualesFormaLabioSup)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaLabioSupInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myBusquedaRoboDelitosSexualesFormaLabioSup.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myBusquedaRoboDelitosSexualesFormaLabioSup.id);
}
if (myBusquedaRoboDelitosSexualesFormaLabioSup.idBusquedaRoboDS == null){
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", myBusquedaRoboDelitosSexualesFormaLabioSup.idBusquedaRoboDS);
}
if (myBusquedaRoboDelitosSexualesFormaLabioSup.idFormaLabioSuperior == null){
myCommand.Parameters.AddWithValue("@idFormaLabioSuperior", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idFormaLabioSuperior", myBusquedaRoboDelitosSexualesFormaLabioSup.idFormaLabioSuperior);
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
/// Deletes a BusquedaRoboDelitosSexualesFormaLabioSup from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesFormaLabioSup to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaLabioSupDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the BusquedaRoboDelitosSexualesFormaLabioSup class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaRoboDelitosSexualesFormaLabioSup FillDataRecord(IDataRecord myDataRecord )
{
BusquedaRoboDelitosSexualesFormaLabioSup myBusquedaRoboDelitosSexualesFormaLabioSup = new BusquedaRoboDelitosSexualesFormaLabioSup();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaRoboDelitosSexualesFormaLabioSup.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusquedaRoboDS")))
{
myBusquedaRoboDelitosSexualesFormaLabioSup.idBusquedaRoboDS = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusquedaRoboDS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idFormaLabioSuperior")))
{
myBusquedaRoboDelitosSexualesFormaLabioSup.idFormaLabioSuperior = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idFormaLabioSuperior"));
}
return myBusquedaRoboDelitosSexualesFormaLabioSup;
}
}

 } 
