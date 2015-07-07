using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The BusquedaRobosDelitosSexualesComisariasDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaRobosDelitosSexualesComisarias objects.
/// </summary>
public partial class BusquedaRobosDelitosSexualesComisariasDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaRobosDelitosSexualesComisarias from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaRobosDelitosSexualesComisarias in the database.</param>
/// <returns>An BusquedaRobosDelitosSexualesComisarias when the id was found in the database, or null otherwise.</returns>
public static BusquedaRobosDelitosSexualesComisarias GetItem(int id)
{
BusquedaRobosDelitosSexualesComisarias myBusquedaRobosDelitosSexualesComisarias = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesComisariasSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaRobosDelitosSexualesComisarias = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaRobosDelitosSexualesComisarias;
}
}

/// <summary>
/// Returns a list with BusquedaRobosDelitosSexualesComisarias objects.
/// </summary>
/// <returns>A generics List with the BusquedaRobosDelitosSexualesComisarias objects.</returns>
public static BusquedaRobosDelitosSexualesComisariasList GetList()
{
BusquedaRobosDelitosSexualesComisariasList tempList = new BusquedaRobosDelitosSexualesComisariasList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesComisariasSelectList", myConnection))
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
/// Returns a list with BusquedaRobosDelitosSexualesComisarias objects.
/// </summary>
/// <returns>A generics List with the BusquedaRobosDelitosSexualesComisarias objects.</returns>
public static BusquedaRobosDelitosSexualesComisariasList GetListByidBusquedaRoboDS(int idBusquedaRoboDS)
{
BusquedaRobosDelitosSexualesComisariasList tempList = new BusquedaRobosDelitosSexualesComisariasList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesComisariasSelectListByidBusquedaRoboDS", myConnection))
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
/// Saves a BusquedaRobosDelitosSexualesComisarias in the database.
/// </summary>
/// <param name="myBusquedaRobosDelitosSexualesComisarias">The BusquedaRobosDelitosSexualesComisarias instance to save.</param>
/// <returns>The new id if the BusquedaRobosDelitosSexualesComisarias is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaRobosDelitosSexualesComisarias myBusquedaRobosDelitosSexualesComisarias)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesComisariasInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myBusquedaRobosDelitosSexualesComisarias.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myBusquedaRobosDelitosSexualesComisarias.id);
}
if (myBusquedaRobosDelitosSexualesComisarias.idBusquedaRoboDS == null){
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", myBusquedaRobosDelitosSexualesComisarias.idBusquedaRoboDS);
}
if (myBusquedaRobosDelitosSexualesComisarias.idComisaria == null){
myCommand.Parameters.AddWithValue("@idComisaria", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idComisaria", myBusquedaRobosDelitosSexualesComisarias.idComisaria);
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
/// Deletes a BusquedaRobosDelitosSexualesComisarias from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRobosDelitosSexualesComisarias to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesComisariasDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the BusquedaRobosDelitosSexualesComisarias class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaRobosDelitosSexualesComisarias FillDataRecord(IDataRecord myDataRecord )
{
BusquedaRobosDelitosSexualesComisarias myBusquedaRobosDelitosSexualesComisarias = new BusquedaRobosDelitosSexualesComisarias();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaRobosDelitosSexualesComisarias.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusquedaRoboDS")))
{
myBusquedaRobosDelitosSexualesComisarias.idBusquedaRoboDS = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusquedaRoboDS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idComisaria")))
{
myBusquedaRobosDelitosSexualesComisarias.idComisaria = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idComisaria"));
}
return myBusquedaRobosDelitosSexualesComisarias;
}
}

 } 
