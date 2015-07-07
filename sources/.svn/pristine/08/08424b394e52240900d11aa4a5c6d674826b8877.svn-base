using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal
{
/// <summary>
/// The ModeloVehiculoDB class is responsible for interacting with the database to retrieve and store information
/// about ModeloVehiculo objects.
/// </summary>
public partial class ModeloVehiculoDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of ModeloVehiculo from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the ModeloVehiculo in the database.</param>
/// <returns>An ModeloVehiculo when the id was found in the database, or null otherwise.</returns>
public static ModeloVehiculo GetItem(int id)
{
ModeloVehiculo myModeloVehiculo = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ModeloVehiculoSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myModeloVehiculo = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myModeloVehiculo;
}
}

/// <summary>
/// Returns a list with ModeloVehiculo objects.
/// </summary>
/// <returns>A generics List with the ModeloVehiculo objects.</returns>
public static ModeloVehiculoList GetList()
{
ModeloVehiculoList tempList = new ModeloVehiculoList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ModeloVehiculoSelectList", myConnection))
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
/// Returns a list with ModeloVehiculo objects.
/// </summary>
/// <returns>A generics List with the ModeloVehiculo objects.</returns>
public static ModeloVehiculoList GetListByidMarcaVehiculo(int idMarcaVehiculo)
{
ModeloVehiculoList tempList = new ModeloVehiculoList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ModeloVehiculoSelectListByidMarcaVehiculo", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@idMarcaVehiculo", idMarcaVehiculo);
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
/// Saves a ModeloVehiculo in the database.
/// </summary>
/// <param name="myModeloVehiculo">The ModeloVehiculo instance to save.</param>
/// <returns>The new id if the ModeloVehiculo is new in the database or the existing id when an item was updated.</returns>
public static int Save(ModeloVehiculo myModeloVehiculo)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ModeloVehiculoInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myModeloVehiculo.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myModeloVehiculo.id);
}
if (string.IsNullOrEmpty(myModeloVehiculo.Descripcion))
{
myCommand.Parameters.AddWithValue("@Descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@Descripcion", myModeloVehiculo.Descripcion);
}

myCommand.Parameters.AddWithValue("@idMarcaVehiculo", myModeloVehiculo.idMarcaVehiculo);


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
/// Deletes a ModeloVehiculo from the database.
/// </summary>
/// <param name="id">The id of the ModeloVehiculo to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ModeloVehiculoDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the ModeloVehiculo class and fills it with the data fom the IDataRecord.
/// </summary>
private static ModeloVehiculo FillDataRecord(IDataRecord myDataRecord )
{
ModeloVehiculo myModeloVehiculo = new ModeloVehiculo();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myModeloVehiculo.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
myModeloVehiculo.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("idMarcaVehiculo")))
{
myModeloVehiculo.idMarcaVehiculo = myDataRecord.GetInt32(myDataRecord.GetOrdinal("idMarcaVehiculo"));
}
return myModeloVehiculo;
}
}

 } 
