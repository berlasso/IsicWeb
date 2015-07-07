using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseVidrioVehiculoDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseVidrioVehiculo objects.
/// </summary>
public partial class NNClaseVidrioVehiculoDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseVidrioVehiculo from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseVidrioVehiculo in the database.</param>
/// <returns>An NNClaseVidrioVehiculo when the id was found in the database, or null otherwise.</returns>
public static NNClaseVidrioVehiculo GetItem(int id)
{
NNClaseVidrioVehiculo myNNClaseVidrioVehiculo = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseVidrioVehiculoSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseVidrioVehiculo = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseVidrioVehiculo;
}
}

/// <summary>
/// Returns a list with NNClaseVidrioVehiculo objects.
/// </summary>
/// <returns>A generics List with the NNClaseVidrioVehiculo objects.</returns>
public static NNClaseVidrioVehiculoList GetList()
{
NNClaseVidrioVehiculoList tempList = new NNClaseVidrioVehiculoList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseVidrioVehiculoSelectList", myConnection))
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
/// Saves a NNClaseVidrioVehiculo in the database.
/// </summary>
/// <param name="myNNClaseVidrioVehiculo">The NNClaseVidrioVehiculo instance to save.</param>
/// <returns>The new id if the NNClaseVidrioVehiculo is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseVidrioVehiculo myNNClaseVidrioVehiculo)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseVidrioVehiculoInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseVidrioVehiculo.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseVidrioVehiculo.id);
}
if (string.IsNullOrEmpty(myNNClaseVidrioVehiculo.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseVidrioVehiculo.descripcion);
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
/// Deletes a NNClaseVidrioVehiculo from the database.
/// </summary>
/// <param name="id">The id of the NNClaseVidrioVehiculo to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseVidrioVehiculoDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseVidrioVehiculo class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseVidrioVehiculo FillDataRecord(IDataRecord myDataRecord )
{
NNClaseVidrioVehiculo myNNClaseVidrioVehiculo = new NNClaseVidrioVehiculo();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseVidrioVehiculo.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseVidrioVehiculo.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
return myNNClaseVidrioVehiculo;
}
}

 } 
