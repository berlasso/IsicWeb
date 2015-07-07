using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal
{
/// <summary>
/// The ColorVehiculoDB class is responsible for interacting with the database to retrieve and store information
/// about ColorVehiculo objects.
/// </summary>
public partial class ColorVehiculoDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of ColorVehiculo from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the ColorVehiculo in the database.</param>
/// <returns>An ColorVehiculo when the id was found in the database, or null otherwise.</returns>
public static ColorVehiculo GetItem(int id)
{
ColorVehiculo myColorVehiculo = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ColorVehiculoSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myColorVehiculo = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myColorVehiculo;
}
}

/// <summary>
/// Returns a list with ColorVehiculo objects.
/// </summary>
/// <returns>A generics List with the ColorVehiculo objects.</returns>
public static ColorVehiculoList GetList()
{
ColorVehiculoList tempList = new ColorVehiculoList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ColorVehiculoSelectList", myConnection))
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
/// Saves a ColorVehiculo in the database.
/// </summary>
/// <param name="myColorVehiculo">The ColorVehiculo instance to save.</param>
/// <returns>The new id if the ColorVehiculo is new in the database or the existing id when an item was updated.</returns>
public static int Save(ColorVehiculo myColorVehiculo)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ColorVehiculoInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myColorVehiculo.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myColorVehiculo.id);
}
if (string.IsNullOrEmpty(myColorVehiculo.Descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myColorVehiculo.Descripcion);
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
/// Deletes a ColorVehiculo from the database.
/// </summary>
/// <param name="id">The id of the ColorVehiculo to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ColorVehiculoDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the ColorVehiculo class and fills it with the data fom the IDataRecord.
/// </summary>
private static ColorVehiculo FillDataRecord(IDataRecord myDataRecord )
{
ColorVehiculo myColorVehiculo = new ColorVehiculo();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myColorVehiculo.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Descripcion")))
{
myColorVehiculo.Descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("Descripcion"));
}
return myColorVehiculo;
}
}

 } 
