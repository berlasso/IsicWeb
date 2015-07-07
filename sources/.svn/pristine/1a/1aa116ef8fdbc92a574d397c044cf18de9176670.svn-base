using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The BusquedaRobosDelitosSexualesEstaturaDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaRobosDelitosSexualesEstatura objects.
/// </summary>
public partial class BusquedaRobosDelitosSexualesEstaturaDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaRobosDelitosSexualesEstatura from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaRobosDelitosSexualesEstatura in the database.</param>
/// <returns>An BusquedaRobosDelitosSexualesEstatura when the id was found in the database, or null otherwise.</returns>
public static BusquedaRobosDelitosSexualesEstatura GetItem(int id)
{
BusquedaRobosDelitosSexualesEstatura myBusquedaRobosDelitosSexualesEstatura = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesEstaturaSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaRobosDelitosSexualesEstatura = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaRobosDelitosSexualesEstatura;
}
}

/// <summary>
/// Returns a list with BusquedaRobosDelitosSexualesEstatura objects.
/// </summary>
/// <returns>A generics List with the BusquedaRobosDelitosSexualesEstatura objects.</returns>
public static BusquedaRobosDelitosSexualesEstaturaList GetList()
{
BusquedaRobosDelitosSexualesEstaturaList tempList = new BusquedaRobosDelitosSexualesEstaturaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesEstaturaSelectList", myConnection))
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
/// Returns a list with BusquedaRobosDelitosSexualesEstatura objects.
/// </summary>
/// <returns>A generics List with the BusquedaRobosDelitosSexualesEstatura objects.</returns>
public static BusquedaRobosDelitosSexualesEstaturaList GetListByidBusquedaRoboDS(int idBusquedaRoboDS)
{
BusquedaRobosDelitosSexualesEstaturaList tempList = new BusquedaRobosDelitosSexualesEstaturaList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesEstaturaSelectListByidBusquedaRoboDS", myConnection))
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
/// Saves a BusquedaRobosDelitosSexualesEstatura in the database.
/// </summary>
/// <param name="myBusquedaRobosDelitosSexualesEstatura">The BusquedaRobosDelitosSexualesEstatura instance to save.</param>
/// <returns>The new id if the BusquedaRobosDelitosSexualesEstatura is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaRobosDelitosSexualesEstatura myBusquedaRobosDelitosSexualesEstatura)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesEstaturaInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myBusquedaRobosDelitosSexualesEstatura.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myBusquedaRobosDelitosSexualesEstatura.id);
}
if (myBusquedaRobosDelitosSexualesEstatura.idBusquedaRoboDS == null){
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", myBusquedaRobosDelitosSexualesEstatura.idBusquedaRoboDS);
}
if (myBusquedaRobosDelitosSexualesEstatura.idestatura == null){
myCommand.Parameters.AddWithValue("@idestatura", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idestatura", myBusquedaRobosDelitosSexualesEstatura.idestatura);
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
/// Deletes a BusquedaRobosDelitosSexualesEstatura from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRobosDelitosSexualesEstatura to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesEstaturaDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the BusquedaRobosDelitosSexualesEstatura class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaRobosDelitosSexualesEstatura FillDataRecord(IDataRecord myDataRecord )
{
BusquedaRobosDelitosSexualesEstatura myBusquedaRobosDelitosSexualesEstatura = new BusquedaRobosDelitosSexualesEstatura();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaRobosDelitosSexualesEstatura.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusquedaRoboDS")))
{
myBusquedaRobosDelitosSexualesEstatura.idBusquedaRoboDS = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusquedaRoboDS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idestatura")))
{
myBusquedaRobosDelitosSexualesEstatura.idestatura = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idestatura"));
}
return myBusquedaRobosDelitosSexualesEstatura;
}
}

 } 
