using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The BusquedaRoboDelitosSexualesFormaBocaDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaRoboDelitosSexualesFormaBoca objects.
/// </summary>
public partial class BusquedaRoboDelitosSexualesFormaBocaDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaRoboDelitosSexualesFormaBoca from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaRoboDelitosSexualesFormaBoca in the database.</param>
/// <returns>An BusquedaRoboDelitosSexualesFormaBoca when the id was found in the database, or null otherwise.</returns>
public static BusquedaRoboDelitosSexualesFormaBoca GetItem(int id)
{
BusquedaRoboDelitosSexualesFormaBoca myBusquedaRoboDelitosSexualesFormaBoca = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaBocaSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaRoboDelitosSexualesFormaBoca = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaRoboDelitosSexualesFormaBoca;
}
}

/// <summary>
/// Returns a list with BusquedaRoboDelitosSexualesFormaBoca objects.
/// </summary>
/// <returns>A generics List with the BusquedaRoboDelitosSexualesFormaBoca objects.</returns>
public static BusquedaRoboDelitosSexualesFormaBocaList GetList()
{
BusquedaRoboDelitosSexualesFormaBocaList tempList = new BusquedaRoboDelitosSexualesFormaBocaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaBocaSelectList", myConnection))
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
/// Returns a list with BusquedaRoboDelitosSexualesFormaBoca objects.
/// </summary>
/// <returns>A generics List with the BusquedaRoboDelitosSexualesFormaBoca objects.</returns>
public static BusquedaRoboDelitosSexualesFormaBocaList GetListByidBusquedaRoboDS(int idBusquedaRoboDS)
{
BusquedaRoboDelitosSexualesFormaBocaList tempList = new BusquedaRoboDelitosSexualesFormaBocaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaBocaSelectListByidBusquedaRoboDS", myConnection))
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
/// Saves a BusquedaRoboDelitosSexualesFormaBoca in the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesFormaBoca">The BusquedaRoboDelitosSexualesFormaBoca instance to save.</param>
/// <returns>The new id if the BusquedaRoboDelitosSexualesFormaBoca is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaRoboDelitosSexualesFormaBoca myBusquedaRoboDelitosSexualesFormaBoca)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaBocaInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myBusquedaRoboDelitosSexualesFormaBoca.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myBusquedaRoboDelitosSexualesFormaBoca.id);
}
if (myBusquedaRoboDelitosSexualesFormaBoca.idBusquedaRoboDS == null){
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", myBusquedaRoboDelitosSexualesFormaBoca.idBusquedaRoboDS);
}
if (myBusquedaRoboDelitosSexualesFormaBoca.idFormaBoca == null){
myCommand.Parameters.AddWithValue("@idFormaBoca", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idFormaBoca", myBusquedaRoboDelitosSexualesFormaBoca.idFormaBoca);
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
/// Deletes a BusquedaRoboDelitosSexualesFormaBoca from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesFormaBoca to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaBocaDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the BusquedaRoboDelitosSexualesFormaBoca class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaRoboDelitosSexualesFormaBoca FillDataRecord(IDataRecord myDataRecord )
{
BusquedaRoboDelitosSexualesFormaBoca myBusquedaRoboDelitosSexualesFormaBoca = new BusquedaRoboDelitosSexualesFormaBoca();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaRoboDelitosSexualesFormaBoca.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusquedaRoboDS")))
{
myBusquedaRoboDelitosSexualesFormaBoca.idBusquedaRoboDS = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusquedaRoboDS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idFormaBoca")))
{
myBusquedaRoboDelitosSexualesFormaBoca.idFormaBoca = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idFormaBoca"));
}
return myBusquedaRoboDelitosSexualesFormaBoca;
}
}

 } 
