using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The BusquedaRobosDelitosSexualesLocalidadesDB class is responsible for interacting with the database to retrieve and store information
/// about BusquedaRobosDelitosSexualesLocalidades objects.
/// </summary>
public partial class BusquedaRobosDelitosSexualesLocalidadesDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of BusquedaRobosDelitosSexualesLocalidades from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the BusquedaRobosDelitosSexualesLocalidades in the database.</param>
/// <returns>An BusquedaRobosDelitosSexualesLocalidades when the id was found in the database, or null otherwise.</returns>
public static BusquedaRobosDelitosSexualesLocalidades GetItem(int id)
{
BusquedaRobosDelitosSexualesLocalidades myBusquedaRobosDelitosSexualesLocalidades = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesLocalidadesSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myBusquedaRobosDelitosSexualesLocalidades = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myBusquedaRobosDelitosSexualesLocalidades;
}
}

/// <summary>
/// Returns a list with BusquedaRobosDelitosSexualesLocalidades objects.
/// </summary>
/// <returns>A generics List with the BusquedaRobosDelitosSexualesLocalidades objects.</returns>
public static BusquedaRobosDelitosSexualesLocalidadesList GetList()
{
BusquedaRobosDelitosSexualesLocalidadesList tempList = new BusquedaRobosDelitosSexualesLocalidadesList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesLocalidadesSelectList", myConnection))
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
/// Returns a list with BusquedaRobosDelitosSexualesLocalidades objects.
/// </summary>
/// <returns>A generics List with the BusquedaRobosDelitosSexualesLocalidades objects.</returns>
public static BusquedaRobosDelitosSexualesLocalidadesList GetListByidBusquedaRoboDS(int idBusquedaRoboDS)
{
BusquedaRobosDelitosSexualesLocalidadesList tempList = new BusquedaRobosDelitosSexualesLocalidadesList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesLocalidadesSelectListByidBusquedaRoboDS", myConnection))
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
/// Saves a BusquedaRobosDelitosSexualesLocalidades in the database.
/// </summary>
/// <param name="myBusquedaRobosDelitosSexualesLocalidades">The BusquedaRobosDelitosSexualesLocalidades instance to save.</param>
/// <returns>The new id if the BusquedaRobosDelitosSexualesLocalidades is new in the database or the existing id when an item was updated.</returns>
public static int Save(BusquedaRobosDelitosSexualesLocalidades myBusquedaRobosDelitosSexualesLocalidades)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesLocalidadesInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myBusquedaRobosDelitosSexualesLocalidades.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myBusquedaRobosDelitosSexualesLocalidades.id);
}
if (myBusquedaRobosDelitosSexualesLocalidades.idBusquedaRoboDS == null){
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idBusquedaRoboDS", myBusquedaRobosDelitosSexualesLocalidades.idBusquedaRoboDS);
}
if (myBusquedaRobosDelitosSexualesLocalidades.idLocalidad == null){
myCommand.Parameters.AddWithValue("@idLocalidad", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@idLocalidad", myBusquedaRobosDelitosSexualesLocalidades.idLocalidad);
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
/// Deletes a BusquedaRobosDelitosSexualesLocalidades from the database.
/// </summary>
/// <param name="id">The id of the BusquedaRobosDelitosSexualesLocalidades to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("BusquedaRobosDelitosSexualesLocalidadesDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the BusquedaRobosDelitosSexualesLocalidades class and fills it with the data fom the IDataRecord.
/// </summary>
private static BusquedaRobosDelitosSexualesLocalidades FillDataRecord(IDataRecord myDataRecord )
{
BusquedaRobosDelitosSexualesLocalidades myBusquedaRobosDelitosSexualesLocalidades = new BusquedaRobosDelitosSexualesLocalidades();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myBusquedaRobosDelitosSexualesLocalidades.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idBusquedaRoboDS")))
{
myBusquedaRobosDelitosSexualesLocalidades.idBusquedaRoboDS = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idBusquedaRoboDS"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idLocalidad")))
{
myBusquedaRobosDelitosSexualesLocalidades.idLocalidad = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idLocalidad"));
}
return myBusquedaRobosDelitosSexualesLocalidades;
}
}

 } 
