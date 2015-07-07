using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal
{
/// <summary>
/// The BusquedaRobosDelitosSexualesSeniasDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaRobosDelitosSexualesSenias objects.
/// </summary>
public partial class BusquedaRobosDelitosSexualesSeniasDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaRobosDelitosSexualesSenias from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaRobosDelitosSexualesSenias in the database.</param>
/// <returns>An BusquedaRobosDelitosSexualesSenias when the id was found in the database, or null otherwise.</returns>
public static BusquedaRobosDelitosSexualesSenias GetItem(int id)
{
BusquedaRobosDelitosSexualesSenias myBusquedaRobosDelitosSexualesSenias = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesSeniasSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaRobosDelitosSexualesSenias = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaRobosDelitosSexualesSenias;
}
}

/// <summary>
/// Returns a list with BusquedaRobosDelitosSexualesSenias objects.
/// </summary>
/// <returns>A generics List with the BusquedaRobosDelitosSexualesSenias objects.</returns>
public static BusquedaRobosDelitosSexualesSeniasList GetList()
{
BusquedaRobosDelitosSexualesSeniasList tempList = new BusquedaRobosDelitosSexualesSeniasList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesSeniasSelectList", myConnection))
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
/// Returns a list with BusquedaRobosDelitosSexualesSenias objects.
/// </summary>
/// <returns>A generics List with the BusquedaRobosDelitosSexualesSenias objects.</returns>
public static BusquedaRobosDelitosSexualesSeniasList GetListByidBusquedaRoboDS(int idBusquedaRoboDS)
{
BusquedaRobosDelitosSexualesSeniasList tempList = new BusquedaRobosDelitosSexualesSeniasList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesSeniasSelectListByidBusquedaRoboDS", myConnection))
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
/// Returns a list with BusquedaRobosDelitosSexualesSenias objects.
/// </summary>
/// <returns>A generics List with the BusquedaRobosDelitosSexualesSenias objects.</returns>
public static BusquedaRobosDelitosSexualesSeniasList GetListByidSenia(int idSenia)
{
BusquedaRobosDelitosSexualesSeniasList tempList = new BusquedaRobosDelitosSexualesSeniasList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesSeniasSelectListByidSenia", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idSenia", idSenia);
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
/// Returns a list with BusquedaRobosDelitosSexualesSenias objects.
/// </summary>
/// <returns>A generics List with the BusquedaRobosDelitosSexualesSenias objects.</returns>
public static BusquedaRobosDelitosSexualesSeniasList GetListByidLugarSenia(int idLugarSenia)
{
BusquedaRobosDelitosSexualesSeniasList tempList = new BusquedaRobosDelitosSexualesSeniasList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesSeniasSelectListByidLugarSenia", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idLugarSenia", idLugarSenia);
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
/// Saves a BusquedaRobosDelitosSexualesSenias in the database.
/// </summary>
/// <param name="myBusquedaRobosDelitosSexualesSenias">The BusquedaRobosDelitosSexualesSenias instance to save.</param>
/// <returns>The new id if the BusquedaRobosDelitosSexualesSenias is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaRobosDelitosSexualesSenias myBusquedaRobosDelitosSexualesSenias)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesSeniasInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myBusquedaRobosDelitosSexualesSenias.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myBusquedaRobosDelitosSexualesSenias.id);
}
if (myBusquedaRobosDelitosSexualesSenias.idBusquedaRoboDS == null){
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", myBusquedaRobosDelitosSexualesSenias.idBusquedaRoboDS);
}
if (myBusquedaRobosDelitosSexualesSenias.idSenia == null){
myCommand.Parameters.AddWithValue("@idSenia", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idSenia", myBusquedaRobosDelitosSexualesSenias.idSenia);
}
if (myBusquedaRobosDelitosSexualesSenias.idLugarSenia == null){
myCommand.Parameters.AddWithValue("@idLugarSenia", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idLugarSenia", myBusquedaRobosDelitosSexualesSenias.idLugarSenia);
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
/// Deletes a BusquedaRobosDelitosSexualesSenias from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRobosDelitosSexualesSenias to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesSeniasDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the BusquedaRobosDelitosSexualesSenias class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaRobosDelitosSexualesSenias FillDataRecord(IDataRecord myDataRecord )
{
BusquedaRobosDelitosSexualesSenias myBusquedaRobosDelitosSexualesSenias = new BusquedaRobosDelitosSexualesSenias();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaRobosDelitosSexualesSenias.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusquedaRoboDS")))
{
myBusquedaRobosDelitosSexualesSenias.idBusquedaRoboDS = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusquedaRoboDS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idSenia")))
{
myBusquedaRobosDelitosSexualesSenias.idSenia = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idSenia"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idLugarSenia")))
{
myBusquedaRobosDelitosSexualesSenias.idLugarSenia = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idLugarSenia"));
}
return myBusquedaRobosDelitosSexualesSenias;
}
}

 } 
