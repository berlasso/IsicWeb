using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The BusquedaRoboDelitosSexualesFormaLabioinfDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaRoboDelitosSexualesFormaLabioinf objects.
/// </summary>
public partial class BusquedaRoboDelitosSexualesFormaLabioinfDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaRoboDelitosSexualesFormaLabioinf from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaRoboDelitosSexualesFormaLabioinf in the database.</param>
/// <returns>An BusquedaRoboDelitosSexualesFormaLabioinf when the id was found in the database, or null otherwise.</returns>
public static BusquedaRoboDelitosSexualesFormaLabioinf GetItem(int id)
{
BusquedaRoboDelitosSexualesFormaLabioinf myBusquedaRoboDelitosSexualesFormaLabioinf = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaLabioinfSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaRoboDelitosSexualesFormaLabioinf = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaRoboDelitosSexualesFormaLabioinf;
}
}

/// <summary>
/// Returns a list with BusquedaRoboDelitosSexualesFormaLabioinf objects.
/// </summary>
/// <returns>A generics List with the BusquedaRoboDelitosSexualesFormaLabioinf objects.</returns>
public static BusquedaRoboDelitosSexualesFormaLabioinfList GetList()
{
BusquedaRoboDelitosSexualesFormaLabioinfList tempList = new BusquedaRoboDelitosSexualesFormaLabioinfList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaLabioinfSelectList", myConnection))
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
/// Returns a list with BusquedaRoboDelitosSexualesFormaLabioinf objects.
/// </summary>
/// <returns>A generics List with the BusquedaRoboDelitosSexualesFormaLabioinf objects.</returns>
public static BusquedaRoboDelitosSexualesFormaLabioinfList GetListByidBusquedaRoboDS(int idBusquedaRoboDS)
{
BusquedaRoboDelitosSexualesFormaLabioinfList tempList = new BusquedaRoboDelitosSexualesFormaLabioinfList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaLabioinfSelectListByidBusquedaRoboDS", myConnection))
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
/// Saves a BusquedaRoboDelitosSexualesFormaLabioinf in the database.
/// </summary>
/// <param name="myBusquedaRoboDelitosSexualesFormaLabioinf">The BusquedaRoboDelitosSexualesFormaLabioinf instance to save.</param>
/// <returns>The new id if the BusquedaRoboDelitosSexualesFormaLabioinf is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaRoboDelitosSexualesFormaLabioinf myBusquedaRoboDelitosSexualesFormaLabioinf)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaLabioinfInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myBusquedaRoboDelitosSexualesFormaLabioinf.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myBusquedaRoboDelitosSexualesFormaLabioinf.id);
}
if (myBusquedaRoboDelitosSexualesFormaLabioinf.idBusquedaRoboDS == null){
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", myBusquedaRoboDelitosSexualesFormaLabioinf.idBusquedaRoboDS);
}
if (myBusquedaRoboDelitosSexualesFormaLabioinf.idFormaLabioInferior == null){
myCommand.Parameters.AddWithValue("@idFormaLabioInferior", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idFormaLabioInferior", myBusquedaRoboDelitosSexualesFormaLabioinf.idFormaLabioInferior);
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
/// Deletes a BusquedaRoboDelitosSexualesFormaLabioinf from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRoboDelitosSexualesFormaLabioinf to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRoboDelitosSexualesFormaLabioinfDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the BusquedaRoboDelitosSexualesFormaLabioinf class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaRoboDelitosSexualesFormaLabioinf FillDataRecord(IDataRecord myDataRecord )
{
BusquedaRoboDelitosSexualesFormaLabioinf myBusquedaRoboDelitosSexualesFormaLabioinf = new BusquedaRoboDelitosSexualesFormaLabioinf();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaRoboDelitosSexualesFormaLabioinf.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusquedaRoboDS")))
{
myBusquedaRoboDelitosSexualesFormaLabioinf.idBusquedaRoboDS = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusquedaRoboDS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idFormaLabioInferior")))
{
myBusquedaRoboDelitosSexualesFormaLabioinf.idFormaLabioInferior = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idFormaLabioInferior"));
}
return myBusquedaRoboDelitosSexualesFormaLabioinf;
}
}

 } 
