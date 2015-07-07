using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The BusquedaRoboDelitosSexualesTipoCalvicieDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaRoboDelitosSexualesTipoCalvicie objects.
/// </summary>
public partial class BusquedaRoboDelitosSexualesTipoCalvicieDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaRoboDelitosSexualesTipoCalvicie from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaRoboDelitosSexualesTipoCalvicie in the database.</param>
/// <returns>An BusquedaRoboDelitosSexualesTipoCalvicie when the id was found in the database, or null otherwise.</returns>
public static BusquedaRoboDelitosSexualesTipoCalvicie GetItem(int id)
{
BusquedaRoboDelitosSexualesTipoCalvicie myBusquedaRoboDelitosSexualesTipoCalvicie = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesTipoCalvicieSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaRoboDelitosSexualesTipoCalvicie = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaRoboDelitosSexualesTipoCalvicie;
}
}

/// <summary>
/// Returns a list with BusquedaRoboDelitosSexualesTipoCalvicie objects.
/// </summary>
/// <returns>A generics List with the BusquedaRoboDelitosSexualesTipoCalvicie objects.</returns>
public static BusquedaRoboDelitosSexualesTipoCalvicieList GetList()
{
BusquedaRoboDelitosSexualesTipoCalvicieList tempList = new BusquedaRoboDelitosSexualesTipoCalvicieList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesTipoCalvicieSelectList", myConnection))
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
/// Returns a list with BusquedaRoboDelitosSexualesTipoCalvicie objects.
/// </summary>
/// <returns>A generics List with the BusquedaRoboDelitosSexualesTipoCalvicie objects.</returns>
public static BusquedaRoboDelitosSexualesTipoCalvicieList GetListByidBusquedaRoboDS(int idBusquedaRoboDS)
{
BusquedaRoboDelitosSexualesTipoCalvicieList tempList = new BusquedaRoboDelitosSexualesTipoCalvicieList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesTipoCalvicieSelectListByidBusquedaRoboDS", myConnection))
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
/// Saves a BusquedaRoboDelitosSexualesTipoCalvicie in the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesTipoCalvicie">The BusquedaRoboDelitosSexualesTipoCalvicie instance to save.</param>
/// <returns>The new id if the BusquedaRoboDelitosSexualesTipoCalvicie is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaRoboDelitosSexualesTipoCalvicie myBusquedaRoboDelitosSexualesTipoCalvicie)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesTipoCalvicieInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myBusquedaRoboDelitosSexualesTipoCalvicie.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myBusquedaRoboDelitosSexualesTipoCalvicie.id);
}
if (myBusquedaRoboDelitosSexualesTipoCalvicie.idBusquedaRoboDS == null){
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", myBusquedaRoboDelitosSexualesTipoCalvicie.idBusquedaRoboDS);
}
if (myBusquedaRoboDelitosSexualesTipoCalvicie.idTipoCalvicie == null){
myCommand.Parameters.AddWithValue("@idTipoCalvicie", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idTipoCalvicie", myBusquedaRoboDelitosSexualesTipoCalvicie.idTipoCalvicie);
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
/// Deletes a BusquedaRoboDelitosSexualesTipoCalvicie from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesTipoCalvicie to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesTipoCalvicieDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the BusquedaRoboDelitosSexualesTipoCalvicie class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaRoboDelitosSexualesTipoCalvicie FillDataRecord(IDataRecord myDataRecord )
{
BusquedaRoboDelitosSexualesTipoCalvicie myBusquedaRoboDelitosSexualesTipoCalvicie = new BusquedaRoboDelitosSexualesTipoCalvicie();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaRoboDelitosSexualesTipoCalvicie.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusquedaRoboDS")))
{
myBusquedaRoboDelitosSexualesTipoCalvicie.idBusquedaRoboDS = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusquedaRoboDS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idTipoCalvicie")))
{
myBusquedaRoboDelitosSexualesTipoCalvicie.idTipoCalvicie = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idTipoCalvicie"));
}
return myBusquedaRoboDelitosSexualesTipoCalvicie;
}
}

 } 
