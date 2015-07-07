using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

using MPBA.SIAC.BusinessEntities;


namespace MPBA.SIAC.Dal {
/// <summary>
/// The ClaseTatuajeDB class is responsible for interacting with the database to retrieve and store information
/// about ClaseTatuaje objects.
/// </summary>
public partial class ClaseTatuajeDB

{
#region "Public Methods"

/// <summary>
/// Gets an instance of ClaseTatuaje from the underlying datasource.
/// </summary>
/// <param name="id">The unique id of the ClaseTatuaje in the database.</param>
/// <returns>An ClaseTatuaje when the id was found in the database, or null otherwise.</returns>
public static ClaseTatuaje GetItem(int id)
{
ClaseTatuaje myClaseTatuaje = null;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClaseTatuajeSelectSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;
myCommand.Parameters.AddWithValue("@id", id);

myConnection.Open();
using (SqlDataReader myReader = myCommand.ExecuteReader())
{
if (myReader.Read()) {
myClaseTatuaje = FillDataRecord(myReader);
}
myReader.Close();
}
myConnection.Close();
}
return myClaseTatuaje;
}
}

/// <summary>
/// Returns a list with ClaseTatuaje objects.
/// </summary>
/// <returns>A generics List with the ClaseTatuaje objects.</returns>
public static ClaseTatuajeList GetList()
{
ClaseTatuajeList tempList = new ClaseTatuajeList();
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClaseTatuajeSelectList", myConnection))
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
/// Saves a ClaseTatuaje in the database.
/// </summary>
/// <param name="myClaseTatuaje">The ClaseTatuaje instance to save.</param>
/// <returns>The new id if the ClaseTatuaje is new in the database or the existing id when an item was updated.</returns>
public static int Save(ClaseTatuaje myClaseTatuaje)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClaseTatuajeInsertUpdateSingleItem", myConnection))
{
myCommand.CommandType = CommandType.StoredProcedure;

if (myClaseTatuaje.id == -1)
{myCommand.Parameters.AddWithValue("@id", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@id", myClaseTatuaje.id);
}
if (string.IsNullOrEmpty(myClaseTatuaje.descripcion))
{
myCommand.Parameters.AddWithValue("@descripcion", DBNull.Value);
}
else
{
myCommand.Parameters.AddWithValue("@descripcion", myClaseTatuaje.descripcion);
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
/// Deletes a ClaseTatuaje from the database.
/// </summary>
/// <param name="id">The id of the ClaseTatuaje to delete.</param>
/// <returns>Returns true when the object was deleted successfully, or false otherwise.</returns>
public static bool Delete(int id)
{
int result = 0;
using (SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ConnectionString))
{
using (SqlCommand myCommand = new SqlCommand("ClaseTatuajeDeleteSingleItem", myConnection))
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
/// Initializes a new instance of the ClaseTatuaje class and fills it with the data fom the IDataRecord.
/// </summary>
private static ClaseTatuaje FillDataRecord(IDataRecord myDataRecord )
{
ClaseTatuaje myClaseTatuaje = new ClaseTatuaje();
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("id")))
{
myClaseTatuaje.id = myDataRecord.GetInt32(myDataRecord.GetOrdinal("id"));
}
if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("descripcion")))
{
myClaseTatuaje.descripcion = myDataRecord.GetString(myDataRecord.GetOrdinal("descripcion"));
}
return myClaseTatuaje;
}
}

 } 
