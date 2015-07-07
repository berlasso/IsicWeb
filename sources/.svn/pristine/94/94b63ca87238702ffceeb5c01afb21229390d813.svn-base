using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.AutoresIgnorados.BusinessEntities;


namespace MPBA.AutoresIgnorados.Dal {
/// <summary>
/// The NNClaseVinculoVehiculoDB class is responsible for interacting with the database to retrieve and store information
/// about NNClaseVinculoVehiculo objects.
/// </summary>
public partial class NNClaseVinculoVehiculoDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of NNClaseVinculoVehiculo from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the NNClaseVinculoVehiculo in the database.</param>
/// <returns>An NNClaseVinculoVehiculo when the id was found in the database, or null otherwise.</returns>
public static NNClaseVinculoVehiculo GetItem(int id)
{
NNClaseVinculoVehiculo myNNClaseVinculoVehiculo = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseVinculoVehiculoSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myNNClaseVinculoVehiculo = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myNNClaseVinculoVehiculo;
}
}

/// <summary>
/// Returns a list with NNClaseVinculoVehiculo objects.
/// </summary>
/// <returns>A generics List with the NNClaseVinculoVehiculo objects.</returns>
public static NNClaseVinculoVehiculoList GetList()
{
NNClaseVinculoVehiculoList tempList = new NNClaseVinculoVehiculoList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseVinculoVehiculoSelectList", myConnection))
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
/// Saves a NNClaseVinculoVehiculo in the database.
/// </summary>
/// <param name="myNNClaseVinculoVehiculo">The NNClaseVinculoVehiculo instance to save.</param>
/// <returns>The new id if the NNClaseVinculoVehiculo is new in the database or the existing id when an item was updated.</returns>
public static int Save(NNClaseVinculoVehiculo myNNClaseVinculoVehiculo)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseVinculoVehiculoInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myNNClaseVinculoVehiculo.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myNNClaseVinculoVehiculo.id);
}
if (string.IsNullOrEmpty(myNNClaseVinculoVehiculo.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myNNClaseVinculoVehiculo.descripcion);
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
/// Deletes a NNClaseVinculoVehiculo from the database.
/// </summary>
/// <param name="id">The id of the NNClaseVinculoVehiculo to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("NNClaseVinculoVehiculoDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the NNClaseVinculoVehiculo class and fills it with the data fom the IDataRecord.
/// </summary>
private static NNClaseVinculoVehiculo FillDataRecord(IDataRecord myDataRecord )
{
NNClaseVinculoVehiculo myNNClaseVinculoVehiculo = new NNClaseVinculoVehiculo();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myNNClaseVinculoVehiculo.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myNNClaseVinculoVehiculo.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
return myNNClaseVinculoVehiculo;
}
}

 } 
